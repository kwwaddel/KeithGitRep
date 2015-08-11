using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;
using System.Collections.Concurrent;

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
        
        public static ConcurrentQueue<String> Connections;

        static HubConn()
        {
            Connections = new ConcurrentQueue<String>();
        }

        public override Task OnConnected()
        {
            //Connections.Enqueue(Context.ConnectionId);
            //.WriteLine("Connections: " + Connections.Count + " " + Context.ConnectionId + " Connected");
            return base.OnConnected();
        }

        public List<String> GetPlayers()
        {
            //if (Connections.Count == 4)
            //{
                List<String> players = new List<String>(Connections);
            //}
            return players;
        }

        public void AddUser()
        {
            Connections.Enqueue(Context.ConnectionId);
            Debug.WriteLine("adduser, Connections: " + Connections.Count + " " + Context.ConnectionId + " Connected");
        }

        //2 used for testing make 4 or more later
        public void FindGame(String id)
        {
            List<String> group;
            bool result = false;

            if (Connections.Count < 2)
                return;

            group = new List<String>(Connections.Where(x => x.IndexOf(x) < 2));

            if (!group.Contains(id))
                result = false;
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    String s;
                    Connections.TryDequeue(out s);
                    Clients.Client(s).startGame();

                }
                result = true;
            }

            //return result;
            
        }

    }
}