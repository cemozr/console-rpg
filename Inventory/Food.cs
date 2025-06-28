using ConsoleRpg.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Food : Item
    {

      public int Nutrition { get; private set; }

        public Food (string name, string description, int price, int nutrition ) : base (name, description, price)
        {
            Nutrition = nutrition;
        }

        //public void Effect(Player player)
        //{
        //    player.Health += Nutrition;
        //}

       
    }
}
