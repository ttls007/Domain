using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Husky.MessageRouting;
using System.Timers;
using HL.DomainModel.DataMapping;
using HL.Common;

namespace HL.Services
{
   public class DomainModelServices
   {
      private Dictionary<string, HLServiceHost> _ServiceHosts = new Dictionary<string, HLServiceHost>();
      public Dictionary<string, HLServiceHost> Services
      {
         get { return _ServiceHosts; }
      }
      internal Timer MessagingTimer { get; private set; }
      public DomainModelServices(List<string> serviceNames)
      {
         var appSettings = DomainModelServicesIoC.Get<IDomainModelServicesAppSettings>();
         AddServiceHost(new HLServiceHost(typeof(MachineService)));
      }

      private void AddServiceHost(HLServiceHost serviceHost)
      {
         _ServiceHosts.Add(serviceHost.Name, serviceHost);
      }

      public void Start()
      {
         MessageRouterManagerProvider.Start();

         //var appSettings = DomainModelServicesIoC.Get<IDomainModelServicesAppSettings>();

         foreach (var serviceHost in _ServiceHosts.Values)
         {
            if (serviceHost.Enable)
            {
               serviceHost.Open();
            }
         }

         //MessagingTimer = new Timer();
         //MessagingTimer.AutoReset = true;
         ////MessagingTimer.AutoReset = false;
         //MessagingTimer.Interval = _CheckMessagingTimerInterval.TotalMilliseconds;
         //MessagingTimer.Elapsed += OnMessagingTimer_Elapsed;
         //MessagingTimer.Start();

         //if (energyLicenseEnabled)
         //{
         //   EnergyTimer = new Timer();
         //   EnergyTimer.AutoReset = true;
         //   EnergyTimer.Interval = _CheckEnergyTimerInterval.TotalMilliseconds;
         //   EnergyTimer.Elapsed += OnEnergyTimer_Elapsed;
         //   EnergyTimer.Start();
         //}

         //{
         //   _CheckBatchTrackingDateTime = DateTime.Now;

         //   BatchTrackingUpdateTimer = new Timer();
         //   BatchTrackingUpdateTimer.AutoReset = true;
         //   BatchTrackingUpdateTimer.Interval = _CheckBatchTrackingUpdateTimerInterval.TotalMilliseconds;
         //   BatchTrackingUpdateTimer.Elapsed += OnUpdateBatchTrackingTimer_Elapsed;
         //   BatchTrackingUpdateTimer.Start();
         //}

         //var scrapManager = new ScrapManager();

         //if (scrapManager.GetScrapMode() == ScrapMode.ScrapReconciliation)
         //{
         //   ScrapReconciliationTimer = new Timer();
         //   ScrapReconciliationTimer.AutoReset = true;
         //   ScrapReconciliationTimer.Interval = _CheckScrapReconciliationTimerInterval.TotalMilliseconds;
         //   ScrapReconciliationTimer.Elapsed += OnScrapReconciliationTimer_Elapsed;
         //   ScrapReconciliationTimer.Start();
         //}

         //SetupModeTimer = new Timer();
         //SetupModeTimer.AutoReset = true;
         //SetupModeTimer.Interval = _CheckSetupModeTimerInterval.TotalMilliseconds;
         //SetupModeTimer.Elapsed += OnSetupModeTimer_Elapsed;
         //SetupModeTimer.Start();

         //if (appSettings.EnableHistoricalDataDeletion)
         //{
         //   DeleteHistoricalDataTimer = new Timer();
         //   DeleteHistoricalDataTimer.AutoReset = true;
         //   DeleteHistoricalDataTimer.Interval = _CheckDeleteHistoricalDataTimerInterval.TotalMilliseconds;
         //   DeleteHistoricalDataTimer.Elapsed += OnDeleteHistoricalDataTimer_Elapsed;
         //   DeleteHistoricalDataTimer.Start();
         //}


         //MachineProductionUpdateManager = new MachineProductionUpdateManager();
         //MachineProductionUpdateManager.Start();

         LogThreadUsage("DomainModelServices.Start");
      }

      private static void LogThreadUsage(string source)
      {
         int workerThreads;
         int completionPortThreads;

         System.Threading.ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);

         //TraceDomainModelServices.LogInfo(source,
         //   "ThreadPool(workerThreads = {0}, completionPortThreads = {1})",
         //   workerThreads, completionPortThreads);
      }

      public void Stop()
      {
         if (MessagingTimer != null)
         {
            MessagingTimer.Stop();
            MessagingTimer.Dispose();
         }

         //if (ScrapReconciliationTimer != null)
         //{
         //   ScrapReconciliationTimer.Stop();
         //   ScrapReconciliationTimer.Dispose();
         //}

         //if (SetupModeTimer != null)
         //{
         //   SetupModeTimer.Stop();
         //   SetupModeTimer.Dispose();
         //}

         //if (MachineProductionUpdateManager != null)
         //{
         //   MachineProductionUpdateManager.Stop();
         //}

         //if (DeleteHistoricalDataTimer != null)
         //{
         //   DeleteHistoricalDataTimer.Stop();
         //   DeleteHistoricalDataTimer.Dispose();
         //}

         foreach (var serviceHost in _ServiceHosts.Values)
         {
            if (serviceHost.Enable)
            {
               serviceHost.Close();
            }
         }

         MessageRouterManagerProvider.Stop();
      }
   }
}
