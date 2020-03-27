using System;
using System.Net;
using System.Net.Sockets;

namespace SimpleServer.Sockets
{
    public class UDPSocket: IDisposable
    {
        Socket socket;

        private UDPSocket(Socket socket)
        {
            this.socket = socket;
        }

        public static UDPSocket CreateUDPSocket(AddressFamily family)
        {
            try
            {
                var sock = new Socket(family, SocketType.Dgram, ProtocolType.Udp);
                return new UDPSocket(sock);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public bool Bind(IPEndPoint ipEndPoint)
        {
            try
            {
                socket.Bind(ipEndPoint);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public int SendTo(byte[] buffer,IPEndPoint remoteEndPoint)
        {
            try
            {
                int sendByte = socket.SendTo(buffer, remoteEndPoint);
                return sendByte;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return -1;
            }
        }

        public int ReceiveFrom(byte[] buffer, ref IPEndPoint fromEndPoint)
        {
            try
            {
                EndPoint ep = fromEndPoint;
                int receiveByte = socket.ReceiveFrom(buffer, ref ep);
                fromEndPoint = ep as IPEndPoint;
                return receiveByte;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return -1;
            }
        }

        public void Dispose()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}