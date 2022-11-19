namespace TP_II
{
    partial class ABMAlojamientosForm
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
            this.gbCasaHotel = new System.Windows.Forms.GroupBox();
            this.btnFotos = new System.Windows.Forms.Button();
            this.btnAltaBaja = new System.Windows.Forms.Button();
            this.labEstado = new System.Windows.Forms.Label();
            this.rbHotel = new System.Windows.Forms.RadioButton();
            this.rbCasa = new System.Windows.Forms.RadioButton();
            this.tBdireccion = new System.Windows.Forms.TextBox();
            this.Direccion = new System.Windows.Forms.Label();
            this.gBoxHotel = new System.Windows.Forms.GroupBox();
            this.nUtriples = new System.Windows.Forms.NumericUpDown();
            this.nUdobles = new System.Windows.Forms.NumericUpDown();
            this.nUsimples = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkB3Estrellas = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.gBoxCasa = new System.Windows.Forms.GroupBox();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numUDminimo = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNumCasa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numUDcamasCasa = new System.Windows.Forms.NumericUpDown();
            this.lbCamasCasa = new System.Windows.Forms.Label();
            this.gBoxServicios = new System.Windows.Forms.GroupBox();
            this.checkBWiFi = new System.Windows.Forms.CheckBox();
            this.checkBLimpieza = new System.Windows.Forms.CheckBox();
            this.checkBDesayuno = new System.Windows.Forms.CheckBox();
            this.checkBMascota = new System.Windows.Forms.CheckBox();
            this.checkBPileta = new System.Windows.Forms.CheckBox();
            this.checkBCochera = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbCasaHotel.SuspendLayout();
            this.gBoxHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUtriples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdobles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUsimples)).BeginInit();
            this.gBoxCasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDminimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDcamasCasa)).BeginInit();
            this.gBoxServicios.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCasaHotel
            // 
            this.gbCasaHotel.Controls.Add(this.btnFotos);
            this.gbCasaHotel.Controls.Add(this.btnAltaBaja);
            this.gbCasaHotel.Controls.Add(this.labEstado);
            this.gbCasaHotel.Controls.Add(this.rbHotel);
            this.gbCasaHotel.Controls.Add(this.rbCasa);
            this.gbCasaHotel.Controls.Add(this.tBdireccion);
            this.gbCasaHotel.Controls.Add(this.Direccion);
            this.gbCasaHotel.Location = new System.Drawing.Point(57, 26);
            this.gbCasaHotel.Margin = new System.Windows.Forms.Padding(4);
            this.gbCasaHotel.Name = "gbCasaHotel";
            this.gbCasaHotel.Padding = new System.Windows.Forms.Padding(4);
            this.gbCasaHotel.Size = new System.Drawing.Size(729, 119);
            this.gbCasaHotel.TabIndex = 0;
            this.gbCasaHotel.TabStop = false;
            // 
            // btnFotos
            // 
            this.btnFotos.Location = new System.Drawing.Point(503, 79);
            this.btnFotos.Margin = new System.Windows.Forms.Padding(4);
            this.btnFotos.Name = "btnFotos";
            this.btnFotos.Size = new System.Drawing.Size(143, 28);
            this.btnFotos.TabIndex = 7;
            this.btnFotos.Text = "Importar Fotos";
            this.btnFotos.UseVisualStyleBackColor = true;
            // 
            // btnAltaBaja
            // 
            this.btnAltaBaja.Location = new System.Drawing.Point(269, 79);
            this.btnAltaBaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnAltaBaja.Name = "btnAltaBaja";
            this.btnAltaBaja.Size = new System.Drawing.Size(145, 33);
            this.btnAltaBaja.TabIndex = 6;
            this.btnAltaBaja.Text = "Dar de Alta";
            this.btnAltaBaja.UseVisualStyleBackColor = true;
            this.btnAltaBaja.Click += new System.EventHandler(this.btnAltaBaja_Click);
            // 
            // labEstado
            // 
            this.labEstado.AutoSize = true;
            this.labEstado.Location = new System.Drawing.Point(165, 85);
            this.labEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labEstado.Name = "labEstado";
            this.labEstado.Size = new System.Drawing.Size(50, 16);
            this.labEstado.TabIndex = 5;
            this.labEstado.Text = "Estado";
            // 
            // rbHotel
            // 
            this.rbHotel.AutoSize = true;
            this.rbHotel.Location = new System.Drawing.Point(21, 73);
            this.rbHotel.Margin = new System.Windows.Forms.Padding(4);
            this.rbHotel.Name = "rbHotel";
            this.rbHotel.Size = new System.Drawing.Size(60, 20);
            this.rbHotel.TabIndex = 4;
            this.rbHotel.TabStop = true;
            this.rbHotel.Text = "Hotel";
            this.rbHotel.UseVisualStyleBackColor = true;
            this.rbHotel.CheckedChanged += new System.EventHandler(this.rbHotel_CheckedChanged);
            // 
            // rbCasa
            // 
            this.rbCasa.AutoSize = true;
            this.rbCasa.Location = new System.Drawing.Point(21, 39);
            this.rbCasa.Margin = new System.Windows.Forms.Padding(4);
            this.rbCasa.Name = "rbCasa";
            this.rbCasa.Size = new System.Drawing.Size(60, 20);
            this.rbCasa.TabIndex = 2;
            this.rbCasa.TabStop = true;
            this.rbCasa.Text = "Casa";
            this.rbCasa.UseVisualStyleBackColor = true;
            this.rbCasa.CheckedChanged += new System.EventHandler(this.rbCasa_CheckedChanged);
            // 
            // tBdireccion
            // 
            this.tBdireccion.Location = new System.Drawing.Point(269, 46);
            this.tBdireccion.Margin = new System.Windows.Forms.Padding(4);
            this.tBdireccion.Name = "tBdireccion";
            this.tBdireccion.Size = new System.Drawing.Size(375, 22);
            this.tBdireccion.TabIndex = 2;
            // 
            // Direccion
            // 
            this.Direccion.AutoSize = true;
            this.Direccion.Location = new System.Drawing.Point(165, 49);
            this.Direccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(64, 16);
            this.Direccion.TabIndex = 0;
            this.Direccion.Text = "Direccion";
            // 
            // gBoxHotel
            // 
            this.gBoxHotel.Controls.Add(this.nUtriples);
            this.gBoxHotel.Controls.Add(this.nUdobles);
            this.gBoxHotel.Controls.Add(this.nUsimples);
            this.gBoxHotel.Controls.Add(this.label6);
            this.gBoxHotel.Controls.Add(this.label5);
            this.gBoxHotel.Controls.Add(this.label4);
            this.gBoxHotel.Controls.Add(this.label3);
            this.gBoxHotel.Controls.Add(this.checkB3Estrellas);
            this.gBoxHotel.Controls.Add(this.label2);
            this.gBoxHotel.Controls.Add(this.tbNombre);
            this.gBoxHotel.Location = new System.Drawing.Point(57, 164);
            this.gBoxHotel.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxHotel.Name = "gBoxHotel";
            this.gBoxHotel.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxHotel.Size = new System.Drawing.Size(729, 178);
            this.gBoxHotel.TabIndex = 1;
            this.gBoxHotel.TabStop = false;
            this.gBoxHotel.Text = "Hotel";
            // 
            // nUtriples
            // 
            this.nUtriples.Location = new System.Drawing.Point(527, 126);
            this.nUtriples.Margin = new System.Windows.Forms.Padding(4);
            this.nUtriples.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nUtriples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUtriples.Name = "nUtriples";
            this.nUtriples.Size = new System.Drawing.Size(69, 22);
            this.nUtriples.TabIndex = 16;
            this.nUtriples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nUdobles
            // 
            this.nUdobles.Location = new System.Drawing.Point(280, 126);
            this.nUdobles.Margin = new System.Windows.Forms.Padding(4);
            this.nUdobles.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nUdobles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdobles.Name = "nUdobles";
            this.nUdobles.Size = new System.Drawing.Size(69, 22);
            this.nUdobles.TabIndex = 15;
            this.nUdobles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nUsimples
            // 
            this.nUsimples.Location = new System.Drawing.Point(37, 126);
            this.nUsimples.Margin = new System.Windows.Forms.Padding(4);
            this.nUsimples.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nUsimples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUsimples.Name = "nUsimples";
            this.nUsimples.Size = new System.Drawing.Size(69, 22);
            this.nUsimples.TabIndex = 14;
            this.nUsimples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(523, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Triples";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Dobles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Simples";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cantidad habitaciones";
            // 
            // checkB3Estrellas
            // 
            this.checkB3Estrellas.AutoSize = true;
            this.checkB3Estrellas.Location = new System.Drawing.Point(527, 30);
            this.checkB3Estrellas.Margin = new System.Windows.Forms.Padding(4);
            this.checkB3Estrellas.Name = "checkB3Estrellas";
            this.checkB3Estrellas.Size = new System.Drawing.Size(91, 20);
            this.checkB3Estrellas.TabIndex = 4;
            this.checkB3Estrellas.Text = "3 Estrellas";
            this.checkB3Estrellas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(129, 21);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(284, 22);
            this.tbNombre.TabIndex = 3;
            // 
            // gBoxCasa
            // 
            this.gBoxCasa.Controls.Add(this.tbPrecio);
            this.gBoxCasa.Controls.Add(this.label8);
            this.gBoxCasa.Controls.Add(this.numUDminimo);
            this.gBoxCasa.Controls.Add(this.label7);
            this.gBoxCasa.Controls.Add(this.tbNumCasa);
            this.gBoxCasa.Controls.Add(this.label1);
            this.gBoxCasa.Controls.Add(this.numUDcamasCasa);
            this.gBoxCasa.Controls.Add(this.lbCamasCasa);
            this.gBoxCasa.Controls.Add(this.gBoxServicios);
            this.gBoxCasa.Location = new System.Drawing.Point(57, 350);
            this.gBoxCasa.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxCasa.Name = "gBoxCasa";
            this.gBoxCasa.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxCasa.Size = new System.Drawing.Size(729, 181);
            this.gBoxCasa.TabIndex = 13;
            this.gBoxCasa.TabStop = false;
            this.gBoxCasa.Text = "Casa";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(101, 137);
            this.tbPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(132, 22);
            this.tbPrecio.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 145);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Precio base";
            // 
            // numUDminimo
            // 
            this.numUDminimo.Location = new System.Drawing.Point(165, 101);
            this.numUDminimo.Margin = new System.Windows.Forms.Padding(4);
            this.numUDminimo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDminimo.Name = "numUDminimo";
            this.numUDminimo.Size = new System.Drawing.Size(69, 22);
            this.numUDminimo.TabIndex = 14;
            this.numUDminimo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Minimo dias";
            // 
            // tbNumCasa
            // 
            this.tbNumCasa.Location = new System.Drawing.Point(99, 36);
            this.tbNumCasa.Margin = new System.Windows.Forms.Padding(4);
            this.tbNumCasa.Name = "tbNumCasa";
            this.tbNumCasa.ReadOnly = true;
            this.tbNumCasa.Size = new System.Drawing.Size(135, 22);
            this.tbNumCasa.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Num. Casa";
            // 
            // numUDcamasCasa
            // 
            this.numUDcamasCasa.Location = new System.Drawing.Point(165, 68);
            this.numUDcamasCasa.Margin = new System.Windows.Forms.Padding(4);
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
            this.lbCamasCasa.Location = new System.Drawing.Point(12, 76);
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
            this.gBoxServicios.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxServicios.Name = "gBoxServicios";
            this.gBoxServicios.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxServicios.Size = new System.Drawing.Size(423, 138);
            this.gBoxServicios.TabIndex = 8;
            this.gBoxServicios.TabStop = false;
            this.gBoxServicios.Text = "Servicios";
            // 
            // checkBWiFi
            // 
            this.checkBWiFi.AutoSize = true;
            this.checkBWiFi.Location = new System.Drawing.Point(33, 100);
            this.checkBWiFi.Margin = new System.Windows.Forms.Padding(4);
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
            this.checkBLimpieza.Margin = new System.Windows.Forms.Padding(4);
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
            this.checkBDesayuno.Margin = new System.Windows.Forms.Padding(4);
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
            this.checkBMascota.Margin = new System.Windows.Forms.Padding(4);
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
            this.checkBPileta.Margin = new System.Windows.Forms.Padding(4);
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
            this.checkBCochera.Margin = new System.Windows.Forms.Padding(4);
            this.checkBCochera.Name = "checkBCochera";
            this.checkBCochera.Size = new System.Drawing.Size(80, 20);
            this.checkBCochera.TabIndex = 7;
            this.checkBCochera.Text = "Cochera";
            this.checkBCochera.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGuardar.Location = new System.Drawing.Point(205, 560);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(460, 560);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ABMAlojamientosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 612);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gBoxCasa);
            this.Controls.Add(this.gBoxHotel);
            this.Controls.Add(this.gbCasaHotel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ABMAlojamientosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altas, Bajas, Modificaciones";
            this.gbCasaHotel.ResumeLayout(false);
            this.gbCasaHotel.PerformLayout();
            this.gBoxHotel.ResumeLayout(false);
            this.gBoxHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUtriples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdobles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUsimples)).EndInit();
            this.gBoxCasa.ResumeLayout(false);
            this.gBoxCasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDminimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDcamasCasa)).EndInit();
            this.gBoxServicios.ResumeLayout(false);
            this.gBoxServicios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Direccion;
        public System.Windows.Forms.NumericUpDown numUDcamasCasa;
        private System.Windows.Forms.GroupBox gBoxServicios;
        public System.Windows.Forms.CheckBox checkBWiFi;
        public System.Windows.Forms.CheckBox checkBLimpieza;
        public System.Windows.Forms.CheckBox checkBDesayuno;
        public System.Windows.Forms.CheckBox checkBMascota;
        public System.Windows.Forms.CheckBox checkBPileta;
        public System.Windows.Forms.CheckBox checkBCochera;
        public System.Windows.Forms.NumericUpDown nUtriples;
        public System.Windows.Forms.NumericUpDown nUdobles;
        public System.Windows.Forms.NumericUpDown nUsimples;
        public System.Windows.Forms.CheckBox checkB3Estrellas;
        public System.Windows.Forms.GroupBox gbCasaHotel;
        public System.Windows.Forms.RadioButton rbCasa;
        public System.Windows.Forms.GroupBox gBoxHotel;
        public System.Windows.Forms.GroupBox gBoxCasa;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Label labEstado;
        public System.Windows.Forms.Button btnFotos;
        public System.Windows.Forms.Button btnAltaBaja;
        public System.Windows.Forms.NumericUpDown numUDminimo;
        public System.Windows.Forms.RadioButton rbHotel;
        public System.Windows.Forms.TextBox tbNombre;
        public System.Windows.Forms.TextBox tBdireccion;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbCamasCasa;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbNumCasa;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tbPrecio;
        public System.Windows.Forms.Label label8;
    }
}