using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HL.Services;

namespace DomainModelServiceHost
{
   public partial class DomainModelServicesHostForm : Form
   {
      public DomainModelServicesHostForm(DomainModelServices domainModelServices)
      {
         InitializeComponent();
         foreach (var serviceHost in domainModelServices.Services.Values)
         {
            int index = _ServicesDataGridView.Rows.Add();
            var dataGridRow = _ServicesDataGridView.Rows[index];
            dataGridRow.Cells[0].Value = serviceHost.Name;
            dataGridRow.Tag = serviceHost;

            UpdateRow(serviceHost, dataGridRow);

            serviceHost.CommunicationStateChanged += OnCommunicationStateChanged;
         }
      }

      private void OnCommunicationStateChanged(object sender, ServiceCommunicationStateChangedEventArgs e)
      {
         var serviceHost = sender as HLServiceHost;

         for (var index = 0; index < _ServicesDataGridView.Rows.Count; index++)
         {
            var dataGridRow = _ServicesDataGridView.Rows[index];
            if (dataGridRow.Tag.Equals(serviceHost))
            {
               UpdateRow(serviceHost, dataGridRow);
               break;
            }
         }
      }
      private static void UpdateRow(HLServiceHost serviceHost, DataGridViewRow dataGridRow)
      {
         dataGridRow.Cells[1].Value = serviceHost.State.ToString();
         dataGridRow.Cells[2].Value = serviceHost.FaultCount.ToString();
      }
   }
}
