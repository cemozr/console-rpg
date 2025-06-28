using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Amulet : Equipment
    {
        public int MaxHealth { get; private set; }

        public Amulet(string name, string description, int price, int maxHealth, int levelRequirement) : base(name, description, price, levelRequirement)
        {
            MaxHealth = maxHealth;
        }
    }
}
