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
    public partial class AyudaForm : Form
    {
        Uri fileURI = new Uri(Application.StartupPath + @"/html/index.html");
        public AyudaForm()
        {
            InitializeComponent();  
            webBrowser1.Navigate(fileURI);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(fileURI);
        }
    }
}
