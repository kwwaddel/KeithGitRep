using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Borderland : Nation
    {
        public String Name { get; set; }
        public Dictionary<Player, int> Relations { get; set; }
        public Player BorderingPlayer { get; set; }
        public int BorderRelation { get; set; }

        public Borderland(String n, Player p, List<Player> players)
        {
            Name = n;
            Relations = new Dictionary<Player, int>();
            BorderingPlayer = p;
            IsOccupied = false;
            FortLevel = 0;
            ArmyLevel = 0;
            WarTechLevel = 0;
            PopArmyRatio = .15;
            Population = 10000;
            ArmyPop = 0;
            DefendingArmy = 0;
            Unrest = false;

            foreach (Player pl in players)
                Relations.Add(pl, 3);
        }
        /*
        public bool Attack(Borderland b)
        {

        }
        */
        public bool Attack(Player p, int sent)
        {
            int def = p.CalcDefense();
            int atk = CalcAttack(sent);
            bool result = false;

            if (atk > def)
            {
                //code
            }
            else
            {
                //code
            }

            return result;
        }
        
    }
}
