using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HL.Common
{
   public interface IThreadPoolHelper<T>
   {
      void QueueMultipleUserWorkItemsAndWaitForCompletion(int maximumThreads, ThreadWorker<T> callback, List<T> parameters);
      void QueueMultipleUserWorkItemsAndWaitForCompletion(int maximumThreads, TimeSpan timeout, ThreadWorker<T> callback, List<T> parameters);
   }

   public delegate void ThreadWorker<T>(T parameter);

   public class ThreadPoolHelper<T> : IThreadPoolHelper<T>
   {
      private enum CallbackStatus
      {
         Pending,
         InProgress,
         Completed
      }

      private class CallbackState
      {
         public ThreadWorker<T> Callback { get; private set; }
         public ManualResetEvent AllWorkItemsCompletedEvent { get; private set; }
         public ManualResetEvent CancelWorkItemProcessing { get; private set; }
         public T Parameter { get; private set; }
         public Queue<CallbackState> WorkItemQueue { get; private set; }

         private Exception _CallbackException;
         public Exception CallbackException
         {
            get
            {
               lock (this)
               {
                  return _CallbackException;
               }
            }
            set
            {
               lock (this)
               {
                  _CallbackException = value;
               }
            }
         }

         private CallbackStatus _CallbackStatus;
         public CallbackStatus Status
         {
            get
            {
               lock (this)
               {
                  return _CallbackStatus;
               }
            }
            set
            {
               lock (this)
               {
                  _CallbackStatus = value;
               }
            }
         }

         public CallbackState(ThreadWorker<T> callback, T parameter, Queue<CallbackState> workItemQueue,
            ManualResetEvent allWorkItemsCompletedEvent, ManualResetEvent cancelWorkItemProcessing)
         {
            Callback = callback;
            Parameter = parameter;
            WorkItemQueue = workItemQueue;
            AllWorkItemsCompletedEvent = allWorkItemsCompletedEvent;
            CancelWorkItemProcessing = cancelWorkItemProcessing;
         }
      }

      private int _WorkItemsWaitingToComplete = 1;

      void IThreadPoolHelper<T>.QueueMultipleUserWorkItemsAndWaitForCompletion(int maximumThreads, ThreadWorker<T> callback, List<T> parameters)
      {
         QueueMultipleUserWorkItemsAndWaitForCompletion(maximumThreads, TimeSpan.FromMilliseconds(-1), callback, parameters);
      }

      void IThreadPoolHelper<T>.QueueMultipleUserWorkItemsAndWaitForCompletion(int maximumThreads, TimeSpan timeout, ThreadWorker<T> callback, List<T> parameters)
      {
         QueueMultipleUserWorkItemsAndWaitForCompletion(maximumThreads, timeout, callback, parameters);
      }

      protected virtual void QueueMultipleUserWorkItemsAndWaitForCompletion(int maximumThreads, TimeSpan timeout, ThreadWorker<T> callback, List<T> parameters)
      {
         if (maximumThreads < 1)
         {
            maximumThreads = 1;
         }

         var pendingWorkItemsQueue = new Queue<CallbackState>();
         var callbackStates = new List<CallbackState>();
         var allWorkItemsCompletedEvent = new ManualResetEvent(false);
         var cancelWorkItemProcessing = new ManualResetEvent(false);

         // prepare all work items first...
         foreach (var parameter in parameters)
         {
            var callbackState = new CallbackState(callback, parameter, pendingWorkItemsQueue,
               allWorkItemsCompletedEvent, cancelWorkItemProcessing);

            pendingWorkItemsQueue.Enqueue(callbackState);
            callbackStates.Add(callbackState);
         }

         // ...and then start the first batch going
         for (var item = 0; item < Math.Min(maximumThreads, callbackStates.Count); item++)
         {
            QueueNextWorkItem(pendingWorkItemsQueue);
         }

         // done preparing and starting off the work
         DecrementThreadsWaitngToComplete(allWorkItemsCompletedEvent);

         // wait for everything to be completed
         if (!allWorkItemsCompletedEvent.WaitOne(timeout))
         {
            cancelWorkItemProcessing.Set();
            ReportWorkItemTimeouts(timeout, pendingWorkItemsQueue, callbackStates);
         }

         var callbacksWithExceptions = callbackStates.Where(cs => cs.CallbackException != null).ToList();

         if (callbacksWithExceptions.Count > 0)
         {
            ReportWorkItemsWithExceptions(callbackStates, callbacksWithExceptions);
         }
      }

      private void ReportWorkItemTimeouts(TimeSpan timeout, Queue<ThreadPoolHelper<T>.CallbackState> pendingWorkItemsQueue, List<ThreadPoolHelper<T>.CallbackState> callbackStates)
      {
         List<CallbackState> workItemsPending = null;

         lock (pendingWorkItemsQueue)
         {
            workItemsPending = pendingWorkItemsQueue.ToList();
         }

         var workItemsInProgress = callbackStates.Where(cs => cs.Status == CallbackStatus.InProgress).ToList();

         throw new TimeoutException(string.Format(
            "Processing exceeded timeout of {0} for work items.",
            timeout)
         );
      }

      private void QueueNextWorkItem(Queue<CallbackState> queue)
      {
         lock (queue)
         {
            if (queue.Count > 0)
            {
               var workItemState = queue.Dequeue();
               Interlocked.Increment(ref _WorkItemsWaitingToComplete);
               ThreadPool.QueueUserWorkItem(WorkerThreadCallback, workItemState);
            }
         }
      }

      private void WorkerThreadCallback(object state)
      {
         var callbackState = (CallbackState)state;

         callbackState.Status = CallbackStatus.InProgress;

         try
         {
            callbackState.Callback(callbackState.Parameter);
         }
         catch (Exception exception)
         {
            callbackState.CallbackException = exception;
         }

         // get current state of event
         if (!callbackState.CancelWorkItemProcessing.WaitOne(0))
         {
            QueueNextWorkItem(callbackState.WorkItemQueue);
         }

         DecrementThreadsWaitngToComplete(callbackState.AllWorkItemsCompletedEvent);

         callbackState.Status = CallbackStatus.Completed;
      }

      private void DecrementThreadsWaitngToComplete(ManualResetEvent completedEvent)
      {
         if (Interlocked.Decrement(ref _WorkItemsWaitingToComplete) == 0)
         {
            completedEvent.Set();
         }
      }

      private void ReportWorkItemsWithExceptions(List<ThreadPoolHelper<T>.CallbackState> callbackStates, List<ThreadPoolHelper<T>.CallbackState> callbacksWithExceptions)
      {
         var exceptionMessage = new StringBuilder();
         exceptionMessage.AppendLine(string.Format("Exceptions occurred while processing {0} of {1} work items.",
            callbacksWithExceptions.Count, callbackStates.Count));

         foreach (var callbackWithExceptions in callbacksWithExceptions)
         {
            exceptionMessage.AppendLine(string.Format("Exception from work item with parameter '{0}':", callbackWithExceptions.Parameter));
            //exceptionMessage.AppendLine(ExceptionHandler.ExceptionMessage("", "", callbackWithExceptions.CallbackException, false));
         }

         throw new InvalidOperationException(exceptionMessage.ToString());
      }
   }
}
