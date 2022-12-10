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
        IInterectuable form;
        private void rbCasa_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCasa.Checked)
            {
                gBoxHotel.Enabled = false;
                gBoxCasa.Enabled = true;
            }
               
        }
        public void setInteractor(Form form)
        {
            this.form = form as IInterectuable;
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
        public void cBoxProvincia_SelectedValueChanged(object sender, EventArgs e)
        {
            cBoxCiudad.Items.Clear();
            cBoxCiudad.SelectedIndex = -1;
            cBoxCiudad.Text = "";
            cBoxCiudad.Items.AddRange(form.ActualizarComboBoxCiudades(cBoxProvincia.Text));

            if (cBoxCiudad.Items.Count > 0)
                cBoxCiudad.SelectedIndex = 0;
        }

        private void ABMAlojamientosForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFotos_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarR_Click(object sender, EventArgs e)
        {

        }

        private void btnImportarR_Click(object sender, EventArgs e)
        {

        }
    }
}
