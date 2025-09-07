using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBL4_Server.Network
{
    public class ServerSocket
    {
        private TcpListener listener;
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();
        private int port;

        public ServerSocket(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.Start();
        }

        private void AcceptClients()
        {
            while (true)
            {
                var client = listener.AcceptTcpClient();
                string ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                lock (clients)
                {
                    clients[ip] = client;
                }
                Console.WriteLine($"Client connected: {ip}");
            }
        }

        public void SendTo(string ip, string message)
        {
            if (clients.ContainsKey(ip))
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    clients[ip].GetStream().Write(data, 0, data.Length);
                }
                catch
                {
                    Console.WriteLine("Send failed to " + ip);
                }
            }
        }
    }
}
