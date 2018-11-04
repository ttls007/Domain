using System;
using System.Transactions;
using System.Linq;

namespace HL.DomainModel.DataMapping
{
   public interface IUnitOfWork : IDisposable
   {
      IRepository<T> GetRepository<T>() where T : class;
      OperationalDataContext DataContext { get; }

      void Complete();
   }

   public class SqlUnitOfWork : IUnitOfWork
   {
      private OperationalDataContext _DataContext;

      public OperationalDataContext DataContext
      {
         get { return _DataContext; }
      }

      //private int _CompleteCount;

      public SqlUnitOfWork()
      {
         _DataContext = new OperationalDataContext();
         //_CompleteCount = 0;
         //_DataContext.Log = Console.Out;
      }

      public IRepository<T> GetRepository<T>() where T : class
      {
         return new SqlRepository<T>(_DataContext);
      }

      public void Complete()
      {
         _DataContext.SubmitChanges();

         //if (++_CompleteCount != 1)
         //{
         //   throw new InvalidOperationException(String.Format("SqlUnitOfWork.Complete called {0} times", _CompleteCount));
         //}
      }

      public void Dispose()
      {
         if (_DataContext != null)
         {
            _DataContext.Dispose();
         }
      }

      public static void TryGetRecordsFromDB()
      {
         using (var unitOfWork = IoC.Get<IUnitOfWork>())
         {
            unitOfWork.GetRepository<Machine>().FirstOrDefault(x => true);
         }
      }
   }
}
