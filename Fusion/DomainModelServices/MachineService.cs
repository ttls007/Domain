using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.DomainModel;
using System.ServiceModel;

namespace HL.Services
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
                    UseSynchronizationContext = false,
                    ConcurrencyMode = ConcurrencyMode.Single)]
   public class MachineService : IMachineService
   {
      private MachineManager _MachineManager;
      public MachineService()
      {
         _MachineManager = new MachineManager();
      }

      public List<Machine> GetMachines()
      {
         return _MachineManager.GetMachines();
      }
   }
}
