using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Game
    {
        
        public List<Player> Players { get; set; }
        public Season TheSeason { get; set; }
        public int TurnCount { get; set; }
        
        public Game()
        {
            TheSeason = Season.Spring;
            TurnCount = 0;
            Players = new List<Player>();
        }

        public void StartGame(List<Player> players)
        {
            Players = new List<Player>(players);

            foreach(Player p in Players)
            {
                p.Deck.Add(new Resource(Res.Gold, 1));
                p.Deck.Add(new Resource(Res.Gold, 1));
                p.Deck.Add(new Resource(Res.Gold, 1));
                p.Deck.Add(new Resource(Res.Gold, 1));
                p.Deck.Add(new Resource(Res.Gold, 1));
                p.Deck.Add(new Resource(Res.Lumber, 1));
                p.Deck.Add(new Resource(Res.Lumber, 1));
                p.Deck.Add(new Resource(Res.Lumber, 1));
                p.Deck.Add(new Resource(Res.Iron, 1));
                p.Deck.Add(new Resource(Res.Iron, 1));

                p.Deck.Shuffle();

                p.Draw();
            }
        }
        
    }
}
