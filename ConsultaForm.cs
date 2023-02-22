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

namespace TP_II
{
    public partial class ConsultaForm : Form
    {
        public ConsultaForm()
        {
            InitializeComponent();
        }
        IInterectuable form1;

        public void SetConsultor(Form consultor)
        {
            form1 = (IInterectuable)consultor;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArrayList actuales = form1.ActualizarConsulta();
            List<Alojamiento> lista = new List<Alojamiento>();

            foreach (Object actual in actuales)
            {
                lista.Add((Alojamiento)actual);
                //sadsa
            }

            dataGridDisponibles.Rows.Clear();
            string[] campos = new string[6];

            foreach (Alojamiento a in actuales)
            {
                if (a is Casa)
                {
                    campos[0] = "Casa";
                    campos[1] = a.Direccion;
                    campos[2] = "-";
                    campos[3] = "-";
                    campos[4] = ((Casa)a).Camas + " personas";
                    campos[5] = ((Casa)a).MinDias.ToString();
                }
                else
                {
                    string status;
                    if (((Hotel)a).TresEstrellas)
                        status = "3 Estrellas";
                    else
                        status = "2 Estrellas";

                    campos[0] = "Hotel";
                    campos[1] = a.Direccion;
                    campos[2] = ((Hotel)a).Nombre;
                    campos[3] = status;
                    campos[4] = ((Hotel)a).TotalCamas + " personas";
                    campos[5] = "-";
                }
                //dataGridDisponibles.Rows.Clear();
                dataGridDisponibles.Rows.Add(campos);
            }

        }

        private void checkBoxHotel_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxHotel.Checked)
                checkB3Estrellas.Visible = true;
            else
            {
                checkB3Estrellas.Visible=false;
                checkB3Estrellas.Checked=false;
            }
        }

        private void ConsultaForm_Load(object sender, EventArgs e)
        {
            gBoxFiltroFecha.Enabled=false;
        }
        /*-------------------------------------------------- EVENTO DOBLE CLICK DATAGRIDVIEW ----------------------------------------------*/
        /*-------------------------------------------------- EVENTO DOBLE CLICK DATAGRIDVIEW ----------------------------------------------*/
        /*-------------------------------------------------- EVENTO DOBLE CLICK DATAGRIDVIEW ----------------------------------------------*/
        /*-------------------------------------------------- EVENTO DOBLE CLICK DATAGRIDVIEW ----------------------------------------------*/
        /*-------------------------------------------------- EVENTO DOBLE CLICK DATAGRIDVIEW ----------------------------------------------*/

        private void dataGridDisponibles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AlojamientoForm vAlojomiento = new AlojamientoForm();
            vAlojomiento.btnCancelarReserva.Enabled = false;
            vAlojomiento.btnReservar.Enabled = true;
            vAlojomiento.btnImprimir.Enabled = false;
            vAlojomiento.SetConsultor(form1);

            int indiceC = 1;
            int indeceR = e.RowIndex;           
            string direccion = dataGridDisponibles[indiceC, indeceR].Value.ToString();
            Alojamiento aBuscar = new Casa(direccion,"","", 1, 1, null, 1.0);
            aBuscar=(Alojamiento)form1.BuscarAlojamiento(aBuscar);
            DateTime[] fechas;

            if (aBuscar is Casa)
            {
                fechas = aBuscar.IntervaloFechasReservadas();
                Casa casa = (Casa)aBuscar;
                vAlojomiento.SetAlojamiento(casa);
                vAlojomiento.nudDias.Minimum = casa.MinDias;
                vAlojomiento.nudDias.Value = casa.MinDias;
                vAlojomiento.Calendario.BoldedDates = fechas;//pintar calendario casa

                vAlojomiento.lbDescripcion.Text= casa.ToString();
                vAlojomiento.cBoxNroHabitaciones.Enabled = false;
                vAlojomiento.cBoxTipoHab.Enabled = false;
                vAlojomiento.lbNumHabitacion.Text= "Capacidad: "+ casa.Camas.ToString() + " personas";
                form1.SetCapacidad(casa.Camas);

                if (vAlojomiento.ShowDialog()==DialogResult.OK)
                {
                    int dias = Convert.ToInt32(vAlojomiento.nudDias.Value);
                    DateTime inicio = vAlojomiento.Calendario.SelectionStart;
                    DateTime fin = inicio.AddDays(dias - 1); // -1 porque se cuenta el dia mismo de inicio
                    if (!casa.CheckFecha(inicio, fin))
                        MessageBox.Show("Rango de fecha invalido"); 
                    else
                    {
                        DatosClienteForm vCliente = new DatosClienteForm();

                        // Manejo evento click del boton "Agregar pasajeros" en ventana DatosCliente
                        vCliente.btnPasajeros.Click += new System.EventHandler(form1.btnPasajeros_Click);

                        if (vCliente.ShowDialog()==DialogResult.OK)
                        {
                            string nombre = vCliente.tbNombre.Text;
                            string apellido = vCliente.tbApellido.Text;
                            int dni = Convert.ToInt32(vCliente.tbDni.Text);
                            DateTime fNacimiento = vCliente.fNacimiento.Value;
                            Cliente cliente = new Cliente(nombre,apellido,dni, fNacimiento);
                            List<Cliente> pasajeros = form1.GetPasajeros();

                            Reserva reserva;
                            if (pasajeros.Count > 0)
                            {
                                reserva = new Reserva(cliente, casa, inicio, fin, casa.PrecioBaseCasa,pasajeros);
                            }
                            else
                                reserva = new Reserva(cliente, casa, inicio, fin, casa.PrecioBaseCasa);
                            form1.AgregarReserva(reserva);
                            form1.EmitirComprobante(reserva);
                        }

                        // Quito evento click del boton "Agregar pasajeros" en ventana DatosCliente
                        vCliente.btnPasajeros.Click -= new System.EventHandler(form1.btnPasajeros_Click);
                    }
                }
            }    
            else
            {
                Hotel hotel = (Hotel)aBuscar;
                vAlojomiento.SetAlojamiento(hotel);

                vAlojomiento.lbDescripcion.Text = "Tipo Habitación:";
                vAlojomiento.cBoxTipoHab.Enabled = true;
                vAlojomiento.cBoxNroHabitaciones.Enabled = true;
                

                if (vAlojomiento.ShowDialog() == DialogResult.OK)
                {
                    int dias=0;
                    int nroHabitacion=0;
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
                                    form1.SetCapacidad(1);
                                    break;
                                case "Doble":
                                    form1.SetCapacidad(2);
                                    break;
                                case "Triple":
                                    form1.SetCapacidad(3);
                                    break;
                            }

                            // Manejo evento click del boton "Agregar pasajeros" en ventana DatosCliente
                            vCliente.btnPasajeros.Click += new System.EventHandler(form1.btnPasajeros_Click);

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
                                    List<Cliente> pasajeros = form1.GetPasajeros();
                                    Reserva reserva;
                                    if (pasajeros.Count > 0)
                                    {
                                        reserva = new Reserva(cliente, hotel, inicio, fin, form1.GetPrecioBaseHoteles(), reservada, pasajeros);
                                    }
                                    else
                                        reserva = new Reserva(cliente, hotel, inicio, fin, form1.GetPrecioBaseHoteles(), reservada);
                                    
                                    form1.AgregarReserva(reserva);
                                    form1.EmitirComprobante(reserva);
                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("Error en los Datos ingresados");
                                }

                            }
                            // Quito evento click del boton "Agregar pasajeros" en ventana DatosCliente
                            vCliente.btnPasajeros.Click -= new System.EventHandler(form1.btnPasajeros_Click);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en el Ingreso de datos para la reserva");
                    }
                    
                }

            }
        }

        private void chechBoxFiltrarPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(chechBoxFiltrarPorFecha.Checked)
            {
                gBoxFiltroFecha.Enabled = true;
            }
            else
                gBoxFiltroFecha.Enabled= false;
        }


    }
}
