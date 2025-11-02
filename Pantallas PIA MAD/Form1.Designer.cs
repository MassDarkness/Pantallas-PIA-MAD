namespace Pantallas_PIA_MAD
{
    partial class Empresa
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Titulo = new System.Windows.Forms.Label();
            this.BTN_Empresa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Lucida Sans", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Titulo.Location = new System.Drawing.Point(87, 171);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(607, 72);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "González Solutions";
            // 
            // BTN_Empresa
            // 
            this.BTN_Empresa.BackColor = System.Drawing.Color.CadetBlue;
            this.BTN_Empresa.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Empresa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_Empresa.Location = new System.Drawing.Point(649, 392);
            this.BTN_Empresa.Name = "BTN_Empresa";
            this.BTN_Empresa.Size = new System.Drawing.Size(139, 46);
            this.BTN_Empresa.TabIndex = 1;
            this.BTN_Empresa.Text = "Ingresar";
            this.BTN_Empresa.UseVisualStyleBackColor = false;
            // 
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.BTN_Empresa);
            this.Name = "Empresa";
            this.Text = "Empresa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Button BTN_Empresa;
    }
}

