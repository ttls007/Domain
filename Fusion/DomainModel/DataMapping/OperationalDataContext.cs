using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Reflection;

using SmartAssembly.Attributes;
using Husky.Database;

namespace Husky.DomainModel.DataMapping
{
   [DoNotObfuscateType]
   public class OperationalDataContext : System.Data.Linq.DataContext
   {
      public static string ConnectionString = FusionOperationalDBSettings.ConnectionStringFusionOperational;

      public OperationalDataContext()
         : base(ConnectionString, DataMapping.GetMapping())
      {
      }

      public Table<ApplicationLog> ApplicationLog
      {
         get { return this.GetTable<ApplicationLog>(); }
      }

      public Table<Machine> Machines
      {
         get { return this.GetTable<Machine>(); }
      }

      public Table<Job> Jobs
      {
         get { return this.GetTable<Job>(); }
      }

      public Table<Cycle> Cycles
      {
         get { return this.GetTable<Cycle>(); }
      }

      public Table<CycleAnnotation> CycleAnnotations
      {
         get { return this.GetTable<CycleAnnotation>(); }
      }

      public Table<Downtime> Downtimes
      {
         get { return this.GetTable<Downtime>(); }
      }

      public Table<MachineStatus> MachineStatuses
      {
         get { return this.GetTable<MachineStatus>(); }
      }

      public Table<MachineStationConfiguration> MachineStationConfigurations
      {
         get { return this.GetTable<MachineStationConfiguration>(); }
      }

      public Table<MachineOperatingState> MachineOperatingStates
      {
         get { return this.GetTable<MachineOperatingState>(); }
      }

      public Table<MachineCurrentData> MachineCurrentData
      {
         get { return this.GetTable<MachineCurrentData>(); }
      }

      public Table<DowntimeReason> DowntimeReasons
      {
         get { return this.GetTable<DowntimeReason>(); }
      }

      public Table<DowntimeCategory> DowntimeCategories
      {
         get { return this.GetTable<DowntimeCategory>(); }
      }

      public Table<DowntimeCategoryReason> DowntimeCategoryResons
      {
         get { return this.GetTable<DowntimeCategoryReason>(); }
      }

      public Table<DowntimeAssignedReason> DowntimeAssignedReasons
      {
         get { return this.GetTable<DowntimeAssignedReason>(); }
      }   

      public Table<Scrap> Scraps
      {
         get { return this.GetTable<Scrap>(); }
      }
            
      public Table<ScrapReason> ScrapReasons
      {
         get { return this.GetTable<ScrapReason>(); }
      }

      public Table<PartScrapReason> PartScrapReason
      {
         get { return this.GetTable<PartScrapReason>(); }
      }

      public Table<GoodPart> GoodParts
      {
         get { return this.GetTable<GoodPart>(); }
      }

      public Table<PartReconciliationStatus> PartReconciliationStatus
      {
         get { return this.GetTable<PartReconciliationStatus>(); }
      }
      
      public Table<ScreenObject> ScreenObjects
      {
         get { return this.GetTable<ScreenObject>(); }
      }

      public Table<MachineVariableDefinition> MachineVariableDefinitions
      {
         get { return this.GetTable<MachineVariableDefinition>(); }
      }

      public Table<PredictiveMaintenanceVariableLimit> PredictiveMaintenanceVariableLimit
      {
         get { return this.GetTable<PredictiveMaintenanceVariableLimit>(); }
      }

      public Table<MasterVariableDefinition> MasterVariableDefinitions
      {
         get { return this.GetTable<MasterVariableDefinition>(); }
      }

      public Table<VariableDefinitionMapping> VariableDefinitionMappings
      {
         get { return this.GetTable<VariableDefinitionMapping>(); }
      }

      public Table<ProcessTarget> ProcessTargets
      {
         get { return this.GetTable<ProcessTarget>(); }
      }

      public Table<SpecLimitHistory> SpecLimitHistory
      {
         get { return this.GetTable<SpecLimitHistory>(); }
      }

      public Table<Event> Events
      {
         get { return this.GetTable<Event>(); }
      }

      public Table<EventType> EventTypes
      {
         get { return this.GetTable<EventType>(); }
      }

      public Table<ShiftCalendar> ShiftCalendar
      {
         get { return this.GetTable<ShiftCalendar>(); }
      }

      public Table<Tool> Tools
      {
         get { return this.GetTable<Tool>();}
      }
            
      public Table<Part> Parts
      {
         get { return this.GetTable<Part>(); }
      }

      public Table<PartToTool> PartsToTools
      {
         get { return this.GetTable<PartToTool>(); }
      }

      public Table<MfgStandard> MfgStandards
      {
         get { return this.GetTable<MfgStandard>(); }
      }

      public Table<MfgOption> MfgOptions
      {
         get { return this.GetTable<MfgOption>(); }
      }

      public Table<DocumentGroup> DocumentGroups
      {
         get { return this.GetTable<DocumentGroup>(); }
      }

      public Table<DocumentGroupFile> DocumentGroupFiles
      {
         get { return this.GetTable<DocumentGroupFile>(); }
      }

      public Table<Run> Runs
      {
         get { return this.GetTable<Run>(); }
      }

      public Table<RunPartAllocation> RunPartAllocations
      {
         get { return this.GetTable<RunPartAllocation>(); }
      }

      public Table<RunActivity> RunActivities
      {
         get { return this.GetTable<RunActivity>(); }
      }

      public Table<MaintenancePlan> MaintenancePlans
      {
         get { return this.GetTable<MaintenancePlan>(); }
      }

      public Table<MaintenancePlanResource> MaintenancePlanResources
      {
         get { return this.GetTable<MaintenancePlanResource>(); }
      }

      public Table<MaintenanceProgram> MaintenancePrograms
      {
         get { return this.GetTable<MaintenanceProgram>(); }
      }

      public Table<MaintenanceIntervalTrigger> MaintenanceIntervalTriggers
      {
         get { return this.GetTable<MaintenanceIntervalTrigger>(); }
      }

      public Table<MaintenanceActivity> MaintenanceActivities
      {
         get { return this.GetTable<MaintenanceActivity>(); }
      }

      public Table<MaintenanceJobRecord> MaintenanceJobRecords
      {
         get { return this.GetTable<MaintenanceJobRecord>(); }
      }

      public Table<MaintenanceTask> MaintenanceTasks
      {
         get { return this.GetTable<MaintenanceTask>(); }
      }

      public Table<MaintenanceTrigger> MaintenanceTriggers
      {
         get { return this.GetTable<MaintenanceTrigger>(); }
      }

      public Table<MaintenanceJob> MaintenanceJobs
      {
         get { return this.GetTable<MaintenanceJob>(); }
      }

      public Table<CycleExtra> CycleExtras
      {
         get { return this.GetTable<CycleExtra>(); }
      }

      public Table<ImageStore> ImageStore
      {
         get { return this.GetTable<ImageStore>(); }
      }

      public Table<MfgResource> MfgResources
      {
         get { return this.GetTable<MfgResource>(); }
      }

      public Table<MfgResourceType> MfgResourceTypes
      {
         get { return this.GetTable<MfgResourceType>(); }
      }

      public Table<MfgOptionResource> MfgOptionResources
      {
         get { return this.GetTable<MfgOptionResource>(); }
      }

      public Table<RunResourceAllocation> RunResourceAllocations
      {
         get { return this.GetTable<RunResourceAllocation>(); }
      }

      //public Table<CurveDefinition> CurveDefinitions
      //{
      //   get { return this.GetTable<CurveDefinition>(); }
      //}

      public Table<Curve> Curves
      {
         get { return this.GetTable<Curve>(); }
      }

      public Table<CurveHistory> CurveHistory
      {
         get { return this.GetTable<CurveHistory>(); }
      }

      public Table<CurveConfiguration> CurveConfigurations
      {
         get { return this.GetTable<CurveConfiguration>(); }
      }

      public Table<CurveStatus> CurveStatuses
      {
         get { return this.GetTable<CurveStatus>(); }
      }

      public Table<EnumerationMapping> EnumerationMapping
      {
         get { return this.GetTable<EnumerationMapping>(); }
      }

      public Table<ObjectCache> ObjectCache
      {
         get { return this.GetTable<ObjectCache>(); }
      }

      public Table<Factory> Factories
      {
         get { return this.GetTable<Factory>(); }
      }

      public Table<MachineToFactory> MachinesToFactories
      {
         get { return this.GetTable<MachineToFactory>(); }
      }

      public Table<DataCollector> DataCollectors
      {
         get { return this.GetTable<DataCollector>(); }
      }

      public Table<Station> Stations
      {
         get { return this.GetTable<Station>(); }
      }

      public Table<ConcatenateData> ConcatenateData
      {
         get { return this.GetTable<ConcatenateData>(); }
      }

      public Table<UnitsConversion> UnitsConversions
      {
         get { return this.GetTable<UnitsConversion>(); }
      }

      public Table<ReportDefinition> ReportDefinition
      {
         get { return this.GetTable<ReportDefinition>(); }
      }

      public Table<ReportRequest> ReportRequest
      {
         get { return this.GetTable<ReportRequest>(); }
      }

      public Table<ErpConfiguration> ErpConfigurations
      {
         get { return this.GetTable<ErpConfiguration>(); }
      }

      public Table<SSNXVersion> SSNXVersions
      {
         get { return this.GetTable<SSNXVersion>(); }
      }

      public Table<SQCVariable> SQCVariables
      {
         get { return this.GetTable<SQCVariable>(); }
      }

      public Table<SQCPartVariable> SQCPartVariables
      {
         get { return this.GetTable<SQCPartVariable>(); }
      }

      public Table<SQCPlan> SQCPlans
      {
         get { return this.GetTable<SQCPlan>(); }
      }

      public Table<SQCPlanVariable> SQCPlanVariables
      {
         get { return this.GetTable<SQCPlanVariable>(); }
      }

      public Table<SQCDataset> SQCDatasets
      {
         get { return this.GetTable<SQCDataset>(); }
      }

      public Table<SQCValue> SQCValues
      {
         get { return this.GetTable<SQCValue>(); }
      }

      public Table<Printer> Printers
      {
         get { return this.GetTable<Printer>(); }
      }

      public Table<MachineDefaultPrinter> MachineDefaultPrinters
      {
         get { return this.GetTable<MachineDefaultPrinter>(); }
      }

      public Table<ContentParameterList> ContentParameterLists
      {
         get { return this.GetTable<ContentParameterList>(); }
      }

      public Table<ContentParameter> ContentParameters
      {
         get { return this.GetTable<ContentParameter>(); }
      }

      public Table<Label> Labels
      {
         get { return this.GetTable<Label>(); }
      }

      public Table<BomMaterial> BomMaterials
      {
         get { return this.GetTable<BomMaterial>(); }
      }

      public Table<BomPartItem> BomPartItems
      {
         get { return this.GetTable<BomPartItem>(); }
      }

      public Table<BomManufacturing> BomManufacturings
      {
         get { return this.GetTable<BomManufacturing>(); }
      }

      public Table<BomManufacturingItem> BomManufacturingsItems
      {
         get { return this.GetTable<BomManufacturingItem>(); }
      }

      public Table<BomManufacturingToPart> BomManufacturingToParts
      {
         get { return this.GetTable<BomManufacturingToPart>(); }
      }

      public Table<MessagingSetting> MessagingSettings
      {
         get { return this.GetTable<MessagingSetting>(); }
      }

      public Table<MessagingRecipient> MessagingRecipients
      {
         get { return this.GetTable<MessagingRecipient>(); }
      }

      public Table<MessagingRule> MessagingRules
      {
         get { return this.GetTable<MessagingRule>(); }
      }

      public Table<MessagingRuleCause> MessagingRuleCauses
      {
         get { return this.GetTable<MessagingRuleCause>(); }
      }

      public Table<MessagingRuleMachine> MessagingRuleMachines
      {
         get { return this.GetTable<MessagingRuleMachine>(); }
      }

      public Table<MessagingRuleRecipient> MessagingRuleRecipients
      {
         get { return this.GetTable<MessagingRuleRecipient>(); }
      }

      public Table<OperatorHelpReason> OperatorHelpReasons
      {
         get { return this.GetTable<OperatorHelpReason>(); }
      }

      public Table<MachineOperatorHelpStatus> MachineOperatorHelpStatuses
      {
         get { return this.GetTable<MachineOperatorHelpStatus>(); }
      }

      public Table<SystemOption> SystemOptions
      {
         get { return this.GetTable<SystemOption>(); }
      }

      public Table<MeasurementLocation> MeasurementLocations
      {
         get { return this.GetTable<MeasurementLocation>(); }
      }

      public Table<MeasurementLocationSensor> MeasurementLocationSensors
      {
         get { return this.GetTable<MeasurementLocationSensor>(); }
      }

      public Table<MeasurementLocationMachine> MeasurementLocationMachines
      {
         get { return this.GetTable<MeasurementLocationMachine>(); }
      }

      public Table<MeasurementLocationToMeasurementLocation> MeasurementLocationToMeasurementLocations
      {
         get { return this.GetTable<MeasurementLocationToMeasurementLocation>(); }
      }

      public Table<EnergySensor> EnergySensors
      {
         get { return this.GetTable<EnergySensor>(); }
      }

      public Table<EnergySensorData> EnergySensorData
      {
         get { return this.GetTable<EnergySensorData>(); }
      }

      public Table<MachineMaterialConsumption> MachineMaterialConsumptions
      {
         get { return this.GetTable<MachineMaterialConsumption>(); }
      }

      public Table<SetPoint> SetPoints
      {
         get { return this.GetTable<SetPoint>(); }
      }

      public Table<HMIPhrase> HMIPhrases
      {
         get { return this.GetTable<HMIPhrase>(); }
      }

      public Table<BatchCode> BatchCodes
      {
         get { return this.GetTable<BatchCode>(); }
      }

      public Table<UserDefinedVariable> UserDefinedVariables
      {
         get { return this.GetTable<UserDefinedVariable>(); }
      }

      public Table<MeasurementLocationTarget> MeasurementLocationTargets
      {
         get { return this.GetTable<MeasurementLocationTarget>(); }
      }

      public Table<BatchTrackingConfiguration> BatchTrackingConfiguration
      {
         get { return this.GetTable<BatchTrackingConfiguration>(); }
      }

      public Table<BatchTracking> BatchTracking
      {
         get { return this.GetTable<BatchTracking>(); }
      }

      public Table<AutomaticPrintEvent> AutomaticPrintEvents
      {
         get { return this.GetTable<AutomaticPrintEvent>(); }
      }

      public Table<Department> Departments
      {
         get { return this.GetTable<Department>(); }
      }

      public Table<DepartmentMachine> DepartmentMachines
      {
         get { return this.GetTable<DepartmentMachine>(); }
      }

      public Table<DowntimeReasonDepartment> DowntimeReasonDepartments
      {
         get { return this.GetTable<DowntimeReasonDepartment>(); }
      }

      public Table<DepartmentUser> DepartmentUser
      {
         get { return this.GetTable<DepartmentUser>(); }
      }
		

      public Table<MoldConfiguration> MoldConfiguration
      {
         get { return this.GetTable<MoldConfiguration>(); }
      }
      public Table<MoldConfigurationProduct> MoldConfigurationProduct
      {
         get { return this.GetTable<MoldConfigurationProduct>(); }
      }

      public Table<GlobalSetting> GlobalSetting
      {
         get { return this.GetTable<GlobalSetting>(); }
      }

      public Table<MachineFeature> MachineFeature
      {
         get { return this.GetTable<MachineFeature>(); }
      }

      public Table<Consumable> Consumables
      {
         get{ return this.GetTable<Consumable>(); }
      }

      public Table<ConsumableSupplier> ConsumableSuppliers
      {
         get { return this.GetTable<ConsumableSupplier>(); }
      }

      public Table<ConsumableToSupplier> ConsumableToSuppliers
      {
         get { return this.GetTable<ConsumableToSupplier>(); }
      }

      public Table<MaintenanceProgramConsumable> MaintenanceProgramConsumables
      {
         get { return this.GetTable<MaintenanceProgramConsumable>(); }
      }

      public Table<DowntimeReasonMachineReason> DowntimeReasonMachineReasons
      {
         get { return this.GetTable<DowntimeReasonMachineReason>(); }
      }

      public Table<MessagingScheduledReport> MessagingScheduledReports
      {
         get { return this.GetTable<MessagingScheduledReport>(); }
      }

      public Table<MachineProductionDataInterface> MachineProductionDataInterfaces
      {
         get { return this.GetTable<MachineProductionDataInterface>(); }
      }

      public Table<MachineProductionDataPartInterface> MachineProductionDataPartInterfaces
      {
         get { return this.GetTable<MachineProductionDataPartInterface>(); }
      }

      public Table<MachineSetupMode> MachineSetupModes
      {
         get { return this.GetTable<MachineSetupMode>(); }
      }

      public Table<OIOption> OIOptions
      {
         get { return this.GetTable<OIOption>(); }
      }

      public Table<MachineIntegratedEnergySensor> MachineIntegratedEnergySensors
      {
         get { return this.GetTable<MachineIntegratedEnergySensor>(); }
      }

      public Table<MachineLastCycleData> MachineLastCycleData
      {
         get { return this.GetTable<MachineLastCycleData>(); }
      }

      public Table<Operator> Operators
      {
         get { return this.GetTable<Operator>(); }
      }

      public Table<OperatorTimecard> OperatorsTimecard
      {
         get { return this.GetTable<OperatorTimecard>(); }
      }

      public Table<OperatorTraceability> OperatorsTraceability 
      {
         get { return this.GetTable<OperatorTraceability>(); }
      }
   }

   #region Helper class for mapping
   [DoNotObfuscateType]
   public static class DataMapping
   {
      static XmlMappingSource _Mapping;

      static DataMapping()
      {
         _Mapping = null;
      }

      public static XmlMappingSource GetMapping()
      {
         if (_Mapping == null)
         {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Husky.DomainModel.DataMapping.OperationalMap.xml"))
            {
               _Mapping = XmlMappingSource.FromStream(stream);
            }
         }

         return _Mapping;
      }
   }
   #endregion
}
