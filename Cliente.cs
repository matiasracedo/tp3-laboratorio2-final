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
        private string nombre;
        private string apellido;
        private int dni;
        private int edad;
        private static int contIdCliente=1;
        private int idCliente;

        public Cliente(string nombre,string apellido, int dni, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.edad = edad;
            idCliente = contIdCliente;//el contador se incrementa en solo en la creacion de la reserva
        }

        public string Nombre { get { return nombre; } }
        public string Apellido { get { return apellido; } }
        public string NombreCompleto { get { return nombre+" "+apellido; } }
        public int DNI { get { return dni; } }
        public int Edad { get { return edad; } }
        public static int ContIdCliente { get{ return contIdCliente; }set { contIdCliente = value; } }
        public int IDcliente { get { return idCliente; }set { idCliente = value; } }
        public override string ToString()
        {
            return string.Format("ID: {0} -- Nombre: {1} -- DNI: {2} -- Edad: {3} años",IDcliente,NombreCompleto,DNI,Edad);
            //return NombreCompleto +", DNI "+ dni+ ", "+edad + " años.";
        }
    }
}
