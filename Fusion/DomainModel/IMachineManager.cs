﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.DomainModel
{
   public interface IMachineManager
   {
      List<Machine> GetMachines();
   }
}
