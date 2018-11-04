
using System.Configuration;

namespace Database
{
   public class FusionOperationalDBSettings
   {
      private static string _ConnectionString = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=FusionOperational; MultipleActiveResultSets=True";

      //private static string _ConnectionStringTest =
      //   "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=FusionOperationalTest; MultipleActiveResultSets=True";

      private static string _ConnectionStringMSDB = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=msdb";

      private static string _ConnectionStringMaster = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=master";

      //private static string _ConnectionStringMasterTest =
      //   "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=master";

      static FusionOperationalDBSettings()
      {
         // FusionOperational
         if (ConfigurationManager.ConnectionStrings["FusionOperational"] != null)
         {
            FusionOperationalDBSettings._ConnectionString = ConfigurationManager.ConnectionStrings["FusionOperational"].ConnectionString;
         }

         // msdb
         if (ConfigurationManager.ConnectionStrings["msdb"] != null)
         {
            FusionOperationalDBSettings._ConnectionStringMSDB = ConfigurationManager.ConnectionStrings["msdb"].ConnectionString;
         }

         // master
         if (ConfigurationManager.ConnectionStrings["master"] != null)
         {
            FusionOperationalDBSettings._ConnectionStringMaster = ConfigurationManager.ConnectionStrings["master"].ConnectionString;
         }
      }

      public static string ConnectionStringFusionOperational
      {
         get { return FusionOperationalDBSettings._ConnectionString; }
         set { FusionOperationalDBSettings._ConnectionString = value; }
      }

      public static string ConnectionStringMaster
      {
         get { return FusionOperationalDBSettings._ConnectionStringMaster; }
         set { FusionOperationalDBSettings._ConnectionStringMaster = value; }
      }

      public static string ConnectionStringMSDB
      {
         get { return FusionOperationalDBSettings._ConnectionStringMSDB; }
         set { FusionOperationalDBSettings._ConnectionStringMSDB = value; }
      }
   }
}
