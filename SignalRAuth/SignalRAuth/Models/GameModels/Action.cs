using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    abstract class Action : Card
    {
        public abstract bool Act(Player p);
    }
}
