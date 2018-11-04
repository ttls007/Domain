using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Reflection;

using Database;

namespace HL.DomainModel.DataMapping
{
   public class OperationalDataContext : System.Data.Linq.DataContext
   {
      public static string ConnectionString = FusionOperationalDBSettings.ConnectionStringFusionOperational;

      public OperationalDataContext()
         : base(ConnectionString, DataMapping.GetMapping())
      {
      }

      public Table<Machine> Machines
      {
         get { return this.GetTable<Machine>(); }
      }
   }

   #region Helper class for mapping
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
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("HL.DomainModel.DataMapping.OperationalMap.xml"))
            {
               _Mapping = XmlMappingSource.FromStream(stream);
            }
         }

         return _Mapping;
      }
   }
   #endregion
}
