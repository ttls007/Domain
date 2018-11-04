using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.Services;

namespace DomainModelServiceHost
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         //Application.EnableVisualStyles();
         //Application.SetCompatibleTextRenderingDefault(false);
         //Application.Run(new DomainModelServicesHostForm());

         try
         {

            var serviceNames = new List<string>();

            var domainModelServices = new DomainModelServices(serviceNames);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Windows Forms application host
            //From VS prompt type a command line, 
            //e.g. "DomainModelServicesHost.exe /CurveService /SpcService"
            //
            var startupForm = new DomainModelServicesHostForm(domainModelServices);

            domainModelServices.Start();
            Application.Run(startupForm);
            domainModelServices.Stop();
         }
         catch (Exception e)
         {
            //ExceptionHandler.WriteExceptionToEventLog("DomainModelServicesHost.Main", e, false);
            var a = e;
         }
      }
   }
}
