using WebSocketSharp.Server;
using System;
namespace Mybarber.WebSockets.Server
{
    public class Server
    {
        public static void Start()
        {
            WebSocketServer webSocket = new WebSocketServer("ws://127.0.0.1:4100");
            webSocket.AddWebSocketService<Echo>("/Echo");
            webSocket.Start();
            Console.WriteLine("ws://127.0.0.1:4100");
        }
        
    }
}
