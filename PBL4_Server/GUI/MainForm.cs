using PBL4_Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL4.PBL4_Server.GUI
{
    public partial class MainForm: Form
    {
        private ServerSocket server;
        public MainForm()
        {
            InitializeComponent();
            server = new ServerSocket(5000);
            server.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DetailPC detailPC = new DetailPC(txtSearch.Text.ToString(),server);
            detailPC.Show();
        }
    }
}
