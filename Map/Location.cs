using ConsoleRpg.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Map
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; private set; }
        public List<Enemy> Enemies { get; set; }
        public List<Npc> Npcs { get; set; }

        public Location(string name)
        {
            Name = name;
            Description = string.Empty;
            Enemies = [];
            Npcs = [];
        }
    }
}
