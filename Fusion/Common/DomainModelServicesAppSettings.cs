using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace HL.Common
{
   public interface IDomainModelServicesAppSettings
   {
      int MachineProductionDataMaximumThreads { get; }
      TimeSpan MachineProductionDataUpdateInterval { get; }
      bool EnablePerformanceCounters { get; }
      TimeSpan LicenseRefreshInterval { get; }
      bool EnableMachineProductionDataInterfaceUpdate { get; }
      TimeSpan MachineProductionDataInterfaceUpdateInterval { get; }
      bool EnableAutomaticCavityDetection { get; }
      int DaysToKeepApplicationLogEvents { get; }
      int DaysToKeepMachineEvents { get; }
      int DaysToKeepProcessData { get; }
      bool EnableHistoricalDataDeletion { get; }
   }

   public class DomainModelServicesAppSettings : IDomainModelServicesAppSettings
   {
      private const int _MachineProductionDataMaximumThreadsDefault = 1;
      private static readonly TimeSpan _MachineProductionDataUpdateIntervalDefault = TimeSpan.FromSeconds(10);
      private const bool _EnablePerformanceCountersDefault = true;
      private static readonly TimeSpan _LicenseRefreshIntervalDefault = TimeSpan.FromDays(30);
      private const bool _EnableMachineProductionDataInterfaceUpdateDefault = false;
      private static readonly TimeSpan _MachineProductionDataInterfaceUpdateIntervallDefault = TimeSpan.FromSeconds(60);
      private const bool _EnableAutomaticCavityDetectionDefault = false;
      private const int _DaysToKeepApplicationLogEventsDefault = 365;
      private const int _DaysToKeepMachineEventsDefault = 365;
      private const int _DaysToKeepProcessDataDefault = 730;
      private const bool _EnableHistoricalDataDeletionDefault = false;


      private int _MachineProductionDataMaximumThreads = _MachineProductionDataMaximumThreadsDefault;
      private TimeSpan _MachineProductionDataUpdateInterval = _MachineProductionDataUpdateIntervalDefault;
      private bool _EnablePerformanceCounters = _EnablePerformanceCountersDefault;
      private TimeSpan _LicenseRefreshInterval = _LicenseRefreshIntervalDefault;
      private bool _EnableMachineProductionDataInterfaceUpdate = _EnableMachineProductionDataInterfaceUpdateDefault;
      private TimeSpan _MachineProductionDataInterfaceUpdateIntervall = _MachineProductionDataInterfaceUpdateIntervallDefault;
      private bool _EnableAutomaticCavityDetection = _EnableAutomaticCavityDetectionDefault;

      private int _DaysToKeepApplicationLogEvents = _DaysToKeepApplicationLogEventsDefault;
      private int _DaysToKeepMachineEvents = _DaysToKeepMachineEventsDefault;
      private int _DaysToKeepProcessData = _DaysToKeepProcessDataDefault;
      private bool _EnableHistoricalDataDeletion = _EnableHistoricalDataDeletionDefault;


      public DomainModelServicesAppSettings()
         : this(ConfigurationManager.AppSettings)
      {
      }

      internal DomainModelServicesAppSettings(NameValueCollection appSettingsNameValueCollection)
      {
         GetSettingValue<int>(appSettingsNameValueCollection, "MachineProductionDataMaximumThreads",
            (settingValue) => int.TryParse(settingValue, out _MachineProductionDataMaximumThreads),
            () =>
            {
               if (_MachineProductionDataMaximumThreads < 1)
               {
                  _MachineProductionDataMaximumThreads = Environment.ProcessorCount;
               }
            },
            null);

         GetSettingValue<TimeSpan>(appSettingsNameValueCollection, "MachineProductionDataUpdateInterval",
            (settingValue) =>
               TimeSpan.TryParse(settingValue, out _MachineProductionDataUpdateInterval) &&
               _MachineProductionDataUpdateInterval > TimeSpan.Zero,
            null,
            "Invalid '{0}' application setting value of '{1}'.  Expected type is '{2}' and value must be greater than 0.");

         GetSettingValue<bool>(appSettingsNameValueCollection, "EnablePerformanceCounters",
            (settingValue) => bool.TryParse(settingValue, out _EnablePerformanceCounters),
            null,
            null);

         GetSettingValue<TimeSpan>(appSettingsNameValueCollection, "LicenseRefreshInterval",
            (settingValue) =>
               TimeSpan.TryParse(settingValue, out _LicenseRefreshInterval) &&
               _LicenseRefreshInterval >= TimeSpan.FromMinutes(30) &&
               _LicenseRefreshInterval <= TimeSpan.FromDays(30),
            null,
            "Invalid '{0}' application setting value of '{1}'.  Expected type is '{2}' and value must be between 0.00:30:00 and 30.00:00:00.");

         GetSettingValue<bool>(appSettingsNameValueCollection, "EnableMachineProductionDataInterfaceUpdate",
            (settingValue) => bool.TryParse(settingValue, out _EnableMachineProductionDataInterfaceUpdate),
            null,
            null);

         GetSettingValue<TimeSpan>(appSettingsNameValueCollection, "MachineProductionDataInterfaceUpdateInterval",
            (settingValue) =>
               TimeSpan.TryParse(settingValue, out _MachineProductionDataInterfaceUpdateIntervall) &&
               _MachineProductionDataInterfaceUpdateIntervall > TimeSpan.Zero,
            null,
            "Invalid '{0}' application setting value of '{1}'.  Expected type is '{2}' and value must be greater than 0.");

         GetSettingValue<bool>(appSettingsNameValueCollection, "EnableAutomaticCavityDetection",
            (settingValue) => bool.TryParse(settingValue, out _EnableAutomaticCavityDetection),
            null,
            null);

         GetSettingValue<int>(appSettingsNameValueCollection, "DaysToKeepApplicationLogEvents",
            (settingValue) => int.TryParse(settingValue, out _DaysToKeepApplicationLogEvents),
            null,
            null);
         GetSettingValue<int>(appSettingsNameValueCollection, "DaysToKeepMachineEvents",
            (settingValue) => int.TryParse(settingValue, out _DaysToKeepMachineEvents),
            null,
            null);
         GetSettingValue<int>(appSettingsNameValueCollection, "DaysToKeepProcessData",
            (settingValue) => int.TryParse(settingValue, out _DaysToKeepProcessData),
            null,
            null);
         GetSettingValue<bool>(appSettingsNameValueCollection, "EnableHistoricalDataDeletion",
            (settingValue) => bool.TryParse(settingValue, out _EnableHistoricalDataDeletion),
            null,
            null);
      }

      private void GetSettingValue<T>(NameValueCollection appSettingsNameValueCollection, string settingName,
         Func<string, bool> parseSettingAndUpdateVariable, Action handleSpecialValues, string exceptionMessageTemplate)
      {
         // fake .net 4 arguement defaults
         if (exceptionMessageTemplate == null)
         {
            exceptionMessageTemplate = "Invalid '{0}' application setting value of '{1}'.  Expected type is '{2}'.";
         }

         var settingValue = appSettingsNameValueCollection[settingName];

         if (settingValue != null)
         {
            if (!parseSettingAndUpdateVariable(settingValue))
            {
               throw new ArgumentException(string.Format(
                  exceptionMessageTemplate,
                  settingName, settingValue,
                  typeof(T).Name)
               );
            }
         }

         if (handleSpecialValues != null)
         {
            handleSpecialValues();
         }
      }

      #region IDomainModelServicesAppSettings members

      int IDomainModelServicesAppSettings.MachineProductionDataMaximumThreads { get { return _MachineProductionDataMaximumThreads; } }
      TimeSpan IDomainModelServicesAppSettings.MachineProductionDataUpdateInterval { get { return _MachineProductionDataUpdateInterval; } }
      bool IDomainModelServicesAppSettings.EnablePerformanceCounters { get { return _EnablePerformanceCounters; } }
      TimeSpan IDomainModelServicesAppSettings.LicenseRefreshInterval { get { return _LicenseRefreshInterval; } }
      bool IDomainModelServicesAppSettings.EnableMachineProductionDataInterfaceUpdate { get { return _EnableMachineProductionDataInterfaceUpdate; } }
      TimeSpan IDomainModelServicesAppSettings.MachineProductionDataInterfaceUpdateInterval { get { return _MachineProductionDataInterfaceUpdateIntervall; } }
      bool IDomainModelServicesAppSettings.EnableAutomaticCavityDetection { get { return _EnableAutomaticCavityDetection; } }
      int IDomainModelServicesAppSettings.DaysToKeepApplicationLogEvents { get { return _DaysToKeepApplicationLogEvents; } }
      int IDomainModelServicesAppSettings.DaysToKeepMachineEvents { get { return _DaysToKeepMachineEvents; } }
      int IDomainModelServicesAppSettings.DaysToKeepProcessData { get { return _DaysToKeepProcessData; } }
      bool IDomainModelServicesAppSettings.EnableHistoricalDataDeletion { get { return _EnableHistoricalDataDeletion; } }
      #endregion
   }
}
