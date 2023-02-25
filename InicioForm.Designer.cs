namespace TP_II
{
    partial class InicioForm
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
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.p4 = new System.Windows.Forms.Panel();
            this.p3 = new System.Windows.Forms.Panel();
            this.p2 = new System.Windows.Forms.Panel();
            this.p1 = new System.Windows.Forms.Panel();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.p7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.p6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.p4.SuspendLayout();
            this.p5.SuspendLayout();
            this.p7.SuspendLayout();
            this.p6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Desea ingresar un nuevo precio base?";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(81, 86);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(75, 20);
            this.tbPrecio.TabIndex = 1;
            this.tbPrecio.TextChanged += new System.EventHandler(this.tbPrecio_TextChanged);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(151, 60);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(39, 17);
            this.rbNo.TabIndex = 2;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Location = new System.Drawing.Point(54, 60);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(34, 17);
            this.rbSi.TabIndex = 3;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "Si";
            this.rbSi.UseVisualStyleBackColor = true;
            // 
            // btnContinuar
            // 
            this.btnContinuar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinuar.Location = new System.Drawing.Point(79, 421);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 37);
            this.btnContinuar.TabIndex = 4;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            // 
            // cbPreguntar
            // 
            this.cbPreguntar.AutoSize = true;
            this.cbPreguntar.Location = new System.Drawing.Point(49, 381);
            this.cbPreguntar.Name = "cbPreguntar";
            this.cbPreguntar.Size = new System.Drawing.Size(129, 17);
            this.cbPreguntar.TabIndex = 5;
            this.cbPreguntar.Text = "No volver a preguntar";
            this.cbPreguntar.UseVisualStyleBackColor = true;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.tbPrecio);
            this.gb1.Controls.Add(this.rbNo);
            this.gb1.Controls.Add(this.rbSi);
            this.gb1.Location = new System.Drawing.Point(12, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(217, 130);
            this.gb1.TabIndex = 6;
            this.gb1.TabStop = false;
            this.gb1.Text = "Precio base";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.p7);
            this.gb2.Controls.Add(this.p6);
            this.gb2.Controls.Add(this.p5);
            this.gb2.Controls.Add(this.p4);
            this.gb2.Controls.Add(this.p3);
            this.gb2.Controls.Add(this.p2);
            this.gb2.Controls.Add(this.p1);
            this.gb2.Controls.Add(this.rb5);
            this.gb2.Controls.Add(this.rb4);
            this.gb2.Controls.Add(this.rb3);
            this.gb2.Controls.Add(this.rb2);
            this.gb2.Controls.Add(this.rb1);
            this.gb2.Location = new System.Drawing.Point(14, 148);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(215, 212);
            this.gb2.TabIndex = 7;
            this.gb2.TabStop = false;
            this.gb2.Text = "Estilos";
            // 
            // p4
            // 
            this.p4.Controls.Add(this.panel1);
            this.p4.Location = new System.Drawing.Point(98, 137);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(56, 18);
            this.p4.TabIndex = 8;
            // 
            // p3
            // 
            this.p3.Location = new System.Drawing.Point(98, 104);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(102, 18);
            this.p3.TabIndex = 7;
            // 
            // p2
            // 
            this.p2.Location = new System.Drawing.Point(98, 70);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(102, 18);
            this.p2.TabIndex = 6;
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(165)))), ((int)(((byte)(189)))));
            this.p1.Location = new System.Drawing.Point(98, 37);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(102, 18);
            this.p1.TabIndex = 5;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(7, 170);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(59, 17);
            this.rb5.TabIndex = 4;
            this.rb5.TabStop = true;
            this.rb5.Text = "Estilo 5";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(7, 138);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(59, 17);
            this.rb4.TabIndex = 3;
            this.rb4.TabStop = true;
            this.rb4.Text = "Estilo 4";
            this.rb4.UseVisualStyleBackColor = true;
            this.rb4.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(6, 104);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(59, 17);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "Estilo 3";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(7, 70);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(59, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "Estilo 2";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(7, 38);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(59, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Estilo 1";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(55, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 18);
            this.panel1.TabIndex = 10;
            // 
            // p5
            // 
            this.p5.Controls.Add(this.panel3);
            this.p5.Location = new System.Drawing.Point(149, 137);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(51, 18);
            this.p5.TabIndex = 10;
            this.p5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(55, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(56, 18);
            this.panel3.TabIndex = 10;
            // 
            // p7
            // 
            this.p7.Controls.Add(this.panel5);
            this.p7.Location = new System.Drawing.Point(149, 170);
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(51, 18);
            this.p7.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(55, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(56, 18);
            this.panel5.TabIndex = 10;
            // 
            // p6
            // 
            this.p6.Controls.Add(this.panel7);
            this.p6.Location = new System.Drawing.Point(98, 170);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(56, 18);
            this.p6.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(55, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(56, 18);
            this.panel7.TabIndex = 10;
            // 
            // InicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 474);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.cbPreguntar);
            this.Controls.Add(this.btnContinuar);
            this.Name = "InicioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido!";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.p4.ResumeLayout(false);
            this.p5.ResumeLayout(false);
            this.p7.ResumeLayout(false);
            this.p6.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gb1;
        public System.Windows.Forms.GroupBox gb2;
        public System.Windows.Forms.RadioButton rb5;
        public System.Windows.Forms.RadioButton rb4;
        public System.Windows.Forms.RadioButton rb3;
        public System.Windows.Forms.RadioButton rb2;
        public System.Windows.Forms.RadioButton rb1;
        public System.Windows.Forms.Panel p4;
        public System.Windows.Forms.Panel p3;
        public System.Windows.Forms.Panel p2;
        public System.Windows.Forms.Panel p1;
        public System.Windows.Forms.Panel p5;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel p7;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel p6;
        public System.Windows.Forms.Panel panel7;
    }
}