﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Editor.TCP
{
    internal class Server
    {
        public string MessageToSend { get; set; }

        private TcpListener tcpListener;
        private Thread listenThread;

        public Server()
        {
            MessageToSend = "";

            tcpListener = new TcpListener(IPAddress.Any, 3000);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        public void Shutdown()
        {
            listenThread.Abort();
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
                clientThread.IsBackground = true;
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
            using (TcpClient tcpClient = (TcpClient)client)
            {
                NetworkStream clientStream = tcpClient.GetStream();

                byte[] message = new byte[Constants.TCP_MESSAGE_SIZE];
                int bytesRead;

                while (true)
                {
                    bytesRead = 0;

                    try
                    {
                        bytesRead = clientStream.Read(message, 0, Constants.TCP_MESSAGE_SIZE);
                    }
                    catch
                    {
                        break;
                    }

                    // disconnect
                    if (bytesRead == 0)
                        break;

                    ASCIIEncoding encoder = new ASCIIEncoding();
                    System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                }
            }
        }
    }
}