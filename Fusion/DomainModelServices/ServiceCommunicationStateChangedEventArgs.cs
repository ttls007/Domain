using System;
using System.ServiceModel;

namespace HL.Services
{
   public class ServiceCommunicationStateChangedEventArgs : EventArgs
   {
      public CommunicationState CommunicationState { get; private set; }
      public string UnrecognizedReceivedMessage { get; private set; }

      public ServiceCommunicationStateChangedEventArgs(CommunicationState communicationState)
         : this(communicationState, string.Empty)
      {
      }

      public ServiceCommunicationStateChangedEventArgs(CommunicationState communicationState,
         string unreconizedReceivedMessage)
      {
         CommunicationState = communicationState;
         UnrecognizedReceivedMessage = unreconizedReceivedMessage;
      }

   }
}
