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

       

        public Enemy(string name, string description, int lvl, int maxHealth, int gold, int attack, int armor, List<object> inventory) :base(name, lvl, description, maxHealth, gold, attack, armor, inventory) { }

        
    }
}
