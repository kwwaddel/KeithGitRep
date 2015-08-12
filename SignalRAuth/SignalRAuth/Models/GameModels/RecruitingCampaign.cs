using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class RecruitingCampaign : Action
    {
        public override bool Act(Player p)
        {
            bool result = true;
            bool b = false;

            if (p.PopArmyRatio < .51)
            {
                p.PopArmyRatio += .3;
                b = true;
            }

            if (p.ArmyPop < p.Population * p.PopArmyRatio)
            {
                p.ArmyPop += (int)(p.Population * .3);

                if (p.ArmyPop > p.Population * p.PopArmyRatio)
                    p.ArmyPop = (int)(p.Population * p.PopArmyRatio);
            }
            else if (!b)
                result = false;
            

            return result;
        }
    }
}
