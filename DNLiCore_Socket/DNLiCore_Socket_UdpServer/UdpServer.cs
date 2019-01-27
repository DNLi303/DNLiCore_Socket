using System;
using System.Collections.Generic;
using System.Text;

namespace DNLiCore_Socket_UdpServer
{
    public class UdpServer
    {
        private DNLiCore_Socket.Server.UdpServer udpServer;

        public UdpServer()
        {
            udpServer = new DNLiCore_Socket.Server.UdpServer(2048);
            udpServer.OnReceive += UdpServer_OnReceive;  //接收数据事件
            udpServer.OnSend += UdpServer_OnSend; //发送数据事件
            udpServer.Start(9999);
        }

        private void UdpServer_OnSend(System.Net.EndPoint arg1, int arg2)
        {
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("【消息发送成功】【客户端地址："+arg1+"】【长度:"+arg2+"】");
        }

        private void UdpServer_OnReceive(System.Net.EndPoint arg1, byte[] arg2, int arg3, int arg4)
        {
            string test = Encoding.UTF8.GetString(arg2);
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("【消息接收成功】【客户端地址：" + arg1 + "】【数据:" + test + "】【偏移量:" + arg3 + "】【长度:" + arg4 + "】");
            udpServer.Send(arg1,arg2,arg3,arg4);
        }
    }
}
