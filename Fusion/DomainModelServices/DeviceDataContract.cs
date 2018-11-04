using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Services
{
   public enum MachineMode
   {
      NoCommunication = 0,
      AutoPurge = 1,
      IdleManual = 2,
      DryCycling = 3,
      SemiCycling = 4,
      AutoCycling = 5,
      CycleInterruption = 6,
      NoDeviceCommunication = 7
   }
   class DeviceDataContract
   {
   }
}
