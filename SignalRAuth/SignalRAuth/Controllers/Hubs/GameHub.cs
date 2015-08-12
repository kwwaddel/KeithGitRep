using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRAuth.Models.GameModels;
using System.Diagnostics;

namespace SignalRAuth.Controllers.Hubs
{
    public class GameHub : Hub
    {
        GameContainer gc = new GameContainer();
        private Object _theLock = new object();
        public void Test()
        {
            Clients.Caller.display();
        }

        public void MakeGame()
        {
            String id = Context.ConnectionId;
            //may have to return a non-generic list of the data back to front end to display game

            //gc = new GameContainer();
            //List<String> Players = new List<String>();
            //Debug.WriteLine("player: " + Players.ElementAt(0));
            //Debug.WriteLine("gamehub username: " );
            lock (_theLock)
            {
                Debug.WriteLine("gamehub username: " + Context.User.Identity.Name + " " + id);
                bool res = gc.StartGame(Context.User.Identity.Name);
                if (res)
                    Clients.All.showGame();
            }
            
        }

        public void GetPlayerData()
        {
            lock (_theLock)
            {
                Debug.WriteLine(Context.User.Identity.Name);
                String s = Context.User.Identity.Name;
                Clients.Caller.showPlayer(gc.getPlayer(s.Substring(0, s.IndexOf("@"))));
            }
            
        }

        public String EmailToName(String s)
        {
            return s.Substring(0, s.IndexOf("@"));
        }
    }
}