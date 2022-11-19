namespace TP_II
{
    partial class ConsultaForm
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
            this.checkBoxCasa = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.checkBoxHotel = new System.Windows.Forms.CheckBox();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.lbFechaFinal = new System.Windows.Forms.Label();
            this.dtPickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dtPickerFinal = new System.Windows.Forms.DateTimePicker();
            this.gBoxFecha = new System.Windows.Forms.GroupBox();
            this.checkB3Estrellas = new System.Windows.Forms.CheckBox();
            this.dataGridDisponibles = new System.Windows.Forms.DataGridView();
            this.columnaTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDirección = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaEstrellas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaCapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxCasa = new System.Windows.Forms.GroupBox();
            this.numUDcamasCasa = new System.Windows.Forms.NumericUpDown();
            this.lbCamasCasa = new System.Windows.Forms.Label();
            this.gBoxServicios = new System.Windows.Forms.GroupBox();
            this.checkBWiFi = new System.Windows.Forms.CheckBox();
            this.checkBLimpieza = new System.Windows.Forms.CheckBox();
            this.checkBDesayuno = new System.Windows.Forms.CheckBox();
            this.checkBMascota = new System.Windows.Forms.CheckBox();
            this.checkBPileta = new System.Windows.Forms.CheckBox();
            this.checkBCochera = new System.Windows.Forms.CheckBox();
            this.gBoxFiltroFecha = new System.Windows.Forms.GroupBox();
            this.chechBoxFiltrarPorFecha = new System.Windows.Forms.CheckBox();
            this.gBoxFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisponibles)).BeginInit();
            this.gBoxCasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDcamasCasa)).BeginInit();
            this.gBoxServicios.SuspendLayout();
            this.gBoxFiltroFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxCasa
            // 
            this.checkBoxCasa.AutoSize = true;
            this.checkBoxCasa.Location = new System.Drawing.Point(23, 34);
            this.checkBoxCasa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCasa.Name = "checkBoxCasa";
            this.checkBoxCasa.Size = new System.Drawing.Size(61, 20);
            this.checkBoxCasa.TabIndex = 0;
            this.checkBoxCasa.Text = "Casa";
            this.checkBoxCasa.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(781, 305);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(147, 44);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // checkBoxHotel
            // 
            this.checkBoxHotel.AutoSize = true;
            this.checkBoxHotel.Location = new System.Drawing.Point(132, 36);
            this.checkBoxHotel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxHotel.Name = "checkBoxHotel";
            this.checkBoxHotel.Size = new System.Drawing.Size(61, 20);
            this.checkBoxHotel.TabIndex = 2;
            this.checkBoxHotel.Text = "Hotel";
            this.checkBoxHotel.UseVisualStyleBackColor = true;
            this.checkBoxHotel.CheckedChanged += new System.EventHandler(this.checkBoxHotel_CheckedChanged);
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Location = new System.Drawing.Point(96, 42);
            this.lbFechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(82, 16);
            this.lbFechaInicio.TabIndex = 3;
            this.lbFechaInicio.Text = "Fecha Inicio:";
            // 
            // lbFechaFinal
            // 
            this.lbFechaFinal.AutoSize = true;
            this.lbFechaFinal.Location = new System.Drawing.Point(401, 42);
            this.lbFechaFinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFechaFinal.Name = "lbFechaFinal";
            this.lbFechaFinal.Size = new System.Drawing.Size(80, 16);
            this.lbFechaFinal.TabIndex = 4;
            this.lbFechaFinal.Text = "Fecha Final:";
            // 
            // dtPickerInicio
            // 
            this.dtPickerInicio.Location = new System.Drawing.Point(207, 38);
            this.dtPickerInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPickerInicio.Name = "dtPickerInicio";
            this.dtPickerInicio.Size = new System.Drawing.Size(167, 22);
            this.dtPickerInicio.TabIndex = 5;
            this.dtPickerInicio.Value = new System.DateTime(2022, 11, 1, 0, 0, 0, 0);
            // 
            // dtPickerFinal
            // 
            this.dtPickerFinal.Location = new System.Drawing.Point(515, 39);
            this.dtPickerFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPickerFinal.Name = "dtPickerFinal";
            this.dtPickerFinal.Size = new System.Drawing.Size(167, 22);
            this.dtPickerFinal.TabIndex = 6;
            this.dtPickerFinal.Value = new System.DateTime(2022, 11, 30, 0, 0, 0, 0);
            // 
            // gBoxFecha
            // 
            this.gBoxFecha.Controls.Add(this.checkB3Estrellas);
            this.gBoxFecha.Controls.Add(this.checkBoxCasa);
            this.gBoxFecha.Controls.Add(this.checkBoxHotel);
            this.gBoxFecha.Location = new System.Drawing.Point(16, 15);
            this.gBoxFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxFecha.Name = "gBoxFecha";
            this.gBoxFecha.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxFecha.Size = new System.Drawing.Size(365, 79);
            this.gBoxFecha.TabIndex = 7;
            this.gBoxFecha.TabStop = false;
            // 
            // checkB3Estrellas
            // 
            this.checkB3Estrellas.AutoSize = true;
            this.checkB3Estrellas.Location = new System.Drawing.Point(241, 36);
            this.checkB3Estrellas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkB3Estrellas.Name = "checkB3Estrellas";
            this.checkB3Estrellas.Size = new System.Drawing.Size(91, 20);
            this.checkB3Estrellas.TabIndex = 3;
            this.checkB3Estrellas.Text = "3 Estrellas";
            this.checkB3Estrellas.UseVisualStyleBackColor = true;
            // 
            // dataGridDisponibles
            // 
            this.dataGridDisponibles.AllowUserToAddRows = false;
            this.dataGridDisponibles.AllowUserToDeleteRows = false;
            this.dataGridDisponibles.AllowUserToResizeColumns = false;
            this.dataGridDisponibles.AllowUserToResizeRows = false;
            this.dataGridDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaTipo,
            this.columnaDirección,
            this.columnaNombre,
            this.columnaEstrellas,
            this.columnaCapacidad,
            this.minDias});
            this.dataGridDisponibles.Location = new System.Drawing.Point(16, 388);
            this.dataGridDisponibles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridDisponibles.Name = "dataGridDisponibles";
            this.dataGridDisponibles.RowHeadersVisible = false;
            this.dataGridDisponibles.RowHeadersWidth = 51;
            this.dataGridDisponibles.Size = new System.Drawing.Size(912, 298);
            this.dataGridDisponibles.TabIndex = 8;
            this.dataGridDisponibles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDisponibles_CellContentClick);
            this.dataGridDisponibles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDisponibles_CellDoubleClick);
            // 
            // columnaTipo
            // 
            this.columnaTipo.HeaderText = "Tipo";
            this.columnaTipo.MinimumWidth = 6;
            this.columnaTipo.Name = "columnaTipo";
            this.columnaTipo.ReadOnly = true;
            this.columnaTipo.Width = 125;
            // 
            // columnaDirección
            // 
            this.columnaDirección.HeaderText = "Dirección";
            this.columnaDirección.MinimumWidth = 6;
            this.columnaDirección.Name = "columnaDirección";
            this.columnaDirección.ReadOnly = true;
            this.columnaDirección.Width = 125;
            // 
            // columnaNombre
            // 
            this.columnaNombre.HeaderText = "Nombre";
            this.columnaNombre.MinimumWidth = 6;
            this.columnaNombre.Name = "columnaNombre";
            this.columnaNombre.ReadOnly = true;
            this.columnaNombre.Width = 125;
            // 
            // columnaEstrellas
            // 
            this.columnaEstrellas.HeaderText = "Status";
            this.columnaEstrellas.MinimumWidth = 6;
            this.columnaEstrellas.Name = "columnaEstrellas";
            this.columnaEstrellas.ReadOnly = true;
            this.columnaEstrellas.Width = 125;
            // 
            // columnaCapacidad
            // 
            this.columnaCapacidad.HeaderText = "Capacidad";
            this.columnaCapacidad.MinimumWidth = 6;
            this.columnaCapacidad.Name = "columnaCapacidad";
            this.columnaCapacidad.ReadOnly = true;
            this.columnaCapacidad.Width = 125;
            // 
            // minDias
            // 
            this.minDias.HeaderText = "Mínimo de días";
            this.minDias.MinimumWidth = 6;
            this.minDias.Name = "minDias";
            this.minDias.Width = 125;
            // 
            // gBoxCasa
            // 
            this.gBoxCasa.Controls.Add(this.numUDcamasCasa);
            this.gBoxCasa.Controls.Add(this.lbCamasCasa);
            this.gBoxCasa.Controls.Add(this.gBoxServicios);
            this.gBoxCasa.Location = new System.Drawing.Point(16, 102);
            this.gBoxCasa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxCasa.Name = "gBoxCasa";
            this.gBoxCasa.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxCasa.Size = new System.Drawing.Size(912, 181);
            this.gBoxCasa.TabIndex = 12;
            this.gBoxCasa.TabStop = false;
            this.gBoxCasa.Text = "Filtro Casa";
            // 
            // numUDcamasCasa
            // 
            this.numUDcamasCasa.Location = new System.Drawing.Point(157, 43);
            this.numUDcamasCasa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numUDcamasCasa.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDcamasCasa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDcamasCasa.Name = "numUDcamasCasa";
            this.numUDcamasCasa.Size = new System.Drawing.Size(69, 22);
            this.numUDcamasCasa.TabIndex = 10;
            this.numUDcamasCasa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbCamasCasa
            // 
            this.lbCamasCasa.AutoSize = true;
            this.lbCamasCasa.Location = new System.Drawing.Point(19, 47);
            this.lbCamasCasa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCamasCasa.Name = "lbCamasCasa";
            this.lbCamasCasa.Size = new System.Drawing.Size(124, 16);
            this.lbCamasCasa.TabIndex = 9;
            this.lbCamasCasa.Text = "Cantidad de camas";
            // 
            // gBoxServicios
            // 
            this.gBoxServicios.Controls.Add(this.checkBWiFi);
            this.gBoxServicios.Controls.Add(this.checkBLimpieza);
            this.gBoxServicios.Controls.Add(this.checkBDesayuno);
            this.gBoxServicios.Controls.Add(this.checkBMascota);
            this.gBoxServicios.Controls.Add(this.checkBPileta);
            this.gBoxServicios.Controls.Add(this.checkBCochera);
            this.gBoxServicios.Location = new System.Drawing.Point(280, 23);
            this.gBoxServicios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxServicios.Name = "gBoxServicios";
            this.gBoxServicios.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxServicios.Size = new System.Drawing.Size(423, 138);
            this.gBoxServicios.TabIndex = 8;
            this.gBoxServicios.TabStop = false;
            this.gBoxServicios.Text = "Servicios";
            // 
            // checkBWiFi
            // 
            this.checkBWiFi.AutoSize = true;
            this.checkBWiFi.Location = new System.Drawing.Point(33, 100);
            this.checkBWiFi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBWiFi.Name = "checkBWiFi";
            this.checkBWiFi.Size = new System.Drawing.Size(60, 20);
            this.checkBWiFi.TabIndex = 12;
            this.checkBWiFi.Text = "WI-FI";
            this.checkBWiFi.UseVisualStyleBackColor = true;
            // 
            // checkBLimpieza
            // 
            this.checkBLimpieza.AutoSize = true;
            this.checkBLimpieza.Location = new System.Drawing.Point(256, 23);
            this.checkBLimpieza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBLimpieza.Name = "checkBLimpieza";
            this.checkBLimpieza.Size = new System.Drawing.Size(83, 20);
            this.checkBLimpieza.TabIndex = 11;
            this.checkBLimpieza.Text = "Limpieza";
            this.checkBLimpieza.UseVisualStyleBackColor = true;
            // 
            // checkBDesayuno
            // 
            this.checkBDesayuno.AutoSize = true;
            this.checkBDesayuno.Location = new System.Drawing.Point(256, 62);
            this.checkBDesayuno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBDesayuno.Name = "checkBDesayuno";
            this.checkBDesayuno.Size = new System.Drawing.Size(91, 20);
            this.checkBDesayuno.TabIndex = 10;
            this.checkBDesayuno.Text = "Desayuno";
            this.checkBDesayuno.UseVisualStyleBackColor = true;
            // 
            // checkBMascota
            // 
            this.checkBMascota.AutoSize = true;
            this.checkBMascota.Location = new System.Drawing.Point(256, 100);
            this.checkBMascota.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBMascota.Name = "checkBMascota";
            this.checkBMascota.Size = new System.Drawing.Size(126, 20);
            this.checkBMascota.TabIndex = 9;
            this.checkBMascota.Text = "Admite Mascota";
            this.checkBMascota.UseVisualStyleBackColor = true;
            // 
            // checkBPileta
            // 
            this.checkBPileta.AutoSize = true;
            this.checkBPileta.Location = new System.Drawing.Point(33, 62);
            this.checkBPileta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBPileta.Name = "checkBPileta";
            this.checkBPileta.Size = new System.Drawing.Size(63, 20);
            this.checkBPileta.TabIndex = 8;
            this.checkBPileta.Text = "Pileta";
            this.checkBPileta.UseVisualStyleBackColor = true;
            // 
            // checkBCochera
            // 
            this.checkBCochera.AutoSize = true;
            this.checkBCochera.Location = new System.Drawing.Point(33, 23);
            this.checkBCochera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBCochera.Name = "checkBCochera";
            this.checkBCochera.Size = new System.Drawing.Size(80, 20);
            this.checkBCochera.TabIndex = 7;
            this.checkBCochera.Text = "Cochera";
            this.checkBCochera.UseVisualStyleBackColor = true;
            // 
            // gBoxFiltroFecha
            // 
            this.gBoxFiltroFecha.Controls.Add(this.lbFechaInicio);
            this.gBoxFiltroFecha.Controls.Add(this.dtPickerInicio);
            this.gBoxFiltroFecha.Controls.Add(this.dtPickerFinal);
            this.gBoxFiltroFecha.Controls.Add(this.lbFechaFinal);
            this.gBoxFiltroFecha.Location = new System.Drawing.Point(17, 292);
            this.gBoxFiltroFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxFiltroFecha.Name = "gBoxFiltroFecha";
            this.gBoxFiltroFecha.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxFiltroFecha.Size = new System.Drawing.Size(701, 74);
            this.gBoxFiltroFecha.TabIndex = 14;
            this.gBoxFiltroFecha.TabStop = false;
            this.gBoxFiltroFecha.Text = "Filtro Fecha";
            // 
            // chechBoxFiltrarPorFecha
            // 
            this.chechBoxFiltrarPorFecha.AutoSize = true;
            this.chechBoxFiltrarPorFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chechBoxFiltrarPorFecha.Location = new System.Drawing.Point(796, 73);
            this.chechBoxFiltrarPorFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chechBoxFiltrarPorFecha.Name = "chechBoxFiltrarPorFecha";
            this.chechBoxFiltrarPorFecha.Size = new System.Drawing.Size(130, 21);
            this.chechBoxFiltrarPorFecha.TabIndex = 15;
            this.chechBoxFiltrarPorFecha.Text = "Filtrar por fecha";
            this.chechBoxFiltrarPorFecha.UseVisualStyleBackColor = true;
            this.chechBoxFiltrarPorFecha.CheckedChanged += new System.EventHandler(this.chechBoxFiltrarPorFecha_CheckedChanged);
            // 
            // ConsultaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 700);
            this.Controls.Add(this.chechBoxFiltrarPorFecha);
            this.Controls.Add(this.gBoxFiltroFecha);
            this.Controls.Add(this.gBoxCasa);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataGridDisponibles);
            this.Controls.Add(this.gBoxFecha);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConsultaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.ConsultaForm_Load);
            this.gBoxFecha.ResumeLayout(false);
            this.gBoxFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisponibles)).EndInit();
            this.gBoxCasa.ResumeLayout(false);
            this.gBoxCasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDcamasCasa)).EndInit();
            this.gBoxServicios.ResumeLayout(false);
            this.gBoxServicios.PerformLayout();
            this.gBoxFiltroFecha.ResumeLayout(false);
            this.gBoxFiltroFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lbFechaInicio;
        private System.Windows.Forms.Label lbFechaFinal;
        private System.Windows.Forms.GroupBox gBoxFecha;
        private System.Windows.Forms.DataGridView dataGridDisponibles;
        private System.Windows.Forms.GroupBox gBoxCasa;
        private System.Windows.Forms.GroupBox gBoxServicios;
        private System.Windows.Forms.Label lbCamasCasa;
        public System.Windows.Forms.CheckBox checkBoxCasa;
        public System.Windows.Forms.CheckBox checkBoxHotel;
        public System.Windows.Forms.DateTimePicker dtPickerInicio;
        public System.Windows.Forms.DateTimePicker dtPickerFinal;
        public System.Windows.Forms.CheckBox checkBWiFi;
        public System.Windows.Forms.CheckBox checkBLimpieza;
        public System.Windows.Forms.CheckBox checkBDesayuno;
        public System.Windows.Forms.CheckBox checkBMascota;
        public System.Windows.Forms.CheckBox checkBPileta;
        public System.Windows.Forms.CheckBox checkBCochera;
        public System.Windows.Forms.NumericUpDown numUDcamasCasa;
        public System.Windows.Forms.CheckBox checkB3Estrellas;
        public System.Windows.Forms.CheckBox chechBoxFiltrarPorFecha;
        public System.Windows.Forms.GroupBox gBoxFiltroFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDirección;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaEstrellas;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaCapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn minDias;
    }
}