using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    [Serializable]
    public class Hotel:Alojamiento
    {
        List<Habitacion> simples = new List<Habitacion>();
        List<Habitacion> dobles = new List<Habitacion>();
        List<Habitacion> triples = new List<Habitacion>();
        public List<Habitacion> this[int tipo]
        {
            get
            {
                switch (tipo)
                {
                    case 0:
                        return Simples;
                    case 1:
                        return Dobles;
                    case 2:
                        return Triples;
                }
                return null;
            }
        }

        Dictionary<int, List<Reserva>> habitacionReservas = new Dictionary<int, List<Reserva>>();

        private string nombre;
        bool tresEstrellas = false;

        public Hotel(string direccion,string jurisdiccion,string ciudad, string nombre, bool tresEstrellas, int cantSimples,int cantDobles, int cantTriples)
            :base(direccion.TrimEnd(' ').TrimStart(' '), jurisdiccion.Trim(' '), ciudad.Trim(' '))
        {
            this.nombre = nombre.TrimEnd(' ').TrimStart(' ');

            this.tresEstrellas = tresEstrellas;
            if(nombre=="")
                throw new DatosIncompletosException();

            int nro = 1;
            
            for(int i = 0; i < cantSimples; i++)
            {
                this.simples.Add(new Habitacion(nro, Habitacion.Tipos.Simple));
                habitacionReservas.Add(nro,null);
                    nro++;
            }
            for (int i = 0; i < cantDobles; i++)
            {
                this.dobles.Add(new Habitacion(nro, Habitacion.Tipos.Doble));
                habitacionReservas.Add(nro, null);
                nro++;
            }
            for (int i = 0; i < cantTriples; i++)
            {
                this.triples.Add(new Habitacion(nro, Habitacion.Tipos.Triple));
               habitacionReservas.Add(nro, null);
                nro++;
            }
        }

        public override double PrecioDia(Reserva r)
        {
            //double retorno = 0;
            //if (r.Habitaciones.Count > 0)
            //{
            //    foreach (Habitacion h in r.Habitaciones)
            //        retorno += PrecioHabitacion(h.Tipo, r.PrecioBaseReserva);
            //}
            //return retorno;
            return PrecioHabitacion(r.HabitacionReservada.Tipo, r.PrecioBaseReserva);
        }

        public double PrecioHabitacion(int tipo,double precioBase)
        {
            double monto=precioBase;
            if (tresEstrellas)
                monto += monto * 0.4;
            switch (tipo)
            {
                
                case 1:
                    break;
                case 2:
                    {  monto+=monto*0.8; }
                    break;
                case 3:
                    {  monto+=monto*1.5; }
                    break;
            }
            return monto;
        }
        public void AgregarReserva(int nroHabitacion,Reserva reserva)
        {
            if(habitacionReservas[nroHabitacion] == null)
            {
                habitacionReservas[nroHabitacion]=new List<Reserva>();
            }
            habitacionReservas[nroHabitacion].Add(reserva);
        }

        public void QuitarReserva(int nroHabitacion,Reserva reserva)
        {
            habitacionReservas[nroHabitacion].Remove(reserva);
        }
        public override bool CheckFecha(DateTime inicio, DateTime final)
        {
            TimeSpan periodoEvaluar = final.Subtract(inicio);
            int dias = periodoEvaluar.Days;

            DateTime[] diasCheck = new DateTime[dias];
            for (int i = 0; i < dias; i++)
            {
                diasCheck[i] = inicio.AddDays(i);
            }

            DateTime comparador;
            int habitacionesOcupadas = 0;

            for(int i = 0; i < habitacionReservas.Count; i++)
            {
                bool ocupada = false;
                if(habitacionReservas[i+1]!=null)
                {
                    foreach (Reserva r in habitacionReservas[i + 1])
                    {
                        for (int j = 0; j < dias; j++)
                        {
                            comparador = r.Ingreso.AddDays(j);
                            foreach (DateTime dia in diasCheck)
                            {
                                if (DateTime.Compare(comparador, dia.Date) == 0)
                                    ocupada = true;
                            }
                        }
                    }
                }
                
                if (ocupada)
                    habitacionesOcupadas++;
            }

            if (habitacionesOcupadas < TotalHabitaciones)
                return true;
            else
                return false;
        }

        public DateTime[] IntervaloFechasHabitacion(int nroHabitacion)
        {
            List<DateTime> retorno = new List<DateTime>();
            List<Reserva> habitacionReservas = GetReservasDeHabitacion(nroHabitacion);

            if(habitacionReservas!= null)
            {
                foreach (Reserva r in habitacionReservas)
                {
                    TimeSpan periodoEvaluar = r.Egreso.Subtract(r.Ingreso);
                    int dias = periodoEvaluar.Days+1;

                    DateTime[] diasCheck = new DateTime[dias];
                    for (int i = 0; i < dias; i++)
                    {
                        diasCheck[i] = r.Ingreso.AddDays(i);
                        retorno.Add(diasCheck[i]);
                    }
                }
            }
            
            return retorno.ToArray();
        }

        // Si eesta disponible devuelve true
        public bool CheckFechaHabitacion(DateTime inicio, DateTime final,int nroHabitacion)
        {
            TimeSpan periodoEvaluar = final.Subtract(inicio);
            int dias = periodoEvaluar.Days+1;
            bool disponible = true;

            DateTime[] diasCheck = new DateTime[dias];
            for (int i = 0; i < dias; i++)
            {
                diasCheck[i] = inicio.AddDays(i);
            }

            foreach (DateTime dia in IntervaloFechasHabitacion(nroHabitacion))
            {
                foreach (DateTime diaEvaluar in diasCheck)
                {
                    if(DateTime.Compare(dia,diaEvaluar)==0)
                        disponible = false;
                }
            }
            return disponible;
        }

        public override string ToString()
        {
            return string.Format("Hotel: {0} - {1}",nombre,direccion);
        }

        public override string[] Exportar()
        {
            string[] campos = new string[8];
            campos[0] = direccion;
            campos[1] = Jurisdiccion;
            campos[2] = Ciudad;
            campos[3] = nombre;
            campos[4] = tresEstrellas.ToString().ToLower();
            campos[5] = simples.Count.ToString();
            campos[6] = dobles.Count.ToString();
            campos[7] = triples.Count.ToString();
            return campos;            
        }


        public int TotalHabitaciones { get { return simples.Count+dobles.Count+triples.Count; } }
        public int TotalCamas { get { return simples.Count + dobles.Count * 2 + triples.Count * 3; } }
        public bool TresEstrellas { get { return tresEstrellas; } set { tresEstrellas = value; } }
        public string Nombre 
        { 
            get { return nombre; } 
            set 
            { 
                if(value=="")
                    throw new DatosIncompletosException();
                    
                nombre = value; 
            }
        }
        public List<Habitacion> Simples { get { return simples; } }
        public List<Habitacion> Dobles { get { return dobles; } }
        public List<Habitacion> Triples { get { return triples; } }
        public List<Habitacion> GetTodasLasHabitaciones() 
        {

                List<Habitacion> ret = new List<Habitacion>();
                ret.AddRange(Simples);
                ret.AddRange(Dobles);
                ret.AddRange(Triples);
                return ret;
            
        }
        public List<Reserva> GetReservasDeHabitacion(int numHabitacion)
        {
            return habitacionReservas[numHabitacion]; 
        }
        public Habitacion GetHabitacion(int nroHabitacion)
        {
            Habitacion buscar = new Habitacion(nroHabitacion, Habitacion.Tipos.Triple);
            Habitacion resultado = null;
            int index;

            List<Habitacion> habitacionList = GetTodasLasHabitaciones();
            index = habitacionList.BinarySearch(buscar);

            if (index >= 0)
            {
               resultado= habitacionList[index];
            }
            return resultado;
        }
    }
}
