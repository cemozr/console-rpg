using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleRpg.Inventory;

namespace ConsoleRpg.Characters.Enemy
{
    public class Enemy : Character
    {
        public int Exp { get; set; }

        public Enemy(string name, int lvl, string description, int gold, List<Item> inventory)
            : base(name, lvl, description, gold, inventory)
        {
            Exp = Lvl * 100;
        }
    }
}
