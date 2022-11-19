using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TP_II
{
    public partial class AlojamientoForm : Form
    {
        public AlojamientoForm()
        {
            InitializeComponent();
        }
        IInterectuable form1;
        Alojamiento aConsultar = null;

        public void SetConsultor(IInterectuable consultor)
        {
            form1 = consultor;
        }
        public void SetAlojamiento(Object a)
        {
            aConsultar = a as Alojamiento;
        }
        private void AlojamientoForm_Load(object sender, EventArgs e)
        {
            flowLayoutImages.WrapContents = true;
            flowLayoutImages.FlowDirection = FlowDirection.LeftToRight;
            if (aConsultar.Imagenes != null && aConsultar.Imagenes.Length > 0)
            {
                foreach (Image imagen in aConsultar.Imagenes)
                {
                    if (imagen != null)
                    {
                        PictureBox pbAlojamiento = new PictureBox();
                        pbAlojamiento.Height = imagen.Height;
                        pbAlojamiento.Width = imagen.Width;
                        pbAlojamiento.Image = imagen;
                        pbAlojamiento.Width = 220;
                        pbAlojamiento.Height = 220;
                        pbAlojamiento.SizeMode = PictureBoxSizeMode.StretchImage;
                        flowLayoutImages.Controls.Add(pbAlojamiento);
                    }
                }
            }
  
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

        }

        private void cBoxTipoHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] numeros = form1.ListaHabitaciones(cBoxTipoHab.SelectedIndex, aConsultar);

            cBoxNroHabitaciones.Items.Clear();
            if (numeros!=null)
            {
                foreach (int numero in numeros)
                {
                    cBoxNroHabitaciones.Items.Add(numero.ToString());
                }
            }     
        }

        private void cBoxNroHabitaciones_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void cBoxNroHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nroHabitacion = Convert.ToInt32(cBoxNroHabitaciones.Text);
            DateTime[] fechas = null;

            fechas = ((Hotel)aConsultar).IntervaloFechasHabitacion(nroHabitacion);
            Calendario.BoldedDates = fechas;//pintar calendario habitacion
        }


    }
}
