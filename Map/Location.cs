using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Characters;
using ConsoleRpg.Characters.Enemy;

namespace ConsoleRpg.Map
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Danger { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Npc> Npcs { get; set; }

        public Location(
            string name,
            string description,
            string danger,
            List<Enemy> enemies,
            List<Npc> npcs
        )
        {
            Name = name;
            Description = description;
            Danger = danger;
            Enemies = enemies;
            Npcs = npcs;
        }
    }
}
