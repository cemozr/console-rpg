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
        public Character(string name, int lvl, string description, int maxHealth, int gold, int attack , int armor, List<object> inventory) {

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Lvl = lvl;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Attack = attack;
        Armor = armor;
        Gold = gold ;
        Inventory = inventory;
        }

    }
}
