using System;

namespace DNLiCore_Socket_UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UdpServer pack = new UdpServer();
            Console.WriteLine("Udp服务端已准备好!");
            Console.Read();
        }
    }
}
