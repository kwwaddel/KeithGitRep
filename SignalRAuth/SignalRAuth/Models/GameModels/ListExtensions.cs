using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    static class ListExtensions
    {
        public static void Shuffle(this List<Card> l)
        {
            Random r = new Random();
            List<Card> copy = new List<Card>(l);

            foreach(Card c in copy)
            {
                int x = r.Next(l.Count);

                l.Remove(c);
                l.Insert(x, c);
            }
        }
    }
}
