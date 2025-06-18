namespace EvParcial2.Vistas
{
    partial class Reporte
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.evParcial2DataSet = new EvParcial2.EvParcial2DataSet();
            this.spReporteLibrosVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteLibrosVendidosTableAdapter = new EvParcial2.EvParcial2DataSetTableAdapters.sp_ReporteLibrosVendidosTableAdapter();
            this.vwVentasConNombreLibroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.evParcial2DataSet2 = new EvParcial2.EvParcial2DataSet2();
            this.vw_VentasConNombreLibroTableAdapter = new EvParcial2.EvParcial2DataSet2TableAdapters.vw_VentasConNombreLibroTableAdapter();
            this.vwVentasConNombreLibroBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.evParcial2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteLibrosVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwVentasConNombreLibroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evParcial2DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwVentasConNombreLibroBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vwVentasConNombreLibroBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EvParcial2.Vistas.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 37);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1139, 549);
            this.reportViewer1.TabIndex = 0;
            // 
            // evParcial2DataSet
            // 
            this.evParcial2DataSet.DataSetName = "EvParcial2DataSet";
            this.evParcial2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spReporteLibrosVendidosBindingSource
            // 
            this.spReporteLibrosVendidosBindingSource.DataMember = "sp_ReporteLibrosVendidos";
            this.spReporteLibrosVendidosBindingSource.DataSource = this.evParcial2DataSet;
            // 
            // sp_ReporteLibrosVendidosTableAdapter
            // 
            this.sp_ReporteLibrosVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // vwVentasConNombreLibroBindingSource
            // 
            this.vwVentasConNombreLibroBindingSource.DataMember = "vw_VentasConNombreLibro";
            this.vwVentasConNombreLibroBindingSource.DataSource = this.evParcial2DataSet2;
            // 
            // evParcial2DataSet2
            // 
            this.evParcial2DataSet2.DataSetName = "EvParcial2DataSet2";
            this.evParcial2DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vw_VentasConNombreLibroTableAdapter
            // 
            this.vw_VentasConNombreLibroTableAdapter.ClearBeforeFill = true;
            // 
            // vwVentasConNombreLibroBindingSource1
            // 
            this.vwVentasConNombreLibroBindingSource1.DataMember = "vw_VentasConNombreLibro";
            this.vwVentasConNombreLibroBindingSource1.DataSource = this.evParcial2DataSet2;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 598);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.evParcial2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteLibrosVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwVentasConNombreLibroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evParcial2DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwVentasConNombreLibroBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spReporteLibrosVendidosBindingSource;
        private EvParcial2DataSet evParcial2DataSet;
        private EvParcial2DataSetTableAdapters.sp_ReporteLibrosVendidosTableAdapter sp_ReporteLibrosVendidosTableAdapter;
        private EvParcial2DataSet2 evParcial2DataSet2;
        private System.Windows.Forms.BindingSource vwVentasConNombreLibroBindingSource;
        private EvParcial2DataSet2TableAdapters.vw_VentasConNombreLibroTableAdapter vw_VentasConNombreLibroTableAdapter;
        private System.Windows.Forms.BindingSource vwVentasConNombreLibroBindingSource1;
    }
}