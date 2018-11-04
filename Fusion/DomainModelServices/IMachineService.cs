using System;
using System.Collections.Generic;
using System.ServiceModel;
using HL.DomainModel;

namespace HL.Services
{
   [ServiceContract(SessionMode = SessionMode.Required)]
   public interface IMachineService
   {
      [OperationContract(IsInitiating = true)]
      List<Machine> GetMachines();

   }

   [ServiceContract(Name = "IMachineService", SessionMode = SessionMode.Required)]
   public interface IMachineServiceAsync : IMachineService
   {

      [OperationContract(AsyncPattern = true)]
      IAsyncResult BeginGetMachines();
      List<Machine> EndGetMachines(IAsyncResult result);
   }
}
