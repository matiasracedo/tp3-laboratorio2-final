namespace TP_II
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAgregarAloj = new System.Windows.Forms.Button();
            this.btnConsultaAloj = new System.Windows.Forms.Button();
            this.btnModificarAloj = new System.Windows.Forms.Button();
            this.cbAlojamientos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.gBreservas = new System.Windows.Forms.GroupBox();
            this.btnConsultaReserva = new System.Windows.Forms.Button();
            this.btnModificarReserva = new System.Windows.Forms.Button();
            this.btnAgregarReserva = new System.Windows.Forms.Button();
            this.cbReservas = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opciones = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precioBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alojamientosStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarAlojStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.casasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.casasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verListaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.verListaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gBreservas.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAgregarAloj
            // 
            this.btnAgregarAloj.Location = new System.Drawing.Point(713, 29);
            this.btnAgregarAloj.Name = "btnAgregarAloj";
            this.btnAgregarAloj.Size = new System.Drawing.Size(75, 46);
            this.btnAgregarAloj.TabIndex = 0;
            this.btnAgregarAloj.Text = "Agregar Alojamiento";
            this.btnAgregarAloj.UseVisualStyleBackColor = true;
            this.btnAgregarAloj.Click += new System.EventHandler(this.btnAgregarAloj_Click);
            // 
            // btnConsultaAloj
            // 
            this.btnConsultaAloj.Location = new System.Drawing.Point(875, 29);
            this.btnConsultaAloj.Name = "btnConsultaAloj";
            this.btnConsultaAloj.Size = new System.Drawing.Size(75, 46);
            this.btnConsultaAloj.TabIndex = 1;
            this.btnConsultaAloj.Text = "Consultar Alojamiento";
            this.btnConsultaAloj.UseVisualStyleBackColor = true;
            this.btnConsultaAloj.Click += new System.EventHandler(this.btnConsultaAloj_Click);
            // 
            // btnModificarAloj
            // 
            this.btnModificarAloj.Location = new System.Drawing.Point(794, 29);
            this.btnModificarAloj.Name = "btnModificarAloj";
            this.btnModificarAloj.Size = new System.Drawing.Size(75, 46);
            this.btnModificarAloj.TabIndex = 2;
            this.btnModificarAloj.Text = "Modificar Alojamiento";
            this.btnModificarAloj.UseVisualStyleBackColor = true;
            this.btnModificarAloj.Click += new System.EventHandler(this.btnModificarAloj_Click);
            // 
            // cbAlojamientos
            // 
            this.cbAlojamientos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAlojamientos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAlojamientos.FormattingEnabled = true;
            this.cbAlojamientos.Location = new System.Drawing.Point(22, 29);
            this.cbAlojamientos.Name = "cbAlojamientos";
            this.cbAlojamientos.Size = new System.Drawing.Size(654, 21);
            this.cbAlojamientos.TabIndex = 3;
            this.cbAlojamientos.SelectedIndexChanged += new System.EventHandler(this.cbAlojamientos_SelectedIndexChanged);
            this.cbAlojamientos.TextChanged += new System.EventHandler(this.cbAlojamientos_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnBusqueda);
            this.groupBox1.Location = new System.Drawing.Point(28, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta general";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 72);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(512, 50);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(75, 46);
            this.btnBusqueda.TabIndex = 5;
            this.btnBusqueda.Text = "Buscar Alojamiento";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // gBreservas
            // 
            this.gBreservas.Controls.Add(this.btnConsultaReserva);
            this.gBreservas.Controls.Add(this.btnModificarReserva);
            this.gBreservas.Controls.Add(this.btnAgregarReserva);
            this.gBreservas.Controls.Add(this.cbReservas);
            this.gBreservas.Location = new System.Drawing.Point(19, 147);
            this.gBreservas.Name = "gBreservas";
            this.gBreservas.Size = new System.Drawing.Size(965, 93);
            this.gBreservas.TabIndex = 5;
            this.gBreservas.TabStop = false;
            this.gBreservas.Text = "Reservas";
            // 
            // btnConsultaReserva
            // 
            this.btnConsultaReserva.Location = new System.Drawing.Point(875, 33);
            this.btnConsultaReserva.Name = "btnConsultaReserva";
            this.btnConsultaReserva.Size = new System.Drawing.Size(75, 46);
            this.btnConsultaReserva.TabIndex = 6;
            this.btnConsultaReserva.Text = "Consultar Reserva";
            this.btnConsultaReserva.UseVisualStyleBackColor = true;
            this.btnConsultaReserva.Click += new System.EventHandler(this.btnConsultaReserva_Click);
            // 
            // btnModificarReserva
            // 
            this.btnModificarReserva.Location = new System.Drawing.Point(794, 33);
            this.btnModificarReserva.Name = "btnModificarReserva";
            this.btnModificarReserva.Size = new System.Drawing.Size(75, 46);
            this.btnModificarReserva.TabIndex = 2;
            this.btnModificarReserva.Text = "Modoficar Reserva";
            this.btnModificarReserva.UseVisualStyleBackColor = true;
            this.btnModificarReserva.Click += new System.EventHandler(this.btnModificarReserva_Click);
            // 
            // btnAgregarReserva
            // 
            this.btnAgregarReserva.Location = new System.Drawing.Point(713, 33);
            this.btnAgregarReserva.Name = "btnAgregarReserva";
            this.btnAgregarReserva.Size = new System.Drawing.Size(75, 46);
            this.btnAgregarReserva.TabIndex = 1;
            this.btnAgregarReserva.Text = "Agregar Reserva";
            this.btnAgregarReserva.UseVisualStyleBackColor = true;
            this.btnAgregarReserva.Click += new System.EventHandler(this.btnAgregarReserva_Click);
            // 
            // cbReservas
            // 
            this.cbReservas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbReservas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbReservas.FormattingEnabled = true;
            this.cbReservas.Location = new System.Drawing.Point(22, 33);
            this.cbReservas.Name = "cbReservas";
            this.cbReservas.Size = new System.Drawing.Size(654, 21);
            this.cbReservas.TabIndex = 0;
            this.cbReservas.SelectedIndexChanged += new System.EventHandler(this.cbReservas_SelectedIndexChanged);
            this.cbReservas.TextChanged += new System.EventHandler(this.cbReservas_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAlojamientos);
            this.groupBox2.Controls.Add(this.btnAgregarAloj);
            this.groupBox2.Controls.Add(this.btnModificarAloj);
            this.groupBox2.Controls.Add(this.btnConsultaAloj);
            this.groupBox2.Location = new System.Drawing.Point(19, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(965, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alojamientos";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opciones,
            this.alojamientosStripMenu,
            this.reservasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opciones
            // 
            this.opciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.restarToolStripMenuItem,
            this.precioBaseToolStripMenuItem});
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(69, 20);
            this.opciones.Text = "Opciones";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // restarToolStripMenuItem
            // 
            this.restarToolStripMenuItem.Name = "restarToolStripMenuItem";
            this.restarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.restarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.restarToolStripMenuItem.Text = "Restar...";
            this.restarToolStripMenuItem.Click += new System.EventHandler(this.restarToolStripMenuItem_Click);
            // 
            // precioBaseToolStripMenuItem
            // 
            this.precioBaseToolStripMenuItem.Name = "precioBaseToolStripMenuItem";
            this.precioBaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.precioBaseToolStripMenuItem.ShowShortcutKeys = false;
            this.precioBaseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.precioBaseToolStripMenuItem.Text = "Precio Base";
            this.precioBaseToolStripMenuItem.Click += new System.EventHandler(this.precioBaseToolStripMenuItem_Click);
            // 
            // alojamientosStripMenu
            // 
            this.alojamientosStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarAlojStripMenu,
            this.modificarToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.importarToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.verListaToolStripMenuItem,
            this.graficoToolStripMenuItem});
            this.alojamientosStripMenu.Name = "alojamientosStripMenu";
            this.alojamientosStripMenu.Size = new System.Drawing.Size(89, 20);
            this.alojamientosStripMenu.Text = "Alojamientos";
            // 
            // agregarAlojStripMenu
            // 
            this.agregarAlojStripMenu.Name = "agregarAlojStripMenu";
            this.agregarAlojStripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.agregarAlojStripMenu.Size = new System.Drawing.Size(179, 22);
            this.agregarAlojStripMenu.Text = "Agregar...";
            this.agregarAlojStripMenu.Click += new System.EventHandler(this.agregarAlojStripMenu_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.modificarToolStripMenuItem.Text = "Modificar...";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.consultarToolStripMenuItem.Text = "Consultar...";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.importarToolStripMenuItem.Text = "Importar...";
            this.importarToolStripMenuItem.Click += new System.EventHandler(this.importarToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exportarToolStripMenuItem.Text = "Exportar...";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // verListaToolStripMenuItem
            // 
            this.verListaToolStripMenuItem.Name = "verListaToolStripMenuItem";
            this.verListaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.verListaToolStripMenuItem.Text = "Ver Lista";
            this.verListaToolStripMenuItem.Click += new System.EventHandler(this.verListaToolStripMenuItem_Click);
            // 
            // graficoToolStripMenuItem
            // 
            this.graficoToolStripMenuItem.Name = "graficoToolStripMenuItem";
            this.graficoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.graficoToolStripMenuItem.Text = "Grafico";
            this.graficoToolStripMenuItem.Click += new System.EventHandler(this.graficoToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem1,
            this.modificarToolStripMenuItem1,
            this.consultarToolStripMenuItem1,
            this.importarToolStripMenuItem1,
            this.exportarToolStripMenuItem1,
            this.verListaToolStripMenuItem1});
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.reservasToolStripMenuItem.Text = "Reservas";
            // 
            // agregarToolStripMenuItem1
            // 
            this.agregarToolStripMenuItem1.Name = "agregarToolStripMenuItem1";
            this.agregarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.agregarToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.agregarToolStripMenuItem1.Text = "Agregar...";
            this.agregarToolStripMenuItem1.Click += new System.EventHandler(this.agregarToolStripMenuItem1_Click);
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            this.modificarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.modificarToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.modificarToolStripMenuItem1.Text = "Modificar...";
            this.modificarToolStripMenuItem1.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click);
            // 
            // consultarToolStripMenuItem1
            // 
            this.consultarToolStripMenuItem1.Name = "consultarToolStripMenuItem1";
            this.consultarToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.consultarToolStripMenuItem1.Text = "Consultar...";
            this.consultarToolStripMenuItem1.Click += new System.EventHandler(this.consultarToolStripMenuItem1_Click);
            // 
            // importarToolStripMenuItem1
            // 
            this.importarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.casasToolStripMenuItem,
            this.hotelesToolStripMenuItem});
            this.importarToolStripMenuItem1.Name = "importarToolStripMenuItem1";
            this.importarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.importarToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.importarToolStripMenuItem1.Text = "Importar...";
            // 
            // casasToolStripMenuItem
            // 
            this.casasToolStripMenuItem.Name = "casasToolStripMenuItem";
            this.casasToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.casasToolStripMenuItem.Text = "Casas";
            this.casasToolStripMenuItem.Click += new System.EventHandler(this.casasToolStripMenuItem_Click);
            // 
            // hotelesToolStripMenuItem
            // 
            this.hotelesToolStripMenuItem.Name = "hotelesToolStripMenuItem";
            this.hotelesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.hotelesToolStripMenuItem.Text = "Hoteles";
            this.hotelesToolStripMenuItem.Click += new System.EventHandler(this.hotelesToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem1
            // 
            this.exportarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.casasToolStripMenuItem1,
            this.hotelesToolStripMenuItem1});
            this.exportarToolStripMenuItem1.Name = "exportarToolStripMenuItem1";
            this.exportarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exportarToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.exportarToolStripMenuItem1.Text = "Exportar...";
            // 
            // casasToolStripMenuItem1
            // 
            this.casasToolStripMenuItem1.Name = "casasToolStripMenuItem1";
            this.casasToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.casasToolStripMenuItem1.Text = "Casas";
            this.casasToolStripMenuItem1.Click += new System.EventHandler(this.casasToolStripMenuItem1_Click);
            // 
            // hotelesToolStripMenuItem1
            // 
            this.hotelesToolStripMenuItem1.Name = "hotelesToolStripMenuItem1";
            this.hotelesToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.hotelesToolStripMenuItem1.Text = "Hoteles";
            this.hotelesToolStripMenuItem1.Click += new System.EventHandler(this.hotelesToolStripMenuItem1_Click);
            // 
            // verListaToolStripMenuItem1
            // 
            this.verListaToolStripMenuItem1.Name = "verListaToolStripMenuItem1";
            this.verListaToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.verListaToolStripMenuItem1.Text = "Ver Lista";
            this.verListaToolStripMenuItem1.Click += new System.EventHandler(this.verListaToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarToolStripMenuItem2,
            this.exportarToolStripMenuItem2,
            this.verListaToolStripMenuItem2,
            this.graficoToolStripMenuItem1});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // importarToolStripMenuItem2
            // 
            this.importarToolStripMenuItem2.Name = "importarToolStripMenuItem2";
            this.importarToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.importarToolStripMenuItem2.Text = "Importar...";
            this.importarToolStripMenuItem2.Click += new System.EventHandler(this.importarToolStripMenuItem2_Click);
            // 
            // exportarToolStripMenuItem2
            // 
            this.exportarToolStripMenuItem2.Name = "exportarToolStripMenuItem2";
            this.exportarToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.exportarToolStripMenuItem2.Text = "Exportar...";
            this.exportarToolStripMenuItem2.Click += new System.EventHandler(this.exportarToolStripMenuItem2_Click);
            // 
            // verListaToolStripMenuItem2
            // 
            this.verListaToolStripMenuItem2.Name = "verListaToolStripMenuItem2";
            this.verListaToolStripMenuItem2.Size = new System.Drawing.Size(129, 22);
            this.verListaToolStripMenuItem2.Text = "Ver lista";
            this.verListaToolStripMenuItem2.Click += new System.EventHandler(this.verListaToolStripMenuItem2_Click);
            // 
            // graficoToolStripMenuItem1
            // 
            this.graficoToolStripMenuItem1.Name = "graficoToolStripMenuItem1";
            this.graficoToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.graficoToolStripMenuItem1.Text = "Grafico";
            this.graficoToolStripMenuItem1.Click += new System.EventHandler(this.graficoToolStripMenuItem1_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionToolStripMenuItem});
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // informacionToolStripMenuItem
            // 
            this.informacionToolStripMenuItem.Name = "informacionToolStripMenuItem";
            this.informacionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.informacionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.informacionToolStripMenuItem.Text = "Informacion";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 258);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gBreservas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservas 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gBreservas.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAgregarAloj;
        private System.Windows.Forms.Button btnConsultaAloj;
        private System.Windows.Forms.Button btnModificarAloj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gBreservas;
        private System.Windows.Forms.Button btnConsultaReserva;
        private System.Windows.Forms.Button btnModificarReserva;
        private System.Windows.Forms.Button btnAgregarReserva;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cbAlojamientos;
        public System.Windows.Forms.ComboBox cbReservas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opciones;
        private System.Windows.Forms.ToolStripMenuItem alojamientosStripMenu;
        private System.Windows.Forms.ToolStripMenuItem agregarAlojStripMenu;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verListaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem precioBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verListaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem casasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem casasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hotelesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem graficoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficoToolStripMenuItem1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

