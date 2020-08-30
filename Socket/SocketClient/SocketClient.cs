using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

namespace SocketClient
{
    public class SocketSender
    {
        public const string strMsgEndFlag = "<EOF>";

        public void ConnectSocketListenerSendReceiveData()
        {
            Socket sender = null;
            CreateSenderSocket(ref sender);

            Console.WriteLine("Socket connected to {0}",
                sender.RemoteEndPoint.ToString());

            string strMsg = "This is a test" + strMsgEndFlag;
            SendMsg(ref sender, strMsg);

            //Receive the response from the remote device.
            byte[] bytes = new byte[1024];
            int bytesRec = sender.Receive(bytes);

            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));

            DispostSocket(sender);
        }

        public void CreateSenderSocket(ref Socket sender)
        {
            // Connect to a Remote server  
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.    
            sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to Remote EndPoint  
            sender.Connect(remoteEP);
        }

        public void SendMsg(ref Socket sender, string strMsg)
        {
            byte[] msg = Encoding.ASCII.GetBytes(strMsg);
            int bytesSent = sender.Send(msg);
        }

        public void DispostSocket(Socket sender)
        {
            // Release the socket.    
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

    }
}
