namespace DomainModelServiceHost
{
   partial class DomainModelServicesHostForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._ServicesDataGridView = new System.Windows.Forms.DataGridView();
         this._ServiceNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._ServiceStateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._FaultCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this._ServicesDataGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // _ServicesDataGridView
         // 
         this._ServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this._ServicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ServiceNameColumn,
            this._ServiceStateColumn,
            this._FaultCountColumn});
         this._ServicesDataGridView.Location = new System.Drawing.Point(12, 12);
         this._ServicesDataGridView.Name = "_ServicesDataGridView";
         this._ServicesDataGridView.RowTemplate.Height = 23;
         this._ServicesDataGridView.Size = new System.Drawing.Size(475, 312);
         this._ServicesDataGridView.TabIndex = 0;
         // 
         // _ServiceNameColumn
         // 
         this._ServiceNameColumn.HeaderText = "Service Name";
         this._ServiceNameColumn.Name = "_ServiceNameColumn";
         this._ServiceNameColumn.Width = 150;
         // 
         // _ServiceStateColumn
         // 
         this._ServiceStateColumn.HeaderText = "State";
         this._ServiceStateColumn.Name = "_ServiceStateColumn";
         // 
         // _FaultCountColumn
         // 
         this._FaultCountColumn.HeaderText = "FaultCount";
         this._FaultCountColumn.Name = "_FaultCountColumn";
         this._FaultCountColumn.Width = 150;
         // 
         // DomainModelServicesHostForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(499, 336);
         this.Controls.Add(this._ServicesDataGridView);
         this.Name = "DomainModelServicesHostForm";
         this.Text = "Domain Model Service Host";
         ((System.ComponentModel.ISupportInitialize)(this._ServicesDataGridView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView _ServicesDataGridView;
      private System.Windows.Forms.DataGridViewTextBoxColumn _ServiceNameColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn _ServiceStateColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn _FaultCountColumn;
   }
}

