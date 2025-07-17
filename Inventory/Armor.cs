using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Armor : Equipment
    {
        public int Defence { get; private set; }

        public Armor(string name, string description, int price, int defence, int levelRequirement)
            : base(name, description, price, levelRequirement)
        {
            Defence = defence;
        }
    }
}
