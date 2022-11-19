namespace TP_II
{
    partial class AlojamientoForm
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
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.btnReservar = new System.Windows.Forms.Button();
            this.nudDias = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.cBoxTipoHab = new System.Windows.Forms.ComboBox();
            this.lbNumHabitacion = new System.Windows.Forms.Label();
            this.cBoxNroHabitaciones = new System.Windows.Forms.ComboBox();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.flowLayoutImages = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDias)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendario
            // 
            this.Calendario.Location = new System.Drawing.Point(24, 97);
            this.Calendario.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Calendario.Name = "Calendario";
            this.Calendario.TabIndex = 0;
            // 
            // btnReservar
            // 
            this.btnReservar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReservar.Location = new System.Drawing.Point(255, 311);
            this.btnReservar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(100, 28);
            this.btnReservar.TabIndex = 1;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // nudDias
            // 
            this.nudDias.Location = new System.Drawing.Point(80, 311);
            this.nudDias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudDias.Name = "nudDias";
            this.nudDias.Size = new System.Drawing.Size(95, 22);
            this.nudDias.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 318);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dias";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(25, 22);
            this.lbDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(35, 16);
            this.lbDescripcion.TabIndex = 4;
            this.lbDescripcion.Text = "Tipo";
            // 
            // cBoxTipoHab
            // 
            this.cBoxTipoHab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoHab.FormattingEnabled = true;
            this.cBoxTipoHab.Items.AddRange(new object[] {
            "Simple",
            "Doble",
            "Triple"});
            this.cBoxTipoHab.Location = new System.Drawing.Point(24, 57);
            this.cBoxTipoHab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxTipoHab.Name = "cBoxTipoHab";
            this.cBoxTipoHab.Size = new System.Drawing.Size(132, 24);
            this.cBoxTipoHab.TabIndex = 5;
            this.cBoxTipoHab.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoHab_SelectedIndexChanged);
            // 
            // lbNumHabitacion
            // 
            this.lbNumHabitacion.AutoSize = true;
            this.lbNumHabitacion.Location = new System.Drawing.Point(215, 22);
            this.lbNumHabitacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumHabitacion.Name = "lbNumHabitacion";
            this.lbNumHabitacion.Size = new System.Drawing.Size(116, 16);
            this.lbNumHabitacion.TabIndex = 6;
            this.lbNumHabitacion.Text = "Nro de Habitación";
            // 
            // cBoxNroHabitaciones
            // 
            this.cBoxNroHabitaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxNroHabitaciones.FormattingEnabled = true;
            this.cBoxNroHabitaciones.Location = new System.Drawing.Point(219, 57);
            this.cBoxNroHabitaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxNroHabitaciones.Name = "cBoxNroHabitaciones";
            this.cBoxNroHabitaciones.Size = new System.Drawing.Size(132, 24);
            this.cBoxNroHabitaciones.TabIndex = 7;
            this.cBoxNroHabitaciones.SelectedIndexChanged += new System.EventHandler(this.cBoxNroHabitaciones_SelectedIndexChanged);
            this.cBoxNroHabitaciones.TextUpdate += new System.EventHandler(this.cBoxNroHabitaciones_TextUpdate);
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnCancelarReserva.Location = new System.Drawing.Point(204, 347);
            this.btnCancelarReserva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(151, 28);
            this.btnCancelarReserva.TabIndex = 8;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            // 
            // flowLayoutImages
            // 
            this.flowLayoutImages.AutoScroll = true;
            this.flowLayoutImages.Location = new System.Drawing.Point(360, 57);
            this.flowLayoutImages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutImages.Name = "flowLayoutImages";
            this.flowLayoutImages.Size = new System.Drawing.Size(304, 240);
            this.flowLayoutImages.TabIndex = 10;
            // 
            // btnImprimir
            // 
            this.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnImprimir.Location = new System.Drawing.Point(24, 347);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(151, 28);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir Cmprobante";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // AlojamientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 390);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.flowLayoutImages);
            this.Controls.Add(this.btnCancelarReserva);
            this.Controls.Add(this.cBoxNroHabitaciones);
            this.Controls.Add(this.lbNumHabitacion);
            this.Controls.Add(this.cBoxTipoHab);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudDias);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.Calendario);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AlojamientoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Alojamiento";
            this.Load += new System.EventHandler(this.AlojamientoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MonthCalendar Calendario;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudDias;
        public System.Windows.Forms.Label lbDescripcion;
        public System.Windows.Forms.ComboBox cBoxTipoHab;
        public System.Windows.Forms.Label lbNumHabitacion;
        public System.Windows.Forms.ComboBox cBoxNroHabitaciones;
        public System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutImages;
        public System.Windows.Forms.Button btnReservar;
        public System.Windows.Forms.Button btnImprimir;
    }
}