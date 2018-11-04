using System;
using System.ServiceModel;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;

namespace HL.Services
{
   public class HLServiceHostFactory : ServiceHostFactory
   {
      protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
      {
         return new HLServiceHost(serviceType, baseAddresses);
      }
   }

   public class HLServiceHost : ServiceHost
   {
      public HLServiceHost(Type serviceType, params Uri[] baseAddresses)
         : base(serviceType, baseAddresses)
      {
         Name = serviceType.Name;
         Enable = true;
         Required = false;
      }

      public HLServiceHost(Type serviceType, bool required, params Uri[] baseAddresses)
         : base(serviceType, baseAddresses)
      {
         Name = serviceType.Name;
         Enable = true;
         Required = required;
      }

      public string Name { get; private set; }
      public bool Enable { get; set; }
      public long FaultCount { get; set; }
      public bool Required { get; private set; }

      protected override void OnClosed()
      {
         base.OnClosed();

         OnCommunicationStateChanged(State);
      }

      protected override void OnClosing()
      {
         base.OnClosing();

         OnCommunicationStateChanged(State);
      }

      protected override void OnFaulted()
      {
         base.OnFaulted();

         FaultCount += 1;
         OnCommunicationStateChanged(State);
      }

      protected override void OnOpened()
      {
         base.OnOpened();

         OnCommunicationStateChanged(State);
      }

      protected override void OnOpening()
      {
         base.OnOpening();

         OnCommunicationStateChanged(State);
      }

      public event EventHandler<ServiceCommunicationStateChangedEventArgs> CommunicationStateChanged;
      private void OnCommunicationStateChanged(CommunicationState communicationState)
      {
         if (CommunicationStateChanged != null)
         {
            CommunicationStateChanged(this, new ServiceCommunicationStateChangedEventArgs(communicationState));
         }
      }
   }
}
