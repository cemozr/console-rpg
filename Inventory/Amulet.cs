using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Amulet : Equipment
    {
        public int Health { get; private set; }

        public Amulet(string name, string description, int price, int health, int levelRequirement) : base(name, description, price, levelRequirement)
        {
            Health = health;
        }
    }
}
