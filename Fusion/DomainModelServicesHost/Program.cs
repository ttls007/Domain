using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Services;
using System.ServiceModel;

namespace HL.DomainModelServicesHost
{
   class Program
   {
      static void Main(string[] args)
      {
         try
         {
            var serviceNames = new List<string>();
            var domainModelServices = new DomainModelServices(serviceNames);

            if ((serviceNames.Count > 0))
            {
               // this displays the console window for troubleshooting
               //if ((bool.Parse(ConfigurationSettings.AppSettings["LaunchConsole"].Trim())))
               //{
               //   NativeMethods.AllocConsole();
               //}
               domainModelServices.Start();
               Console.ReadKey();
               domainModelServices.Stop();
            }
            else
            {
               //Windows Service host
               //From VS prompt type a command line to install the service
               //e.g. "InstallUtil.exe DomainModelServicesHost.exe"
               //Verify the service using Control Panel->Services
               //
               var servicesToRun = new ServiceBase[] { new DomainModelServicesHost(domainModelServices) };
               ServiceBase.Run(servicesToRun);
            }
         }
         catch (Exception e)
         {
         }
      }
   }
}
