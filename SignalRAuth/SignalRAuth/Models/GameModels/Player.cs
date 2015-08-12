using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Player : Nation
    {
        public String Name { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Discard { get; set; }
        public Hand PlayerHand { get; set; }
        public List<Borderland> MyBorders { get; set; }
        public List<Borderland> OtherBorderlands { get; set; }
        public List<Player> Opponents { get; set; }

        public Player(String n)
        {
            Name = n;
            FortLevel = 0;
            ArmyLevel = 0;
            WarTechLevel = 0;
            PopArmyRatio = .15;
            Population = 10000;
            ArmyPop = 0;
            DefendingArmy = 0;
            Unrest = false;
            Deck = new List<Card>();
            Discard = new List<Card>();
            PlayerHand = new Hand();
            IsOccupied = false;
            MyBorders = new List<Borderland>();
            OtherBorderlands = new List<Borderland>();
            Opponents = new List<Player>();
        }

        public void Draw()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Deck.Count != 0)
                {
                    Card c = Deck.ElementAt(0);
                    Deck.RemoveAt(0);
                    PlayerHand.Add(c);
                }
                else
                {
                    Deck.Shuffle();
                    i--;
                }
            }
        }

        public bool BuyFood(int q)
        {
            bool result = false;

            if (PlayerHand.Resources[Res.Gold] >= q)
            {
                PlayerHand.Resources[Res.Gold] -= q;
                FoodLevel += q;
                result = true;
            }

            return result;
        }

        public int GetRelation(Borderland b)
        {
            int result = 0;

            if (MyBorders.Contains(b))
                result = MyBorders[MyBorders.IndexOf(b)].BorderRelation;
            else
                result = OtherBorderlands[OtherBorderlands.IndexOf(b)].Relations.First(x => x.Key == this).Value;

            return result;
        }

        public void DiscardHand()
        { 
            foreach (Card c in PlayerHand.Cards)
            {
                PlayerHand.Cards.Remove(c);
                Discard.Add(c);
                PlayerHand.Actions = new List<Action>();
                PlayerHand.Resources = new Dictionary<Res, int>();

                Draw();
            }
        }


        public bool Attack(Borderland b, int sent)
        {
            int def = b.CalcDefense();
            int atk = CalcAttack(sent);
            bool result = false;

            if (atk > def)
            {
                //code
                int r = b.Relations[this];

                if (r > 3)
                {
                    //code
                }
                else
                {
                    //code
                }
            }
            else
            {
                //code
            }

            return result;
        }
        
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
