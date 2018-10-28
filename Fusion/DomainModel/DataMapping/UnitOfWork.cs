using System;
using System.Transactions;
using System.Linq;

namespace Husky.DomainModel.DataMapping
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
            unitOfWork.GetRepository<ApplicationLog>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Machine>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Job>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineStatus>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineOperatingState>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineCurrentData>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineStationConfiguration>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Cycle>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<CycleAnnotation>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<SetPoint>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineProductionDataInterface>().FirstOrDefault(x => true);

            #region Downtimes
            unitOfWork.GetRepository<Downtime>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DowntimeReason>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DowntimeCategory>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DowntimeCategoryReason>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DowntimeReasonMachineReason>().FirstOrDefault(x => true);
            #endregion

            #region Scraps
            unitOfWork.GetRepository<Scrap>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ScrapReason>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<PartScrapReason>().FirstOrDefault(x => true);
            #endregion

            #region GoodPart
            unitOfWork.GetRepository<GoodPart>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<PartReconciliationStatus>().FirstOrDefault(x => true);
            #endregion

            unitOfWork.GetRepository<ScreenObject>().FirstOrDefault(x => true);

            #region DatalogData
            unitOfWork.GetRepository<MachineVariableDefinition>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MasterVariableDefinition>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<VariableDefinitionMapping>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<PredictiveMaintenanceVariableLimit>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ProcessTarget>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<UserDefinedVariable>().FirstOrDefault(x => true);
            #endregion

            #region Events
            unitOfWork.GetRepository<Event>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<EventType>().FirstOrDefault(x => true);
            #endregion

            unitOfWork.GetRepository<ShiftCalendar>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Tool>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Part>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<PartToTool>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MfgStandard>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MfgOption>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Run>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<RunPartAllocation>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<RunActivity>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<CycleExtra>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MfgResource>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MfgResourceType>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MfgOptionResource>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<RunResourceAllocation>().FirstOrDefault(x => true);

            #region Maintenance
            unitOfWork.GetRepository<MaintenanceTask>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceTrigger>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceJob>().FirstOrDefault(x => true);

            unitOfWork.GetRepository<MaintenancePlan>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceProgram>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceIntervalTrigger>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenancePlanResource>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceActivity>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceJobRecord>().FirstOrDefault(x => true);
            #endregion

            #region Documents
            unitOfWork.GetRepository<DocumentGroup>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DocumentGroupFile>().FirstOrDefault(x => true);
            #endregion

            unitOfWork.GetRepository<ImageStore>().FirstOrDefault(x => true);

            #region Curves
            unitOfWork.GetRepository<Curve>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<CurveHistory>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<CurveConfiguration>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<CurveStatus>().FirstOrDefault(x => true);
            #endregion

            unitOfWork.GetRepository<EnumerationMapping>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ObjectCache>().FirstOrDefault(x => true);

            #region Factories
            unitOfWork.GetRepository<Factory>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineToFactory>().FirstOrDefault(x => true);
            #endregion

            unitOfWork.GetRepository<DataCollector>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Station>().FirstOrDefault(x => true);

            // Units:
            {
               if (unitOfWork.GetRepository<UnitsConversion>().Find(u => u.MachineUnits == "?C" || u.MachineUnits == "?F").Count() > 0)
               {
                  throw new ApplicationException("Units table contains illegal records (?C or ?F). Please call Husky support.");
               }
            }

            unitOfWork.GetRepository<ReportDefinition>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ReportRequest>().FirstOrDefault(x => true);

            unitOfWork.GetRepository<ErpConfiguration>().FirstOrDefault(x => true);

            unitOfWork.GetRepository<SSNXVersion>().FirstOrDefault(x => true);

            #region Labels
            unitOfWork.GetRepository<Printer>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ContentParameterList>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ContentParameter>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Label>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineDefaultPrinter>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<AutomaticPrintEvent>().FirstOrDefault(x => true);
            #endregion

            #region BOM
            unitOfWork.GetRepository<BomMaterial>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<BomPartItem>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<BomManufacturing>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<BomManufacturingItem>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<BomManufacturingToPart>().FirstOrDefault(x => true);
            #endregion

            #region Messaging
            unitOfWork.GetRepository<MessagingSetting>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MessagingRecipient>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MessagingRule>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MessagingRuleCause>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MessagingRuleMachine>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MessagingRuleRecipient>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MessagingScheduledReport>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<OperatorHelpReason>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineOperatorHelpStatus>().FirstOrDefault(x => true);
            #endregion

            #region SystemOption
            unitOfWork.GetRepository<SystemOption>().FirstOrDefault(x => true);
            #endregion

            #region EnergyManagement
            unitOfWork.GetRepository<EnergySensor>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MeasurementLocation>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<EnergySensorData>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MeasurementLocationSensor>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MeasurementLocationMachine>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineMaterialConsumption>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MeasurementLocationToMeasurementLocation>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MeasurementLocationTarget>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineIntegratedEnergySensor>().FirstOrDefault(x => true);
            #endregion

            #region BatchTracking
            unitOfWork.GetRepository<BatchTrackingConfiguration>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<BatchTracking>().FirstOrDefault(x => true);
            #endregion

            #region ConcatenateData
            unitOfWork.GetRepository<ConcatenateData>().FirstOrDefault(x => true);
            #endregion

            #region GlobalSetting
            unitOfWork.GetRepository<GlobalSetting>().FirstOrDefault(x => true);
            #endregion

            #region Department
            unitOfWork.GetRepository<Department>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DepartmentMachine>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DowntimeReasonDepartment>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<DepartmentUser>().FirstOrDefault(x => true);
            #endregion

            #region MoldConfiguration
            unitOfWork.GetRepository<MoldConfigurationProduct>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MoldConfiguration>().FirstOrDefault(x => true);
            #endregion

            #region MachineFeature
            unitOfWork.GetRepository<MachineFeature>().FirstOrDefault(x => true);
            #endregion

            #region Preventative Maintenance (Consumable)
            unitOfWork.GetRepository<ConsumableSupplier>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<Consumable>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<ConsumableToSupplier>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MaintenanceProgramConsumable>().FirstOrDefault(x => true);
            #endregion

            #region Machine Production Data Interface
            unitOfWork.GetRepository<MachineProductionDataInterface>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<MachineProductionDataPartInterface>().FirstOrDefault(x => true);
            #endregion

            #region MachineSetupMode
            unitOfWork.GetRepository<MachineSetupMode>().FirstOrDefault(x => true);
            #endregion

            #region OIOption
            unitOfWork.GetRepository<OIOption>().FirstOrDefault(x => true);
            #endregion

            #region Operator Traceability
            unitOfWork.GetRepository<Operator>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<OperatorTimecard>().FirstOrDefault(x => true);
            unitOfWork.GetRepository<OperatorTraceability>().FirstOrDefault(x => true);
            #endregion
         }
      }
   }
}
