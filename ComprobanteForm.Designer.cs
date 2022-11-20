namespace TP_II
{
    partial class ComprobanteForm
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lbComprobante = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(193, 347);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lbComprobante
            // 
            this.lbComprobante.FormattingEnabled = true;
            this.lbComprobante.Location = new System.Drawing.Point(2, 4);
            this.lbComprobante.Name = "lbComprobante";
            this.lbComprobante.Size = new System.Drawing.Size(332, 329);
            this.lbComprobante.TabIndex = 2;
            // 
            // ComprobanteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 382);
            this.Controls.Add(this.lbComprobante);
            this.Controls.Add(this.btnAceptar);
            this.Name = "ComprobanteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Su Comprobante";
            this.Load += new System.EventHandler(this.ComprobanteForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        public System.Windows.Forms.ListBox lbComprobante;
    }
}