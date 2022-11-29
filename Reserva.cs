using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    [Serializable]
    public class Reserva:IComparable
    {
        
        private static int contIdReservas = 1000;
        private Cliente cliente;
        private Alojamiento alojamiento;
        private Habitacion habitacionReservada;
        private List<Cliente> pasajeros = new List<Cliente>();
        private DateTime ingreso;
        private DateTime egreso;
        private TimeSpan periodo;
       
        private double precioBaseReserva;
        private double precioDia;
        private string[] comprobante;
        private readonly int id;

        public Reserva(Cliente cliente, Alojamiento alojamiento,DateTime ingreso, DateTime egreso,double precioBase,Habitacion h)
        {
            this.cliente = cliente;
            this.alojamiento = alojamiento;
            this.ingreso = ingreso;
            this.egreso = egreso;
            this.periodo = egreso.AddDays(1).Subtract(ingreso);
            this.precioBaseReserva=precioBase;
            habitacionReservada = h;
            id = contIdReservas;
            contIdReservas++;
            Cliente.ContIdCliente++;
            CalcularPrecioDia();
            GenerarComprobante();

        }

        public Reserva(Cliente cliente, Alojamiento alojamiento, DateTime ingreso, DateTime egreso, double precioBase)
        {
            this.cliente = cliente;
            this.alojamiento = alojamiento;
            this.ingreso = ingreso;
            this.egreso = egreso;
            this.periodo = egreso.AddDays(1).Subtract(ingreso);
            this.precioBaseReserva = precioBase;
            habitacionReservada = new Habitacion(-1, Habitacion.Tipos.Simple);
            this.id = contIdReservas;
            contIdReservas++;
            Cliente.ContIdCliente++;
            CalcularPrecioDia();
            GenerarComprobante();
        }

        public Reserva(Cliente cliente, Alojamiento alojamiento, DateTime ingreso, DateTime egreso, double precioBase, List<Cliente> p)
        {
            this.cliente = cliente;
            this.alojamiento = alojamiento;
            this.ingreso = ingreso;
            this.egreso = egreso;
            this.periodo = egreso.AddDays(1).Subtract(ingreso);
            this.precioBaseReserva = precioBase;
            habitacionReservada =  new Habitacion(-1, Habitacion.Tipos.Simple);
            if (p.Count > 0)
                p.ForEach(acomp => pasajeros.Add(acomp));
            id = contIdReservas;
            contIdReservas++;
            Cliente.ContIdCliente++;
            CalcularPrecioDia();
            GenerarComprobante();
        }

        public Reserva(Cliente cliente, Alojamiento alojamiento, DateTime ingreso, DateTime egreso, double precioBase, Habitacion h, List<Cliente> p)
        {
            this.cliente = cliente;
            this.alojamiento = alojamiento;
            this.ingreso = ingreso;
            this.egreso = egreso;
            this.periodo = egreso.AddDays(1).Subtract(ingreso);
            this.precioBaseReserva = precioBase;
            p.ForEach(acomp => pasajeros.Add(acomp));
            habitacionReservada = h;          
            id = contIdReservas;
            contIdReservas++;
            Cliente.ContIdCliente++;
            CalcularPrecioDia();
            GenerarComprobante();

        }

        public void AgregarHabitacion(Habitacion habitacion)
        {
            habitacionReservada = habitacion;
            comprobante[0] += " - " + habitacionReservada.ToString();
            comprobante[1] += habitacionReservada.Tipo;
        }
        public void QuitarHabitacion(Habitacion habitacion)
        {
            habitacionReservada = null;
        }

        public void CalcularPrecioDia()
        {
            precioDia=alojamiento.PrecioDia(this);
        }

        public void GenerarComprobante()
        {
            string[] datos = new string[8];
            DateTime fecha = DateTime.Now;

            datos[0] = Alojamiento.ToString();
            datos[2] = getCliente.ToString();
            datos[3] = fecha.ToLongDateString();
            datos[4] = String.Format("Ingreso {0}, Egreso {1}", Ingreso, Egreso);
            datos[5] = PrecioDia.ToString();
            datos[6] = PrecioTotal.ToString();

            if (pasajeros.Count > 0)
            {
                foreach (Cliente p in pasajeros)
                    datos[7] += String.Format("{0}-", p.NombreCompleto);
                //datos[7] += String.Format("{0}\n\r", p.ToString());

            }
            else
                datos[7] = "-";

            if (Alojamiento is Casa)
                datos[1] += ((Casa)Alojamiento).Camas;
            else
                datos[1] = habitacionReservada.Tipo.ToString();

            comprobante = datos;
        }

        public Reserva Modificar(Cliente cliente,DateTime ingreso, DateTime egreso, List<Cliente> pasajeros)
        {
            string fecha = comprobante[3];

            ////////////         PARA MANTENER EL MISMO ID ORIGINAL
            int idOriginal = this.cliente.IDcliente;
            this.cliente = cliente;
            cliente.IDcliente = idOriginal;
            // Cliente.ContIdCliente--;
            ///////////

            this.ingreso = ingreso;
            this.egreso = egreso;
            this.periodo = egreso.AddDays(1).Subtract(ingreso);
            this.pasajeros = pasajeros;

            CalcularPrecioDia();
            GenerarComprobante();
            comprobante[3] = fecha;
            return this;
        }

        public void AgregarPasajero(Cliente pasajero)
        {
            pasajeros.Add(pasajero);
        }

        public void RemoverPasajero(Cliente pasajero)
        {
            pasajeros.Add(pasajero);
            //pasajeros.Remove(pasajero);
        }
        public override string ToString()
        {
            if(alojamiento is Casa)
                return String.Format("IDR:{0} - {1}: {2} - Alojamiento: {3}",id , cliente.IDcliente , cliente.NombreCompleto , alojamiento.ToString());
            else
                return String.Format("IDR:{0} - {1}: {2} - Alojamiento: {3} - NroHabitacion: {4}",id , cliente.IDcliente , cliente.NombreCompleto , alojamiento.ToString(),habitacionReservada.ToString());
        }
        public string[] ExportarCasa()
        {
            string[] ret = new string[5];
            ret[0] = cliente.DNI.ToString();
            ret[1] = alojamiento.IDalojamiento.ToString();
            ret[2] = ingreso.ToString();
            ret[3] = egreso.ToString();

            if (pasajeros.Count > 0)
            {
                foreach (Cliente p in pasajeros)
                    ret[4] += String.Format("{0}-", p.NombreCompleto);
            }
            else
                ret[4] = "-";

            return ret;
        }
        public string[] ExportarHotel()
        {
            string[] ret = new string[6];
            ret[0] = cliente.DNI.ToString();
            ret[1] = alojamiento.IDalojamiento.ToString();
            ret[2] = ingreso.ToString();
            ret[3] = egreso.ToString();
            ret[4] = habitacionReservada.Numero.ToString();

            if (pasajeros.Count > 0)
            {
                foreach (Cliente p in pasajeros)
                    ret[5] += String.Format("{0}-", p.NombreCompleto);
            }
            else
                ret[5] = "-";

            return ret;
        }
        public string[] ExportarDatosReserva()
        {
            string[] retorno = new string[6];
            retorno[0] = cliente.DNI.ToString();
            retorno[1] = alojamiento.IDalojamiento.ToString();
            retorno[2] = ingreso.ToString();
            retorno[3] = egreso.ToString();
            retorno[4] = habitacionReservada.Numero.ToString();

            if (pasajeros.Count > 0)
            {
                foreach (Cliente p in pasajeros)
                    retorno[5] += String.Format("{0}-", p.NombreCompleto);
            }
            else
                retorno[5] = "-";
            return retorno;
        }
        public int CompareTo(object o)
        {
            return this.id.CompareTo(((Reserva)o).id);
        }
        
        public Habitacion HabitacionReservada { get { return habitacionReservada; } }
        public int Dias { get { return periodo.Days; } }
        public double PrecioBaseReserva { get { return precioBaseReserva; } }
        public double PrecioDia { get { return precioDia; } }
        public double PrecioTotal { get { return precioDia * Dias; } }
        public Alojamiento Alojamiento { get { return alojamiento; } }
        public DateTime Ingreso
        {
            get { return ingreso; }
        }
        public DateTime Egreso
        {
            get { return egreso; }
        }
        public Cliente getCliente { get { return cliente; } }
        public int ID { get { return id; } }

        public List<Cliente> Pasajeros { get { return pasajeros; } }

        public string[] DatosComprobante { get { return comprobante; } }
        public static int ContIdReservas { get { return contIdReservas; } set { contIdReservas = value; } }
    }
}
