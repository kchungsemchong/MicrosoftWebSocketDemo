using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebSockets;

namespace WebSocketDemo
{
    public class MsWebSocket : WebSocketHandler
    {
        //The WebSocketColection allows the broadcast the message to all clients.
        private static WebSocketCollection clients = new WebSocketCollection();

        private string name;

        public override void OnOpen()
        {
            this.name = this.WebSocketContext.QueryString["userName"];

            //Add the client that just connected
            clients.Add(this);

            //Broadcast the newly connected user
            clients.Broadcast(name + " is online");
        }

        public override void OnMessage(string message)
        {
            //When message comes in broadcast the message
            clients.Broadcast(string.Format("{0} :{1}", name, message));
        }

        public override void OnClose()
        {
            //When user is disconnected. Message is broadcasted
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} went offline", name));
        }
    }
}