using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Equipment : Item
    {
        public int LevelRequirement { get; set; }
        public int Durability { get; set; }
        public bool IsEquipped { get; set; }

        public Equipment(string name, string description, int price, int levelRequirement)
            : base(name, description, price)
        {
            LevelRequirement = levelRequirement;
            Durability = 100;
            IsEquipped = false;
        }
    }
}
