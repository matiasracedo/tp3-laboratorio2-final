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
        int a;
        int b;
     
        public Alojamiento(string direccion)
        {
            this.direccion = direccion;
            alta = true;
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

    }
}
