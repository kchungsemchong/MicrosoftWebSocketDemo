using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace WebSocketDemo
{
    public class Server : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new MsWebSocket());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}