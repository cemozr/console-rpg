using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Characters
{
    public class Npc : Character
    {
        public string Dialog { get; set; }
        public Npc(string name, int lvl,  string description,  int maxHealth, int gold, int attack, int armor, List<object> inventory, string dialog)
            : base(name, lvl, description, maxHealth,  gold, attack, armor, inventory)
        {
            Dialog = dialog;
        }
    }
}
