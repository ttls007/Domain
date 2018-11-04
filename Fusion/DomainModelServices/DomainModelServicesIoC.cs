using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Core;
using HL.Common;

namespace HL.Services
{
   public static class DomainModelServicesIoC
   {
      private static IKernel Kernel { get; set; }

      static DomainModelServicesIoC()
      {
         RebuildDefault();
      }

      public static void RebuildDefault()
      {
         Kernel = new StandardKernel(
            new DomainModelServicesIoCProductionModule());
      }

      public static T Get<T>()
      {
         return Kernel.Get<T>();
      }
   }

   class DomainModelServicesIoCProductionModule : StandardModule
   {
      //private MachinesConnectionManager _MachinesConnectionManager;

      public DomainModelServicesIoCProductionModule()
         : base()
      {
         //_MachinesConnectionManager = new MachinesConnectionManager(new WcfOperationContextAdapter());
      }
      public override void Load()
      {
         //Bind<IOperationContext>().To<WcfOperationContextAdapter>();
         //Bind<MachinesConnectionManager>().ToFactoryMethod(() => _MachinesConnectionManager);
         Bind<IDomainModelServicesAppSettings>().To<DomainModelServicesAppSettings>();
         //Bind<IShotscopeNxCachingPerformanceCounters>().To<ShotscopeNxCachingPerformanceCounters>()
         //   .WithArguments(new Dictionary<string, object> { { "performanceCounterCategory", new PerformanceCounterCategoryAdapter() } });
      }
   }
}
