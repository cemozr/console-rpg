using ConsoleRpg.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Characters
{
    public class Player : Character
    {
        public List<Equipment> EquippedItems { get; set; } = new List<Equipment>();

        public int Exp { get; set; } = 0;
        public Player(string name, int lvl, string description, int gold, List<object> inventory) : base(name, lvl, description, gold, inventory) { }

        public void Eat(Food food)
        {
            if (Inventory.Contains(food))
            {
               food.ApplyEffect(this);
                Inventory.Remove(food);
              
            }
            else
            {
                Console.WriteLine($"{Name} does not have {food.Name} in their inventory.");
            }
        }
        public void Drink(Potion potion)
        {
            if (Inventory.Contains(potion))
            {
               potion.ApplyEffect(this);
                Inventory.Remove(potion);
                

            }
            else
            {
                Console.WriteLine($"{Name} does not have {potion.Name} in their inventory.");
            }
        }
        public void Equip(Equipment equipment)
        {
            if (!Inventory.Contains(equipment))
            {
                Console.WriteLine($"{Name} does not have {equipment.Name} in their inventory.");
                return;
            }

            if (equipment.LevelRequirement > this.Lvl)
            {
                Console.WriteLine($"{Name} does not meet the level requirement to equip {equipment.Name}.");
                return;
            }

            if (equipment.Durability <= 0)
            {
                Console.WriteLine($"{equipment.Name} is broken and cannot be equipped.");
                return;
            }

            Equipment? oldEquipment = null;
            if (equipment is Weapon)
                oldEquipment = EquippedItems.OfType<Weapon>().FirstOrDefault();
            if (equipment is Amulet)
                oldEquipment = EquippedItems.OfType<Amulet>().FirstOrDefault();
            if (equipment is Armor)
                oldEquipment = EquippedItems.OfType<Armor>().FirstOrDefault();

            if (oldEquipment != null)
            {

                if (oldEquipment is Weapon oldWeapon)
                    Attack -= oldWeapon.Attack;
                if (oldEquipment is Amulet oldAmulet)
                    MaxHealth -= oldAmulet.MaxHealth;
                if (oldEquipment is Armor oldArmor)
                    Armor -= oldArmor.Defence;
                EquippedItems.Remove(oldEquipment);
                Inventory.Add(oldEquipment);
            }
            if (equipment is Weapon weapon)
            {
                Attack += weapon.Attack;
            }
            else if (equipment is Amulet amulet)
            {
                MaxHealth += amulet.MaxHealth;
            }
            else if (equipment is Armor armor)
            {
                Armor += armor.Defence;
            }

            EquippedItems.Add(equipment);
            Inventory.Remove(equipment);





        }
        public void Buy(Item item)
        {
            if (Gold > item.Price)
            {
                Inventory.Add(item);
                Gold -= item.Price;
                Console.WriteLine($"{Name} bought {item.Name} for {item.Price} golds ");

            }
            else
            {
                Console.WriteLine($"You do not have enough gold to buy {item.Name}.");
            }
        }
        public void Sell(Item item, Npc npc)
        {
            if(Inventory.Contains(item) && npc.Gold >= item.Price )
            {
                Inventory.Remove(item);
                Gold += item.Price;
                npc.Gold -= item.Price;
                npc.Inventory.Add(item);
                Console.WriteLine($"{Name} sold {item.Name} to {npc.Name} for {item.Price} golds.");
            }
        }
        }
    }


