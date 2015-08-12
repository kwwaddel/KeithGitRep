using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalRAuth.Models.GameModels
{
    class GameContainer
    {
        public static Game g;
        public static ConcurrentBag<Player> players;

        static GameContainer()
        {
            g = new Game();
            players = new ConcurrentBag<Player>();
        }

        //2 for testing, 4 or more later
        public bool StartGame(String playerName)
        {
            bool result = false;
            //g = new Game();
            players.Add(new Player(playerName.Substring(0, playerName.IndexOf("@"))));
            if (players.Count == 2)
            {
                g.StartGame(new List<Player>(players));
                Debug.WriteLine("player name: " + g.Players.ElementAt(0).Name + " player2 name: " + g.Players.ElementAt(1).Name);
                result = true;
            }

            return result;
                
            //g.StartGame();
        }

        public Player getPlayer(String s)
        {
            return g.Players.First(x => x.Name == s);
        }
    }
}