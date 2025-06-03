using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal4S
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            Form form = new FrmAPI();
            form.Show();
            this.Hide();
        }

        private void btnDataSet_Click(object sender, EventArgs e)
        {
            Form form = new FrmDataSet();
            form.Show();
            this.Hide();
        }
    }
}
