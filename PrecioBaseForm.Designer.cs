namespace TP_II
{
    partial class PrecioBaseForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.cbPreguntar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Desea ingresar un nuevo precio base?";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(109, 110);
            this.tbPrecio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(99, 22);
            this.tbPrecio.TabIndex = 1;
            this.tbPrecio.TextChanged += new System.EventHandler(this.tbPrecio_TextChanged);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(203, 78);
            this.rbNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(46, 20);
            this.rbNo.TabIndex = 2;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Location = new System.Drawing.Point(73, 78);
            this.rbSi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(40, 20);
            this.rbSi.TabIndex = 3;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "Si";
            this.rbSi.UseVisualStyleBackColor = true;
            // 
            // btnContinuar
            // 
            this.btnContinuar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinuar.Location = new System.Drawing.Point(109, 207);
            this.btnContinuar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(100, 46);
            this.btnContinuar.TabIndex = 4;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            // 
            // cbPreguntar
            // 
            this.cbPreguntar.AutoSize = true;
            this.cbPreguntar.Location = new System.Drawing.Point(73, 158);
            this.cbPreguntar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPreguntar.Name = "cbPreguntar";
            this.cbPreguntar.Size = new System.Drawing.Size(158, 20);
            this.cbPreguntar.TabIndex = 5;
            this.cbPreguntar.Text = "No volver a preguntar";
            this.cbPreguntar.UseVisualStyleBackColor = true;
            // 
            // PrecioBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 276);
            this.Controls.Add(this.cbPreguntar);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.rbSi);
            this.Controls.Add(this.rbNo);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PrecioBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tbPrecio;
        public System.Windows.Forms.RadioButton rbNo;
        public System.Windows.Forms.RadioButton rbSi;
        public System.Windows.Forms.CheckBox cbPreguntar;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnContinuar;
    }
}