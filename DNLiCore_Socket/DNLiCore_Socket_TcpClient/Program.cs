using System;
using System.Text;
using DNLiCore_Socket.Client;

namespace DNLiCore_Socket_TcpClient
{
    class Program
    {
       static DNLiCore_Socket.Client.TcpPushClient tcpPushClient;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ClientConnect();
            Console.WriteLine("Tcp客户端已准备好!");
            Console.Read();
        }

        public static void ClientConnect()
        {
            tcpPushClient = new TcpPushClient(1024);
            tcpPushClient.OnConnect += TcpPushClient_OnConnect; //连接服务器事件
            tcpPushClient.OnSend += TcpPushClient_OnSend; //发送消息事件
            tcpPushClient.OnReceive += TcpPushClient_OnReceive; //接收消息事件
            tcpPushClient.OnClose += TcpPushClient_OnClose; //客户端断开事件
            tcpPushClient.Connect("119.23.25.106", 8888);
        }

        private static void TcpPushClient_OnClose()
        {
            Console.WriteLine("设备断开了");
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("设备断开了");
        }

        private static void TcpPushClient_OnReceive(byte[] obj)
        {
            Console.WriteLine("接收到 消息了，消息内容:" + Encoding.UTF8.GetString(obj));
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("接收到 消息了，消息内容:" + Encoding.UTF8.GetString(obj));
        }

        private static void TcpPushClient_OnSend(int obj)
        {
            Console.WriteLine("数据发送成功，发送的长度为:" + obj);
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("数据发送成功，发送的长度为:" + obj);
        }

        private static void TcpPushClient_OnConnect(bool obj)
        {
            Console.WriteLine("连接服务器了,状态:" + obj);
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("连接服务器了,状态:" + obj);
            //发送一下数据
            if (tcpPushClient.Connected)
            {
                tcpPushClient.Send(new byte[] { 1, 2, 3 }, 0, 3);
            }
        }
    }
}
