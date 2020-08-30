using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketListenerDemo
{
    public class SocketListen
    {
        public const string strMsgEndFlag = "<EOF>";
        public string strNewMsg = " LSJRock ";

        public void StartServer()
        {
            SocketListen socketListen = new SocketListen();

            try
            {
                Socket listener = socketListen.Listen();

                Console.WriteLine("Waiting for a connection...");

                while (true)
                {
                    Socket connectedSocket = listener.Accept();
                    var childSocketThread = new Thread(() =>
                    {
                        string data = ReceiveDataFromConnectedSocket(connectedSocket);

                        Console.WriteLine("Text received : {0}", data);

                        data = data.Replace(SocketListen.strMsgEndFlag, strNewMsg) + SocketListen.strMsgEndFlag;

                        SendMsgToConnectedSocket(data, connectedSocket);
                        DispostConnectedSocket(connectedSocket);

                        connectedSocket.Close();
                    });

                    childSocketThread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }

        public Socket Listen()
        {
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a Socket that will use Tcp protocol      
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(100);

            return listener;
        }

        private string ReceiveDataFromConnectedSocket(Socket connectedSocket)
        {
            //Store incoming data from the client.
            string data = null;
            byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];

                int bytesRec = connectedSocket.Receive(bytes);

                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf(strMsgEndFlag) > -1)
                {
                    break;
                }
            }

            return data;
        }

        public void SendMsgToConnectedSocket(string data, Socket connectedSocket)
        {
            byte[] msg = Encoding.ASCII.GetBytes(data);
            connectedSocket.Send(msg);
        }

        public void DispostConnectedSocket(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

    }
}
