namespace Pantallas_PIA_MAD
{
    partial class Form5
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTN_EditarEMP = new System.Windows.Forms.Button();
            this.Vista_Empresa = new System.Windows.Forms.DataGridView();
            this.TB_Contacto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_DomicilioFi = new System.Windows.Forms.TextBox();
            this.BTN_CancelarEMP = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.BTN_GuardarEMP = new System.Windows.Forms.Button();
            this.FechaInicio_Empresa = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_RegistroPa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_RazonSocial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_RFC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DepaPues__MEAD = new System.Windows.Forms.Button();
            this.Salir_MEAD = new System.Windows.Forms.Button();
            this.Reporte_MEAD = new System.Windows.Forms.Button();
            this.Nomina_MEAD = new System.Windows.Forms.Button();
            this.Usuarios_MEAD = new System.Windows.Forms.Button();
            this.Empresa_MEAD = new System.Windows.Forms.Button();
            this.proyectoMADDataSet = new Pantallas_PIA_MAD.ProyectoMADDataSet();
            this.empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresaTableAdapter = new Pantallas_PIA_MAD.ProyectoMADDataSetTableAdapters.EmpresaTableAdapter();
            this.Empleados_MEAD = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_Empresa)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoMADDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.BTN_EditarEMP);
            this.panel2.Controls.Add(this.Vista_Empresa);
            this.panel2.Controls.Add(this.TB_Contacto);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.TB_DomicilioFi);
            this.panel2.Controls.Add(this.BTN_CancelarEMP);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.BTN_GuardarEMP);
            this.panel2.Controls.Add(this.FechaInicio_Empresa);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.TB_RegistroPa);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.TB_RazonSocial);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TB_RFC);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TB_Nombre);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(154, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 486);
            this.panel2.TabIndex = 2;
            // 
            // BTN_EditarEMP
            // 
            this.BTN_EditarEMP.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_EditarEMP.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_EditarEMP.Location = new System.Drawing.Point(630, 353);
            this.BTN_EditarEMP.Name = "BTN_EditarEMP";
            this.BTN_EditarEMP.Size = new System.Drawing.Size(121, 34);
            this.BTN_EditarEMP.TabIndex = 19;
            this.BTN_EditarEMP.Text = "Editar";
            this.BTN_EditarEMP.UseVisualStyleBackColor = false;
            this.BTN_EditarEMP.Click += new System.EventHandler(this.BTN_EditarEMP_Click);
            // 
            // Vista_Empresa
            // 
            this.Vista_Empresa.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Vista_Empresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vista_Empresa.Location = new System.Drawing.Point(575, 111);
            this.Vista_Empresa.Name = "Vista_Empresa";
            this.Vista_Empresa.RowHeadersWidth = 51;
            this.Vista_Empresa.Size = new System.Drawing.Size(233, 236);
            this.Vista_Empresa.TabIndex = 18;
            this.Vista_Empresa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_Empresa_CellContentClick);
            this.Vista_Empresa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Vista_Empresa_CellContentClick);
            // 
            // TB_Contacto
            // 
            this.TB_Contacto.Location = new System.Drawing.Point(233, 327);
            this.TB_Contacto.Name = "TB_Contacto";
            this.TB_Contacto.Size = new System.Drawing.Size(311, 20);
            this.TB_Contacto.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(157, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "RFC:";
            // 
            // TB_DomicilioFi
            // 
            this.TB_DomicilioFi.Location = new System.Drawing.Point(233, 285);
            this.TB_DomicilioFi.Name = "TB_DomicilioFi";
            this.TB_DomicilioFi.Size = new System.Drawing.Size(311, 20);
            this.TB_DomicilioFi.TabIndex = 15;
            // 
            // BTN_CancelarEMP
            // 
            this.BTN_CancelarEMP.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_CancelarEMP.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CancelarEMP.Location = new System.Drawing.Point(361, 404);
            this.BTN_CancelarEMP.Name = "BTN_CancelarEMP";
            this.BTN_CancelarEMP.Size = new System.Drawing.Size(121, 34);
            this.BTN_CancelarEMP.TabIndex = 14;
            this.BTN_CancelarEMP.Text = "Cancelar";
            this.BTN_CancelarEMP.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(113, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "Nombre:";
            // 
            // BTN_GuardarEMP
            // 
            this.BTN_GuardarEMP.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_GuardarEMP.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_GuardarEMP.Location = new System.Drawing.Point(105, 404);
            this.BTN_GuardarEMP.Name = "BTN_GuardarEMP";
            this.BTN_GuardarEMP.Size = new System.Drawing.Size(121, 34);
            this.BTN_GuardarEMP.TabIndex = 12;
            this.BTN_GuardarEMP.Text = "Guardar";
            this.BTN_GuardarEMP.UseVisualStyleBackColor = false;
            this.BTN_GuardarEMP.Click += new System.EventHandler(this.BTN_GuardarEMP_Click);
            // 
            // FechaInicio_Empresa
            // 
            this.FechaInicio_Empresa.Location = new System.Drawing.Point(233, 365);
            this.FechaInicio_Empresa.Name = "FechaInicio_Empresa";
            this.FechaInicio_Empresa.Size = new System.Drawing.Size(311, 20);
            this.FechaInicio_Empresa.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha De Inicio:";
            // 
            // TB_RegistroPa
            // 
            this.TB_RegistroPa.Location = new System.Drawing.Point(233, 245);
            this.TB_RegistroPa.Name = "TB_RegistroPa";
            this.TB_RegistroPa.Size = new System.Drawing.Size(311, 20);
            this.TB_RegistroPa.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(101, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Contacto:";
            // 
            // TB_RazonSocial
            // 
            this.TB_RazonSocial.Location = new System.Drawing.Point(233, 206);
            this.TB_RazonSocial.Name = "TB_RazonSocial";
            this.TB_RazonSocial.Size = new System.Drawing.Size(311, 20);
            this.TB_RazonSocial.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Domicilio Fiscal:";
            // 
            // TB_RFC
            // 
            this.TB_RFC.Location = new System.Drawing.Point(233, 168);
            this.TB_RFC.Name = "TB_RFC";
            this.TB_RFC.Size = new System.Drawing.Size(311, 20);
            this.TB_RFC.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Registro Patronal:";
            // 
            // TB_Nombre
            // 
            this.TB_Nombre.Location = new System.Drawing.Point(233, 138);
            this.TB_Nombre.Name = "TB_Nombre";
            this.TB_Nombre.Size = new System.Drawing.Size(311, 20);
            this.TB_Nombre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Razón Social:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datos De La Empresa";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(820, 52);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(717, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.Empleados_MEAD);
            this.panel1.Controls.Add(this.DepaPues__MEAD);
            this.panel1.Controls.Add(this.Salir_MEAD);
            this.panel1.Controls.Add(this.Reporte_MEAD);
            this.panel1.Controls.Add(this.Nomina_MEAD);
            this.panel1.Controls.Add(this.Usuarios_MEAD);
            this.panel1.Controls.Add(this.Empresa_MEAD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 486);
            this.panel1.TabIndex = 3;
            // 
            // DepaPues__MEAD
            // 
            this.DepaPues__MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DepaPues__MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepaPues__MEAD.Location = new System.Drawing.Point(0, 220);
            this.DepaPues__MEAD.Name = "DepaPues__MEAD";
            this.DepaPues__MEAD.Size = new System.Drawing.Size(155, 73);
            this.DepaPues__MEAD.TabIndex = 9;
            this.DepaPues__MEAD.Text = "Gestión De Departamentos Y Puestos";
            this.DepaPues__MEAD.UseVisualStyleBackColor = true;
            this.DepaPues__MEAD.Click += new System.EventHandler(this.DepaPues__MEAD_Click);
            // 
            // Salir_MEAD
            // 
            this.Salir_MEAD.BackColor = System.Drawing.Color.DarkCyan;
            this.Salir_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Salir_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir_MEAD.Location = new System.Drawing.Point(0, 439);
            this.Salir_MEAD.Name = "Salir_MEAD";
            this.Salir_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Salir_MEAD.TabIndex = 8;
            this.Salir_MEAD.Text = "SALIR";
            this.Salir_MEAD.UseVisualStyleBackColor = false;
            this.Salir_MEAD.Click += new System.EventHandler(this.Salir_MEAD_Click);
            // 
            // Reporte_MEAD
            // 
            this.Reporte_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reporte_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reporte_MEAD.Location = new System.Drawing.Point(0, 352);
            this.Reporte_MEAD.Name = "Reporte_MEAD";
            this.Reporte_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Reporte_MEAD.TabIndex = 7;
            this.Reporte_MEAD.Text = "Reportes";
            this.Reporte_MEAD.UseVisualStyleBackColor = true;
            this.Reporte_MEAD.Click += new System.EventHandler(this.Reporte_MEAD_Click);
            // 
            // Nomina_MEAD
            // 
            this.Nomina_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Nomina_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nomina_MEAD.Location = new System.Drawing.Point(3, 299);
            this.Nomina_MEAD.Name = "Nomina_MEAD";
            this.Nomina_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Nomina_MEAD.TabIndex = 4;
            this.Nomina_MEAD.Text = "Gestión De Nómina";
            this.Nomina_MEAD.UseVisualStyleBackColor = true;
            this.Nomina_MEAD.Click += new System.EventHandler(this.Nomina_MEAD_Click);
            // 
            // Usuarios_MEAD
            // 
            this.Usuarios_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Usuarios_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuarios_MEAD.Location = new System.Drawing.Point(0, 111);
            this.Usuarios_MEAD.Name = "Usuarios_MEAD";
            this.Usuarios_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Usuarios_MEAD.TabIndex = 1;
            this.Usuarios_MEAD.Text = "Gestión De Usuarios";
            this.Usuarios_MEAD.UseVisualStyleBackColor = true;
            this.Usuarios_MEAD.Click += new System.EventHandler(this.Usuarios_MEAD_Click);
            // 
            // Empresa_MEAD
            // 
            this.Empresa_MEAD.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Empresa_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Empresa_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Empresa_MEAD.Location = new System.Drawing.Point(0, 58);
            this.Empresa_MEAD.Name = "Empresa_MEAD";
            this.Empresa_MEAD.Size = new System.Drawing.Size(155, 47);
            this.Empresa_MEAD.TabIndex = 0;
            this.Empresa_MEAD.Text = "Gestion De Empresa";
            this.Empresa_MEAD.UseVisualStyleBackColor = false;
            // 
            // proyectoMADDataSet
            // 
            this.proyectoMADDataSet.DataSetName = "ProyectoMADDataSet";
            this.proyectoMADDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empresaBindingSource
            // 
            this.empresaBindingSource.DataMember = "Empresa";
            this.empresaBindingSource.DataSource = this.proyectoMADDataSet;
            // 
            // empresaTableAdapter
            // 
            this.empresaTableAdapter.ClearBeforeFill = true;
            // 
            // Empleados_MEAD
            // 
            this.Empleados_MEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Empleados_MEAD.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.Empleados_MEAD.Location = new System.Drawing.Point(0, 164);
            this.Empleados_MEAD.Name = "Empleados_MEAD";
            this.Empleados_MEAD.Size = new System.Drawing.Size(155, 50);
            this.Empleados_MEAD.TabIndex = 10;
            this.Empleados_MEAD.Text = "Gestión De Empleados";
            this.Empleados_MEAD.UseVisualStyleBackColor = true;
            this.Empleados_MEAD.Click += new System.EventHandler(this.Empleados_MEAD_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form5";
            this.Text = "Gestión De Empresa";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_Empresa)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proyectoMADDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Nomina_MEAD;
        private System.Windows.Forms.Button Usuarios_MEAD;
        private System.Windows.Forms.Button Empresa_MEAD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_RegistroPa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_RazonSocial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_RFC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_Nombre;
        private System.Windows.Forms.Button BTN_GuardarEMP;
        private System.Windows.Forms.DateTimePicker FechaInicio_Empresa;
        private System.Windows.Forms.TextBox TB_DomicilioFi;
        private System.Windows.Forms.Button BTN_CancelarEMP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Contacto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BTN_EditarEMP;
        private System.Windows.Forms.Button Reporte_MEAD;
        private System.Windows.Forms.Button Salir_MEAD;
        private System.Windows.Forms.Button DepaPues__MEAD;
        private System.Windows.Forms.DataGridView Vista_Empresa;
        private ProyectoMADDataSet proyectoMADDataSet;
        private System.Windows.Forms.BindingSource empresaBindingSource;
        private ProyectoMADDataSetTableAdapters.EmpresaTableAdapter empresaTableAdapter;
        private System.Windows.Forms.Button Empleados_MEAD;
    }
}