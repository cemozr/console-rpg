using ConsoleRpg.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleRpg.Characters
{
    public class Enemy: Character    {


        public int Exp { get; set; }
        public Enemy(string name, int lvl, string description,  int maxHealth, int gold, int attack, int armor, List<object> inventory) :base(name, lvl, description, maxHealth, gold, attack, armor, inventory) {

            Exp = Lvl * 100;
        }

       
        
    }
}
