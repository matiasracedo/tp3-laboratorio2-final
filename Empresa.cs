using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Drawing; 

namespace TP_II
{
    [Serializable]
    public class Empresa
    {
        private List<Reserva> reservas = new List<Reserva>();
        private List<Alojamiento> alojamientos = new List<Alojamiento>();
        private List<Casa> casas = new List<Casa>();
        private List<Hotel> hoteles = new List<Hotel>();
        private List<Cliente> clientesHistorico = new List<Cliente>();

        public int contBackReservas;
        public int contBackCliente;
        public int contBackAlojamientos;
        public int contBackCasas;

        private bool preguntar = true;

        private double precioBaseHotel;
        private SortedList<string,List<string>> lugares = new SortedList<string,List<string>>(); // son objects

        public Empresa(List<string> lugares)
        {
            foreach (string l in lugares)
                this.lugares.Add(l,new List<string>());         
        }
        public Empresa()
        {
            string[] jurisdicciones = {"Buenos Aires","Ciudad Autónoma de Buenos Aires","Catamarca","Chaco","Chubut","Córdoba","Corrientes",
                                    "Entre Ríos","Formosa","Jujuy","La Pampa","La Rioja","Mendoza","Misiones",
                                    "Neuquén","Río Negro","Salta","San Juan","San Luis","Santa Cruz","Santa Fe",
                                    "Santiago del Estero","Tierra del Fuego","Tucumán"};


            foreach (string s in jurisdicciones)
                lugares.Add(s, new List<string>());
        }
        public void AgregarAlojamiento(Alojamiento nuevo)
        {
            alojamientos.Add(nuevo);
            if (nuevo is Casa)
                casas.Add(nuevo as Casa);
            else
                hoteles.Add(nuevo as Hotel);

            AgregarLugar(nuevo.Jurisdiccion, nuevo.Ciudad);
        }
        public void AgregarLugar(string jurisdiccion,string ciudad)
        {
            if(!lugares[jurisdiccion].Contains(ciudad))
                lugares[jurisdiccion].Add(ciudad);

        }

        public void AgregarReservas(Reserva r)
        {
            Alojamiento a = r.Alojamiento;
            reservas.Add(r);
            a.Reservas.Add(r);
            if (r.Alojamiento is Hotel)
                ((Hotel)a).AgregarReserva(r.HabitacionReservada.Numero, r);

            if (clientesHistorico != null && !clientesHistorico.Contains(r.getCliente))
                clientesHistorico.Add(r.getCliente);
        }
        public void CancelarReserva(int id)
        {
            Reserva quitar = this[id];
            quitar.Alojamiento.Reservas.Remove(quitar);

            reservas.Remove(quitar);
        }

        public void OrdenarReservasPorId()
        {
            reservas.Sort();
            if (alojamientos.Count > 0)
            {
                foreach (Alojamiento a in alojamientos)
                    a.Reservas.Sort();
            }
        }
        public Reserva this[int id]
        {
            get
            {
                Reserva devolver = null;

                if (reservas.Count > 0)
                {
                    foreach (Reserva reserva in reservas)
                    {
                        if (reserva.ID == id)
                            devolver = reserva;
                    }
                }
                return devolver;
            }
        }

        public string AltaYBaja(string direccion)
        {
            Alojamiento actualizable = this[direccion];
            if (actualizable != null)
            {
                actualizable.Alta = !actualizable.Alta;
            }
            return actualizable.Estado;
        }


        public List<Alojamiento> FiltrarCasas(int cantCamas, String[] servicios)
        {
            List<Alojamiento> filtrados = new List<Alojamiento>();

            foreach (Casa a in casas)
            {
                if (a.Alta && a.FiltrarCasa(cantCamas, servicios))
                    filtrados.Add(a);
            }
            return filtrados;
        }
        public List<Alojamiento> FiltrarHoteles(bool tresEstrellas)
        {
            List<Alojamiento> filtrados = new List<Alojamiento>();
            if (tresEstrellas)
            {
                foreach (Hotel h in hoteles)
                {
                    if (h.Alta && h.TresEstrellas)
                        filtrados.Add(h);
                }
            }
            else
            {
                foreach (Hotel h in hoteles)
                {
                    if (h.Alta)
                        filtrados.Add(h);
                }
            }

            return filtrados;
        }
        public List<Alojamiento> FiltrarFechaRango(List<Alojamiento> rango, DateTime fechaInicio, DateTime fechaFinal)
        {
            Alojamiento[] copia = new Alojamiento[rango.Count];
            rango.CopyTo(copia);

            foreach (Alojamiento a in copia)
            {
                if (a.CheckFecha(fechaInicio, fechaFinal) == false)
                    rango.Remove(a);
            }
            return rango;
        }
        public void DisminuirContadorCasas()
        {
            Casa.ContCasa--;
        }
        public List<Reserva> ListaDeReservas { get { return reservas; } }
        public List<Alojamiento> Alojamientos { get { return alojamientos; } }
        public Alojamiento this[string direccion]
        {
            get
            {
                bool encontrado = false;
                int cont = 0;
                Alojamiento comparador;

                // int indice = empresa.Alojamientos.BinarySearch(unAlojameinto); OTRA OPCION DE BUSQUEDA

                while (encontrado == false && cont < alojamientos.Count)
                {
                    comparador = alojamientos[cont];

                    if (comparador.Direccion == direccion)
                    {
                        return comparador;
                    }
                    cont++;
                }

                return null;
            }
        }
        public bool VerificarJurisdiccion(string jurisdiccion)
        {
            bool verificado = false;

            if (lugares!=null && lugares.ContainsKey(jurisdiccion))
                verificado = true;

            return verificado;
        }
        public string[] GenerarComprobante(Reserva reserva)
        {
            return reserva.DatosComprobante;
        }
        public double PrecioBaseHotel { get { return precioBaseHotel; } set { precioBaseHotel = value; } }
        public bool Preguntar { get { return preguntar; } set { preguntar = value; } }
        public int NumeroCasaSiguiente { get { return Casa.ContCasa; } }
        public List<Cliente> GetClientesHistoricos { get { return clientesHistorico; } }
        public List<Cliente> GetClientesActuales
        {
            get
            {
                List<Cliente> ret = new List<Cliente>();
                foreach (Reserva r in reservas)
                    ret.Add(r.getCliente);
                return ret;
            }
        }
        public bool HayReservasCasas
        {

            get
            {
                bool hay = false;
                int cont = 0;

                while (hay == false && cont < reservas.Count)
                {
                    if (reservas[cont].Alojamiento is Casa)
                        hay = true;

                    cont++;
                }

                return hay;
            }
        }
        public bool HayReservasHoteles
        {

            get
            {
                bool hay = false;
                int cont = 0;

                while (hay == false && cont < reservas.Count)
                {
                    if (reservas[cont].Alojamiento is Hotel)
                        hay = true;

                    cont++;
                }

                return hay;
            }
        }
        public bool ExisteCliente(ref Cliente cliente)
        {
            bool ret = false;

            if (clientesHistorico.Count > 0)
            {
                clientesHistorico.Sort();
                int index = clientesHistorico.BinarySearch(cliente);

                if (index > -1)
                {
                    ret = true;
                    cliente = clientesHistorico[index];
                }
            }
            return ret;
        }
        public Cliente ExisteCliente(int dni)
        {
            Cliente retorno = null;
            clientesHistorico.Sort();
            Cliente c = new Cliente("a", "a", dni,new DateTime(1990,1,1));
            int indice = clientesHistorico.BinarySearch(c);
            if (indice > -1)
                retorno = clientesHistorico[indice];
            return retorno;
        }
        public bool ExisteAlojamiento(int id, ref Alojamiento buscado)
        {
            bool encontrado = false;
            int cont = 0;
            int max = alojamientos.Count;

            if (max > 0)
            {
                while (encontrado == false && cont < max)
                {
                    if (alojamientos[cont].IDalojamiento == id)
                    {
                        encontrado = true;
                        buscado = alojamientos[cont];
                    }
                    cont++;
                }
            }
            return encontrado;
        }
        public Alojamiento ExisteAlojamiento(int id)
        {
            bool encontrado = false;
            Alojamiento retorno = null;
            int cont = 0;
            while (!encontrado && cont < alojamientos.Count)
            {
                if (alojamientos[cont].IDalojamiento == id)
                {
                    encontrado = true;
                    retorno = alojamientos[cont];
                }
                cont++;
            }
            return retorno;

        }
        
        public bool ExisteAlojamiento(int id, ref Alojamiento buscado, int nroHabitacion)
        {
            bool encontrado = false;
            int cont = 0;
            int max = alojamientos.Count;

            if (max > 0)
            {
                Alojamiento aloj;
                while (encontrado == false && cont < max)
                {                 
                    aloj = alojamientos[cont];

                    if(aloj is Hotel)
                    {
                        Hotel actual = aloj as Hotel;
                        if (actual.IDalojamiento == id && actual.GetHabitacion(nroHabitacion)!=null)
                        {
                            encontrado = true;
                            buscado = alojamientos[cont];
                        }

                    }                    
                    cont++;
                }
            }

            return encontrado;
        }


        public bool ExisteReservaCasa(Cliente cliente, Alojamiento alojamiento, DateTime ingreso, DateTime egreso)
        {
            bool ret = false;
            foreach (Reserva r in alojamiento.Reservas)
            {
                if (cliente.CompareTo(r.getCliente) == 0 && DateTime.Compare(ingreso, r.Ingreso) == 0 && DateTime.Compare(egreso, r.Egreso) == 0)
                {
                    ret = true;
                }
            }
            return ret;
        }
        public bool ExisteReservaHotel(Cliente cliente, Hotel hotel, DateTime ingreso, DateTime egreso, int nroHabitacion)
        {
            bool ret = false;
            List<Reserva> reservas = hotel.GetReservasDeHabitacion(nroHabitacion);
            if(reservas.Count>0)
            {
                foreach (Reserva r in reservas)
                {
                    if (cliente.CompareTo(r.getCliente) == 0 && DateTime.Compare(ingreso, r.Ingreso) == 0 && DateTime.Compare(egreso, r.Egreso) == 0)
                        ret = true;
                }
            }
            return ret;
        }

        public Reserva ExisteReserva(Cliente cliente, Alojamiento alojamiento, DateTime ingreso, DateTime egreso, int nroHabitacion)
        {
            Reserva retorno = null;
            bool encontrado = false;
            int cont = 0;
            while (!encontrado && cont < ListaDeReservas.Count)
            {
                if(nroHabitacion == ListaDeReservas[cont].HabitacionReservada.Numero)
                {
                    if (cliente.CompareTo(alojamiento.Reservas[cont].getCliente) == 0 &&
                    DateTime.Compare(ingreso, alojamiento.Reservas[cont].Ingreso) == 0 &&
                    DateTime.Compare(egreso, alojamiento.Reservas[cont].Egreso) == 0)
                    {
                        retorno = alojamiento.Reservas[cont];
                        encontrado = true;
                    }
                }
                cont++;
            }
            return retorno;
        }
        public void ImportarClientes(List<Cliente> clientesNuevos)
        {
            foreach (Cliente cliente in clientesNuevos)
            {
                cliente.IDcliente = Cliente.ContIdCliente;
                Cliente.ContIdCliente++;
                clientesHistorico.Add(cliente);
            }
        }

        // Metodos de Importacion / Exportacion para Reservas
        public void ExportarReservasDeAlojamiento(Alojamiento alojamiento, string path)
        {

            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine("DNICLIENTE , IDALOJAMIENTO , CHECKIN , CHECKOUT , NROHABITACION , ACOMPANIANTES");
                string linea = null;
                string[] campos = null;

                foreach (Reserva r in alojamiento.Reservas)
                {
                    campos = r.Exportar();
                    linea = campos[0] + "," + campos[1] + "," + campos[2] + "," + campos[3] + "," + campos[4] + "," + campos[5];
                    sw.WriteLine(linea);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Exportacion: " + ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    sw.Close();
                    fs.Close();
                }
            }
        }

        public Dictionary<int, string> ImportarReservasDeAlojamiento(string path)
        {
            /*      linea - descripcion        */
            Dictionary<int, string> errores = new Dictionary<int, string>();
            Dictionary<int, string> aciertos = new Dictionary<int, string>();
            FileStream fs = null;
            StreamReader sr = null;
            int contLinea = 1;
            string[] campos;

            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                int dni;
                int id;
                DateTime ingreso;
                DateTime egreso;
                int nroHabitacion;
                List<Cliente> acompañantes = new List<Cliente>();

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    campos = sr.ReadLine().Split(',');
                    //DNICLIENTE , IDALOJAMIENTO , CHECKIN , CHECKOUT , NROHABITACION , ACOMPANIANTES
                    dni = Convert.ToInt32(campos[0]);
                    id = Convert.ToInt32(campos[1]);
                    ingreso = DateTime.Parse(campos[2]);
                    egreso = DateTime.Parse(campos[3]);
                    nroHabitacion = Convert.ToInt32(campos[4]);
                    string linea = campos[5].TrimEnd('-');
                    if (linea != "")
                    {
                        string[] nombreApellido = linea.Split('-');
                        string[] aux;
                        Cliente pasajero;
                        foreach (string s in nombreApellido)
                        {
                            aux = s.Split(' ');
                            pasajero = new Cliente(aux[0], aux[1]);
                            acompañantes.Add(pasajero);
                        }
                    }

                    Alojamiento a = null;
                    Habitacion h = null;
                    Cliente c = null;
                    Reserva r = null;

                    a = ExisteAlojamiento(id);
                    if (a != null) // si existe
                    {
                        c = ExisteCliente(dni);
                        if (c == null) // No Existe
                        {
                            c = new Cliente("Generico", "Generico");
                            clientesHistorico.Add(c);
                        }
                        r = ExisteReserva(c, a, ingreso, egreso, nroHabitacion);
                        if (r == null) //No existe
                        {        
                            if (nroHabitacion >= 0)
                            {
                                Hotel ah = (Hotel)a;
                                h = ah.GetHabitacion(nroHabitacion);
                                if (ah.CheckFechaHabitacion(ingreso,egreso,nroHabitacion))
                                {
                                    r = new Reserva(c, a, ingreso, egreso, precioBaseHotel, h, acompañantes);
                                    AgregarReservas(r);
                                    aciertos.Add(contLinea,String.Format("Alojamiento: {0} -- Ingreso: {1} -- Egreso: {2}",r.Alojamiento.ToString(),r.Ingreso,r.Egreso));
                                }
                                else
                                    errores.Add(contLinea, "La Habitacion se encuentra ocupada");
                            }
                            else
                            {
                                h = new Habitacion(-1, Habitacion.Tipos.Simple);
                                r = new Reserva(c, a, ingreso, egreso, precioBaseHotel, h, acompañantes);
                                AgregarReservas(r);
                                aciertos.Add(contLinea, String.Format("Alojamiento: {0} -- Ingreso: {1} -- Egreso: {2}", r.Alojamiento.ToString(), r.Ingreso, r.Egreso));
                            }

                        }
                        else
                            errores.Add(contLinea, "La Reserva ya Existe");
                       
                    }
                    else
                        errores.Add(contLinea, "El Alojamiento No Existe");
                    contLinea++;

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error en la Importacion: " + ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    sr.Close();
                    fs.Close();
                }
            }
            return errores;
        }

        public double[] DatosGraficoAlojamientos()
        {
            int cantReservados = 0;
            int cantHoteles = 0;
            int cantCasas = 0;
            double[] retorno = new double[3];

            foreach (Casa c in casas)
            {
                if (c.Reservas.Count > 0)
                {
                    cantReservados++;
                    cantCasas++;
                }
            }
            foreach (Hotel h in hoteles)
            {
                if (h.Reservas.Count > 0)
                {
                    cantReservados++;
                    cantHoteles++;
                }
            }

            retorno[0] = Math.Round((cantReservados * 100.0) / alojamientos.Count, 2);
            retorno[1] = Math.Round((cantCasas * 100.0) / alojamientos.Count, 2);
            retorno[2] = Math.Round((cantHoteles * 100.0) / alojamientos.Count, 2);
            return retorno;
        }
        public Dictionary<int, double[]> DatosGraficoClientes()
        {
            //        key    -----    value
            //   N° Clientes -----  [Cant]-[%]
            Dictionary<int, double[]> retorno = new Dictionary<int, double[]>();
            double[] aux = { 0, 0 };

            for (int i = 1; i < 7; i++)
                retorno.Add(i, new double[] {0,0});

            foreach (Reserva r in reservas)
            {
                switch (r.Pasajeros.Count)
                {
                    case 0:
                        {
                            aux = retorno[1];
                            aux[0] += 1;
                        }
                        break;
                    case 1:
                        {
                            aux = retorno[2];
                            aux[0] += 1;
                        }
                        break;
                    case 2:
                        {
                            aux = retorno[3];
                            aux[0] += 1;
                        }
                        break;
                    case 3:
                        {
                            aux = retorno[4];
                            aux[0] += 1;
                        }
                        break;
                    case 4:
                        {
                            aux = retorno[5];
                            aux[0] += 1;
                        }
                        break;
                    case 5:
                        {
                            aux = retorno[6];
                            aux[0] += 1;
                        }
                        break;
                    default:
                        {
                            aux = retorno[6];
                            aux[0] += 1;
                        }
                        break;
                }
            }
            foreach (KeyValuePair<int, double[]> pair in retorno)
            {
                pair.Value[1] = Math.Round((pair.Value[0] * 100.0) / reservas.Count, 2);
            }
            return retorno;
        }
        public List<string> Jurisdicciones
        {
            get
            {
                List<string> ret = new List<string>();
                foreach(string s in lugares.Keys)
                    ret.Add(s);

                return ret;
            }
        }
        public List<string> Ciudades(string jurisdiccion)
        {
                return lugares[jurisdiccion];
        }
    }
}
