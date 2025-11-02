namespace Pantallas_PIA_MAD
{
    partial class Form2
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
            this.Titulo = new System.Windows.Forms.Label();
            this.Correo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IS_Correo = new System.Windows.Forms.TextBox();
            this.IS_Contraseña = new System.Windows.Forms.TextBox();
            this.BTN_IS = new System.Windows.Forms.Button();
            this.BTN_SALIRIS = new System.Windows.Forms.Button();
            this.RB_ADMIN = new System.Windows.Forms.RadioButton();
            this.RB_AUXILIAR = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Titulo.Location = new System.Drawing.Point(16, 11);
            this.Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(381, 46);
            this.Titulo.TabIndex = 1;
            this.Titulo.Text = "González Solutions";
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correo.Location = new System.Drawing.Point(88, 162);
            this.Correo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(260, 32);
            this.Correo.TabIndex = 2;
            this.Correo.Text = "Correo Electronico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // IS_Correo
            // 
            this.IS_Correo.Location = new System.Drawing.Point(400, 167);
            this.IS_Correo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IS_Correo.Name = "IS_Correo";
            this.IS_Correo.Size = new System.Drawing.Size(468, 22);
            this.IS_Correo.TabIndex = 4;
            // 
            // IS_Contraseña
            // 
            this.IS_Contraseña.Location = new System.Drawing.Point(400, 283);
            this.IS_Contraseña.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IS_Contraseña.Name = "IS_Contraseña";
            this.IS_Contraseña.Size = new System.Drawing.Size(468, 22);
            this.IS_Contraseña.TabIndex = 5;
            // 
            // BTN_IS
            // 
            this.BTN_IS.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BTN_IS.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_IS.Location = new System.Drawing.Point(236, 389);
            this.BTN_IS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_IS.Name = "BTN_IS";
            this.BTN_IS.Size = new System.Drawing.Size(188, 47);
            this.BTN_IS.TabIndex = 6;
            this.BTN_IS.Text = "Iniciar Sesion";
            this.BTN_IS.UseVisualStyleBackColor = false;
            this.BTN_IS.Click += new System.EventHandler(this.BTN_IS_Click);
            // 
            // BTN_SALIRIS
            // 
            this.BTN_SALIRIS.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BTN_SALIRIS.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SALIRIS.Location = new System.Drawing.Point(664, 390);
            this.BTN_SALIRIS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_SALIRIS.Name = "BTN_SALIRIS";
            this.BTN_SALIRIS.Size = new System.Drawing.Size(188, 47);
            this.BTN_SALIRIS.TabIndex = 7;
            this.BTN_SALIRIS.Text = "Salir";
            this.BTN_SALIRIS.UseVisualStyleBackColor = false;
            // 
            // RB_ADMIN
            // 
            this.RB_ADMIN.AutoSize = true;
            this.RB_ADMIN.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_ADMIN.Location = new System.Drawing.Point(317, 97);
            this.RB_ADMIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RB_ADMIN.Name = "RB_ADMIN";
            this.RB_ADMIN.Size = new System.Drawing.Size(97, 27);
            this.RB_ADMIN.TabIndex = 9;
            this.RB_ADMIN.TabStop = true;
            this.RB_ADMIN.Text = "ADMIN";
            this.RB_ADMIN.UseVisualStyleBackColor = true;
            // 
            // RB_AUXILIAR
            // 
            this.RB_AUXILIAR.AutoSize = true;
            this.RB_AUXILIAR.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_AUXILIAR.Location = new System.Drawing.Point(591, 97);
            this.RB_AUXILIAR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RB_AUXILIAR.Name = "RB_AUXILIAR";
            this.RB_AUXILIAR.Size = new System.Drawing.Size(120, 27);
            this.RB_AUXILIAR.TabIndex = 10;
            this.RB_AUXILIAR.TabStop = true;
            this.RB_AUXILIAR.Text = "AUXILIAR";
            this.RB_AUXILIAR.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.RB_AUXILIAR);
            this.Controls.Add(this.RB_ADMIN);
            this.Controls.Add(this.BTN_SALIRIS);
            this.Controls.Add(this.BTN_IS);
            this.Controls.Add(this.IS_Contraseña);
            this.Controls.Add(this.IS_Correo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Correo);
            this.Controls.Add(this.Titulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Inicio De Sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IS_Correo;
        private System.Windows.Forms.TextBox IS_Contraseña;
        private System.Windows.Forms.Button BTN_IS;
        private System.Windows.Forms.Button BTN_SALIRIS;
        private System.Windows.Forms.RadioButton RB_ADMIN;
        private System.Windows.Forms.RadioButton RB_AUXILIAR;
    }
}