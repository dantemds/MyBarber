using WebSocketSharp;
using WebSocketSharp.Server;

namespace Mybarber.WebSockets
{
    public class Echo:WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
           Send(e.Data);
           var id = Sessions.IDs;
           var sessions = Sessions.Sessions;
           
           Sessions.Broadcast("IDS: " + id);
        }
    }
}
