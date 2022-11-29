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
            this.checkBoxCasa.Location = new System.Drawing.Point(17, 28);
            this.checkBoxCasa.Name = "checkBoxCasa";
            this.checkBoxCasa.Size = new System.Drawing.Size(50, 17);
            this.checkBoxCasa.TabIndex = 0;
            this.checkBoxCasa.Text = "Casa";
            this.checkBoxCasa.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(586, 248);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 36);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // checkBoxHotel
            // 
            this.checkBoxHotel.AutoSize = true;
            this.checkBoxHotel.Location = new System.Drawing.Point(99, 29);
            this.checkBoxHotel.Name = "checkBoxHotel";
            this.checkBoxHotel.Size = new System.Drawing.Size(51, 17);
            this.checkBoxHotel.TabIndex = 2;
            this.checkBoxHotel.Text = "Hotel";
            this.checkBoxHotel.UseVisualStyleBackColor = true;
            this.checkBoxHotel.CheckedChanged += new System.EventHandler(this.checkBoxHotel_CheckedChanged);
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Location = new System.Drawing.Point(72, 34);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lbFechaInicio.TabIndex = 3;
            this.lbFechaInicio.Text = "Fecha Inicio:";
            // 
            // lbFechaFinal
            // 
            this.lbFechaFinal.AutoSize = true;
            this.lbFechaFinal.Location = new System.Drawing.Point(301, 34);
            this.lbFechaFinal.Name = "lbFechaFinal";
            this.lbFechaFinal.Size = new System.Drawing.Size(65, 13);
            this.lbFechaFinal.TabIndex = 4;
            this.lbFechaFinal.Text = "Fecha Final:";
            // 
            // dtPickerInicio
            // 
            this.dtPickerInicio.Location = new System.Drawing.Point(155, 31);
            this.dtPickerInicio.Name = "dtPickerInicio";
            this.dtPickerInicio.Size = new System.Drawing.Size(126, 20);
            this.dtPickerInicio.TabIndex = 5;
            this.dtPickerInicio.Value = new System.DateTime(2022, 11, 1, 0, 0, 0, 0);
            // 
            // dtPickerFinal
            // 
            this.dtPickerFinal.Location = new System.Drawing.Point(386, 32);
            this.dtPickerFinal.Name = "dtPickerFinal";
            this.dtPickerFinal.Size = new System.Drawing.Size(126, 20);
            this.dtPickerFinal.TabIndex = 6;
            this.dtPickerFinal.Value = new System.DateTime(2022, 11, 30, 0, 0, 0, 0);
            // 
            // gBoxFecha
            // 
            this.gBoxFecha.Controls.Add(this.checkB3Estrellas);
            this.gBoxFecha.Controls.Add(this.checkBoxCasa);
            this.gBoxFecha.Controls.Add(this.checkBoxHotel);
            this.gBoxFecha.Location = new System.Drawing.Point(12, 12);
            this.gBoxFecha.Name = "gBoxFecha";
            this.gBoxFecha.Size = new System.Drawing.Size(274, 64);
            this.gBoxFecha.TabIndex = 7;
            this.gBoxFecha.TabStop = false;
            // 
            // checkB3Estrellas
            // 
            this.checkB3Estrellas.AutoSize = true;
            this.checkB3Estrellas.Location = new System.Drawing.Point(181, 29);
            this.checkB3Estrellas.Name = "checkB3Estrellas";
            this.checkB3Estrellas.Size = new System.Drawing.Size(74, 17);
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
            this.dataGridDisponibles.Location = new System.Drawing.Point(12, 315);
            this.dataGridDisponibles.Name = "dataGridDisponibles";
            this.dataGridDisponibles.RowHeadersVisible = false;
            this.dataGridDisponibles.Size = new System.Drawing.Size(684, 242);
            this.dataGridDisponibles.TabIndex = 8;
            this.dataGridDisponibles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDisponibles_CellDoubleClick);
            // 
            // columnaTipo
            // 
            this.columnaTipo.HeaderText = "Tipo";
            this.columnaTipo.Name = "columnaTipo";
            this.columnaTipo.ReadOnly = true;
            // 
            // columnaDirección
            // 
            this.columnaDirección.HeaderText = "Dirección";
            this.columnaDirección.Name = "columnaDirección";
            this.columnaDirección.ReadOnly = true;
            // 
            // columnaNombre
            // 
            this.columnaNombre.HeaderText = "Nombre";
            this.columnaNombre.Name = "columnaNombre";
            this.columnaNombre.ReadOnly = true;
            // 
            // columnaEstrellas
            // 
            this.columnaEstrellas.HeaderText = "Status";
            this.columnaEstrellas.Name = "columnaEstrellas";
            this.columnaEstrellas.ReadOnly = true;
            // 
            // columnaCapacidad
            // 
            this.columnaCapacidad.HeaderText = "Capacidad";
            this.columnaCapacidad.Name = "columnaCapacidad";
            this.columnaCapacidad.ReadOnly = true;
            // 
            // minDias
            // 
            this.minDias.HeaderText = "Mínimo de días";
            this.minDias.Name = "minDias";
            // 
            // gBoxCasa
            // 
            this.gBoxCasa.Controls.Add(this.numUDcamasCasa);
            this.gBoxCasa.Controls.Add(this.lbCamasCasa);
            this.gBoxCasa.Controls.Add(this.gBoxServicios);
            this.gBoxCasa.Location = new System.Drawing.Point(12, 83);
            this.gBoxCasa.Name = "gBoxCasa";
            this.gBoxCasa.Size = new System.Drawing.Size(684, 147);
            this.gBoxCasa.TabIndex = 12;
            this.gBoxCasa.TabStop = false;
            this.gBoxCasa.Text = "Filtro Casa";
            // 
            // numUDcamasCasa
            // 
            this.numUDcamasCasa.Location = new System.Drawing.Point(118, 35);
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
            this.numUDcamasCasa.Size = new System.Drawing.Size(52, 20);
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
            this.lbCamasCasa.Location = new System.Drawing.Point(14, 38);
            this.lbCamasCasa.Name = "lbCamasCasa";
            this.lbCamasCasa.Size = new System.Drawing.Size(98, 13);
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
            this.gBoxServicios.Location = new System.Drawing.Point(210, 19);
            this.gBoxServicios.Name = "gBoxServicios";
            this.gBoxServicios.Size = new System.Drawing.Size(317, 112);
            this.gBoxServicios.TabIndex = 8;
            this.gBoxServicios.TabStop = false;
            this.gBoxServicios.Text = "Servicios";
            // 
            // checkBWiFi
            // 
            this.checkBWiFi.AutoSize = true;
            this.checkBWiFi.Location = new System.Drawing.Point(25, 81);
            this.checkBWiFi.Name = "checkBWiFi";
            this.checkBWiFi.Size = new System.Drawing.Size(52, 17);
            this.checkBWiFi.TabIndex = 12;
            this.checkBWiFi.Text = "WI-FI";
            this.checkBWiFi.UseVisualStyleBackColor = true;
            // 
            // checkBLimpieza
            // 
            this.checkBLimpieza.AutoSize = true;
            this.checkBLimpieza.Location = new System.Drawing.Point(192, 19);
            this.checkBLimpieza.Name = "checkBLimpieza";
            this.checkBLimpieza.Size = new System.Drawing.Size(67, 17);
            this.checkBLimpieza.TabIndex = 11;
            this.checkBLimpieza.Text = "Limpieza";
            this.checkBLimpieza.UseVisualStyleBackColor = true;
            // 
            // checkBDesayuno
            // 
            this.checkBDesayuno.AutoSize = true;
            this.checkBDesayuno.Location = new System.Drawing.Point(192, 50);
            this.checkBDesayuno.Name = "checkBDesayuno";
            this.checkBDesayuno.Size = new System.Drawing.Size(74, 17);
            this.checkBDesayuno.TabIndex = 10;
            this.checkBDesayuno.Text = "Desayuno";
            this.checkBDesayuno.UseVisualStyleBackColor = true;
            // 
            // checkBMascota
            // 
            this.checkBMascota.AutoSize = true;
            this.checkBMascota.Location = new System.Drawing.Point(192, 81);
            this.checkBMascota.Name = "checkBMascota";
            this.checkBMascota.Size = new System.Drawing.Size(102, 17);
            this.checkBMascota.TabIndex = 9;
            this.checkBMascota.Text = "Admite Mascota";
            this.checkBMascota.UseVisualStyleBackColor = true;
            // 
            // checkBPileta
            // 
            this.checkBPileta.AutoSize = true;
            this.checkBPileta.Location = new System.Drawing.Point(25, 50);
            this.checkBPileta.Name = "checkBPileta";
            this.checkBPileta.Size = new System.Drawing.Size(52, 17);
            this.checkBPileta.TabIndex = 8;
            this.checkBPileta.Text = "Pileta";
            this.checkBPileta.UseVisualStyleBackColor = true;
            // 
            // checkBCochera
            // 
            this.checkBCochera.AutoSize = true;
            this.checkBCochera.Location = new System.Drawing.Point(25, 19);
            this.checkBCochera.Name = "checkBCochera";
            this.checkBCochera.Size = new System.Drawing.Size(66, 17);
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
            this.gBoxFiltroFecha.Location = new System.Drawing.Point(13, 237);
            this.gBoxFiltroFecha.Name = "gBoxFiltroFecha";
            this.gBoxFiltroFecha.Size = new System.Drawing.Size(526, 60);
            this.gBoxFiltroFecha.TabIndex = 14;
            this.gBoxFiltroFecha.TabStop = false;
            this.gBoxFiltroFecha.Text = "Filtro Fecha";
            // 
            // chechBoxFiltrarPorFecha
            // 
            this.chechBoxFiltrarPorFecha.AutoSize = true;
            this.chechBoxFiltrarPorFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chechBoxFiltrarPorFecha.Location = new System.Drawing.Point(597, 59);
            this.chechBoxFiltrarPorFecha.Name = "chechBoxFiltrarPorFecha";
            this.chechBoxFiltrarPorFecha.Size = new System.Drawing.Size(99, 17);
            this.chechBoxFiltrarPorFecha.TabIndex = 15;
            this.chechBoxFiltrarPorFecha.Text = "Filtrar por fecha";
            this.chechBoxFiltrarPorFecha.UseVisualStyleBackColor = true;
            this.chechBoxFiltrarPorFecha.CheckedChanged += new System.EventHandler(this.chechBoxFiltrarPorFecha_CheckedChanged);
            // 
            // ConsultaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 569);
            this.Controls.Add(this.chechBoxFiltrarPorFecha);
            this.Controls.Add(this.gBoxFiltroFecha);
            this.Controls.Add(this.gBoxCasa);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataGridDisponibles);
            this.Controls.Add(this.gBoxFecha);
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