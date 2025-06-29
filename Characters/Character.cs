using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Characters
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Lvl { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public List<object> Inventory { get; set; }
        public int Attack { get; set; }
        public int Armor { get; set; }
        public Character(string name, int lvl, string description, int gold , List<object> inventory) {

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Lvl = lvl;
        MaxHealth = Lvl * 100;
        Health = MaxHealth;
        Attack = Lvl * 10;
        Armor = Lvl * 10;
        Gold = gold ;
        Inventory = inventory;
        }

    }
}
