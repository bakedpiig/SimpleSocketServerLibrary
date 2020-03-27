using System;
using System.Net;

namespace SimpleServer
{
    public static class SocketAddressFactory
    {
        public static IPEndPoint CreateIPv4FromString(string host)
        {
            var pos = host.Split(':');
            var address = IPAddress.Parse(pos[0]);
            int port;
            if (pos.Length > 1)
                port = int.Parse(pos[1]);
            else
                port = 0;
            return new IPEndPoint(address, port);
        }

        public static IPEndPoint CreateIPv6FromString(string host)
        {
            var ipEndPoint = CreateIPv4FromString(host);
            ipEndPoint.Address = ipEndPoint.Address.MapToIPv6();
            return ipEndPoint;
        }
    }
}