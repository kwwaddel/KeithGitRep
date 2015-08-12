using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Fortify : Action
    {
        public override bool Act(Player p)
        {
            bool result = true;

            if (p.FortLevel < 5)
                p.FortLevel++;
            else
                result = false;

            return result;
        }
    }
}
