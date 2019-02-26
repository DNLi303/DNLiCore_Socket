using System;

namespace DNLiCore_Socket_TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Pack pack = new Pack();
            Console.WriteLine("Tcp服务端已准备好,端口8889!");
            Console.Read();
        }
    }
}
