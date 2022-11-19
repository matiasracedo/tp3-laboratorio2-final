using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_II
{
    public partial class ABMAlojamientosForm : Form
    {
        public ABMAlojamientosForm()
        {
            InitializeComponent();
        }
        
        private void rbCasa_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCasa.Checked)
            {
                gBoxHotel.Enabled = false;
                gBoxCasa.Enabled = true;
            }
               
        }

        private void rbHotel_CheckedChanged(object sender, EventArgs e)
        {
            if(rbHotel.Checked)
            {
                gBoxCasa.Enabled = false;
                gBoxHotel.Enabled = true;
            }
                
        }

        private void btnAltaBaja_Click(object sender, EventArgs e)
        {
            if (btnAltaBaja.Text == "Dar de Baja")
            {
                btnAltaBaja.Text = "Dar de Alta";
                labEstado.Text = "Desactivado";
                labEstado.Enabled = false;
            }
            else
            {
                btnAltaBaja.Text = "Dar de Baja";
                labEstado.Text = "Activado";
                labEstado.Enabled = true;
            }
                


        }

    }
}
