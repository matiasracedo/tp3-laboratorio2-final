using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    [Serializable]
    public class Cliente
    {
        string nombre;
        string apellido;
        int dni;
        int edad;
        public Cliente(string nombre,string apellido, int dni, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.edad = edad;
        }

        public string Nombre { get { return nombre; } }
        public string Apellido { get { return apellido; } }
        public string NombreCompleto { get { return nombre+" "+apellido; } }
        public int DNI { get { return dni; } }
        public int Edad { get { return edad; } }
        public override string ToString()
        {
            return string.Format("Nombre: {0} -- DNI: {1} -- Edad: {2} años",NombreCompleto,DNI,Edad);
            //return NombreCompleto +", DNI "+ dni+ ", "+edad + " años.";
        }
    }
}
