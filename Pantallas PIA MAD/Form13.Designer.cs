namespace Pantallas_PIA_MAD
{
    partial class Form13
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
            this.Titulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Salir__MEAU = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Reportes__MEAU = new System.Windows.Forms.Button();
            this.Nomina__MEAU = new System.Windows.Forms.Button();
            this.Empresa_MEAU = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.Titulo);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(153, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 450);
            this.panel2.TabIndex = 2;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Lucida Sans", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Titulo.Location = new System.Drawing.Point(75, 192);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(484, 72);
            this.Titulo.TabIndex = 1;
            this.Titulo.Text = "BIENVENIDO/A";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(647, 52);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "AUXILIAR";
            // 
            // Salir__MEAU
            // 
            this.Salir__MEAU.BackColor = System.Drawing.Color.DarkCyan;
            this.Salir__MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Salir__MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir__MEAU.Location = new System.Drawing.Point(0, 403);
            this.Salir__MEAU.Name = "Salir__MEAU";
            this.Salir__MEAU.Size = new System.Drawing.Size(155, 47);
            this.Salir__MEAU.TabIndex = 8;
            this.Salir__MEAU.Text = "SALIR";
            this.Salir__MEAU.UseVisualStyleBackColor = false;
            this.Salir__MEAU.Click += new System.EventHandler(this.Salir__MEAU_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.Reportes__MEAU);
            this.panel1.Controls.Add(this.Nomina__MEAU);
            this.panel1.Controls.Add(this.Empresa_MEAU);
            this.panel1.Controls.Add(this.Salir__MEAU);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 450);
            this.panel1.TabIndex = 3;
            // 
            // Reportes__MEAU
            // 
            this.Reportes__MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reportes__MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reportes__MEAU.Location = new System.Drawing.Point(1, 255);
            this.Reportes__MEAU.Name = "Reportes__MEAU";
            this.Reportes__MEAU.Size = new System.Drawing.Size(155, 47);
            this.Reportes__MEAU.TabIndex = 11;
            this.Reportes__MEAU.Text = "Reportes";
            this.Reportes__MEAU.UseVisualStyleBackColor = true;
            this.Reportes__MEAU.Click += new System.EventHandler(this.Reportes__MEAU_Click);
            // 
            // Nomina__MEAU
            // 
            this.Nomina__MEAU.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Nomina__MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Nomina__MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nomina__MEAU.Location = new System.Drawing.Point(-2, 202);
            this.Nomina__MEAU.Name = "Nomina__MEAU";
            this.Nomina__MEAU.Size = new System.Drawing.Size(155, 47);
            this.Nomina__MEAU.TabIndex = 10;
            this.Nomina__MEAU.Text = "Gestión De Nómina";
            this.Nomina__MEAU.UseVisualStyleBackColor = false;
            this.Nomina__MEAU.Click += new System.EventHandler(this.Nomina__MEAU_Click);
            // 
            // Empresa_MEAU
            // 
            this.Empresa_MEAU.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Empresa_MEAU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Empresa_MEAU.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Empresa_MEAU.Location = new System.Drawing.Point(-2, 149);
            this.Empresa_MEAU.Name = "Empresa_MEAU";
            this.Empresa_MEAU.Size = new System.Drawing.Size(152, 47);
            this.Empresa_MEAU.TabIndex = 9;
            this.Empresa_MEAU.Text = "Gestion De Empleados";
            this.Empresa_MEAU.UseVisualStyleBackColor = false;
            this.Empresa_MEAU.Click += new System.EventHandler(this.Empresa_MEAU_Click);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form13";
            this.Text = "Menu Auxiliar";
            this.Load += new System.EventHandler(this.Form13_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Salir__MEAU;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Reportes__MEAU;
        private System.Windows.Forms.Button Nomina__MEAU;
        private System.Windows.Forms.Button Empresa_MEAU;
    }
}