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


namespace TP_II
{
    public partial class Form1 : Form, IInterectuable
    {
        Empresa empresa;
        ConsultaForm vConsulta = null;
        string nombreArchivo = Application.StartupPath + @"\persistencia.dat";
        bool restart = false;
        Image[] imagenes;
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
            bool primeraVez = false;

            if (File.Exists(nombreArchivo))
            {
                FileStream fs = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();

                empresa = (Empresa)bf.Deserialize(fs);
                Reserva.ContIdReservas = empresa.contBackReservas;
                Cliente.ContIdCliente = empresa.contBackCliente;
                Alojamiento.ContIdAlojamiento = empresa.contBackAlojamientos;

                fs.Close();
                ActualizarListas();
               
            }
            else
            {
                empresa = new Empresa();
                primeraVez = true;
                ActualizarListas();
            }


            PrecioBaseForm vInicio = new PrecioBaseForm();

            if (empresa.Preguntar)
            {
                if (primeraVez)
                {
                    vInicio.rbSi.Checked = true;
                    vInicio.rbNo.Enabled = false;
                }

                vInicio.btnContinuar.Enabled = false;

                if (vInicio.ShowDialog() == DialogResult.OK)
                {
                    empresa.Preguntar = !vInicio.cbPreguntar.Checked;
                    if (vInicio.rbSi.Checked)
                        empresa.PrecioBaseHotel = Convert.ToDouble(vInicio.tbPrecio.Text);
                }
            }

            vInicio.Dispose();

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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!restart)
            {
                FileStream archivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                empresa.contBackReservas = Reserva.ContIdReservas;
                empresa.contBackCliente = Cliente.ContIdCliente;
                empresa.contBackAlojamientos = Alojamiento.ContIdAlojamiento;
                bf.Serialize(archivo, empresa);
                archivo.Close();
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

            if (c.chechBoxFiltrarPorFecha.Checked)
            {
                empresa.FiltrarFechaRango(nuevos, c.dtPickerInicio.Value, c.dtPickerFinal.Value);
            }
            ArrayList a = new ArrayList();
            a.AddRange(nuevos);
            return a;
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

            // Visibilidad controles estado
            ventanaABM.labEstado.Visible = false;
            ventanaABM.btnAltaBaja.Visible = false;
            // Manejo evento click del boton "Importar fotos" en ventana ABM
            ventanaABM.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);

            if (ventanaABM.ShowDialog() == DialogResult.OK)
            {
                Alojamiento alojamiento;

                direccion = ventanaABM.tBdireccion.Text;
                hotel = ventanaABM.rbHotel.Checked;

                if (hotel)
                {
                    nombre = ventanaABM.tbNombre.Text;
                    tresEstrellas = ventanaABM.checkB3Estrellas.Checked;
                    simples = Convert.ToInt32(ventanaABM.nUsimples.Value);
                    dobles = Convert.ToInt32(ventanaABM.nUdobles.Value);
                    triples = Convert.ToInt32(ventanaABM.nUtriples.Value);
                    alojamiento = new Hotel(direccion, nombre, tresEstrellas, simples, dobles, triples);

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
                    alojamiento = new Casa(direccion, minDias, cantCamas, servicios, precioBase);
                }
                alojamiento.Imagenes = imagenes;

                empresa.AgregarAlojamiento(alojamiento);
                ActualizarListas();
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
        }

        // Aca va nuevo boton

        private void btnModificarAloj_Click(object sender, EventArgs e)
        {
            ABMAlojamientosForm vModificacion = new ABMAlojamientosForm();
            int indice = cbAlojamientos.SelectedIndex;
            Alojamiento alojamiento = empresa.Alojamientos[indice];
            imagenes = new Image[5];
            // Manejo evento click del boton "Importar fotos" en ventana ABM
            vModificacion.btnFotos.Click += new System.EventHandler(this.btnFotos_Click);


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

            if (vModificacion.ShowDialog() == DialogResult.OK)
            {
                // Reemplazo las imagenes si seleccione nuevas
                if (imagenes.Length > 0)
                    alojamiento.Imagenes = imagenes;

                bool esHotel = vModificacion.rbHotel.Checked;

                if (vModificacion.labEstado.Text == "Activado")
                    alojamiento.Alta = true;
                else
                    alojamiento.Alta = false;

                if (esHotel)
                {
                    Hotel unHotel = (Hotel)alojamiento;
                    unHotel.Direccion = vModificacion.tBdireccion.Text;
                    unHotel.Nombre = vModificacion.tbNombre.Text;
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

                    unaCasa.Direccion = vModificacion.tBdireccion.Text;
                    unaCasa.Servicios = servicios;
                    unaCasa.Camas = Convert.ToInt32(vModificacion.numUDcamasCasa.Value);
                    unaCasa.MinDias = Convert.ToInt32(vModificacion.numUDminimo.Value);
                    unaCasa.PrecioBaseCasa = Convert.ToInt32(vModificacion.tbPrecio.Text);
                }
                ActualizarListas();

                cbAlojamientos.ResetText();
                cbAlojamientos.SelectedIndex = -1;
            }
            // Quito evento click del boton "Importar fotos" en ventana ABM
            vModificacion.btnFotos.Click -= new System.EventHandler(this.btnFotos_Click);
            vModificacion.Dispose();
        }

        private void btnConsultaAloj_Click(object sender, EventArgs e)
        {
            AlojamientoForm vAlojomiento = new AlojamientoForm();
            vAlojomiento.btnCancelarReserva.Visible = false;
            string[] campos = new string[2];
            campos = cbAlojamientos.Text.Split('-');
            string direccion = campos[1].TrimEnd(' ').TrimStart(' ');

            Alojamiento aBuscar = new Casa(direccion, 1, 1,null, 1.0);
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

                if (vAlojomiento.ShowDialog() == DialogResult.OK)
                {
                    int dias = Convert.ToInt32(vAlojomiento.nudDias.Value);
                    DateTime inicio = vAlojomiento.Calendario.SelectionStart;
                    DateTime fin = inicio.AddDays(dias-1);
                    if (!casa.CheckFecha(inicio, fin))
                        MessageBox.Show("Rango de fecha invalido");
                    else
                    {
                        DatosClienteForm vCliente = new DatosClienteForm();
                        //DatosClienteForm vPasajero = new DatosClienteForm();

                        if (vCliente.ShowDialog() == DialogResult.OK)
                        {
                            string nombre = vCliente.tbNombre.Text;
                            string apellido = vCliente.tbApellido.Text;
                            int dni = Convert.ToInt32(vCliente.tbDni.Text);
                            int edad = Convert.ToInt32(vCliente.tbEdad.Text);
                            Cliente cliente = new Cliente(nombre, apellido, dni, edad);
                            Reserva reserva = new Reserva(cliente, casa, inicio, fin, casa.PrecioBaseCasa);
                            this.AgregarReserva(reserva);
                            EmitirComprobante(reserva);
                        }
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
                            if (vCliente.ShowDialog() == DialogResult.OK)
                            {
                                string nombre = vCliente.tbNombre.Text;
                                string apellido = vCliente.tbApellido.Text;
                                int dni = Convert.ToInt32(vCliente.tbDni.Text);
                                int edad = Convert.ToInt32(vCliente.tbEdad.Text);

                                try
                                {
                                    Habitacion reservada = hotel.GetHabitacion(nroHabitacion);
                                    Cliente cliente = new Cliente(nombre, apellido, dni, edad);
                                    Reserva reserva = new Reserva(cliente, hotel, inicio, fin, GetPrecioBaseHoteles(), reservada);
                                    hotel.AgregarReserva(nroHabitacion, reserva);
                                    AgregarReserva(reserva);
                                    EmitirComprobante(reserva);
                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("Error en los Datos ingresados");
                                }

                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en el Ingreso de datos para la reserva");
                    }
                }


            }
        }

        private void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            vConsulta = new ConsultaForm();
            vConsulta.gBoxFiltroFecha.Enabled = false;
            vConsulta.SetConsultor(this);
            vConsulta.ShowDialog();
            ActualizarListas();
            vConsulta.Dispose();
        }

        private void btnConsultaReserva_Click(object sender, EventArgs e)
        {
            int indice = cbReservas.SelectedIndex;
            Reserva unaReserva = empresa.Reservas[indice];
            Alojamiento unAlojamiento = unaReserva.Alojamiento;
            AlojamientoForm vAlojomiento = new AlojamientoForm();
            vAlojomiento.btnCancelarReserva.Enabled = false;
            vAlojomiento.btnReservar.Enabled = false;
            vAlojomiento.btnImprimir.Enabled = true;

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
                Habitacion habitacionReservada = unaReserva.Habitaciones[0];

                vAlojomiento.lbDescripcion.Text = "Tipo Habitación:";
                vAlojomiento.cBoxTipoHab.Enabled = true;
                vAlojomiento.cBoxNroHabitaciones.Enabled = true;

                vAlojomiento.cBoxTipoHab.SelectedIndex = habitacionReservada.Tipo - 1;
                vAlojomiento.cBoxNroHabitaciones.Text = habitacionReservada.Numero.ToString();

                DateTime[] intervaloPintar = hotel.IntervaloFechasHabitacion(habitacionReservada.Numero);
                vAlojomiento.Calendario.BoldedDates = intervaloPintar;// REVISAR

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
            Reserva unaReserva = empresa.Reservas[indice];
            Alojamiento unAlojamiento = unaReserva.Alojamiento;

            AlojamientoForm vAlojomiento = new AlojamientoForm();
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
                        vCliente.tbNombre.Text = unaReserva.getCliente.Nombre;
                        vCliente.tbApellido.Text = unaReserva.getCliente.Apellido;
                        vCliente.tbDni.Text = unaReserva.getCliente.DNI.ToString();
                        vCliente.tbEdad.Text = unaReserva.getCliente.Edad.ToString();

                        if (vCliente.ShowDialog() == DialogResult.OK)
                        {
                            string nombre = vCliente.tbNombre.Text;
                            string apellido = vCliente.tbApellido.Text;
                            int dni = Convert.ToInt32(vCliente.tbDni.Text);
                            int edad = Convert.ToInt32(vCliente.tbEdad.Text);
                            Cliente cliente = new Cliente(nombre, apellido, dni, edad);

                            unaReserva.Modificar(cliente, inicio, fin);
                            this.AgregarReserva(unaReserva);
                            unaReserva.GenerarComprobante();
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
                empresa.OrdenarReservasPorId();
                ActualizarListas();
                cbReservas.ResetText();

            }// esto si era casa
            else
            {
                Hotel hotel = (Hotel)unAlojamiento;
                vAlojomiento.SetConsultor(this);
                vAlojomiento.SetAlojamiento(hotel);

                Habitacion habitacionReservada = unaReserva.Habitaciones[0];
                int numHabitacionAnterior = habitacionReservada.Numero;

                vAlojomiento.lbDescripcion.Text = "Tipo Habitación:";
                vAlojomiento.cBoxTipoHab.Enabled = true;
                vAlojomiento.cBoxNroHabitaciones.Enabled = true;

                vAlojomiento.cBoxTipoHab.SelectedIndex = habitacionReservada.Tipo - 1;
                vAlojomiento.cBoxNroHabitaciones.Text = habitacionReservada.Numero.ToString();

                hotel.QuitarReserva(numHabitacionAnterior, unaReserva);//SE QUITA MOMENTANEAMENTE

                DateTime[] intervaloPintar = hotel.IntervaloFechasHabitacion(habitacionReservada.Numero);
                vAlojomiento.Calendario.BoldedDates = intervaloPintar;// REVISAR

                vAlojomiento.nudDias.Value = unaReserva.Dias;
                vAlojomiento.nudDias.Minimum = 1;

                if (vAlojomiento.ShowDialog() == DialogResult.OK)
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

                        vCliente.tbNombre.Text = unaReserva.getCliente.Nombre;
                        vCliente.tbApellido.Text = unaReserva.getCliente.Apellido;
                        vCliente.tbDni.Text = unaReserva.getCliente.DNI.ToString();
                        vCliente.tbEdad.Text = unaReserva.getCliente.Edad.ToString();

                        if (vCliente.ShowDialog() == DialogResult.OK)
                        {
                            string nombre = vCliente.tbNombre.Text;
                            string apellido = vCliente.tbApellido.Text;
                            int dni = Convert.ToInt32(vCliente.tbDni.Text);
                            int edad = Convert.ToInt32(vCliente.tbEdad.Text);


                            Cliente cliente = new Cliente(nombre, apellido, dni, edad);
                            unaReserva.Modificar(cliente, inicio, fin);

                            if (numHabitacionAnterior != nroHabitacionNuevo)
                            {
                                unaReserva.QuitarHabitacion(habitacionReservada);
                                unaReserva.AgregarHabitacion(hotel.GetHabitacion(nroHabitacionNuevo));

                            }
                            hotel.AgregarReserva(nroHabitacionNuevo,unaReserva);
                            EmitirComprobante(unaReserva);
                        }
                    }
                }
                else
                {
                    if (dialogResult != DialogResult.Abort)
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
            foreach (Reserva r in empresa.Reservas)
                cbReservas.Items.Add(r.ToString());

        }

        public void EmitirComprobante(Reserva r)
        {
            ComprobanteForm comprobante = new ComprobanteForm();
            string[] datos = r.DatosComprobante;

            comprobante.lbComprobante.Items.Add("Fecha: "+datos[3]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add(datos[0]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add(datos[2]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Pasajeros admitidos: "+ datos[1]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add(datos[4]);
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Costo por dia "+ String.Format("${0:C2}", datos[5]));
            comprobante.lbComprobante.Items.Add("");
            comprobante.lbComprobante.Items.Add("Precio total "+ String.Format("${0:C2}", datos[6]));

            comprobante.ShowDialog();
            comprobante.Dispose();
        }






        //MENU STRIP OPTIONS:::::
        //MENU STRIP OPTIONS:::::
        //MENU STRIP OPTIONS:::::
        //MENU STRIP OPTIONS:::::

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream archivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(archivo, empresa);
            archivo.Close();
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
            PrecioBaseForm vInicio = new PrecioBaseForm();
            vInicio.Text = "Modificar Precio Base de Hoteles";

            vInicio.rbSi.Checked = true;
            vInicio.btnContinuar.Enabled = false;

            if (vInicio.ShowDialog() == DialogResult.OK)
            {
                empresa.Preguntar = !vInicio.cbPreguntar.Checked;
                if (vInicio.rbSi.Checked)
                    empresa.PrecioBaseHotel = Convert.ToDouble(vInicio.tbPrecio.Text);
            }
            vInicio.Dispose();
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

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
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

                sr.ReadLine();//descripcion casas
                sr.ReadLine();//descripcion Hoteles
                string linea;
                string[] campos;
                Dictionary<int, Alojamiento> lineaExistentes = new Dictionary<int,Alojamiento>();
               
                int contLinea = 0;
                while(!sr.EndOfStream)
                {
                    contLinea++;
                    linea = sr.ReadLine();
                    campos = linea.Split(';');
                    Alojamiento nuevo=null;

                    if(campos.Length == 10)
                    {
                        string direc= campos[0];
                        int minDias= Convert.ToInt32(campos[1]);
                        int camas = Convert.ToInt32(campos[2]);
                        double precioBaseCasa= Convert.ToDouble(campos[3]);

                        string[] servicios;
                        linea = null;

                        for(int i=4; i<campos.Length; i++)
                        {
                            linea += campos[i]+";";
                        }
                        servicios=linea.Trim(';').Split(';');

                        nuevo= new Casa(direc,minDias,camas,servicios,precioBaseCasa);
                    }
                    if(campos.Length==6)
                    {
                        string direc = campos[0];
                        string nombre= campos[1];
                        bool tresEstrellas= Convert.ToBoolean(campos[2]);
                        int cantSimples= Convert.ToInt32(campos[3]);
                        int cantDobles= Convert.ToInt32(campos[4]);
                        int cantTriples= Convert.ToInt32(campos[5]);

                        nuevo = new Hotel(direc, nombre, tresEstrellas, cantSimples, cantDobles, cantTriples);
                    }

                    Alojamiento comparador = empresa[nuevo.Direccion];
                    if (comparador ==null)
                    {
                        empresa.AgregarAlojamiento(nuevo);
                    }
                    else
                    {
                        lineaExistentes.Add(contLinea, comparador);
                        empresa.DisminuirContadorCasas();
                    }
                        
                }

                if (lineaExistentes.Count > 0)
                {
                    AlojamientosExistentesForm exists = new AlojamientosExistentesForm();

                    exists.listBox1.Items.Add("Se han encontrado alojamientos que ya estaban cargados o que la dirección ");
                    exists.listBox1.Items.Add("coincide con alguno de los cargados");
                    exists.listBox1.Items.Add("");
                    foreach (var pareja in lineaExistentes)
                    {
                        exists.listBox1.Items.Add(pareja.Value.ToString() + " // LINEA: " + pareja.Key);
                    }
                    exists.Show();
                }
                if(contLinea==lineaExistentes.Count)
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
            sfd.DefaultExt = ".txt";  sfd.AddExtension = true;
            //ofd.Filter = "texto |.txt";
            FileStream fs;
            StreamWriter sw;

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create,FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine("direccion; minDias; camas; precioBaseCasa; s1; s2; s3; s4; s5; s6 //Para casas");
                sw.WriteLine("direccion, nombre, tresEstrellas, cantSimples, cantDobles, cantTriples //Para Hoteles");
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

        /*private void importarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exportarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        */
        private void verListaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

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
                    int edad;


                    if(campos.Length==5)
                    {
                        id = Convert.ToInt16(campos[0]);
                        nombre=campos[1];
                        apellido=campos[2];
                        dni= Convert.ToInt32(campos[3]);
                        edad=Convert.ToInt32(campos[4]);

                        Cliente nuevo=new Cliente(nombre,apellido,dni,edad);

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
            sfd.DefaultExt = ".txt"; sfd.AddExtension = true;
            //ofd.Filter = "texto |.txt";
            FileStream fs;
            StreamWriter sw;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine("ID , NOMBRE , APELLIDO , DNI , EDAD");

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

        //MENU STRIP ACERCADE - INFO:::::
        //MENU STRIP ACERCADE - INFO:::::
        //MENU STRIP ACERCADE - INFO:::::
        //MENU STRIP ACERCADE - INFO:::::
        /*
        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        */
    }
}
