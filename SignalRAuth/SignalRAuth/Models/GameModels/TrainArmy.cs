using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class TrainArmy : Action
    {
        public override bool Act(Player p)
        {
            bool result = true;

            if (p.ArmyLevel < 10)
                p.ArmyLevel++;
            else
                result = false;

            return result;
        }
    }
}
