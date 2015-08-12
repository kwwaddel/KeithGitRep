using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    abstract class Nation
    {
        public bool IsOccupied { get; set; }
        public Player Occupier { get; set; }

        public int FoodLevel { get; set; }
        public bool Unrest { get; set; }
        public int Population { get; set; }
        public int FortLevel { get; set; }
        public int ArmyLevel { get; set; }
        public int WarTechLevel { get; set; }
        public double PopArmyRatio { get; set; }
        public int ArmyPop { get; set; }
        public int DefendingArmy { get; set; }
        /*
         * Attacking Rules:
         * A nation can always attack a nation that borders itself
         * A nation can't attack a non-border nation unless at least one border nation is on friendlier terms than with the target, has relation of(1-2) with target, or is occupied/defeated
         * A player nation can't be attacked unless at least one bordering nation of the attack target is on friendlier terms than with the target, has relation of(1-2) with target, or is occupied/defeated
         */
        /*
        public bool CanAttack(Nation n)
        {
            bool result = false;

            if (n is Borderland && ((n as Borderland).BorderingPlayer == this))
                 result = true;
            else
            {
                
            }

            return result;
        }
         * */
        public bool CanAttack(Borderland b)
        {
            bool result = false;

            if (b.BorderingPlayer == this)
                result = true;
            else
            {
                if (this is Borderland)
                    result = true;
                else if ((this as Player).MyBorders.Exists(x => (x.BorderRelation > 2 || x.Occupier == this)))
                    result = true;
            }

            return result;
        }

        public bool CanAttack(Player p)
        {
            bool result = false;

            if (this is Borderland && (this as Borderland).BorderingPlayer == p)
                result = true;
            else
            {
                if (this is Player)
                {
                    //May have to allow other players to attack target if borderland occupied by another player, requiring a prompt
                    if (p.MyBorders.Exists(x => x.BorderRelation < x.Relations[(this as Player)] || x.Occupier == this))
                        result = true;
                }
                else
                {
                    if (p.MyBorders.Exists(x => x.BorderRelation < x.Relations[(this as Borderland).BorderingPlayer] || x.Occupier == this))
                        result = true;
                }
            }

            return result;
        }

        public int CalcAttack(int armySent)
        {
            return armySent * WarTechLevel;
        }

        public int CalcDefense()
        {
            return DefendingArmy * FortLevel * WarTechLevel;
        }

        public int CalcCasualties(int atk, int def)
        {
            int result = 0;

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

        public int CalcCasualties(int atk, int def, int rel)
        {
            int result = 0;
            
            if (atk > def)
            {
                if (rel > 3)
                {
                    //defenders fight til end out of loyalty
                    result = (int)((atk * 1.5) / (atk / def));
                }
                else
                {
                    //defenders surrender, less casualties
                    result = (int)(((atk * 1.5) / (atk / def)) / 2);
                }
            }
            else
            {
                //might not have code
            }

            return result;
        }

    }
}
