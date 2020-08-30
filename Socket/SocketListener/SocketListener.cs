using System;

using SocketListenerDemo;

namespace SocketListener
{
    public class SocketListener
    {
        public static int Main(String[] args)
        {
            SocketListen socketListen = new SocketListen();
            socketListen.StartServer();

            return 0;
        }

    }
}
