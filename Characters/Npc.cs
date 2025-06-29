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
        public Npc(string name, int lvl,  string description,  int gold, List<object> inventory, string dialog)
            : base(name, lvl, description,  gold,  inventory)
        {
            Dialog = dialog;
        }
    }
}
