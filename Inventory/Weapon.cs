using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Weapon: Equipment
    {
        public int Attack { get; private set; }

        public Weapon(string name, string description, int price, int attack, int levelRequirement) : base(name, description, price, levelRequirement)
        {
            Attack = attack;
        }
    }
}
