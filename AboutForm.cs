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
    public partial class AboutForm : Form
    {
        Uri fileURI = new Uri(Application.StartupPath + @"/html/about.html");
        public AboutForm()
        {
            InitializeComponent();
            webBrowser1.Navigate(fileURI);
        }
    }
}
