using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TP_II
{
    public interface IInterectuable
    {
        ArrayList ActualizarConsulta();
        object BuscarAlojamiento(object aBuscar);
        void AgregarReserva(object r);
        int[] ListaHabitaciones(int tipo, Object hotel);

        double GetPrecioBaseHoteles();

        void EmitirComprobante(Reserva reserva);

    }
}
