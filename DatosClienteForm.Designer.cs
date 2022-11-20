namespace TP_II
{
    partial class DatosClienteForm
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
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.Edad = new System.Windows.Forms.Label();
            this.tbEdad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.bnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAcompaniantes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(13, 32);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(135, 20);
            this.tbNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(13, 78);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(135, 20);
            this.tbApellido.TabIndex = 2;
            // 
            // Edad
            // 
            this.Edad.AutoSize = true;
            this.Edad.Location = new System.Drawing.Point(13, 155);
            this.Edad.Name = "Edad";
            this.Edad.Size = new System.Drawing.Size(32, 13);
            this.Edad.TabIndex = 5;
            this.Edad.Text = "Edad";
            // 
            // tbEdad
            // 
            this.tbEdad.Location = new System.Drawing.Point(13, 171);
            this.tbEdad.Name = "tbEdad";
            this.tbEdad.Size = new System.Drawing.Size(135, 20);
            this.tbEdad.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DNI";
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(13, 126);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(135, 20);
            this.tbDni.TabIndex = 6;
            // 
            // bnAceptar
            // 
            this.bnAceptar.BackColor = System.Drawing.Color.LightBlue;
            this.bnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAceptar.Location = new System.Drawing.Point(12, 248);
            this.bnAceptar.Name = "bnAceptar";
            this.bnAceptar.Size = new System.Drawing.Size(132, 23);
            this.bnAceptar.TabIndex = 8;
            this.bnAceptar.Text = "Aceptar";
            this.bnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(12, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAcompaniantes
            // 
            this.btnAcompaniantes.Location = new System.Drawing.Point(12, 209);
            this.btnAcompaniantes.Name = "btnAcompaniantes";
            this.btnAcompaniantes.Size = new System.Drawing.Size(132, 23);
            this.btnAcompaniantes.TabIndex = 10;
            this.btnAcompaniantes.Text = "Agregar pasajeros";
            this.btnAcompaniantes.UseVisualStyleBackColor = true;
            // 
            // DatosClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 312);
            this.Controls.Add(this.btnAcompaniantes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.bnAceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDni);
            this.Controls.Add(this.Edad);
            this.Controls.Add(this.tbEdad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNombre);
            this.Name = "DatosClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbNombre;
        public System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label Edad;
        public System.Windows.Forms.TextBox tbEdad;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Button bnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAcompaniantes;
    }
}