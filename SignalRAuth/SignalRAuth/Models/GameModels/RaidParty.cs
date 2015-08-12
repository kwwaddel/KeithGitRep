using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class RaidParty : Action
    {
        public RaidParty()
        {
            ResCost = new Cost(new Dictionary<Res, int>() { { Res.Gold, 3 } });
        }

        public override bool Act(Player p)
        {
            return false;
        }
    }
}
