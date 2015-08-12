using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class ResearchWarTech : Action
    {
        public override bool Act(Player p)
        {
            bool result = true;

            if (p.WarTechLevel < 5)
                p.WarTechLevel++;
            else
                result = false;

            return result;
        }
    }
}
