using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    [Serializable]
   public class Empresa
    {
        List<Reserva> reservas = new List<Reserva>();
        List<Alojamiento> alojamientos = new List<Alojamiento>();    
        List<Casa> casas = new List<Casa>();
        List<Hotel> hoteles= new List<Hotel>();

        public int contBackReservas;
        public int contBackCliente;
        public int contBackAlojamientos;

        private bool preguntar=true;

        private double precioBaseHotel;

        

        public void AgregarAlojamiento(Alojamiento nuevo)
        {
            alojamientos.Add(nuevo);
            if(nuevo is Casa)
                casas.Add(nuevo as Casa);
            else
                hoteles.Add(nuevo as Hotel);    
        }

        public void AgregarReservas(Reserva nueva)
        {
                reservas.Add(nueva);
                nueva.Alojamiento.Reservas.Add(nueva);
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
            if(alojamientos.Count>0)
            {
                foreach(Alojamiento a in alojamientos)
                    a.Reservas.Sort();
            }               
        }
        public Reserva this[int id]
        {
            get 
            {
                Reserva devolver = null;

                if(reservas.Count>0)
                {
                    foreach(Reserva reserva in reservas)
                    {
                        if(reserva.ID==id)
                            devolver = reserva;
                    }
                }
                return devolver;
            }
        }
        //public bool ModificarAlojamiento(Alojamiento modificado)
        //{
        //    bool encontrado=false;
        //    int cont = 0;
        //    Alojamiento comparador;

        //    while (encontrado==false && cont<alojamientos.Count)
        //    {
        //        comparador=alojamientos[cont];

        //        if (comparador.Direccion == modificado.Direccion)
        //        {
        //            int index=alojamientos.IndexOf(comparador);
        //            alojamientos.RemoveAt(index);
        //            alojamientos.Insert(index, modificado);

        //            if(modificado is Casa)
        //            {
        //                casas.Remove(comparador as Casa);
        //                casas.Add(modificado as Casa);
        //            }
        //            else
        //            {
        //                hoteles.Remove(comparador as Hotel);
        //                hoteles.Add(modificado as Hotel);
        //            }
        //            encontrado=true;
        //        }
        //        cont++;
        //    }
        //    return encontrado;
        //}

        public string AltaYBaja(string direccion)
        {
            Alojamiento actualizable = this[direccion];
            if (actualizable != null)
            {
                actualizable.Alta=!actualizable.Alta;
            }
            return actualizable.Estado;
        }


        public List<Alojamiento> FiltrarCasas(int cantCamas,String[] servicios)
        {
            List<Alojamiento> filtrados = new List<Alojamiento>();

            foreach(Casa a in casas)
            {
                if (a.Alta && a.FiltrarCasa(cantCamas, servicios))
                    filtrados.Add(a);
            }
            return filtrados;
        }
        public List<Alojamiento> FiltrarHoteles(bool tresEstrellas)
        {
            List<Alojamiento> filtrados = new List<Alojamiento>();
            if(tresEstrellas)
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
            Alojamiento[] copia= new Alojamiento[rango.Count];
            rango.CopyTo(copia);

            foreach (Alojamiento a in copia)
            {
                if (a.CheckFecha(fechaInicio, fechaFinal)==false)
                    rango.Remove(a);
            }
            return rango;
        }
        public void DisminuirContadorCasas()
        {
            Casa.ContCasa--;
        }
        public List<Reserva> Reservas { get { return reservas; } }
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

        public string[] GenerarComprobante(Reserva reserva)
        {
            return reserva.DatosComprobante;
        }
        public double PrecioBaseHotel{ get { return precioBaseHotel; } set { precioBaseHotel = value; } }
       
        public bool Preguntar { get { return preguntar; } set { preguntar = value; } }

        public int NumeroCasaSiguiente { get { return Casa.ContCasa; } }
    }
}
