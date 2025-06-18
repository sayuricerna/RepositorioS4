namespace EvParcial2.Vistas.Ventas
{
    partial class VentasForm
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
            this.lblFrm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btbCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLibro = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFrm
            // 
            this.lblFrm.AutoSize = true;
            this.lblFrm.Location = new System.Drawing.Point(310, 72);
            this.lblFrm.Name = "lblFrm";
            this.lblFrm.Size = new System.Drawing.Size(55, 16);
            this.lblFrm.TabIndex = 40;
            this.lblFrm.Text = "TITULO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "LIBRO";
            // 
            // btbCancelar
            // 
            this.btbCancelar.Location = new System.Drawing.Point(535, 254);
            this.btbCancelar.Name = "btbCancelar";
            this.btbCancelar.Size = new System.Drawing.Size(116, 125);
            this.btbCancelar.TabIndex = 36;
            this.btbCancelar.Text = "CANCELAR";
            this.btbCancelar.UseVisualStyleBackColor = true;
            this.btbCancelar.Click += new System.EventHandler(this.btbCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(535, 128);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 120);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(244, 177);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(265, 22);
            this.txtCantidad.TabIndex = 31;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "CANTIDAD";
            // 
            // cboLibro
            // 
            this.cboLibro.FormattingEnabled = true;
            this.cboLibro.Items.AddRange(new object[] {
            "Pendiente",
            "Pagada",
            "Cancelar"});
            this.cboLibro.Location = new System.Drawing.Point(245, 231);
            this.cboLibro.Name = "cboLibro";
            this.cboLibro.Size = new System.Drawing.Size(264, 24);
            this.cboLibro.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(244, 357);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(265, 22);
            this.txtTotal.TabIndex = 42;
            // 
            // VentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.cboLibro);
            this.Controls.Add(this.lblFrm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btbCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label1);
            this.Name = "VentasForm";
            this.Text = "VentasForm";
            this.Load += new System.EventHandler(this.VentasForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btbCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLibro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
    }
}