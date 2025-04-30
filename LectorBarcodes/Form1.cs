using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LectorBarcodes
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void cmd_add_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBarcodes Win2 = new AddBarcodes();
            Win2.Show();
        }

        private void cmd_read_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
