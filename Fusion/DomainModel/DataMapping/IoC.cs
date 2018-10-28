using System;
using System.Collections.Generic;

using Ninject.Core;
using Ninject.Core.Creation;
using Ninject.Core.Activation;

namespace Husky.DomainModel.DataMapping
{
   public interface IMockObject
   {
      // empty
   }

   public static class IoC
   {
      private static IKernel Kernel { get; set; }

      static IoC()
      {
         RebuildDefault();
      }

      public static void RebuildDefault()
      {
         Kernel = new StandardKernel(new ProductionModule());
      }

      //public static void RebuildForTest(DateTime fixedTime)
      //{
      //   Kernel = new StandardKernel(new TestModule(fixedTime, new List<IMockObject>()));
      //}

      //public static void RebuildForTest(DateTime fixedTime, List<IMockObject> mockManagers)
      //{
      //   Kernel = new StandardKernel(new TestModule(fixedTime, mockManagers));
      //}

      //public static void RebuildForTest(List<IMockObject> mockManagers)
      //{
      //   Kernel = new StandardKernel(new TestModule(mockManagers));
      //}

      public static T Get<T>()
      {
         return Kernel.Get<T>();
      }
   }

   public class ProductionModule : StandardModule
   {
      public override void Load()
      {
         Bind<IUnitOfWork>().To<SqlUnitOfWork>();
         Bind<ITimeManager>().To<TimeManager>();
         Bind<IStopwatch>().To<StopwatchAdapter>();

         // Managers
         Bind<IMachineProductionManager>().To<MachineProductionManager>();
         Bind<IMachineManager>().To<MachineManager>();
         Bind<IDataCollectorManager>().To<DataCollectorManager>();
         Bind<ILicenseManager>().To<LicenseManager>();
         Bind<IFactoryManager>().To<FactoryManager>();
         Bind<IShiftManager>().To<ShiftManager>();
         Bind<IEnergyManagementManager>().To<EnergyManagementManager>();
         
         // Notifiers
         Bind<IMachineNotifier>().To<MachineNotifier>();
         Bind<IErpNotifier>().To<ErpNotifier>();

         // Misc. Objects
         //Bind<IPlusLicense>().To<PlusLicense>();
         Bind<IMessageRouterManager>().ToProvider<MessageRouterManagerProvider>();
         Bind(typeof(IThreadPoolHelper<>)).To(typeof(ThreadPoolHelper<>));
         Bind<IDomainModelServicesAppSettings>().To<DomainModelServicesAppSettings>();
      }
   }

   //public class TestModule : StandardModule
   //{
   //   private MockTimeManager _MockTimeManager;

   //   // Managers
   //   private IMachineProductionManager _MachineProductionManager;
   //   private IMachineManager _MachineManager;
   //   private IDataCollectorManager _DataCollectorManager;
   //   private ILicenseManager _LicenseManager;
   //   private IFactoryManager _FactoryManager;

   //   private IShiftManager _ShiftManager;
   //   private IEnergyManagementManager _EnergyManagementManager;

   //   // Notifiers
   //   private IMachineNotifier _MachineNotifier;
   //   private IErpNotifier _ErpNotifier;

   //   // Misc. Objects
   //   private IPlusLicense _PlusLicense;
   //   private IThreadPoolHelper<short> _ThreadPoolHelper_Short;
   //   private IDomainModelServicesAppSettings _DomainModelServicesAppSettings;

   //   public TestModule(DateTime? fixedTime, List<IMockObject> mockObjects)
   //      : base()
   //   {
   //      if (fixedTime != null)
   //      {
   //         _MockTimeManager = new MockTimeManager(fixedTime.Value);
   //      }

   //      _MachineProductionManager = null;
   //      _MachineManager = null;
   //      _DataCollectorManager = null;
   //      _LicenseManager = null;
   //      _FactoryManager = null;
   //      _ShiftManager = null;
   //      _EnergyManagementManager = null;

   //      _MachineNotifier = null;
   //      _ErpNotifier = null;

   //      _PlusLicense = null;

   //      mockObjects.ForEach(mockObject =>
   //      {
   //         if (mockObject.GetType() == typeof(MockMachineProductionManager))
   //         {
   //            _MachineProductionManager = mockObject as IMachineProductionManager;
   //         }
   //         else if (mockObject is IMachineManager)
   //         {
   //            _MachineManager = mockObject as IMachineManager;
   //         }
   //         else if (mockObject is IDataCollectorManager)
   //         {
   //            _DataCollectorManager = mockObject as IDataCollectorManager;
   //         }
   //         else if (mockObject is ILicenseManager)
   //         {
   //            _LicenseManager = mockObject as ILicenseManager;
   //         }
   //         else if (mockObject.GetType() == typeof(MockFactoryManager))
   //         {
   //            _FactoryManager = mockObject as IFactoryManager;
   //         }
   //         else if (mockObject.GetType() == typeof(MockShiftManager))
   //         {
   //            _ShiftManager = mockObject as MockShiftManager;
   //         }
   //         else if (mockObject.GetType() == typeof(MockMachineNotifier))
   //         {
   //            _MachineNotifier = mockObject as IMachineNotifier;
   //         }
   //         else if (mockObject.GetType() == typeof(MockErpNotifier))
   //         {
   //            _ErpNotifier = mockObject as IErpNotifier;
   //         }
   //         else if (mockObject.GetType() == typeof(MockPlusLicense))
   //         {
   //            _PlusLicense = mockObject as IPlusLicense;
   //         }
   //         else if (mockObject.GetType() == typeof(MockEnergyManagementManager))
   //         {
   //            _EnergyManagementManager = mockObject as IEnergyManagementManager;
   //         }
   //         else if (mockObject.GetType() == typeof(MockDomainModelServicesAppSettings))
   //         {
   //            _DomainModelServicesAppSettings = mockObject as IDomainModelServicesAppSettings;
   //         }
   //         else if (mockObject.GetType().GetGenericTypeDefinition() == typeof(MockThreadPoolHelper<>))
   //         {
   //            // TODO: Need to figure out how to do this generically for the mocking (real mapping is okay).  Tried a few 
   //            //       but couldn't get it to work in the end, so at least support what we need.
   //            if (mockObject.GetType() == typeof(MockThreadPoolHelper<short>))
   //            {
   //               _ThreadPoolHelper_Short = mockObject as IThreadPoolHelper<short>;
   //            }
   //            else
   //            {
   //               throw new NotImplementedException(string.Format(
   //                  "Full generic support for {0} is not supported yet.  " +
   //                  "Either figure out how to get Ninject to support the mock (real types are okay), " +
   //                  "or just extend {1} to support the specific type you need.",
   //                  mockObject.GetType().Name, this.GetType().Name)
   //               );
   //            }
   //         }
   //         else
   //         {
   //            throw new NotImplementedException();
   //         }
   //      });
   //   }

   //   public TestModule(List<IMockObject> mockObjects)
   //      : this(null, mockObjects)
   //   {
   //   }

   //   public override void Load()
   //   {
   //      Bind<IUnitOfWork>().To<SqlUnitOfWork>();

   //      if (_MockTimeManager != null)
   //      {
   //         //Bind<ITimeManager>().To<MockTimeManager>().WithArgument("fixedTime", _FixedTime);
   //         Bind<ITimeManager>().ToFactoryMethod(() => _MockTimeManager);
   //      }
   //      else
   //      {
   //         Bind<ITimeManager>().To<TimeManager>();
   //      }

   //      // TODO: Support mock
   //      Bind<IStopwatch>().To<StopwatchAdapter>();

   //      if (_MachineProductionManager != null)
   //      {
   //         Bind<IMachineProductionManager>().ToFactoryMethod(() => _MachineProductionManager);
   //      }
   //      else
   //      {
   //         Bind<IMachineProductionManager>().To<MachineProductionManager>();
   //      }

   //      if (_MachineManager != null)
   //      {
   //         Bind<IMachineManager>().ToFactoryMethod(() => _MachineManager);
   //      }
   //      else
   //      {
   //         Bind<IMachineManager>().To<MachineManager>();
   //      }

   //      if (_DataCollectorManager!= null)
   //      {
   //         Bind<IDataCollectorManager>().ToFactoryMethod(() => _DataCollectorManager);
   //      }
   //      else
   //      {
   //         Bind<IDataCollectorManager>().To<DataCollectorManager>();
   //      }

   //      if (_LicenseManager != null)
   //      {
   //         Bind<ILicenseManager>().ToFactoryMethod(() => _LicenseManager);
   //      }
   //      else
   //      {
   //         Bind<ILicenseManager>().To<LicenseManager>();
   //      }

   //      if (_FactoryManager != null)
   //      {
   //         Bind<IFactoryManager>().ToFactoryMethod(() => _FactoryManager);
   //      }
   //      else
   //      {
   //         Bind<IFactoryManager>().To<FactoryManager>();
   //      }

   //      if (_ShiftManager != null)
   //      {
   //         Bind<IShiftManager>().ToFactoryMethod(() => _ShiftManager);
   //      }
   //      else
   //      {
   //         Bind<IShiftManager>().To<ShiftManager>();
   //      }

   //      if (_EnergyManagementManager != null)
   //      {
   //         Bind<IEnergyManagementManager>().ToFactoryMethod(() => _EnergyManagementManager);
   //      }
   //      else
   //      {
   //         Bind<IEnergyManagementManager>().To<EnergyManagementManager>();
   //      }

   //      if (_MachineNotifier != null)
   //      {
   //         Bind<IMachineNotifier>().ToFactoryMethod(() => _MachineNotifier);
   //      }
   //      else
   //      {
   //         Bind<IMachineNotifier>().To<MachineNotifier>();
   //      }

   //      if (_ErpNotifier != null)
   //      {
   //         Bind<IErpNotifier>().ToFactoryMethod(() => _ErpNotifier);
   //      }
   //      else
   //      {
   //         Bind<IErpNotifier>().To<ErpNotifier>();
   //      }

   //      if (_PlusLicense != null)
   //      {
   //         Bind<IPlusLicense>().ToFactoryMethod(() => _PlusLicense);
   //      }
   //      else
   //      {
   //         Bind<IPlusLicense>().To<PlusLicense>();
   //      }

   //      if (_ThreadPoolHelper_Short != null)
   //      {
   //         Bind(typeof(IThreadPoolHelper<short>)).ToFactoryMethod(() => _ThreadPoolHelper_Short);
   //      }
   //      else
   //      {
   //         Bind(typeof(IThreadPoolHelper<>)).To(typeof(ThreadPoolHelper<>));
   //      }

   //      if (_DomainModelServicesAppSettings != null)
   //      {
   //         Bind<IDomainModelServicesAppSettings>().ToFactoryMethod(() => _DomainModelServicesAppSettings);
   //      }
   //      else
   //      {
   //         Bind<IDomainModelServicesAppSettings>().To<DomainModelServicesAppSettings>();
   //      }

   //      Bind<IMessageRouterManager>().ToProvider<MessageRouterManagerProvider>();
   //   }
   //}

   public class MessageRouterManagerProvider : SimpleProvider<IMessageRouterManager>
   {
      private const string MessageRouterManagerName = "ShotscopeNxMessageRouterManager";

      private static IMessageRouterManager _MessageRouterManager;
      private static readonly object _ExceptionHandlerLock = new Object();

      public static void Start()
      {
         _MessageRouterManager = new MessageRouterManager(MessageRouterManagerName, UnhandledExceptionHandler);
      }

      public static void Start(IMessageRouterManager messageRouterManager)
      {
         _MessageRouterManager = messageRouterManager;
      }


      public static void Stop()
      {
         if (_MessageRouterManager != null)
         {
            _MessageRouterManager.Dispose();
         }
      }

      protected override IMessageRouterManager CreateInstance(IContext context)
      {
         return _MessageRouterManager;
      }

      // Catch any unhandled exceptions generated by the message routers
      private static void UnhandledExceptionHandler(IMessageRouter messageRouter, Exception exception)
      {
         // Only allow exceptions from one thread to be handled at one time...
         lock (_ExceptionHandlerLock)
         {
            //ExceptionHandler.WriteExceptionToEventLog("MessageRouterUnhandledExceptionHandler", exception, true);
         }
      }

   }
}
