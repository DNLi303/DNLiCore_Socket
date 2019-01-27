using System;
using System.Net;
using System.Text;
using DNLiCore_Socket.Client;

namespace DNLiCore_Socket_UdpClient
{
    class Program
    {
        private static DNLiCore_Socket.Client.UdpClients udpClients;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ClientConnect();
            Console.WriteLine("Udp客户端已准备好!");
            Console.Read();
        }

        public static void ClientConnect()
        {
            udpClients = new UdpClients(1024);
            udpClients.OnReceive += UdpClients_OnReceive; //接收消息事件
            udpClients.OnSend += UdpClients_OnSend; //接收消息事件
            udpClients.Start("119.23.25.106", 9999);
            udpClients.Send(new byte[] { 1, 1, 1 }, 0, 3);
            Console.WriteLine("数据发送成功");
        }

        private static void UdpClients_OnSend(int obj)
        {
            Console.WriteLine("发送消息，长度:" + obj);
        }

        private static void UdpClients_OnReceive(byte[] arg1, int arg2, int arg3)
        {
            Console.WriteLine("接收到消息:" + Encoding.Default.GetString(arg1) + ",偏移量:" + arg2 + ",长度:" + arg3);
        }
    }
}
