using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL4_Server.Network;

namespace PBL4.PBL4_Server.GUI
{
    public partial class DetailPC : Form
    {
        private string clientIp;
        private ServerSocket server;

        public DetailPC(string ip,ServerSocket server)
        {
            clientIp = ip;
            InitializeComponent();
            this.server = server;
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            server.SendTo(clientIp, "SHUTDOWN");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            server.SendTo(clientIp, "RESTART");
        }

        private void btnScreenWatching_Click(object sender, EventArgs e)
        {
            server.SendTo(clientIp, "SCREENSHOT");
        }

        private void DetailPC_Load(object sender, EventArgs e)
        {

        }
    }
}
