using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Editor.TCP
{
    class Server
    {
        public string MessageToSend { get; set; }

        private TcpListener tcpListener;
        private Thread listenThread;

        public Server()
        {
            MessageToSend = "";

            tcpListener = new TcpListener(IPAddress.Any, 3000);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        private void ListenForClients()
        {
            byte[] buffer;
            ASCIIEncoding encoder = new ASCIIEncoding();

            tcpListener.Start();

            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);

                while (client.Connected)
                {
                    if (MessageToSend != "")
                    {
                        lock (MessageToSend)
                        {
                            buffer = encoder.GetBytes(MessageToSend + "\r\n");
                            MessageToSend = "";
                        }
                            
                        NetworkStream clientStream = client.GetStream();
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                    }
                }
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                // disconnect
                if (bytesRead == 0)
                {
                    break;
                }

                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
            }

            tcpClient.Close();
        }
        
    }
}
