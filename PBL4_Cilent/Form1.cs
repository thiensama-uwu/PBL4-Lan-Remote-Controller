using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL4_Cilent.Network;
namespace PBL4_Cilent
{
    public partial class Form1: Form
    {
        private ClientSocket clientSocket;
        public Form1()
        {
            InitializeComponent();
            clientSocket = new ClientSocket("127.0.0.1", 5000);
            clientSocket.Connect();
            Console.ReadLine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
