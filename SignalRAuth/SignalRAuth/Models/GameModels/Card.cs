using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    abstract class Card
    {
        public Cost ResCost { get; set; }

        public bool TryBuy(Player p)
        {
            bool b = ResCost.TryBuy(p);
            
            if (b)
                p.Discard.Add(this);

            return b;
        }
    }
}
