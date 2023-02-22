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
        List<Cliente> GetPasajeros();

        void SetCapacidad(int capac);

        ArrayList ActualizarConsulta();
        object BuscarAlojamiento(object aBuscar);
        void AgregarReserva(object r);
        int[] ListaHabitaciones(int tipo, Object hotel);

        double GetPrecioBaseHoteles();

        void EmitirComprobante(Reserva reserva);

        void btnPasajeros_Click(object sender, EventArgs e);

        string[] ActualizarComboBoxCiudades(string jurisdiccion);
    }
}
