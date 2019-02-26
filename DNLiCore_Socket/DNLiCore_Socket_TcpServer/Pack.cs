using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DNLiCore_Socket_TcpServer
{
    class Pack
    {
        DNLiCore_Socket.Server.TcpPushServer TcpPackServer;

        public Pack()
        {
            TcpPackServer = new DNLiCore_Socket.Server.TcpPushServer(1000, 4028, 200,4);
            TcpPackServer.OnAccept += TcpPackServer_OnAccept;  //连接成功事件
            TcpPackServer.OnClose += TcpPackServer_OnClose; //设备断开事件
            TcpPackServer.OnReceive += TcpPackServer_OnReceive; //接收到数据事件
            TcpPackServer.OnSend += TcpPackServer_OnSend;  //发送消息回调事件
            
            TcpPackServer.Start(8889);
        }

        private void TcpPackServer_OnSend(int arg1, int arg2)
        {

            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("【消息发送了】【设备ID："+arg1+"】【长度:" + arg2 + "】");
        }

        private void TcpPackServer_OnReceive(int arg1, byte[] arg2)
        {
            string clientDataString = Encoding.UTF8.GetString(arg2);
            Console.WriteLine(clientDataString);
           // DNLiCore_Utility.Log.FileTxtLogs.WriteLog("【接收消息】【设备ID：" + arg1 + "】【消息内容:"+System.Text.Encoding.UTF8.GetString(arg2)+"】");
            //TcpPackServer.Send(arg1, arg2, 0, arg2.Length);
        }

        private void TcpPackServer_OnClose(int obj)
        {
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("【设备断开了】【" + obj + "】");
        }

        private void TcpPackServer_OnAccept(int obj)
        {
            DNLiCore_Utility.Log.FileTxtLogs.WriteLog("【设备连接了】【"+obj+"】");
        }
    }
}
