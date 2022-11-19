using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    [Serializable]
    public class Habitacion: IComparable
    {
        private bool estado;
        private readonly int numero;
        public enum Tipos { Simple = 1, Doble = 2, Triple = 3 };
        private Tipos tipo;

        public int Tipo { get { return (int)tipo; } }

        public Habitacion(int numero, Tipos tipo)
        {
            this.estado = false;
            this.numero = numero;
            this.tipo = tipo;
        }
        public void SetEstado(bool estado)
        {
            this.estado = estado;
        }
        public bool GetEstado()
        {
            return estado;
        }

        public override string ToString()
        {
            return String.Format("Habitacion {0} Nº {1}", tipo, numero);
        }
        public int Numero { get { return numero; } }

        public int CompareTo(Object o)
        {
            return this.Numero.CompareTo(((Habitacion)o).Numero); 
        }
    }
}
