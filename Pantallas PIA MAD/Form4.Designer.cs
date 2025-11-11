namespace Pantallas_PIA_MAD
{
    partial class Form4
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
            System.Windows.Forms.Button Empresa_MEAU;
            this.panel1 = new System.Windows.Forms.Panel();
            this.Salir_MEAU = new System.Windows.Forms.Button();
            this.Reportes__MEAU = new System.Windows.Forms.Button();
            this.Nomina__MEAU = new System.Windows.Forms.Button();
            this.BTN_ExportarPDFAUX = new System.Windows.Forms.Button();
            this.Vista_ReporteAUX = new System.Windows.Forms.DataGridView();
            this.BTN_CalcularReporteAUX = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_AñoReportesAUX = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_MesReportesAUX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_TipoReporteAUX = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_DepartamentoReporteAUX = new System.Windows.Forms.ComboBox();
            Empresa_MEAU = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ReporteAUX)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Empresa_MEAU
            // 
            Empresa_MEAU.BackColor = System.Drawing.Color.DarkSlateGray;
            Empresa_MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Empresa_MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Empresa_MEAU.Location = new System.Drawing.Point(-3, 232);
            Empresa_MEAU.Name = "Empresa_MEAU";
            Empresa_MEAU.Size = new System.Drawing.Size(152, 47);
            Empresa_MEAU.TabIndex = 0;
            Empresa_MEAU.Text = "Gestion De Empleados";
            Empresa_MEAU.UseVisualStyleBackColor = false;
            Empresa_MEAU.Click += new System.EventHandler(this.Empresa_MEAU_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.Salir_MEAU);
            this.panel1.Controls.Add(this.Reportes__MEAU);
            this.panel1.Controls.Add(this.Nomina__MEAU);
            this.panel1.Controls.Add(Empresa_MEAU);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 712);
            this.panel1.TabIndex = 5;
            // 
            // Salir_MEAU
            // 
            this.Salir_MEAU.BackColor = System.Drawing.Color.DarkCyan;
            this.Salir_MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Salir_MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir_MEAU.Location = new System.Drawing.Point(-3, 672);
            this.Salir_MEAU.Name = "Salir_MEAU";
            this.Salir_MEAU.Size = new System.Drawing.Size(155, 47);
            this.Salir_MEAU.TabIndex = 7;
            this.Salir_MEAU.Text = "SALIR";
            this.Salir_MEAU.UseVisualStyleBackColor = false;
            this.Salir_MEAU.Click += new System.EventHandler(this.Salir_MEAU_Click);
            // 
            // Reportes__MEAU
            // 
            this.Reportes__MEAU.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Reportes__MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reportes__MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reportes__MEAU.Location = new System.Drawing.Point(-3, 338);
            this.Reportes__MEAU.Name = "Reportes__MEAU";
            this.Reportes__MEAU.Size = new System.Drawing.Size(155, 47);
            this.Reportes__MEAU.TabIndex = 6;
            this.Reportes__MEAU.Text = "Reportes";
            this.Reportes__MEAU.UseVisualStyleBackColor = false;
            // 
            // Nomina__MEAU
            // 
            this.Nomina__MEAU.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Nomina__MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Nomina__MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nomina__MEAU.Location = new System.Drawing.Point(0, 285);
            this.Nomina__MEAU.Name = "Nomina__MEAU";
            this.Nomina__MEAU.Size = new System.Drawing.Size(155, 47);
            this.Nomina__MEAU.TabIndex = 4;
            this.Nomina__MEAU.Text = "Gestión De Nómina";
            this.Nomina__MEAU.UseVisualStyleBackColor = false;
            this.Nomina__MEAU.Click += new System.EventHandler(this.Nomina__MEAU_Click);
            // 
            // BTN_ExportarPDFAUX
            // 
            this.BTN_ExportarPDFAUX.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_ExportarPDFAUX.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ExportarPDFAUX.Location = new System.Drawing.Point(270, 638);
            this.BTN_ExportarPDFAUX.Name = "BTN_ExportarPDFAUX";
            this.BTN_ExportarPDFAUX.Size = new System.Drawing.Size(183, 34);
            this.BTN_ExportarPDFAUX.TabIndex = 62;
            this.BTN_ExportarPDFAUX.Text = "Exportar PDF";
            this.BTN_ExportarPDFAUX.UseVisualStyleBackColor = false;
            this.BTN_ExportarPDFAUX.Click += new System.EventHandler(this.BTN_ExportarPDFAUX_Click);
            // 
            // Vista_ReporteAUX
            // 
            this.Vista_ReporteAUX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_ReporteAUX.Location = new System.Drawing.Point(33, 217);
            this.Vista_ReporteAUX.Name = "Vista_ReporteAUX";
            this.Vista_ReporteAUX.Size = new System.Drawing.Size(729, 387);
            this.Vista_ReporteAUX.TabIndex = 61;
            // 
            // BTN_CalcularReporteAUX
            // 
            this.BTN_CalcularReporteAUX.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_CalcularReporteAUX.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CalcularReporteAUX.Location = new System.Drawing.Point(270, 177);
            this.BTN_CalcularReporteAUX.Name = "BTN_CalcularReporteAUX";
            this.BTN_CalcularReporteAUX.Size = new System.Drawing.Size(183, 34);
            this.BTN_CalcularReporteAUX.TabIndex = 60;
            this.BTN_CalcularReporteAUX.Text = "Calcular Reporte";
            this.BTN_CalcularReporteAUX.UseVisualStyleBackColor = false;
            this.BTN_CalcularReporteAUX.Click += new System.EventHandler(this.BTN_CalcularReporteAUX_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(421, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 22);
            this.label4.TabIndex = 58;
            this.label4.Text = "Departamento:";
            // 
            // CB_AñoReportesAUX
            // 
            this.CB_AñoReportesAUX.FormattingEnabled = true;
            this.CB_AñoReportesAUX.Location = new System.Drawing.Point(151, 135);
            this.CB_AñoReportesAUX.Name = "CB_AñoReportesAUX";
            this.CB_AñoReportesAUX.Size = new System.Drawing.Size(148, 21);
            this.CB_AñoReportesAUX.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 22);
            this.label3.TabIndex = 56;
            this.label3.Text = "Año:";
            // 
            // CB_MesReportesAUX
            // 
            this.CB_MesReportesAUX.FormattingEnabled = true;
            this.CB_MesReportesAUX.Location = new System.Drawing.Point(385, 135);
            this.CB_MesReportesAUX.Name = "CB_MesReportesAUX";
            this.CB_MesReportesAUX.Size = new System.Drawing.Size(173, 21);
            this.CB_MesReportesAUX.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 22);
            this.label2.TabIndex = 54;
            this.label2.Text = "Mes:";
            // 
            // CB_TipoReporteAUX
            // 
            this.CB_TipoReporteAUX.FormattingEnabled = true;
            this.CB_TipoReporteAUX.Location = new System.Drawing.Point(169, 84);
            this.CB_TipoReporteAUX.Name = "CB_TipoReporteAUX";
            this.CB_TipoReporteAUX.Size = new System.Drawing.Size(210, 21);
            this.CB_TipoReporteAUX.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 22);
            this.label10.TabIndex = 52;
            this.label10.Text = "Tipo De Reporte:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.CB_DepartamentoReporteAUX);
            this.panel2.Controls.Add(this.BTN_ExportarPDFAUX);
            this.panel2.Controls.Add(this.Vista_ReporteAUX);
            this.panel2.Controls.Add(this.BTN_CalcularReporteAUX);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CB_AñoReportesAUX);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CB_MesReportesAUX);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CB_TipoReporteAUX);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(149, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 712);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(825, 52);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(717, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "AUXILIAR";
            // 
            // CB_DepartamentoReporteAUX
            // 
            this.CB_DepartamentoReporteAUX.FormattingEnabled = true;
            this.CB_DepartamentoReporteAUX.Location = new System.Drawing.Point(575, 84);
            this.CB_DepartamentoReporteAUX.Name = "CB_DepartamentoReporteAUX";
            this.CB_DepartamentoReporteAUX.Size = new System.Drawing.Size(187, 21);
            this.CB_DepartamentoReporteAUX.TabIndex = 64;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 712);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form4";
            this.Text = "Reportes AUX";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_ReporteAUX)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Salir_MEAU;
        private System.Windows.Forms.Button Nomina__MEAU;
        private System.Windows.Forms.Button BTN_ExportarPDFAUX;
        private System.Windows.Forms.DataGridView Vista_ReporteAUX;
        private System.Windows.Forms.Button BTN_CalcularReporteAUX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_AñoReportesAUX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_MesReportesAUX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_TipoReporteAUX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Reportes__MEAU;
        private System.Windows.Forms.ComboBox CB_DepartamentoReporteAUX;
    }
}