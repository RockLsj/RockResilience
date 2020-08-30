using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    class SocketClient
    {
        public static int Main(String[] args)
        {
            StartClient();

            return 0;
        }

        public static void StartClient()
        {
            try
            {
                SocketSender socketSender = new SocketSender();

                try
                {
                    socketSender.ConnectSocketListenerSendReceiveData();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
