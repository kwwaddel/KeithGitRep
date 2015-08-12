using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Hand
    {
        public List<Card> Cards { get; set; }
        public List<Action> Actions { get; set; }
        public Dictionary<Res, int> Resources { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
            Actions = new List<Action>();
            Resources = new Dictionary<Res, int>();
        }

        public void Add(Card c)
        {
            Cards.Add(c);
            if (c is Action)
                Actions.Add((Action)c);
            else
            {
                Resource r = (Resource)c;
                if (Resources.ContainsKey(r.TheResource))
                    Resources[r.TheResource] += r.Quantity;
                else
                    Resources.Add(r.TheResource, r.Quantity);
            }
        }

    }
}
