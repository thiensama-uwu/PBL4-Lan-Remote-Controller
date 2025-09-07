using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL4_Cilent.Controllers;

namespace PBL4_Cilent.Network
{
    public class ClientSocket
    {
        private string serverIp;
        private int serverPort;
        private TcpClient client;
        private CommandExecutor commandExecutor;

        public ClientSocket(string ip, int port)
        {
            serverIp = ip;
            serverPort = port;
            commandExecutor = new CommandExecutor();
        }

        public void Connect()
        {
            client = new TcpClient();
            client.Connect(serverIp, serverPort);
            Console.WriteLine("Connected to server!");

            Thread t = new Thread(ReceiveData);
            t.Start();
        }

        private void ReceiveData()
        {
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                string cmd = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Command received: " + cmd);

                commandExecutor.Execute(cmd);
            }
        }
    }
}
