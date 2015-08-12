using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Cost
    {
        public Dictionary<Res, int> TheCost { get; set; }

        public Cost()
        {
            TheCost = new Dictionary<Res, int>();
        }

        public Cost(Dictionary<Res, int> d)
        {
            TheCost = d;
        }

        public bool TryBuy(Player p)
        {
            
            bool result = true;

            Dictionary<Res, int> r = p.PlayerHand.Resources;

            List<Res> l = new List<Res>(TheCost.Keys);

            foreach (Res x in l)
            {
                if (r.Keys.Contains(x))
                {
                    if (!(TheCost[x] <= r.First(y => y.Key == x).Value))
                        result = false;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                foreach (Res x in l)
                {
                    r[r.First(y => y.Key == x).Key] -= TheCost[x];
                    p.PlayerHand.Cards.RemoveAll(z => z is Resource && (z as Resource).TheResource == x);
                }
            }
            
            return result;
        }
    }
}
