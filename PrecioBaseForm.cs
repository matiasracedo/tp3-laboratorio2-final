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
    public partial class PrecioBaseForm : Form
    {
        public PrecioBaseForm()
        {
            InitializeComponent();
        }


        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNo.Checked)
            {
                btnContinuar.Enabled = true;
            }
            else
            {
                if(tbPrecio.Text=="")
                    btnContinuar.Enabled=false;
                else btnContinuar.Enabled=true;
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            // hacer check de nros y espacios despues
            if (tbPrecio.Text == "")
                btnContinuar.Enabled = false;
            else btnContinuar.Enabled = true;
        }
    }
}
