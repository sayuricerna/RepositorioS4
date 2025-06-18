namespace AdventureWorks
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.adventureWorks2017DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adventureWorks2017DataSet = new AdventureWorks.AdventureWorks2017DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.adventureWorks2017DataSet2 = new AdventureWorks.AdventureWorks2017DataSet2();
            this.adventureWorks2017DataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.businessEntityAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.businessEntityAddressTableAdapter = new AdventureWorks.AdventureWorks2017DataSet2TableAdapters.BusinessEntityAddressTableAdapter();
            this.emailAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailAddressTableAdapter = new AdventureWorks.AdventureWorks2017DataSetTableAdapters.EmailAddressTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessEntityAddressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAddressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // adventureWorks2017DataSetBindingSource
            // 
            this.adventureWorks2017DataSetBindingSource.DataSource = this.adventureWorks2017DataSet;
            this.adventureWorks2017DataSetBindingSource.Position = 0;
            // 
            // adventureWorks2017DataSet
            // 
            this.adventureWorks2017DataSet.DataSetName = "AdventureWorks2017DataSet";
            this.adventureWorks2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.emailAddressBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.businessEntityAddressBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AdventureWorks.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 81);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(914, 427);
            this.reportViewer1.TabIndex = 0;
            // 
            // adventureWorks2017DataSet2
            // 
            this.adventureWorks2017DataSet2.DataSetName = "AdventureWorks2017DataSet2";
            this.adventureWorks2017DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adventureWorks2017DataSet2BindingSource
            // 
            this.adventureWorks2017DataSet2BindingSource.DataSource = this.adventureWorks2017DataSet2;
            this.adventureWorks2017DataSet2BindingSource.Position = 0;
            // 
            // businessEntityAddressBindingSource
            // 
            this.businessEntityAddressBindingSource.DataMember = "BusinessEntityAddress";
            this.businessEntityAddressBindingSource.DataSource = this.adventureWorks2017DataSet2BindingSource;
            // 
            // businessEntityAddressTableAdapter
            // 
            this.businessEntityAddressTableAdapter.ClearBeforeFill = true;
            // 
            // emailAddressBindingSource
            // 
            this.emailAddressBindingSource.DataMember = "EmailAddress";
            this.emailAddressBindingSource.DataSource = this.adventureWorks2017DataSetBindingSource;
            // 
            // emailAddressTableAdapter
            // 
            this.emailAddressTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 520);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessEntityAddressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailAddressBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource adventureWorks2017DataSetBindingSource;
        private AdventureWorks2017DataSet adventureWorks2017DataSet;
        private AdventureWorks2017DataSet2 adventureWorks2017DataSet2;
        private System.Windows.Forms.BindingSource adventureWorks2017DataSet2BindingSource;
        private System.Windows.Forms.BindingSource businessEntityAddressBindingSource;
        private AdventureWorks2017DataSet2TableAdapters.BusinessEntityAddressTableAdapter businessEntityAddressTableAdapter;
        private System.Windows.Forms.BindingSource emailAddressBindingSource;
        private AdventureWorks2017DataSetTableAdapters.EmailAddressTableAdapter emailAddressTableAdapter;
    }
}

