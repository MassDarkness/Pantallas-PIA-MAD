namespace Pantallas_PIA_MAD
{
    partial class Form9
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTN_ExportarNomina = new System.Windows.Forms.Button();
            this.TB_Aguinaldo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.VistaNOMINA = new System.Windows.Forms.DataGridView();
            this.BTN_CalcularNomina = new System.Windows.Forms.Button();
            this.TB_CuotaSindical = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_CuotaIMSS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_BNAsistencia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_BNPuntualidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_DiasTrabajados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_AñoNomina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_MenuNomina = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Salir_MEAD = new System.Windows.Forms.Button();
            this.Reporte_MEAD = new System.Windows.Forms.Button();
            this.Nomina_MEAD = new System.Windows.Forms.Button();
            this.DepaPues__MEAD = new System.Windows.Forms.Button();
            this.Usuarios_MEAD = new System.Windows.Forms.Button();
            this.Empresa_MEAD = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VistaNOMINA)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.BTN_ExportarNomina);
            this.panel2.Controls.Add(this.TB_Aguinaldo);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.VistaNOMINA);
            this.panel2.Controls.Add(this.BTN_CalcularNomina);
            this.panel2.Controls.Add(this.TB_CuotaSindical);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.TB_CuotaIMSS);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.TB_BNAsistencia);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.TB_BNPuntualidad);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TB_DiasTrabajados);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CB_AñoNomina);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CB_MenuNomina);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(152, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 719);
            this.panel2.TabIndex = 2;
            // 
            // BTN_ExportarNomina
            // 
            this.BTN_ExportarNomina.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_ExportarNomina.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ExportarNomina.Location = new System.Drawing.Point(304, 650);
            this.BTN_ExportarNomina.Name = "BTN_ExportarNomina";
            this.BTN_ExportarNomina.Size = new System.Drawing.Size(183, 34);
            this.BTN_ExportarNomina.TabIndex = 53;
            this.BTN_ExportarNomina.Text = "Exportar CSV";
            this.BTN_ExportarNomina.UseVisualStyleBackColor = false;
            this.BTN_ExportarNomina.Click += new System.EventHandler(this.button9_Click);
            // 
            // TB_Aguinaldo
            // 
            this.TB_Aguinaldo.Location = new System.Drawing.Point(304, 191);
            this.TB_Aguinaldo.Name = "TB_Aguinaldo";
            this.TB_Aguinaldo.Size = new System.Drawing.Size(318, 20);
            this.TB_Aguinaldo.TabIndex = 52;
            this.TB_Aguinaldo.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(74, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 18);
            this.label10.TabIndex = 51;
            this.label10.Text = "Dias Trabajados:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // VistaNOMINA
            // 
            this.VistaNOMINA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VistaNOMINA.Location = new System.Drawing.Point(53, 402);
            this.VistaNOMINA.Name = "VistaNOMINA";
            this.VistaNOMINA.Size = new System.Drawing.Size(682, 231);
            this.VistaNOMINA.TabIndex = 50;
            this.VistaNOMINA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // BTN_CalcularNomina
            // 
            this.BTN_CalcularNomina.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_CalcularNomina.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CalcularNomina.Location = new System.Drawing.Point(304, 362);
            this.BTN_CalcularNomina.Name = "BTN_CalcularNomina";
            this.BTN_CalcularNomina.Size = new System.Drawing.Size(183, 34);
            this.BTN_CalcularNomina.TabIndex = 49;
            this.BTN_CalcularNomina.Text = "Calcular Nomina";
            this.BTN_CalcularNomina.UseVisualStyleBackColor = false;
            this.BTN_CalcularNomina.Click += new System.EventHandler(this.button5_Click);
            // 
            // TB_CuotaSindical
            // 
            this.TB_CuotaSindical.Location = new System.Drawing.Point(304, 323);
            this.TB_CuotaSindical.Name = "TB_CuotaSindical";
            this.TB_CuotaSindical.Size = new System.Drawing.Size(318, 20);
            this.TB_CuotaSindical.TabIndex = 48;
            this.TB_CuotaSindical.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(87, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 18);
            this.label9.TabIndex = 47;
            this.label9.Text = "Cuota Sindical:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // TB_CuotaIMSS
            // 
            this.TB_CuotaIMSS.Location = new System.Drawing.Point(304, 294);
            this.TB_CuotaIMSS.Name = "TB_CuotaIMSS";
            this.TB_CuotaIMSS.Size = new System.Drawing.Size(318, 20);
            this.TB_CuotaIMSS.TabIndex = 46;
            this.TB_CuotaIMSS.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(84, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Cuota Del IMSS:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // TB_BNAsistencia
            // 
            this.TB_BNAsistencia.Location = new System.Drawing.Point(304, 257);
            this.TB_BNAsistencia.Name = "TB_BNAsistencia";
            this.TB_BNAsistencia.Size = new System.Drawing.Size(318, 20);
            this.TB_BNAsistencia.TabIndex = 44;
            this.TB_BNAsistencia.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 18);
            this.label7.TabIndex = 43;
            this.label7.Text = "Bono De Asistencia:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // TB_BNPuntualidad
            // 
            this.TB_BNPuntualidad.Location = new System.Drawing.Point(304, 228);
            this.TB_BNPuntualidad.Name = "TB_BNPuntualidad";
            this.TB_BNPuntualidad.Size = new System.Drawing.Size(318, 20);
            this.TB_BNPuntualidad.TabIndex = 42;
            this.TB_BNPuntualidad.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "Bono Puntualidad:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // TB_DiasTrabajados
            // 
            this.TB_DiasTrabajados.Location = new System.Drawing.Point(304, 162);
            this.TB_DiasTrabajados.Name = "TB_DiasTrabajados";
            this.TB_DiasTrabajados.Size = new System.Drawing.Size(318, 20);
            this.TB_DiasTrabajados.TabIndex = 40;
            this.TB_DiasTrabajados.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Aguinaldo:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(174, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(467, 37);
            this.label3.TabIndex = 35;
            this.label3.Text = "Persupciones Y Deducciones:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // CB_AñoNomina
            // 
            this.CB_AñoNomina.FormattingEnabled = true;
            this.CB_AñoNomina.Location = new System.Drawing.Point(517, 79);
            this.CB_AñoNomina.Name = "CB_AñoNomina";
            this.CB_AñoNomina.Size = new System.Drawing.Size(124, 21);
            this.CB_AñoNomina.TabIndex = 33;
            this.CB_AñoNomina.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(444, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Año:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CB_MenuNomina
            // 
            this.CB_MenuNomina.FormattingEnabled = true;
            this.CB_MenuNomina.Location = new System.Drawing.Point(262, 75);
            this.CB_MenuNomina.Name = "CB_MenuNomina";
            this.CB_MenuNomina.Size = new System.Drawing.Size(124, 21);
            this.CB_MenuNomina.TabIndex = 31;
            this.CB_MenuNomina.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(178, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "Mes:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(822, 52);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(735, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.Salir_MEAD);
            this.panel1.Controls.Add(this.Reporte_MEAD);
            this.panel1.Controls.Add(this.Nomina_MEAD);
            this.panel1.Controls.Add(this.DepaPues__MEAD);
            this.panel1.Controls.Add(this.Usuarios_MEAD);
            this.panel1.Controls.Add(this.Empresa_MEAD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 719);
            this.panel1.TabIndex = 3;
            // 
            // Salir_MEAD
            // 
            this.Salir_MEAD.BackColor = System.Drawing.Color.DarkCyan;
            this.Salir_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Salir_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir_MEAD.Location = new System.Drawing.Point(0, 672);
            this.Salir_MEAD.Name = "Salir_MEAD";
            this.Salir_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Salir_MEAD.TabIndex = 8;
            this.Salir_MEAD.Text = "SALIR";
            this.Salir_MEAD.UseVisualStyleBackColor = false;
            // 
            // Reporte_MEAD
            // 
            this.Reporte_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reporte_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reporte_MEAD.Location = new System.Drawing.Point(0, 298);
            this.Reporte_MEAD.Name = "Reporte_MEAD";
            this.Reporte_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Reporte_MEAD.TabIndex = 7;
            this.Reporte_MEAD.Text = "Reportes";
            this.Reporte_MEAD.UseVisualStyleBackColor = true;
            // 
            // Nomina_MEAD
            // 
            this.Nomina_MEAD.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Nomina_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Nomina_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nomina_MEAD.Location = new System.Drawing.Point(0, 245);
            this.Nomina_MEAD.Name = "Nomina_MEAD";
            this.Nomina_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Nomina_MEAD.TabIndex = 4;
            this.Nomina_MEAD.Text = "Gestión De Nómina";
            this.Nomina_MEAD.UseVisualStyleBackColor = false;
            // 
            // DepaPues__MEAD
            // 
            this.DepaPues__MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DepaPues__MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepaPues__MEAD.Location = new System.Drawing.Point(0, 165);
            this.DepaPues__MEAD.Name = "DepaPues__MEAD";
            this.DepaPues__MEAD.Size = new System.Drawing.Size(155, 73);
            this.DepaPues__MEAD.TabIndex = 2;
            this.DepaPues__MEAD.Text = "Gestión De Departamentos Y Puestos";
            this.DepaPues__MEAD.UseVisualStyleBackColor = true;
            // 
            // Usuarios_MEAD
            // 
            this.Usuarios_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Usuarios_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuarios_MEAD.Location = new System.Drawing.Point(0, 112);
            this.Usuarios_MEAD.Name = "Usuarios_MEAD";
            this.Usuarios_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Usuarios_MEAD.TabIndex = 1;
            this.Usuarios_MEAD.Text = "Gestión De Usuarios";
            this.Usuarios_MEAD.UseVisualStyleBackColor = true;
            // 
            // Empresa_MEAD
            // 
            this.Empresa_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Empresa_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Empresa_MEAD.Location = new System.Drawing.Point(0, 58);
            this.Empresa_MEAD.Name = "Empresa_MEAD";
            this.Empresa_MEAD.Size = new System.Drawing.Size(152, 47);
            this.Empresa_MEAD.TabIndex = 0;
            this.Empresa_MEAD.Text = "Gestion De Empresa";
            this.Empresa_MEAD.UseVisualStyleBackColor = true;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 719);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form9";
            this.Text = "Gestión De Nomina";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VistaNOMINA)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Salir_MEAD;
        private System.Windows.Forms.Button Reporte_MEAD;
        private System.Windows.Forms.Button Nomina_MEAD;
        private System.Windows.Forms.Button DepaPues__MEAD;
        private System.Windows.Forms.Button Usuarios_MEAD;
        private System.Windows.Forms.Button Empresa_MEAD;
        private System.Windows.Forms.ComboBox CB_AñoNomina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_MenuNomina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_BNPuntualidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_DiasTrabajados;
        private System.Windows.Forms.TextBox TB_CuotaSindical;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_CuotaIMSS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_BNAsistencia;
        private System.Windows.Forms.DataGridView VistaNOMINA;
        private System.Windows.Forms.Button BTN_CalcularNomina;
        private System.Windows.Forms.TextBox TB_Aguinaldo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BTN_ExportarNomina;
    }
}