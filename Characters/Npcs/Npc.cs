using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Inventory;
using Spectre.Console;

namespace ConsoleRpg.Characters.Npcs
{
    public class Npc : Character
    {
        public string Dialog { get; set; }
        public string Job { get; set; }

        public Npc(
            string name,
            int lvl,
            string description,
            int gold,
            List<Item> inventory,
            string dialog,
            string job
        )
            : base(name, lvl, description, gold, inventory)
        {
            Dialog = dialog;
            Job = job;
        }
    }
}
