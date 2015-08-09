using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace SignalRAuth.Models
{
    public class HubConn : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
        public String Test(string message)
        {
            // Call the broadcastMessage method to update clients.
            Debug.Fail("Send");
            Clients.All.broadcastMessage(Context.User.Identity.Name, message);
            return " returned";
        }

        public static List<String> Connections;

        static HubConn()
        {
            Connections = new List<String>();
        }

        public override Task OnConnected()
        {
            Connections.Add(Context.ConnectionId);
            Debug.WriteLine("Connections: " + Connections.Count + " " + Context.ConnectionId + " Connected");
            return base.OnConnected();
        }
    }
}