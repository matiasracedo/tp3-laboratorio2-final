using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace TP_II
{
    public partial class Form1 : Form, IInterectuable
    {

        Color[] paleta= new Color[5];
        Empresa empresa;
        ConsultaForm vConsulta = null;
        string nombreArchivo = Application.StartupPath + @"\persistencia.dat";
        bool restart = false;
        bool primeraVez = false;
        Image[] imagenes; // Imagenes de un alojamiento
        List<Cliente> pasajeros = new List<Cliente>(); // Pasajeros adicionales reserva
        int capacidad = 0; // Auxiliar para evento click agregar pasajeros
        Reserva temp = null; // Objeto auxiliar para imprimir comprobante 
        int copia = 0; // Para comprobante duplicado                          
        GraficoForm vGrafico;
       
        public Form1()
        {
            InitializeComponent();
            btnModificarAloj.Enabled = false;
            btnModificarReserva.Enabled = false;
            btnConsultaAloj.Enabled = false;
            btnConsultaReserva.Enabled = false;
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            if (File.Exists(nombreArchivo))
            {
                try
                {
                    fs = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                    BinaryFormatter bf = new BinaryFormatter();

                    empresa = (Empresa)bf.Deserialize(fs);
                    Reserva.ContIdReservas = empresa.contBackReservas;
                    Cliente.ContIdCliente = empresa.contBackCliente;
                    Alojamiento.ContIdAlojamiento = empresa.contBackAlojamientos;
                    Casa.ContCasa = empresa.contBackCasas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ActualizarListas();
                    if (fs != null)
                        fs.Close();
                }        
            }
            else
            {
                empresa = new Empresa();
                primeraVez = true;
                ActualizarListas();
            }
            Form_Inicio();
            Pintarcontroles(this);    
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream archivo = null;
            if (!restart)
            {
                try
                {
                    archivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    empresa.contBackReservas = Reserva.ContIdReservas;
                    empresa.contBackCliente = Cliente.ContIdCliente;
                    empresa.contBackAlojamientos = Alojamiento.ContIdAlojamiento;
                    empresa.contBackCasas = Casa.ContCasa;
                    bf.Serialize(archivo, empresa);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ActualizarListas();
                    if (archivo != null)
                        archivo.Close();
                }
            }
        }
        private void Form_Inicio()
        {
            InicioForm vInicio = new InicioForm();
            if (empresa.Preguntar)
            {
                if (primeraVez)
                {
                    vInicio.rbSi.Checked = true;
                    vInicio.rbNo.Enabled = false;
                }
                vInicio.btnContinuar.Enabled = false;
                vInicio.rb5.Checked = true;
                SetColors(1);
                vInicio.p1.BackColor = GetColors(5);
                SetColors(2);
                vInicio.p2.BackColor = GetColors(5);
                SetColors(3);
                vInicio.p3.BackColor = GetColors(5);
                SetColors(4);
                vInicio.p4.BackColor = GetColors(4);
                vInicio.p5.BackColor = GetColors(2);
                SetColors(5);
                vInicio.p6.BackColor = GetColors(5);
                vInicio.p7.BackColor = GetColors(2);
                Pintarcontroles(vInicio);
                vInicio.tbRazonSocial.Text = empresa.RazonSocial;

                try
                {
                    if (vInicio.ShowDialog() == DialogResult.OK)
                    {
                        empresa.Preguntar = !vInicio.cbPreguntar.Checked;

                            if (vInicio.rbSi.Checked)
                            {
                                empresa.PrecioBaseHotel = Convert.ToDouble(vInicio.tbPrecio.Text);
                                empresa.RazonSocial = vInicio.tbRazonSocial.Text;
                            }

                            if (vInicio.rb1.Checked)
                                SetColors(1);
                            if (vInicio.rb2.Checked)
                                SetColors(2);
                            if (vInicio.rb3.Checked)
                                SetColors(3);
                            if (vInicio.rb4.Checked)
                                SetColors(4);
                            if (vInicio.rb5.Checked)
                                SetColors(5);
            
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    empresa.Preguntar = true;
                    Form_Inicio();

                }

            }
            else
            {
                SetColors(empresa.IndiceColor);
            }

            if (cbAlojamientos.Text != "" || cbAlojamientos.SelectedIndex != -1)
            {
                btnModificarAloj.Enabled = true;
                btnConsultaAloj.Enabled = true;
                modificarToolStripMenuItem.Enabled = true;
                consultarToolStripMenuItem.Enabled = true;

            }
            else
            {
                btnConsultaAloj.Enabled = false;
                btnModificarAloj.Enabled = false;
                modificarToolStripMenuItem.Enabled = false;
                consultarToolStripMenuItem.Enabled = false;
            }
            vInicio.Dispose();
        }
        public Color GetColors(int i)
        {
            return paleta[i - 1];
        }
        public void SetColors(int i)
        {
            empresa.IndiceColor = i;
            switch (i)
            {
                case 1:
                    {
                        paleta[0] = Color.FromArgb(255, 212, 165, 189);
                        paleta[1] = Color.FromArgb(255, 194, 148, 171);
                        paleta[2] = Color.FromArgb(255, 175, 130, 154);
                        paleta[3] = Color.FromArgb(255, 157, 113, 136);
                        paleta[4] = Color.FromArgb(255, 138, 95, 118);
                    }
                    break;
                case 2:
                    {
                        paleta[4] = Color.FromArgb(255, 165, 183, 149);
                        paleta[3] = Color.FromArgb(255, 185, 201, 174);
                        paleta[2] = Color.FromArgb(255, 208, 219, 199);
                        paleta[1] = Color.FromArgb(255, 232, 237, 224);
                        paleta[0] = Color.FromArgb(255, 255, 255, 249);
                    }
                    break;
                case 3:
                    {
                        paleta[0] = Color.FromArgb(255, 255, 255, 161);
                        paleta[1] = Color.FromArgb(255, 248, 209, 113);
                        paleta[2] = Color.FromArgb(255, 88, 122, 168);
                        paleta[3] = Color.FromArgb(255, 245, 186, 88);
                        paleta[4] = Color.FromArgb(255, 241, 163, 64);
                    }
                    break;
                case 4:
                    {
                        paleta[0] = Color.FromArgb(255, 76, 167, 203);
                        paleta[1] = Color.FromArgb(255, 57, 150, 185);
                        paleta[2] = Color.FromArgb(255, 38, 133, 167);
                        paleta[3] = Color.FromArgb(255, 19, 115, 149);
                        paleta[4] = Color.FromArgb(255, 76, 86, 84);
                    }
                    break;
                case 5:
                    {
                        paleta[0] = Color.FromArgb(255, 255, 248, 212);
                        paleta[1] = Color.FromArgb(255, 245, 223, 152);
                        paleta[2] = Color.FromArgb(255, 175, 130, 154);
                        paleta[3] = Color.FromArgb(255, 192, 209, 194);
                        paleta[4] = Color.FromArgb(255, 46, 67, 71);

                    }
                    break;
            }
        }

        ///------------------------------------------------------------------------------------------------
        ///Métodos de IInteractuable
        ///Métodos de IInteractuable
        ///Métodos de IInteractuable
        public ArrayList ActualizarConsulta()
        {
            List<Alojamiento> nuevos = new List<Alojamiento>();
            ConsultaForm c = vConsulta;

            //////servicios:

            List<string> s = new List<string>();
            if (c.checkBCochera.Checked) s.Add(c.checkBCochera.Text);
            if (c.checkBPileta.Checked) s.Add(c.checkBPileta.Text);
            if (c.checkBWiFi.Checked) s.Add(c.checkBWiFi.Text);
            if (c.checkBLimpieza.Checked) s.Add(c.checkBLimpieza.Text);
            if (c.checkBDesayuno.Checked) s.Add(c.checkBDesayuno.Text);
            if (c.checkBMascota.Checked) s.Add(c.checkBMascota.Text);

            String[] servicios = s.ToArray();

            ////////////

            if (c.checkBoxCasa.Checked == true && c.checkBoxHotel.Checked == false)
                nuevos.AddRange(empresa.FiltrarCasas(Convert.ToInt16(c.numUDcamasCasa.Value), servicios));
            else if (c.checkBoxCasa.Checked == false && c.checkBoxHotel.Checked == true)
            {
                nuevos.AddRange(empresa.FiltrarHoteles(c.checkB3Estrellas.Checked));
            }
            else if (c.checkBoxCasa.Checked && c.checkBoxHotel.Checked)
            {
                nuevos.AddRange(empresa.FiltrarCasas(Convert.ToInt16(c.numUDcamasCasa.Value), servicios));
                nuevos.AddRange(empresa.FiltrarHoteles(c.checkB3Estrellas.Checked));
            }
            if (c.checkBoxFiltrarPorLugar.Checked == true)
            {
                string ciudad= c.cBoxCiudad.Text.Trim(' ');
                if (ciudad != "")
                    empresa.FiltrarLugarRango(nuevos, c.cBoxProvincia.Text, ciudad);
                else
                    MessageBox.Show("No hay establecimientos en la provincia solicitada");

            }

            if (c.chechBoxFiltrarPorFecha.Checked)
            {
                empresa.FiltrarFechaRango(nuevos, c.dtPickerInicio.Value, c.dtPickerFinal.Value);
            }
            ArrayList a = new ArrayList();
            a.AddRange(nuevos);

            return a;
        }
        public void Pintarcontroles(Form f)
        {
            // ----------------------- Color set -------------------------------- //
            // -------------------------------------------------------------------//
            f.BackColor = GetColors(5);

            foreach (Control control in f.Controls)
            {
                if (control is MenuStrip || control is Button)
                { control.BackColor = GetColors(2); }
                if (control is DataGridView)
                { control.BackColor = GetColors(1); }

                if (control is GroupBox)
                {
                    control.BackColor = GetColors(4);
                    foreach (Control subControl in control.Controls)
                    {
                        if (subControl is Button || subControl is ComboBox)
                        { subControl.BackColor = GetColors(2); }

                        if (subControl is TextBox || subControl is NumericUpDown)
                        { subControl.BackColor = GetColors(1); }

                        if (subControl is DateTimePicker)
                        {
                            ((DateTimePicker)subControl).CalendarMonthBackground = GetColors(1);
                        }
                    }
                }

            }

            // -------------------------------------------------------------------//
            // ----------------------- Color set -------------------------------- //
        }
        public void EmitirComprobante(Reserva r)
        {
            ComprobanteForm comprobante = new ComprobanteForm();
            Pintarcontroles(comprobante);
            string[] datos = r.DatosComprobante;
            temp = r;

            // Manejo evento click del boton "Imprimir" en ventana ComprobanteForm
            comprobante.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);

            comprobante.lbComprobante.Items.Add("Fecha: " + datos[3]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add(datos[0]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add(datos[2]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Pasajeros admitidos: " + datos[1]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Acompañantes: ");

            string acom = datos[7].TrimEnd('-');
            if (acom != "")
            {

                List<string> nombres = new List<string>();
                if (acom.Contains('-'))
                    nombres.AddRange(acom.Split('-'));
                else
                    nombres.Add(acom);

                foreach (string s in nombres)
                    comprobante.lbComprobante.Items.Add("             -" + s);
            }
            else
                comprobante.lbComprobante.Items.Add("          --- No hay --");
            //comprobante.lbComprobante.Items.Add(datos[7]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add(datos[4]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Costo por dia " + String.Format("${0:C2}", datos[5]));
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Precio total " + String.Format("${0:C2}", datos[6]));

            comprobante.ShowDialog();
            comprobante.Dispose();
            // Quito evento click del boton "Imprimir" en ventana ComprobanteForm
            comprobante.btnImprimir.Click -= new System.EventHandler(this.btnImprimir_Click);
            temp = null;
        }
        public object BuscarAlojamiento(object unAlojameinto)
        {
            return empresa[((Alojamiento)unAlojameinto).Direccion];// indexador de empresa    
        }
        public void AgregarReserva(object r)
        {
            empresa.AgregarReservas((Reserva)r);
        }

        public int[] ListaHabitaciones(int tipoHab, object hotel)
        {
            Hotel actual = hotel as Hotel;
            int[] retorno = null;
            List<Habitacion> habitaciones = actual[tipoHab];


            if (habitaciones != null)
            {
                retorno = new int[habitaciones.Count];

                for (int i = 0; i < habitaciones.Count; i++)
                {
                    retorno[i] = habitaciones[i].Numero;
                }
            }

            return retorno;
        }

        public double GetPrecioBaseHoteles()
        {
            return empresa.PrecioBaseHotel;
        }

        


        ///------------------------------------------------------------------------------------------------


        ///------------------------------------------------------------------------------------------------
        ///Acciones de Botones
        private void btnAgregarAloj_Click(object sender, EventArgs e)
        {
            ABMAlojamientosForm ventanaABM = new ABMAlojamientosForm();
            ventanaABM.setInteractor(this);
            ventanaABM.btnExportarR.Enabled = false;
            ventanaABM.btnImportarR.Enabled = false;
            bool hotel;
            string direccion;
            string nombre;
            bool tresEstrellas;
            int simples;
            int dobles;
            int triples;
            int numCasa = empresa.NumeroCasaSiguiente;
            int cantCamas;
            int minDias;
            double precioBase;
            string[] servicios;
            imagenes = new Image[5];
            string jurisdiccion;
            string ciudad;

            // Visibilidad controles estado
            ventanaABM.labEstado.Visible = false;
            ventanaABM.btnAltaBaja.Visible = false;
            // Manejo evento click del boton "Importar fotos" en ventana ABM
            ventanaABM.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);       

            ventanaABM.cBoxProvincia.Items.AddRange(empresa.Jurisdicciones.ToArray());
            ventanaABM.tbNumCasa.Text = numCasa.ToString();
            Pintarcontroles(ventanaABM);

            if (ventanaABM.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Alojamiento alojamiento = null;

                    direccion = ventanaABM.tBdireccion.Text;
                    hotel = ventanaABM.rbHotel.Checked;
                    jurisdiccion = ventanaABM.cBoxProvincia.Text;
                    ciudad = ventanaABM.cBoxCiudad.Text;

                    if (hotel)
                    {
                        nombre = ventanaABM.tbNombre.Text;
                        tresEstrellas = ventanaABM.checkB3Estrellas.Checked;
                        simples = Convert.ToInt32(ventanaABM.nUsimples.Value);
                        dobles = Convert.ToInt32(ventanaABM.nUdobles.Value);
                        triples = Convert.ToInt32(ventanaABM.nUtriples.Value);
                    
                        alojamiento = new Hotel(direccion, jurisdiccion, ciudad, nombre, tresEstrellas, simples, dobles, triples);
                    }
                    else
                    {
                        ventanaABM.tbNumCasa.Text = numCasa.ToString();
                        cantCamas = Convert.ToInt32(ventanaABM.numUDcamasCasa.Value);
                        minDias = Convert.ToInt32(ventanaABM.numUDminimo.Value);
                        precioBase = Convert.ToDouble(ventanaABM.tbPrecio.Text);



                        List<string> s = new List<string>();
                        if (ventanaABM.checkBCochera.Checked) s.Add(ventanaABM.checkBCochera.Text);
                        if (ventanaABM.checkBPileta.Checked) s.Add(ventanaABM.checkBPileta.Text);
                        if (ventanaABM.checkBWiFi.Checked) s.Add(ventanaABM.checkBWiFi.Text);
                        if (ventanaABM.checkBLimpieza.Checked) s.Add(ventanaABM.checkBLimpieza.Text);
                        if (ventanaABM.checkBDesayuno.Checked) s.Add(ventanaABM.checkBDesayuno.Text);
                        if (ventanaABM.checkBMascota.Checked) s.Add(ventanaABM.checkBMascota.Text);

                        servicios = new string[s.Count];
                        for (int i = 0; i < s.Count; i++)
                            servicios[i] = s[i];

                        alojamiento = new Casa(direccion, jurisdiccion, ciudad, minDias, cantCamas, servicios, precioBase);
        
                    }
                    alojamiento.Imagenes = imagenes;

                    empresa.AgregarAlojamiento(alojamiento);
                    ActualizarListas();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            // Quito evento click del boton "Importar fotos" en ventana ABM
            ventanaABM.btnFotos.Click -= new System.EventHandler(this.btnFotos_Click);
            ventanaABM.Dispose();
        }

        //Evento click boton Importar fotos ventana ABM Alojamientos
        private void btnFotos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImageFile = new OpenFileDialog();
            // Filtrar solo imagenes
            openImageFile.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF;*.JPEG";

            //Permitir al usuario seleccionar multiples archivos
            openImageFile.Multiselect = true;
            openImageFile.Title = "Fotos del alojamiento";

            if (openImageFile.ShowDialog() == DialogResult.OK)
            {
                // Leo los archivos de imagen
                int i = 0;
                foreach (String file in openImageFile.FileNames)
                {
                    try
                    {
                        Image loadedImage = Image.FromFile(file);
                        imagenes[i] = loadedImage;
                        i++;
                    }
                    catch (Exception ex)
                    {
                        // No pudo cargarse la imagen
                        MessageBox.Show("No pudo cargarse la imagen: " + file.Substring(file.LastIndexOf('\\'))
                            + "\n\nError: " + ex.Message);
                    }
                }
            }
            openImageFile.Dispose();
        }
     
        private void btnModificarAloj_Click(object sender, EventArgs e)
        {
            ABMAlojamientosForm vModificacion = new ABMAlojamientosForm();
            Pintarcontroles(vModificacion);
            vModificacion.setInteractor(this);

            int indice = cbAlojamientos.SelectedIndex;
            Alojamiento alojamiento = empresa.Alojamientos[indice];
            imagenes = new Image[5];
            // Manejo evento click del boton "Importar fotos" en ventana ABM
            vModificacion.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);

            vModificacion.cBoxProvincia.Items.AddRange(empresa.Jurisdicciones.ToArray());
            vModificacion.cBoxCiudad.Items.AddRange(empresa.Ciudades(alojamiento.Jurisdiccion).ToArray());

            vModificacion.cBoxProvincia.Text = alojamiento.Jurisdiccion;
            vModificacion.cBoxCiudad.Text = alojamiento.Ciudad;

            // Manejo evento click del boton "Exportar Reservas" en ventana ABM
            vModificacion.btnExportarR.Click += new System.EventHandler(this.btnExportarR_Click);
            // Manejo evento click del boton "Importar Reservas" en ventana ABM
            vModificacion.btnImportarR.Click += new System.EventHandler(this.btnImportarR_Click);

            if (alojamiento is Hotel)
            {
                vModificacion.rbCasa.Enabled = false;
                Hotel unHotel = (Hotel)alojamiento;
                vModificacion.rbHotel.Checked = true;
                vModificacion.tbNombre.Text = unHotel.Nombre;
                vModificacion.checkB3Estrellas.Checked = unHotel.TresEstrellas;
                vModificacion.nUsimples.Value = unHotel.Simples.Count;
                vModificacion.nUdobles.Value = unHotel.Dobles.Count;
                vModificacion.nUtriples.Value = unHotel.Triples.Count;
                vModificacion.tBdireccion.Text = unHotel.Direccion;
            }
            else
            {
                vModificacion.rbHotel.Enabled = false;
                Casa unaCasa = (Casa)alojamiento;
                vModificacion.tBdireccion.Text = unaCasa.Direccion;
                vModificacion.tbNumCasa.Text = unaCasa.Numero.ToString();
                vModificacion.numUDcamasCasa.Value = unaCasa.Camas;
                vModificacion.numUDminimo.Value = unaCasa.MinDias;
                vModificacion.tbPrecio.Text = unaCasa.PrecioBaseCasa.ToString();
                vModificacion.checkBCochera.Checked = unaCasa.Servicios.Contains("Cochera");
                vModificacion.checkBPileta.Checked = unaCasa.Servicios.Contains("Pileta");
                vModificacion.checkBWiFi.Checked = unaCasa.Servicios.Contains("WI-FI");
                vModificacion.checkBLimpieza.Checked = unaCasa.Servicios.Contains("Limpieza");
                vModificacion.checkBDesayuno.Checked = unaCasa.Servicios.Contains("Desayuno");
                vModificacion.checkBMascota.Checked = unaCasa.Servicios.Contains("Admite Mascota");

            }

            if (alojamiento.Alta)
            {
                vModificacion.btnAltaBaja.Text = "Dar de Baja";
                vModificacion.labEstado.Text = "Activado";
                vModificacion.labEstado.Enabled = true;
            }
            else
            {
                vModificacion.btnAltaBaja.Text = "Dar de Alta";
                vModificacion.labEstado.Text = "Desactivado";
                vModificacion.labEstado.Enabled = false;
            }
            vModificacion.nUsimples.Enabled = false;
            vModificacion.nUdobles.Enabled = false;
            vModificacion.nUtriples.Enabled = false;
          
            // ESTE AGREGA EL EVENTO MISMO PARA QUE VUELVA A ACTUALIZAR DE NUEVO EL cBoxCiudad

            if (vModificacion.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Reemplazo las imagenes si seleccione nuevas
                    if (imagenes.Length > 0)
                        alojamiento.Imagenes = imagenes;

                    bool esHotel = vModificacion.rbHotel.Checked;

                    if (vModificacion.labEstado.Text == "Activado")
                        alojamiento.Alta = true;
                    else
                        alojamiento.Alta = false;

                    string jurisd = vModificacion.cBoxProvincia.Text.Trim();
                    string ciudad = vModificacion.cBoxCiudad.Text.Trim();


                        alojamiento.Jurisdiccion = jurisd;

                        alojamiento.Ciudad = ciudad;

                    empresa.AgregarLugar(jurisd, ciudad);// si se repite lo resuelve el método

                    if (esHotel)
                    {
                        Hotel unHotel = (Hotel)alojamiento;
                        unHotel.Direccion = vModificacion.tBdireccion.Text.Trim();
                        unHotel.Nombre = vModificacion.tbNombre.Text.Trim();
                        unHotel.TresEstrellas = vModificacion.checkB3Estrellas.Checked;
                    }
                    else
                    {
                        Casa unaCasa = (Casa)alojamiento;
                        List<string> s = new List<string>();
                        if (vModificacion.checkBCochera.Checked) s.Add(vModificacion.checkBCochera.Text);
                        if (vModificacion.checkBPileta.Checked) s.Add(vModificacion.checkBPileta.Text);
                        if (vModificacion.checkBWiFi.Checked) s.Add(vModificacion.checkBWiFi.Text);
                        if (vModificacion.checkBLimpieza.Checked) s.Add(vModificacion.checkBLimpieza.Text);
                        if (vModificacion.checkBDesayuno.Checked) s.Add(vModificacion.checkBDesayuno.Text);
                        if (vModificacion.checkBMascota.Checked) s.Add(vModificacion.checkBMascota.Text);

                        string[] servicios = new string[s.Count];
                        for (int i = 0; i < s.Count; i++)
                        {
                            servicios[i] = s[i];
                        }

                        unaCasa.Direccion = vModificacion.tBdireccion.Text.Trim();
                        unaCasa.Servicios = servicios;
                        unaCasa.Camas = Convert.ToInt32(vModificacion.numUDcamasCasa.Value);
                        unaCasa.MinDias = Convert.ToInt32(vModificacion.numUDminimo.Value);
                        unaCasa.PrecioBaseCasa = Convert.ToInt32(vModificacion.tbPrecio.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
            }
            ActualizarListas();
            cbAlojamientos.ResetText();
            cbAlojamientos.SelectedIndex = -1;
            // Quito evento click del boton "Importar fotos" en ventana ABM
            vModificacion.btnFotos.Click -= new System.EventHandler(this.btnFotos_Click);
            // Quito evento click del boton "Exportar Reservas" en ventana ABM
            vModificacion.btnExportarR.Click -= new System.EventHandler(this.btnExportarR_Click);
            // Quito evento click del boton "Importar Reservas" en ventana ABM
            vModificacion.btnImportarR.Click -= new System.EventHandler(this.btnImportarR_Click);
            vModificacion.Dispose();
        }

        //Evento click boton Exportar Reservas ventana ABM Alojamientos
        private void btnExportarR_Click(object sender, EventArgs e)
        {
            int indice = cbAlojamientos.SelectedIndex;
            Alojamiento alojamiento = empresa.Alojamientos[indice];

            string path;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            if (alojamiento is Hotel)
                sfd.FileName = string.Format("Exportacion Reservas de Hotel-{0}-{1}", ((Hotel)alojamiento).Nombre, ((Hotel)alojamiento).Direccion);
            else
                sfd.FileName = string.Format("Exportacion Reservas de Casa-{0}-{1}", ((Casa)alojamiento).Numero, ((Casa)alojamiento).Direccion);  

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = sfd.FileName;
                    empresa.ExportarReservasDeAlojamiento(alojamiento, path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Evento click boton Importar Reservas ventana ABM Alojamientos
        private void btnImportarR_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> d=new Dictionary<int, string>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.DefaultExt = ".txt";
            ofd.AddExtension = true;

            string path;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                
                path = ofd.FileName;
                d=empresa.ImportarReservasDeAlojamiento(path);
                
                ofd.Dispose();
                  
                AlojamientosExistentesForm vInforme = new AlojamientosExistentesForm();
                if(d.Count > 0)
                {
                    vInforme.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES ERRORES");
                    vInforme.listBox1.Items.Add("");
                    foreach (KeyValuePair<int, string> error in d)
                        vInforme.listBox1.Items.Add(string.Format("Error en Linea: {0} ----- {1}",error.Key,error.Value));
                }
                else
                    vInforme.listBox1.Items.Add("Carga Exitosa, no se encontraron errores");
                vInforme.ShowDialog();
                vInforme.Dispose();
            }
        }

        //Evento click boton Agregar pasajeros ventana DatosCliente
        public void btnPasajeros_Click(object sender, EventArgs e)
        {
            DatosClienteForm vPasajero = new DatosClienteForm();
            Pintarcontroles(vPasajero);
            vPasajero.btnPasajeros.Visible = false;
            if (pasajeros.Count < (capacidad - 1)) 
            {
                if (vPasajero.ShowDialog() == DialogResult.OK)
                {
                    string nombre = vPasajero.tbNombre.Text;
                    string apellido = vPasajero.tbApellido.Text;
                    int dni = Convert.ToInt32(vPasajero.tbDni.Text);
                    DateTime fNacimiento = vPasajero.fNacimiento.Value;
                    Cliente cliente = new Cliente(nombre, apellido, dni, fNacimiento);
                    pasajeros.Add(cliente);
                    capacidad -= 1;
                }
            }
            else MessageBox.Show("Capacidad del alojamiento alcanzada.");  
        }

        private void btnConsultaAloj_Click(object sender, EventArgs e)
        {
            AlojamientoForm vAlojomiento = new AlojamientoForm();

            Pintarcontroles(vAlojomiento);
            vAlojomiento.btnCancelarReserva.Visible = false;
            string[] campos = new string[2];
            campos = cbAlojamientos.Text.Split('-');
            string direccion = campos[1].TrimEnd(' ').TrimStart(' ');

           

            try
            {
                Alojamiento aBuscar = new Casa(direccion, "a", "a", 1, 1, null, 1.0);
                aBuscar = (Alojamiento)this.BuscarAlojamiento(aBuscar);
                DateTime[] fechas;
                vAlojomiento.SetAlojamiento(aBuscar);

                if (aBuscar is Casa)
                {
                    fechas = aBuscar.IntervaloFechasReservadas();
                    Casa casa = (Casa)aBuscar;
                    vAlojomiento.nudDias.Minimum = casa.MinDias;
                    vAlojomiento.nudDias.Value = casa.MinDias;
                    vAlojomiento.Calendario.BoldedDates = fechas;//pintar calendario casa

                    vAlojomiento.lbDescripcion.Text = casa.ToString();
                    vAlojomiento.cBoxNroHabitaciones.Enabled = false;
                    vAlojomiento.cBoxTipoHab.Enabled = false;
                    vAlojomiento.lbNumHabitacion.Text = "Capacidad: " + casa.Camas.ToString() + " personas";
                    capacidad = casa.Camas;

                    if (vAlojomiento.ShowDialog() == DialogResult.OK)
                    {
                        int dias = Convert.ToInt32(vAlojomiento.nudDias.Value);
                        DateTime inicio = vAlojomiento.Calendario.SelectionStart;
                        DateTime fin = inicio.AddDays(dias - 1);
                        if (!casa.CheckFecha(inicio, fin))
                            MessageBox.Show("Rango de fecha invalido");
                        else
                        {
                            DatosClienteForm vCliente = new DatosClienteForm();
                            Pintarcontroles(vCliente);
                            // Manejo evento click del boton "Agregar pasajeros" en ventana DatosCliente
                            vCliente.btnPasajeros.Click += new System.EventHandler(this.btnPasajeros_Click);

                            if (vCliente.ShowDialog() == DialogResult.OK)
                            {
                                string nombre = vCliente.tbNombre.Text;
                                string apellido = vCliente.tbApellido.Text;
                                int dni = Convert.ToInt32(vCliente.tbDni.Text);
                                DateTime fNacimiento = vCliente.fNacimiento.Value;
                                Cliente cliente = new Cliente(nombre, apellido, dni, fNacimiento);
                                Reserva reserva;
                                if (pasajeros.Count > 0)
                                {
                                    reserva = new Reserva(cliente, casa, inicio, fin, casa.PrecioBaseCasa, pasajeros);
                                    pasajeros.Clear();
                                }
                                else
                                    reserva = new Reserva(cliente, casa, inicio, fin, casa.PrecioBaseCasa);
                                this.AgregarReserva(reserva);
                                EmitirComprobante(reserva);
                            }

                            // Quito evento click del boton "Agregar pasajeros" en ventana DatosCliente
                            vCliente.btnPasajeros.Click -= new System.EventHandler(this.btnPasajeros_Click);
                        }
                    }
                }
                else
                {
                    Hotel hotel = (Hotel)aBuscar;
                    vAlojomiento.SetConsultor(this);
                    vAlojomiento.SetAlojamiento(hotel);

                    vAlojomiento.lbDescripcion.Text = "Tipo Habitación:";
                    vAlojomiento.cBoxTipoHab.Enabled = true;
                    vAlojomiento.cBoxNroHabitaciones.Enabled = true;


                    if (vAlojomiento.ShowDialog() == DialogResult.OK)
                    {
                        int dias = 0;
                        int nroHabitacion = 0;
                        DateTime inicio = new DateTime();
                        DateTime fin = new DateTime();
                        try
                        {
                            dias = Convert.ToInt32(vAlojomiento.nudDias.Value);
                            nroHabitacion = Convert.ToInt32(vAlojomiento.cBoxNroHabitaciones.Text);
                            inicio = vAlojomiento.Calendario.SelectionStart;
                            fin = inicio.AddDays(dias - 1);
                            if (!hotel.CheckFechaHabitacion(inicio, fin, nroHabitacion))
                                MessageBox.Show("Rango de fecha invalido para la habitación nro " + nroHabitacion);
                            else
                            {
                                DatosClienteForm vCliente = new DatosClienteForm();
                                switch (vAlojomiento.cBoxTipoHab.Text)
                                {
                                    case "Simple":
                                        capacidad = 1;
                                        break;
                                    case "Doble":
                                        capacidad = 2;
                                        break;
                                    case "Triple":
                                        capacidad = 3;
                                        break;
                                }
                                // Manejo evento click del boton "Agregar pasajeros" en ventana DatosCliente
                                vCliente.btnPasajeros.Click += new System.EventHandler(this.btnPasajeros_Click);

                                if (vCliente.ShowDialog() == DialogResult.OK)
                                {
                                    string nombre = vCliente.tbNombre.Text;
                                    string apellido = vCliente.tbApellido.Text;
                                    int dni = Convert.ToInt32(vCliente.tbDni.Text);
                                    DateTime fNacimiento = vCliente.fNacimiento.Value;

                                    try
                                    {
                                        Habitacion reservada = hotel.GetHabitacion(nroHabitacion);
                                        Cliente cliente = new Cliente(nombre, apellido, dni, fNacimiento);
                                        Reserva reserva;
                                        if (pasajeros.Count > 0)
                                        {
                                            reserva = new Reserva(cliente, hotel, inicio, fin, GetPrecioBaseHoteles(), reservada, pasajeros);
                                            pasajeros.Clear();
                                        }
                                        else
                                            reserva = new Reserva(cliente, hotel, inicio, fin, GetPrecioBaseHoteles(), reservada);
                                        hotel.AgregarReserva(nroHabitacion, reserva);
                                        AgregarReserva(reserva);
                                        EmitirComprobante(reserva);
                                    }
                                    catch (Exception)
                                    {

                                        MessageBox.Show("Error en los Datos ingresados");
                                    }

                                }
                                // Quito evento click del boton "Agregar pasajeros" en ventana DatosCliente
                                vCliente.btnPasajeros.Click -= new System.EventHandler(this.btnPasajeros_Click);
                                vCliente.Dispose();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error en el Ingreso de datos para la reserva");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            vAlojomiento.Dispose();
            ActualizarListas();
        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            vConsulta = new ConsultaForm();
            Pintarcontroles(vConsulta);
            vConsulta.gBoxFiltroFecha.Enabled = false;
            vConsulta.dtPickerInicio.Value = DateTime.Now;
            vConsulta.dtPickerFinal.Value = DateTime.Now.AddDays(20);

            vConsulta.SetConsultor(this);
            vConsulta.cBoxProvincia.Items.AddRange(empresa.Jurisdicciones.ToArray());
            vConsulta.ShowDialog();
            ActualizarListas();
            vConsulta.Dispose();
        }

        private void btnConsultaReserva_Click(object sender, EventArgs e)
        {
            int indice = cbReservas.SelectedIndex;
            Reserva unaReserva = empresa.ListaDeReservas[indice];
            Alojamiento unAlojamiento = unaReserva.Alojamiento;
            AlojamientoForm vAlojomiento = new AlojamientoForm();
            Pintarcontroles(vAlojomiento);
            vAlojomiento.btnCancelarReserva.Enabled = false;
            vAlojomiento.btnReservar.Enabled = false;
            vAlojomiento.btnImprimir.Enabled = true;

            vAlojomiento.Calendario.SetDate(unaReserva.Ingreso);
            vAlojomiento.Calendario.SelectionStart = unaReserva.Ingreso;

            if (unAlojamiento is Casa)
            {
                Casa casa = (Casa)unAlojamiento;
                vAlojomiento.SetAlojamiento(casa);
                vAlojomiento.nudDias.Minimum = casa.MinDias;
                vAlojomiento.nudDias.Value = unaReserva.Dias;
                DateTime[] fechasPintar;
                fechasPintar = unAlojamiento.IntervaloFechasReservadas();
                vAlojomiento.Calendario.BoldedDates = fechasPintar; //pintar calendario casa
                vAlojomiento.lbDescripcion.Text = casa.ToString();
                vAlojomiento.cBoxNroHabitaciones.Enabled = false;
                vAlojomiento.cBoxTipoHab.Enabled = false;
                vAlojomiento.lbNumHabitacion.Text = "Capacidad: " + casa.Camas.ToString() + " personas";

                if(vAlojomiento.ShowDialog()==DialogResult.Retry)
                {
                    EmitirComprobante(unaReserva);
                }
            }
            else
            {
                Hotel hotel = (Hotel)unAlojamiento;
                vAlojomiento.SetAlojamiento(hotel);
                vAlojomiento.SetConsultor(this);
                Habitacion habitacionReservada = unaReserva.HabitacionReservada;

                vAlojomiento.lbDescripcion.Text = "Tipo Habitación:";
                vAlojomiento.cBoxTipoHab.Enabled = true;
                vAlojomiento.cBoxNroHabitaciones.Enabled = true;

                vAlojomiento.cBoxTipoHab.SelectedIndex = habitacionReservada.Tipo - 1;
                vAlojomiento.cBoxNroHabitaciones.Text = habitacionReservada.Numero.ToString();

                DateTime[] intervaloPintar = hotel.IntervaloFechasHabitacion(habitacionReservada.Numero);
                vAlojomiento.Calendario.BoldedDates = intervaloPintar;

                vAlojomiento.nudDias.Value = unaReserva.Dias;
                vAlojomiento.nudDias.Minimum = 1;

                if (vAlojomiento.ShowDialog() == DialogResult.Retry)
                {
                    EmitirComprobante(unaReserva);
                }
            }
        }
        private void btnModificarReserva_Click(object sender, EventArgs e)
        {
           
            int indice = cbReservas.SelectedIndex;
            Reserva unaReserva = empresa.ListaDeReservas[indice];
            Alojamiento unAlojamiento = unaReserva.Alojamiento;
            List<Cliente> acomp = unaReserva.Pasajeros;

            AlojamientoForm vAlojomiento = new AlojamientoForm();
            Pintarcontroles(vAlojomiento);
            vAlojomiento.btnCancelarReserva.Enabled = true;
            vAlojomiento.btnReservar.Enabled = true;
            vAlojomiento.btnImprimir.Enabled = false;

            DateTime[] fechasPintar;
            vAlojomiento.Calendario.SetDate(unaReserva.Ingreso);
            vAlojomiento.Calendario.SelectionStart = unaReserva.Ingreso;
            
            DialogResult dialogResult= DialogResult.Ignore;//No hace nada

            if (unAlojamiento is Casa)
            {
                vAlojomiento.SetConsultor(this);
                Casa casa = (Casa)unAlojamiento;
                vAlojomiento.SetAlojamiento(casa);
                vAlojomiento.nudDias.Minimum = casa.MinDias;
                vAlojomiento.nudDias.Value = unaReserva.Dias;
                try
                {
                    empresa.CancelarReserva(unaReserva.ID);//Se cancela momentaneamente hasta que se confirme o no

                    fechasPintar = unAlojamiento.IntervaloFechasReservadas();
                    vAlojomiento.Calendario.BoldedDates = fechasPintar; //pintar calendario casa

                    vAlojomiento.lbDescripcion.Text = casa.ToString();
                    vAlojomiento.cBoxNroHabitaciones.Enabled = false;
                    vAlojomiento.cBoxTipoHab.Enabled = false;
                    vAlojomiento.lbNumHabitacion.Text = "Capacidad: " + casa.Camas.ToString() + " personas";

                    dialogResult = vAlojomiento.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        int dias = Convert.ToInt32(vAlojomiento.nudDias.Value);
                        DateTime inicio = vAlojomiento.Calendario.SelectionStart;
                        DateTime fin = inicio.AddDays(dias - 1); // -1 porque se cuenta el dia mismo de inicio

                        if (!casa.CheckFecha(inicio, fin))
                        {
                            MessageBox.Show("Rango de fecha invalido");
                            this.AgregarReserva(unaReserva);
                        }
                        else
                        {
                            DatosClienteForm vCliente = new DatosClienteForm();
                            Pintarcontroles(vCliente);
                            vCliente.btnPasajeros.Visible = false;
                            vCliente.tbNombre.Text = unaReserva.getCliente.Nombre;
                            vCliente.tbApellido.Text = unaReserva.getCliente.Apellido;
                            vCliente.tbDni.Text = unaReserva.getCliente.DNI.ToString();
                            vCliente.fNacimiento.Value = unaReserva.getCliente.FechaNacimiento;

                            if (vCliente.ShowDialog() == DialogResult.OK)
                            {
                                string nombre = vCliente.tbNombre.Text;
                                string apellido = vCliente.tbApellido.Text;
                                int dni = Convert.ToInt32(vCliente.tbDni.Text);
                                DateTime fNacimiento = vCliente.fNacimiento.Value;

                                Cliente cliente = new Cliente(nombre.Trim(), apellido.Trim(), dni, fNacimiento);

                                unaReserva.Modificar(cliente, inicio, fin, acomp);
                                this.AgregarReserva(unaReserva);
                                EmitirComprobante(unaReserva);
                            }
                            vCliente.Dispose();
                        }
                    }
                    else
                    {
                        if (dialogResult != DialogResult.Abort)//Si no aprieta el boton cancelar
                        {
                            this.AgregarReserva(unaReserva);//PORQUE CIERRA DESDE LA BARRA, NO CANCELA LA RESERVA                                                       
                        }
                        else
                        {
                            // SE MANTIENE ELIMINADA,NO SE AGREGA DE NUEVO
                        }
                    }
                }
                catch(Exception ex)
                {
                    this.AgregarReserva(unaReserva);
                    MessageBox.Show(ex.Message);
                }
                
                empresa.OrdenarReservasPorId();
                ActualizarListas();

            }// esto si era casa
            else
            {
                Hotel hotel = (Hotel)unAlojamiento;
                vAlojomiento.SetConsultor(this);
                vAlojomiento.SetAlojamiento(hotel);

                Habitacion habitacionReservada = unaReserva.HabitacionReservada;
                int numHabitacionAnterior = habitacionReservada.Numero;
                try
                {
                    vAlojomiento.lbDescripcion.Text = "Tipo Habitación:";
                    vAlojomiento.cBoxTipoHab.Enabled = true;
                    vAlojomiento.cBoxNroHabitaciones.Enabled = true;

                    vAlojomiento.cBoxTipoHab.SelectedIndex = habitacionReservada.Tipo - 1;
                    vAlojomiento.cBoxNroHabitaciones.Text = habitacionReservada.Numero.ToString();

                    hotel.QuitarReserva(numHabitacionAnterior, unaReserva);//SE QUITA MOMENTANEAMENTE

                    DateTime[] intervaloPintar = hotel.IntervaloFechasHabitacion(habitacionReservada.Numero);
                    vAlojomiento.Calendario.BoldedDates = intervaloPintar; // ESTO VA PORQUE NO SE DISPARA EL EVENTO DE CAMBIO DE HABITACION EN COMBOBOX

                    vAlojomiento.nudDias.Value = unaReserva.Dias;
                    vAlojomiento.nudDias.Minimum = 1;
                    DialogResult resultado = vAlojomiento.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        int dias = Convert.ToInt32(vAlojomiento.nudDias.Value);
                        int nroHabitacionNuevo = Convert.ToInt32(vAlojomiento.cBoxNroHabitaciones.Text);

                        DateTime inicio = vAlojomiento.Calendario.SelectionStart;
                        DateTime fin = inicio.AddDays(dias - 1);

                        if (!hotel.CheckFechaHabitacion(inicio, fin, nroHabitacionNuevo))
                        {
                            MessageBox.Show("Rango de fecha invalido para la habitación nro " + nroHabitacionNuevo);
                            hotel.AgregarReserva(numHabitacionAnterior, unaReserva);//SE VUELVE A AGREGAR 
                        }
                        else
                        {
                            DatosClienteForm vCliente = new DatosClienteForm();
                            Pintarcontroles(vCliente);
                            vCliente.btnPasajeros.Visible = false;

                            vCliente.tbNombre.Text = unaReserva.getCliente.Nombre;
                            vCliente.tbApellido.Text = unaReserva.getCliente.Apellido;
                            vCliente.tbDni.Text = unaReserva.getCliente.DNI.ToString();
                            vCliente.fNacimiento.Value = unaReserva.getCliente.FechaNacimiento;

                            if (vCliente.ShowDialog() == DialogResult.OK)
                            {
                                string nombre = vCliente.tbNombre.Text;
                                string apellido = vCliente.tbApellido.Text;
                                int dni = Convert.ToInt32(vCliente.tbDni.Text);
                                DateTime fNacimiento = vCliente.fNacimiento.Value;


                                Cliente cliente = new Cliente(nombre, apellido, dni, fNacimiento);
                                unaReserva.Modificar(cliente, inicio, fin, acomp);

                                if (numHabitacionAnterior != nroHabitacionNuevo)
                                {
                                    unaReserva.QuitarHabitacion(habitacionReservada);
                                    unaReserva.AgregarHabitacion(hotel.GetHabitacion(nroHabitacionNuevo));

                                }
                                hotel.AgregarReserva(nroHabitacionNuevo, unaReserva);
                                EmitirComprobante(unaReserva);
                            }
                        }
                    }
                    else
                    {
                        if (resultado == DialogResult.Abort)
                        {
                            unaReserva.QuitarHabitacion(habitacionReservada);
                            empresa.CancelarReserva(unaReserva.ID);
                        }
                        else
                        {
                            hotel.AgregarReserva(numHabitacionAnterior, unaReserva);
                        }
                    }
                }
                catch (Exception ex)
                {
                    hotel.AgregarReserva(numHabitacionAnterior, unaReserva);
                    MessageBox.Show(ex.Message);
                }
                    
            }
            
            ActualizarListas();
            vAlojomiento.Dispose();
        }




        ///-----------------------------------------------------------------------------------------------


        ///------------------------------------------------------------------------------------------------
        ///Eventos y metodos auxiliares
        ///Eventos y metodos auxiliares
        ///Eventos y metodos auxiliares
        ///Eventos y metodos auxiliares

        // BLOQUEAR Y DESBLOQUEAR CONTROLES ALOJAMIENTO::
        // BLOQUEAR Y DESBLOQUEAR CONTROLES ALOJAMIENTO::

        
        private void cbAlojamientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BloquearControlesAlojamiento();
        }
        private void cbAlojamientos_TextChanged(object sender, EventArgs e)
        {
            BloquearControlesAlojamiento();
        }
        private void BloquearControlesAlojamiento()
        {
            if (cbAlojamientos.Text != "" || cbAlojamientos.SelectedIndex != -1)
            {
                btnModificarAloj.Enabled = true;
                btnConsultaAloj.Enabled = true;
                modificarToolStripMenuItem.Enabled = true;
                consultarToolStripMenuItem.Enabled = true;

            }
            else
            {
                btnConsultaAloj.Enabled = false;
                btnModificarAloj.Enabled = false;
                modificarToolStripMenuItem.Enabled = false;
                consultarToolStripMenuItem.Enabled = false;
            }
        }

        // BLOQUEAR Y DESBLOQUEAR CONTROLES RESERVA::
        // BLOQUEAR Y DESBLOQUEAR CONTROLES RESERVA::

        private void cbReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BloquearControlesReservas();
        }
        private void cbReservas_TextChanged(object sender, EventArgs e)
        {
            BloquearControlesReservas();
        }
        private void BloquearControlesReservas()
        {
            if (cbReservas.Text != "" || cbReservas.SelectedIndex != -1)
            {
                btnModificarReserva.Enabled = true;
                btnConsultaReserva.Enabled = true;
                modificarToolStripMenuItem1.Enabled = true;
                consultarToolStripMenuItem1.Enabled = true;
            }
            else
            {
                btnModificarReserva.Enabled = false;
                btnConsultaReserva.Enabled = false;
                modificarToolStripMenuItem1.Enabled = false;
                consultarToolStripMenuItem1.Enabled = false;
            }
        }

        // ACTUALIZAR LISTAS COMBO BOX ALOJAMIENTO Y RESERVAS
        // ACTUALIZAR LISTAS COMBO BOX ALOJAMIENTO Y RESERVAS:

        public void ActualizarListas()
        {
            cbAlojamientos.Items.Clear();
            cbAlojamientos.ResetText();
            cbReservas.Items.Clear();
            cbReservas.ResetText();
            foreach (Alojamiento a in empresa.Alojamientos)
                cbAlojamientos.Items.Add(a.ToString());
            foreach (Reserva r in empresa.ListaDeReservas)
                cbReservas.Items.Add(r.ToString());

        }

        

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 10);
            Brush brush = new SolidBrush(Color.Black);
            float x, y;
            int margSup = 50;
            int margIzq = 50;
            int[] anchoColumn = new int[] { 100, 250, 150, 100, 100};
            int altoColumn = 20;
            y = margSup;

            //lista de vectores de string, cada vector representa una línea del comprobante
            //cada elemento de cada vector representa una celda.
            List<string[]> lineas = new List<string[]>();

            //cabecera de la factura

            //variables auxiliares
            Image imagen = null;
            string razonSocial = empresa.RazonSocial;
            //string razonSocial = "TuAlquilerYa.com S.A.";
            string tipoComprobante = "Recibo X";
            string nombClient = temp.getCliente.NombreCompleto;
            string dniClient = temp.getCliente.DNI.ToString();
            string fecha = temp.DatosComprobante[3];
            string fNacimiento = temp.getCliente.FechaNacimiento.ToShortDateString();
            if (temp.Alojamiento.Imagenes.Length > 0)
            {
                imagen = temp.Alojamiento.Imagenes[0];
            }

            //línea 1
            lineas.Add(new[] { razonSocial, "", tipoComprobante, "", fecha });
            //línea 2
            lineas.Add(new[] { "", "", "", "", "" });
            //línea 3
            lineas.Add(new[] { "Ap., Nomb.:", nombClient, "", "", "" });
            //línea 4
            lineas.Add(new[] { "DNI", dniClient, "", "", "" });
            //línea 5
            lineas.Add(new[] { "F. Nac.", fNacimiento, "", "", "" });
            //línea 6 - línea en blanco adicional.
            lineas.Add(new[] { "", "", "", "", "" });
            //línea 7
            lineas.Add(new[] { "Cod.", "Descripción", "Cantidad", "Precio / noche", "Total" });
            //fin de cabecera de la factura
            //
                //variables auxiliares - realizar las conversiones y formateos necesarios.
                string cod = "1";
                string desc = temp.DatosComprobante[0];
                string cant = temp.Dias.ToString() + " noches";
                string precU = temp.DatosComprobante[5].ToString();
                string subtot = String.Format("{0:C2}", temp.DatosComprobante[6]);
                string iva = String.Format("{0:C2}", (Convert.ToDouble(temp.DatosComprobante[6])*0.105));
                double total = Convert.ToDouble(temp.DatosComprobante[6]) + (Convert.ToDouble(temp.DatosComprobante[6]) * 0.105);
                string tot = String.Format("{0:C2}", total);
            //línea 8 detalle
            lineas.Add(new[] { cod, desc, cant, precU, tot });
            //linea 9 acompanantes
            if (temp.Pasajeros.Count > 0)
            {
                lineas.Add(new[] { "", "Acompañantes:", "", "", "" });
                foreach (Cliente pasajero in temp.Pasajeros)
                {
                    lineas.Add(new[] { "", pasajero.NombreCompleto, "", "", "" });
                    lineas.Add(new[] { "", pasajero.DNI.ToString(), "", "", "" });
                    lineas.Add(new[] { "", pasajero.FechaNacimiento.ToShortDateString(), "", "", "" });
                }
            }
            //fin del detalle

            //sumary o footer
            //variables auxiliares - realizar las conversiones y formateos necesarios.
            //string subtotal = venta.SubTotal;
            //línea 6 + n-ésimo detalle + 1
            lineas.Add(new[] { "", "", "", "Sub-Total", subtot });
            lineas.Add(new[] { "", "", "", "IVA 10,5 %", iva });
            lineas.Add(new[] { "", "", "", "TOTAL", tot });
            //fin
 
            foreach (string[] fila in lineas)
            {
                int column = 1;
                x = margIzq;
                foreach (string columna in fila)
                {
                    string campo = columna;
                    int anchoColumna = anchoColumn[column-1];
                    g.DrawString(campo, font, brush, x, y);
                    x += anchoColumna;
                    column++;
                }
                y += altoColumn;
            }
            if (imagen != null)
            {
                g.DrawImage(imagen, new Rectangle(margIzq, (Int32)y, 300, 300));
            }
                
            if (copia < 1)
            {
                copia++;
                e.HasMorePages = true;
            } else
            {
                copia = 0;
                e.HasMorePages = false;
            }
            font.Dispose();
            brush.Dispose();
        }

        public List<Cliente> GetPasajeros()
        {
            List<Cliente> resultado = new List<Cliente>();
            pasajeros.ForEach(acomp => resultado.Add(acomp));
            pasajeros.Clear();
            return resultado;
        }

        public void SetCapacidad(int capac)
        {
            capacidad = capac;
        }

        public string[] ActualizarComboBoxCiudades(string jurisdiccion)
        {
            return empresa.Ciudades(jurisdiccion).ToArray();
        }


        //MENU STRIP OPTIONS:::::
        //MENU STRIP OPTIONS:::::
        //MENU STRIP OPTIONS:::::
        //MENU STRIP OPTIONS:::::

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream archivo = null;
            try
            {
                archivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(archivo, empresa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ActualizarListas();
                if (archivo != null)
                    archivo.Close();
            }
        }
        private void restarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartConfirmationForm restartPrimero = new RestartConfirmationForm();
            RestartConfirmationForm segundaOportunidad = new RestartConfirmationForm();

            if (restartPrimero.ShowDialog() == DialogResult.Yes)
            {
                segundaOportunidad.lbTexto.Text = "Luego de confirmar será necesario reiniciar el programa";
                if (segundaOportunidad.ShowDialog() == DialogResult.Yes)
                {
                    if (File.Exists(nombreArchivo))
                        File.Delete(nombreArchivo);

                    restart = true; // al principio del forms
                    this.Close();  // en el closing se usa el restart
                }
            }
        }

        private void precioBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empresa.Preguntar = true;
            Form_Inicio();
            Pintarcontroles(this);
        }

        //MENU STRIP ALOJAMIENTO:::::
        //MENU STRIP ALOJAMIENTO:::::
        //MENU STRIP ALOJAMIENTO:::::
        //MENU STRIP ALOJAMIENTO:::::
        private void agregarAlojStripMenu_Click(object sender, EventArgs e)
        {
            btnAgregarAloj.PerformClick();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnModificarAloj.PerformClick();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnConsultaAloj.PerformClick();
        }

        //Importar Alojamiento
        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = path;
            ofd.DefaultExt = ".txt";
            ofd.AddExtension = true;
            FileStream fs;
            StreamReader sr;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                sr.ReadLine();//descripcion casas
                sr.ReadLine();//descripcion Hoteles
                string linea;
                string[] campos;
                Dictionary<int, Alojamiento> lineaExistentes = new Dictionary<int,Alojamiento>();
                Dictionary<int, string> jurisdiccionNoExistente = new Dictionary<int, string>();
                int contLinea = 0;
                while(!sr.EndOfStream)
                {
                    contLinea++;
                    linea = sr.ReadLine();
                    campos = linea.Split(';');
                    Alojamiento nuevo=null;
                    string jurisdiccion = null;

                    if (campos.Length == 12)
                    {
                        string direc= campos[0];
                        jurisdiccion= campos[1];
                        string ciudad = campos[2];
                        int minDias= Convert.ToInt32(campos[3]);
                        int camas = Convert.ToInt32(campos[4]);
                        double precioBaseCasa= Convert.ToDouble(campos[5]);

                        string[] servicios;
                        linea = null;

                        for(int i=6; i<campos.Length; i++)
                        {
                            linea += campos[i] + ";";
                        }
                        servicios = linea.Trim(';').Split(';');
                        nuevo= new Casa(direc,jurisdiccion,ciudad,minDias,camas,servicios,precioBaseCasa);
                    }
                    if(campos.Length==8)
                    {
                        string direc = campos[0];
                        jurisdiccion = campos[1];
                        string ciudad = campos[2];
                        string nombre= campos[3];
                        bool tresEstrellas= Convert.ToBoolean(campos[4]);
                        int cantSimples= Convert.ToInt32(campos[5]);
                        int cantDobles= Convert.ToInt32(campos[6]);
                        int cantTriples= Convert.ToInt32(campos[7]);

                        nuevo = new Hotel(direc,jurisdiccion,ciudad, nombre, tresEstrellas, cantSimples, cantDobles, cantTriples);
                    }

                    Alojamiento comparador = empresa[nuevo.Direccion];
                    if (comparador ==null)
                    {
                        if (empresa.VerificarJurisdiccion(jurisdiccion))
                            empresa.AgregarAlojamiento(nuevo);
                        else
                            jurisdiccionNoExistente.Add(contLinea, "La jurisdicción no existe");
                    }
                    else
                    {
                        lineaExistentes.Add(contLinea, comparador);
                        empresa.DisminuirContadorCasas();// Revisar
                    }
                        
                }

                AlojamientosExistentesForm exists = new AlojamientosExistentesForm();
                exists.listBox1.Items.Add("No hay errores.");

                if (lineaExistentes.Count > 0)
                {
                    exists.listBox1.Items.Clear();
                    exists.listBox1.Items.Add("Se han encontrado alojamientos que ya estaban cargados o que la dirección ");
                    exists.listBox1.Items.Add("coincide con alguno de los cargados");
                    exists.listBox1.Items.Add("");
                    foreach (var pareja in lineaExistentes)
                    {
                        exists.listBox1.Items.Add(pareja.Value.ToString() + " // LINEA: " + pareja.Key);
                    }
                    exists.listBox1.Items.Add("");
                    exists.listBox1.Items.Add("");
                    exists.listBox1.Items.Add("");
                }

                if (jurisdiccionNoExistente.Count > 0)
                {
                    if (lineaExistentes.Count == 0)
                        exists.listBox1.Items.Clear();

                    exists.listBox1.Items.Add("Se han encontrado jurisdicciones inexistentes ");
                    exists.listBox1.Items.Add("");
                    foreach (var pareja in jurisdiccionNoExistente)
                    {
                        exists.listBox1.Items.Add(pareja.Value.ToString() + " // LINEA: " + pareja.Key);
                    }
                    exists.listBox1.Items.Add("");
                    exists.listBox1.Items.Add("");
                    exists.listBox1.Items.Add("");
                }

                exists.Show();

                if (contLinea==lineaExistentes.Count)
                {
                    MessageBox.Show("Todos los alojamientos estaban cargados previamente");
                }
                else
                    MessageBox.Show("Carga Exitosa");

                ActualizarListas();

                sr.Close();
                fs.Close();
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = path;
            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            sfd.FileName = string.Format("Exportacion Alojamientos - {0}",DateTime.Now.ToLongDateString());
            FileStream fs;
            StreamWriter sw;

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create,FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine("direccion; jurisdiccion; ciudad; minDias; camas; precioBaseCasa; s1; s2; s3; s4; s5; s6 //Para casas");
                sw.WriteLine("direccion, jurisdiccion, ciudad, nombre, tresEstrellas, cantSimples, cantDobles, cantTriples //Para Hoteles");
                foreach(Alojamiento a in empresa.Alojamientos)
                {
                    string[] campos= a.Exportar();
                    string linea = null;
                    for(int i = 0; i < campos.Length; i++)
                    {
                        if(i!=campos.Length-1)
                        {
                            linea += campos[i] + ";";
                        }
                        else
                            linea += campos[i];
                    }
                   
                    sw.WriteLine(linea);
                }
                sw.Close();
                fs.Close();
            }        
        }

        private void verListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlojamientosExistentesForm listaForm = new AlojamientosExistentesForm();
            listaForm.Text = "Lista de Alojamientos";

            List<Alojamiento> lista = empresa.Alojamientos;
            if (lista.Count > 0)
            {
                foreach (Alojamiento a in lista)
                    listaForm.listBox1.Items.Add(a.ToString());
            }
            else
                listaForm.listBox1.Items.Add("No hay Alojamientos registrados");

            listaForm.ShowDialog();

            listaForm.Dispose();
        }


        //MENU STRIP RESERVA:::::
        //MENU STRIP RESERVA:::::
        //MENU STRIP RESERVA:::::
        //MENU STRIP RESERVA:::::
        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnAgregarReserva.PerformClick();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnModificarReserva.PerformClick();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnConsultaReserva.PerformClick();
        }
        //Importar Reservas Casas
        private void casasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = path;
            ofd.DefaultExt = ".txt"; ofd.AddExtension = true;
            //ofd.Filter = "texto |.txt";

            FileStream fs;
            StreamReader sr;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                sr.ReadLine();
                int contLinea = 1;

                List<int> lineasErroresCampos = new List<int>();
                
                Dictionary<int, string> errorClientesInexistentes = new Dictionary<int, string>();
                Dictionary<int, string> errorAlojamientosInexistentes = new Dictionary<int, string>();
                Dictionary<int, string> errorReservaExistentes = new Dictionary<int, string>();
                Dictionary<int, string> errorFechaOcupada = new Dictionary<int, string>();
                Dictionary<int, string> errorMinimoDias = new Dictionary<int, string>();
                Dictionary<int, string> errorCapacidadMaxima = new Dictionary<int, string>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] campos = line.Split(',');

                    int dni; //se utiliza solo para informar error
                    int idAlojamiento;
                    DateTime ingreso;
                    DateTime egreso;
                    List<Cliente> acompaniantes= new List<Cliente>();


                    if (campos.Length == 5)
                    {
                        dni = Convert.ToInt32(campos[0]);
                        idAlojamiento = Convert.ToInt32(campos[1]);
                        ingreso = DateTime.Parse(campos[2]);
                        egreso = DateTime.Parse(campos[3]);

                        string linea=campos[4].TrimEnd('-');
                        if(linea!="")
                        {
                            string[] campos2 = linea.Split('-');
                            string[] nombreApellido;
                            Cliente pasajero;                          
                            foreach (string acom in campos2)
                            {
                               nombreApellido =acom.Split(' ');
                               pasajero= new Cliente(nombreApellido[0],nombreApellido[1]);
                               acompaniantes.Add(pasajero);
                            }           
                        }


                        Reserva nuevaReserva;
                        Cliente cliente = new Cliente("a", "a", dni, new DateTime(1990,1,1));

                        if(empresa.ExisteCliente(ref cliente)) //se actualiza por referencia en el método
                        {
                            Alojamiento buscado = new Casa("a","a","a", 1, 1, null, 1);
                            Casa casita;
                            if (empresa.ExisteAlojamiento(idAlojamiento, ref buscado)) //si existe actualiza por referencia en el método
                            {
                                 casita= buscado as Casa;
                                int diasReserva=egreso.AddDays(1).Subtract(ingreso).Days;
                                if(diasReserva>=casita.MinDias)
                                {
                                    if (acompaniantes.Count + 1 <= casita.Camas)
                                    {
                                        if (empresa.ExisteReservaCasa(cliente, buscado, ingreso, egreso))
                                            errorReservaExistentes.Add(contLinea, line);
                                        else
                                        {
                                            if (buscado.CheckFecha(ingreso, egreso))
                                            {
                                                if (acompaniantes.Count > 0)
                                                    nuevaReserva = new Reserva(cliente, buscado, ingreso, egreso, casita.PrecioBaseCasa, acompaniantes);
                                                else
                                                    nuevaReserva = new Reserva(cliente, buscado, ingreso, egreso, casita.PrecioBaseCasa);

                                                this.AgregarReserva(nuevaReserva);
                                            }
                                            else
                                                errorFechaOcupada.Add(contLinea, line);
                                        }
                                    }
                                    else
                                        errorCapacidadMaxima.Add(contLinea, "Casa ID: " + casita.IDalojamiento + " - Camas: " + casita.Camas + " - Solicitadas: " + pasajeros.Count+1);
                                }
                                else
                                    errorMinimoDias.Add(contLinea, "Casa ID: "+ casita.IDalojamiento + " - Minimo: "+ casita.MinDias + " - Solicitado: "+ diasReserva);
                            }
                            else
                                errorAlojamientosInexistentes.Add(contLinea,idAlojamiento.ToString());
                        }
                        else
                            errorClientesInexistentes.Add(contLinea, dni.ToString());     
                    }
                    else
                    {
                        lineasErroresCampos.Add(contLinea);
                    }
                    contLinea++;
                }


                AlojamientosExistentesForm ventanaExistentes = new AlojamientosExistentesForm();

                string lineaShowErrores = null;

                if (lineasErroresCampos.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES ERRORES DE CAMPO: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (int a in lineasErroresCampos)
                    {
                        lineaShowErrores = "LINEA NRO: " + a;
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorClientesInexistentes.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES CLIENTES NO REGISTRADOS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorClientesInexistentes)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - DNI: " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorAlojamientosInexistentes.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES ALOJAMIENTOS NO REGISTRADOS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorAlojamientosInexistentes)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - IDalojamiento: " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorReservaExistentes.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO RESERVAS YA REGISTRADAS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorReservaExistentes)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorFechaOcupada.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO FECHAS NO DISPONIBLES: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorFechaOcupada)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }
                if (errorCapacidadMaxima.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO ERRORES DE CAPACIDAD DE PASAJEROS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorCapacidadMaxima)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }
                if (errorMinimoDias.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO ERRORES DE CANTIDAD DE DIAS DE RESERVA: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorMinimoDias)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }


                if (lineaShowErrores != null)
                {
                    ventanaExistentes.Show();
                }

                if (contLinea - 1 == errorReservaExistentes.Count)
                    MessageBox.Show("Todas las reservas ya estaban cargadas");
                else
                    MessageBox.Show("Carga Exitosa!");

                sr.Close();
                fs.Close();
                ActualizarListas();
            }
        }

        // Importar Reservas Hoteles
        private void hotelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = path;
            ofd.DefaultExt = ".txt"; ofd.AddExtension = true;
            //ofd.Filter = "texto |.txt";

            FileStream fs;
            StreamReader sr;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                sr.ReadLine();
                int contLinea = 1;

                List<int> lineasErroresCampos = new List<int>();

                Dictionary<int, string> errorClientesInexistentes = new Dictionary<int, string>();
                Dictionary<int, string> errorAlojamientosInexistentes = new Dictionary<int, string>();
                Dictionary<int, string> errorReservaExistentes = new Dictionary<int, string>();
                Dictionary<int, string> errorFechaOcupada = new Dictionary<int, string>();
                Dictionary<int, string> errorMinimoDias = new Dictionary<int, string>();
                Dictionary<int, string> errorCapacidadMaxima = new Dictionary<int, string>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] campos = line.Split(',');

                    int dni; //se utiliza solo para informar error
                    int idAlojamiento;
                    DateTime ingreso;
                    DateTime egreso;
                    int nroHabitacion;
                    List<Cliente> acompaniantes = new List<Cliente>();

                    if (campos.Length == 6)
                    {
                        dni = Convert.ToInt32(campos[0]);
                        idAlojamiento = Convert.ToInt32(campos[1]);
                        ingreso = DateTime.Parse(campos[2]);
                        egreso = DateTime.Parse(campos[3]);
                        nroHabitacion = Convert.ToInt32(campos[4]);

                        string linea = campos[5].TrimEnd('-');
                        if (linea != "")
                        {
                            string[] campos2 = linea.Split('-');
                            string[] nombreApellido;
                            Cliente pasajero;
                            foreach (string acom in campos2)
                            {
                                nombreApellido = acom.Split(' ');
                                pasajero = new Cliente(nombreApellido[0], nombreApellido[1]);
                                acompaniantes.Add(pasajero);
                            }
                        }

                        Reserva nuevaReserva;
                        Cliente cliente = new Cliente("a", "a", dni, new DateTime(1900,1,1));

                        if (empresa.ExisteCliente(ref cliente)) //se actualiza por referencia en el método
                        {
                            Alojamiento buscado = new Hotel("a","a","a","a", false, 1, 1, 1);
                            Hotel hotelcito;
                            if (empresa.ExisteAlojamiento(idAlojamiento, ref buscado, nroHabitacion)) //si existe actualiza por referencia en el método
                            {
                                hotelcito = buscado as Hotel;
                                Habitacion h = hotelcito.GetHabitacion(nroHabitacion);
                                int diasReserva = egreso.AddDays(1).Subtract(ingreso).Days;

                                if (diasReserva > 0)
                                {
                                    if (acompaniantes.Count + 1 <= hotelcito.GetHabitacion(nroHabitacion).Tipo)
                                    {
                                        if (empresa.ExisteReservaHotel(cliente, hotelcito, ingreso, egreso, nroHabitacion))
                                            errorReservaExistentes.Add(contLinea, line);
                                        else
                                        {
                                            if (hotelcito.CheckFechaHabitacion(ingreso, egreso, nroHabitacion))
                                            {
                                                
                                                if (acompaniantes.Count > 0)
                                                    nuevaReserva = new Reserva(cliente, buscado, ingreso, egreso, empresa.PrecioBaseHotel, h, acompaniantes);
                                                else
                                                    nuevaReserva = new Reserva(cliente, buscado, ingreso, egreso, empresa.PrecioBaseHotel, h);

                                                this.AgregarReserva(nuevaReserva);
                                                hotelcito.AgregarReserva(nroHabitacion, nuevaReserva);
                                            }
                                            else
                                                errorFechaOcupada.Add(contLinea, line);
                                        }
                                    }
                                    else
                                        errorCapacidadMaxima.Add(contLinea, "Hotel ID: " + hotelcito.IDalojamiento + " - Tipo habitación Nro. " + nroHabitacion+": " + h.Tipo + " - Solicitado: " + (acompaniantes.Count + 1));
                                }
                                else
                                    errorMinimoDias.Add(contLinea, "Hotel ID: " + hotelcito.IDalojamiento + " - Minimo: " + 1 + " - Solicitado: " + diasReserva);
                            }
                            else
                                errorAlojamientosInexistentes.Add(contLinea, idAlojamiento.ToString());
                        }
                        else
                            errorClientesInexistentes.Add(contLinea, dni.ToString());
                    }
                    else
                    {
                        lineasErroresCampos.Add(contLinea);
                    }
                    contLinea++;
                }


                AlojamientosExistentesForm ventanaExistentes = new AlojamientosExistentesForm();

                string lineaShowErrores = null;

                if (lineasErroresCampos.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES ERRORES DE CAMPO: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (int a in lineasErroresCampos)
                    {
                        lineaShowErrores = "LINEA NRO: " + a;
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorClientesInexistentes.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES CLIENTES NO REGISTRADOS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorClientesInexistentes)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - DNI: " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorAlojamientosInexistentes.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES ALOJAMIENTOS NO REGISTRADOS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorAlojamientosInexistentes)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - IDalojamiento: " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorReservaExistentes.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO RESERVAS YA REGISTRADAS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorReservaExistentes)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                if (errorFechaOcupada.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO FECHAS NO DISPONIBLES: ");
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorFechaOcupada)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }
                if (errorCapacidadMaxima.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO ERRORES DE CAPACIDAD DE PASAJEROS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorCapacidadMaxima)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }
                if (errorMinimoDias.Count > 0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN DETECTADO ERRORES DE CANTIDAD DE DIAS DE RESERVA: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, string> pair in errorMinimoDias)
                    {
                        lineaShowErrores = "LINEA NRO: " + pair.Key.ToString() + " - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(lineaShowErrores);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }


                if (lineaShowErrores != null)
                {
                    ventanaExistentes.Show();
                }

                if (contLinea - 1 == errorReservaExistentes.Count)
                    MessageBox.Show("Todas las reservas ya estaban cargadas");
                else
                    MessageBox.Show("Carga Exitosa!");

                sr.Close();
                fs.Close();
                ActualizarListas();
            }
        }

        private void casasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = path;
            sfd.DefaultExt = ".txt"; sfd.AddExtension = true;
            sfd.FileName = string.Format("Exportacion Reservas Casas - {0}", DateTime.Now.ToLongDateString());
            FileStream fs;
            StreamWriter sw;
            if (empresa.HayReservasCasas)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("DNICLIENTE , IDALOJAMIENTO , CHECKIN , CHECKOUT , ACOMPANIANTES");

                    foreach (Reserva r in empresa.ListaDeReservas)
                    {
                        if (r.Alojamiento is Casa)
                        {
                            string linea = null;
                            string[] campos = r.ExportarCasa();

                            linea = campos[0] + "," + campos[1] + "," + campos[2] + "," + campos[3] + "," + campos[4];
                            sw.WriteLine(linea);
                        }
                    }

                    sw.Close();
                    fs.Close();
                }
            }
            else
                MessageBox.Show("No hay reservas registradas");

        }
        private void hotelesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = path;
            sfd.DefaultExt = ".txt"; sfd.AddExtension = true;
            string.Format("Exportacion Reservas Casas - {0}", DateTime.Now.ToLongDateString());
            FileStream fs;
            StreamWriter sw;

            if (empresa.HayReservasHoteles)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("DNICLIENTE , IDALOJAMIENTO , CHECKIN , CHECKOUT , NROHABITACION , ACOMPANIANTES");


                    foreach (Reserva r in empresa.ListaDeReservas)
                    {
                        if (r.Alojamiento is Hotel)
                        {
                            string linea = null;
                            string[] campos = r.ExportarHotel();

                            linea = campos[0] + "," + campos[1] + "," + campos[2] + "," + campos[3] + "," + campos[4] + "," + campos[5];
                            sw.WriteLine(linea);
                        }
                    }
                    sw.Close();
                    fs.Close();
                }
            }
            else
                MessageBox.Show("No hay reservas registradas");

        }
        private void verListaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AlojamientosExistentesForm listaForm = new AlojamientosExistentesForm();
            listaForm.Text = "Lista de Reservas";

            List<Reserva> lista = empresa.ListaDeReservas;
            if (lista.Count > 0)
            {
                foreach (Reserva r in lista)
                    listaForm.listBox1.Items.Add(r.ToString());
            }
            else
                listaForm.listBox1.Items.Add("No hay Reservas registradas");

            listaForm.ShowDialog();
            listaForm.Dispose();
        }



        //MENUSTRIP CLIENTE
        //MENUSTRIP CLIENTE
        //MENUSTRIP CLIENTE
        //MENUSTRIP CLIENTE
        
        private void importarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ///CLIENTE
            ///
            string path = Application.StartupPath;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = path;
            ofd.DefaultExt = ".txt"; ofd.AddExtension = true;
            //ofd.Filter = "texto |.txt";

            FileStream fs;
            StreamReader sr;


            if(ofd.ShowDialog() == DialogResult.OK)
            {
                fs=new FileStream(ofd.FileName, FileMode.Open,FileAccess.Read);
                sr=new StreamReader(fs);

                sr.ReadLine();
                int contLinea = 1;

                List<String> lineasErroresCampos=new List<String>();
;
                Dictionary<int,Cliente> lineasErroresRepetidos = new Dictionary<int, Cliente>();
                List<int> dniUsadosActuales=new List<int>();

                List<Cliente> clientesNuevos= new List<Cliente>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] campos = line.Split(',');

                    int id; //se utiliza solo para informar error
                    string nombre;
                    string apellido;
                    int dni;
                    DateTime fNacimiento;


                    if(campos.Length==5)
                    {
                        id = Convert.ToInt16(campos[0]);
                        nombre=campos[1];
                        apellido=campos[2];
                        dni= Convert.ToInt32(campos[3]);
                        fNacimiento=DateTime.Parse(campos[4]);
                        Cliente nuevo=null;

                        if(dni >= 1000000 && dni <= 99999999)
                            nuevo=new Cliente(nombre,apellido,dni,fNacimiento);
                        else
                            nuevo = new Cliente(nombre, apellido, 99999999, fNacimiento);

                        int index=-1;
                        if (empresa.GetClientesHistoricos.Count > 0)
                        {
                            empresa.GetClientesHistoricos.Sort();
                            index = empresa.GetClientesHistoricos.BinarySearch(nuevo);       
                        }

                        if (index < 0 && !dniUsadosActuales.Contains(dni))
                        {
                            clientesNuevos.Add(nuevo);
                            dniUsadosActuales.Add(dni);
                        }
                        else
                        {
                            nuevo.IDcliente = id;
                            lineasErroresRepetidos.Add(contLinea,nuevo);
                        }
                    }
                    else
                    {
                        lineasErroresCampos.Add("línea " + contLinea);
                    }
                    contLinea++;
                }

                if(clientesNuevos!=null&&clientesNuevos.Count>0)
                    empresa.ImportarClientes(clientesNuevos);

                AlojamientosExistentesForm ventanaExistentes = new AlojamientosExistentesForm();

                string erroresCampos=null;
                if(lineasErroresCampos.Count>0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES ERRORES DE CAMPO: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (string lineaNro in lineasErroresCampos)
                    {
                        erroresCampos = "Error en la " + lineaNro;
                        ventanaExistentes.listBox1.Items.Add(lineaNro);
                    }
                    ventanaExistentes.listBox1.Items.Add("");
                    ventanaExistentes.listBox1.Items.Add("");
                }

                string erroresRepetidos=null;
                if(lineasErroresRepetidos.Count>0)
                {
                    ventanaExistentes.listBox1.Items.Add("SE HAN ENCONTRADO LOS SIGUIENTES CLIENTES REPETIDOS: ");
                    ventanaExistentes.listBox1.Items.Add("");

                    foreach (KeyValuePair<int, Cliente> pair in lineasErroresRepetidos)
                    {
                       erroresRepetidos = "Línea "+ pair.Key.ToString()+" - " + pair.Value.ToString();
                        ventanaExistentes.listBox1.Items.Add(erroresRepetidos);
                    }
                }
               
                if(erroresCampos!=null||erroresRepetidos!=null)
                {
                    ventanaExistentes.Show();
                }

                if(contLinea-1==lineasErroresRepetidos.Count)
                    MessageBox.Show("Todos los clientes ya estaban cargados");
                else
                    MessageBox.Show("Carga Exitosa!");

                sr.Close();
                fs.Close();
            }
        }

        private void exportarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = path;
            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            sfd.FileName = string.Format("Exportacion Clientes - {0}", DateTime.Now.ToLongDateString());
            //ofd.Filter = "texto |.txt";
            FileStream fs;
            StreamWriter sw;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine("ID , NOMBRE , APELLIDO , DNI , FECHA NACIMIENTO");

                if(empresa.GetClientesHistoricos.Count>0)
                {
                    foreach(Cliente c in empresa.GetClientesHistoricos)
                    {
                        string linea = null;
                        string[] campos= c.Exportar();

                        linea = campos[0] + ","+campos[1] + ","+campos[2] + ","+campos[3] + ","+campos[4];
                        sw.WriteLine(linea);
                    }
                }
                sw.Close();
                fs.Close();
            }
        }

        private void verListaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AlojamientosExistentesForm listaForm= new AlojamientosExistentesForm();
            listaForm.Text = "Lista de Clientes";

            List<Cliente> lista = empresa.GetClientesHistoricos;
            if (lista.Count> 0)
            {
                foreach (Cliente cliente in lista)
                    listaForm.listBox1.Items.Add(cliente.ToString());
            }
            else
                listaForm.listBox1.Items.Add("No hay clientes registrados");

            listaForm.ShowDialog();

            listaForm.Dispose();
        }

        //GRAFICA DE ALOJAMIENTOS
       private void graficoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vGrafico = new GraficoForm();
            vGrafico.Text = "Grafico Ocupacion (Reservas)";
            vGrafico.Size = new Size(688,355);
            vGrafico.pb.Size = new Size(650,300);
            vGrafico.pb.Paint += new PaintEventHandler(DibujarGraficoAlojamientos);
            vGrafico.ShowDialog();
            vGrafico.Dispose();
        }
        //GRAFICA DE CLIENTES
        private void graficoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vGrafico = new GraficoForm();
            vGrafico.Text = "Grafico Clientes por reserva";
            vGrafico.Size = new Size(1300, 355);
            vGrafico.pb.Size = new Size(1250, 300);
            vGrafico.pb.Paint += new PaintEventHandler(DibujarGraficoClientes);
            vGrafico.ShowDialog();
            vGrafico.Dispose();
        }

        private void DibujarGraficoAlojamientos(object sender, PaintEventArgs e)
        {
            double[] datos = empresa.DatosGraficoAlojamientos();
            Brush relleno;
            Font letra = new Font("Times New Roman", 13, FontStyle.Bold);
            int alto;
            int ancho = 150;
            string texto;
            Point p;

            //barra de Casas
            relleno = new SolidBrush(Color.LightGreen);
            alto = (int)(vGrafico.Height * datos[1]) / 100;
            e.Graphics.FillRectangle(relleno, 50, vGrafico.pb.Height-alto, ancho, alto);         
            relleno = new SolidBrush(Color.Black);
            if (datos[1]>=10.0)
                p = new Point(65, vGrafico.pb.Height - (alto/2));
            else
                p = new Point(65, vGrafico.pb.Height - (alto-5));
            texto = string.Format("Casas : {0} %", datos[1]);
            e.Graphics.DrawString(texto, letra, relleno, p);

            //barra de Hotel
            relleno = new SolidBrush(Color.LightBlue);
            alto = (int)(vGrafico.Height * datos[2]) / 100;
            e.Graphics.FillRectangle(relleno, 250, vGrafico.pb.Height - alto, ancho, alto);
            relleno = new SolidBrush(Color.Black);
            if (datos[2] >= 10.0)
                p = new Point(265, vGrafico.pb.Height - (alto / 2));
            else
                p = new Point(265, vGrafico.pb.Height - (alto - 5));
            texto = string.Format("Hoteles : {0} %", datos[2]);
            e.Graphics.DrawString(texto, letra, relleno, p);

            //barra Total
            relleno = new SolidBrush(Color.LightSalmon);
            alto = (int)(vGrafico.Height * datos[0]) / 100;
            e.Graphics.FillRectangle(relleno, 450, vGrafico.pb.Height - alto, ancho, alto);
            relleno = new SolidBrush(Color.Black);

            if (datos[2] >= 10.0)
                p = new Point(465, vGrafico.pb.Height - (alto / 2));
            else
            { p = new Point(465, vGrafico.pb.Height - (alto - 5)); }
                

            texto = string.Format("Total : {0} %", datos[0]);
            e.Graphics.DrawString(texto, letra, relleno, p);

            relleno.Dispose();
        }



        //MENU STRIP ACERCADE - INFO:::::
        //MENU STRIP ACERCADE - INFO:::::
        //MENU STRIP ACERCADE - INFO:::::
        //MENU STRIP ACERCADE - INFO:::::
 
        //private void informacionToolStripMenuItem_Click(object sender, EventArgs e)

        private void DibujarGraficoClientes(object sender, PaintEventArgs e)
        {
            Dictionary<int, double[]> d = empresa.DatosGraficoClientes();
            Brush relleno=null;
            Font letra = null;
            int alto;
            int ancho = 150;
            string texto;
            Point p1;
            Point p2;
            double[] datos;
            int[] puntero = {50,0};

            foreach (KeyValuePair<int, double[]> pair in d)
            {
                datos = pair.Value;
                relleno = new SolidBrush(Color.LightBlue);
                alto = (int)(vGrafico.Height * datos[1]) / 100;
                puntero[1] = vGrafico.pb.Height - alto;
                e.Graphics.FillRectangle(relleno, puntero[0], puntero[1], ancho, alto);
                relleno = new SolidBrush(Color.Black);

                //Texto
                if (pair.Value[1] >=20.0)
                {
                    p1 = new Point(puntero[0] + 20, vGrafico.pb.Height - (alto / 2));
                    p2 = new Point(puntero[0] + 15, (vGrafico.pb.Height - (alto / 2)) + 15);
                    letra = new Font("Times New Roman", 13, FontStyle.Bold);
                }        
                else
                {
                    p1 = new Point(puntero[0] + 20, vGrafico.pb.Height - (alto -5));
                    p2 = new Point(puntero[0] + 15, (vGrafico.pb.Height - (alto -5)) + 15);
                    letra = new Font("Times New Roman", 10, FontStyle.Bold);
                }
                texto = string.Format("{0} Cliente", pair.Key);
                e.Graphics.DrawString(texto, letra, relleno, p1);
                texto = string.Format("Cant: {0} - {1}%", datos[0], datos[1]);
                e.Graphics.DrawString(texto, letra, relleno, p2);

                puntero[0] += 200;
            }
            relleno.Dispose();
            
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AyudaForm vAyuda = new AyudaForm();
            vAyuda.ShowDialog();
            vAyuda.Dispose();
        }



        //    Efecto para botones

        private void btnAgregarAloj_MouseEnter(object sender, EventArgs e)
        {    
            // 215; 199; 190
            ((Button)sender).BackColor=GetColors(1);
        }

        private void btnAgregarAloj_MouseLeave(object sender, EventArgs e)
        {
            // 179; 197; 186

            ((Button)sender).BackColor = GetColors(2);
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"/html/about.html";
            Process.Start(path);
        }

        private void importarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
