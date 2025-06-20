using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Characters
{
    public class Player : Character
    {
        public Player(string name, int lvl, string description, int maxHealth, int gold, int attack, int armor, List<object> inventory) : base(name, lvl, description, maxHealth, gold, attack, armor, inventory) { }
    }
}
