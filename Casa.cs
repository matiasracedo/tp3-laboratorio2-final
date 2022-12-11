using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    [Serializable]
    public class Casa : Alojamiento
    {
        string[] servicios;
        private readonly int numero;// número único
        private static int contCasa = 1;
        int camas;
        int minDias;
        double precioBaseCasa;


        public Casa(string direccion, string jurisdiccion, string ciudad, int minDias, int camas, string[] servicios, double precioBaseCasa)
            : base(direccion.TrimEnd(' ').TrimStart(' '), jurisdiccion,ciudad.TrimEnd(' ').TrimStart(' '))
        {
            this.minDias = minDias;
            this.camas = camas;
            this.servicios = servicios;
            this.numero = contCasa;
            contCasa++;
            this.precioBaseCasa = precioBaseCasa;
        }   

        public override double PrecioDia(Reserva r)
        {
            return (precioBaseCasa * camas) + (CantidadServicios * (0.03) * (precioBaseCasa * camas));
        }
   

        public override bool CheckFecha(DateTime inicio, DateTime final)
        {
            TimeSpan periodoEvaluar = final.Subtract(inicio);
            int dias = periodoEvaluar.Days + 1;

            DateTime[] diasCheck = new DateTime[dias];
            for (int i = 0; i < dias; i++)
            {
                diasCheck[i] = inicio.AddDays(i);
            }

            DateTime comparador;

            foreach (Reserva r in reservas)
            {
                for (int i = 0; i < r.Dias; i++)
                {
                    comparador = r.Ingreso.AddDays(i);
                    foreach (DateTime dia in diasCheck)
                    {
                        if (DateTime.Compare(comparador, dia) == 0)
                            return false;
                    }
                }
            }
            return true;
        }
        public bool FiltrarCasa(int cantCamas, string[] servicios)
        {
            if (cantCamas <= this.camas)
            {
                int cont = 0;
                foreach (string s in servicios)
                {
                    foreach (string s2 in this.servicios)
                    {
                        if (s == s2)
                            cont++;
                    }
                }
                if (cont == servicios.Length)
                    return true;
            }
            return false;
        }

        

        public override string ToString()
        {
            return string.Format("Casa: {0} - {1}",numero, direccion);
        }

        public override string[] Exportar()
        {
            string[] campos = new string[12];
            campos[0] = direccion;
            campos[1] = Jurisdiccion;
            campos[2] = Ciudad;
            campos[3] = minDias.ToString();
            campos[4] = camas.ToString();
            campos[5] = precioBaseCasa.ToString();
        
            int contThisServicios = 0;

            for (int i = 6; i < 12; i++)
            {
                if(contThisServicios<servicios.Length)
                {
                    campos[i] = servicios[contThisServicios];
                    contThisServicios++;
                }
                else
                    campos[i] = "";
            }

            campos[10] = lugar[0];
            campos[11] = lugar[1];

            return campos;
        }

        public string[] Servicios { get { return servicios; } set { servicios = value; } }
        public int CantidadServicios { get { return servicios.Length; } }
        public int Numero { get { return numero; } }
        public int Camas { get { return camas; } set { camas = value; } }
        public int MinDias { get { return minDias; } set { minDias = value; } }
        public double PrecioBaseCasa { get { return precioBaseCasa; } set { precioBaseCasa = value; } }
        public static int ContCasa { get { return contCasa; } set { contCasa = value; } }
    }
}
