using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.DomainModel.DataMapping;


namespace HL.DomainModel
{
   public class MachineManager : IMachineManager
   {
      public MachineManager()
      {
      }

      public List<Machine> GetMachines()
      {
         var machines = new List<Machine>();
         using (var unitOfWork = IoC.Get<IUnitOfWork>())
         {
            var machineRepository = unitOfWork.GetRepository<Machine>();
            if (machineRepository.FindAll().ToList().Count > 0)
            {
               machines = machineRepository.FindAll().ToList();
            }
         }
         return machines;
      }
   }
}
