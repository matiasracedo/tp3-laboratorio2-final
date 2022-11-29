using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP_II
{
    [Serializable]
    public abstract class Alojamiento:IComparable
    {
        protected string direccion;
        private bool alta;
        
        protected List<Reserva> reservas = new List<Reserva>();
        protected Image[] imagenes;
        private int idAlojamiento;
        private static int contIdAlojamiento = 1;

        private string[] lugar=new string[2];

        public Alojamiento(string direccion, string jurisdiccion, string ciudad)
        {
            this.direccion = direccion;
            alta = true;
            idAlojamiento=contIdAlojamiento;
            contIdAlojamiento++;

            lugar[0] = jurisdiccion; lugar[1] = ciudad;
        }
               
        public DateTime[] IntervaloFechasReservadas()
        {
            List<DateTime> retorno = new List<DateTime>();
            foreach (Reserva r in reservas)
            {
                TimeSpan periodoEvaluar = r.Egreso.Subtract(r.Ingreso);
                int dias = periodoEvaluar.Days +1;

                DateTime[] diasCheck = new DateTime[dias];
                for (int i = 0; i < dias; i++)
                {
                    diasCheck[i] = r.Ingreso.AddDays(i);
                    retorno.Add(diasCheck[i]);
                }
            }
            return retorno.ToArray();
        }

        public abstract double PrecioDia(Reserva r);
        public abstract bool CheckFecha(DateTime inicio, DateTime final);
        public abstract string[] Exportar();

        public int CompareTo(object o)
        {
            int retorno = 1;
            if(o!=null)
                retorno= this.direccion.CompareTo(((Alojamiento)o).Direccion);
            return retorno;
        }


        public List<Reserva> Reservas { get { return reservas; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public bool Alta { set { alta = value; } get { return alta; } }
        public string Estado 
        {          
            get 
            {
                string estado = "Dado de ";

                if (Alta == true)
                    estado += "Alta";
                else
                    estado += "Baja";
                
            return estado;
            }
        }
        public Image[] Imagenes { get { return imagenes; } set { imagenes = value; } }
        public static int ContIdAlojamiento { get { return contIdAlojamiento; } set { contIdAlojamiento = value; } }
        public int IDalojamiento { get { return idAlojamiento; } }
        public string Jurisdiccion { get { return lugar[0]; } set { lugar[0] = value; } }
        public string Ciudad { get { return lugar[1]; } set { lugar[1] = value; } }
    }
}
