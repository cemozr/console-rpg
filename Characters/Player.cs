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
        public List<object> EquippedItems { get; set; } = new List<object>();
        public Player(string name, int lvl, int exp, string description, int maxHealth, int gold, int attack, int armor, List<object> inventory) : base(name, lvl, exp, description, maxHealth, gold, attack, armor, inventory) { }

        public void Eat(Food food)
        {
            if (Inventory.Contains(food))
            {
                Health += food.Nutrition;
                if (Health > MaxHealth)
                {
                    Health = MaxHealth; // Ensure health does not exceed max health
                }
                Inventory.Remove(food);
                Console.WriteLine($"{Name} ate {food.Name} and gained {food.Nutrition} health.");
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
                switch (potion.EffectType)
                {
                    case "heal":
                        if (Health != MaxHealth)
                        {
                            Health += potion.EffectValue;
                            if (Health > MaxHealth)
                            {
                                Health = MaxHealth; // Ensure health does not exceed max health
                            }
                            Console.WriteLine($"{Name} drank {potion.Name} and gained {potion.EffectValue} health.");
                        }
                        else
                        {
                            Console.WriteLine($"{Name} is already at full health.");
                        }
                        break;
                    case "increase attack":
                        Attack += potion.EffectValue;
                        Console.WriteLine($"{Name} drank {potion.Name} and increased attack by {potion.EffectValue}.");
                        break;
                    case "increase armor":
                        Armor += potion.EffectValue;
                        Console.WriteLine($"{Name} drank {potion.Name} and increased armor by {potion.EffectValue}.");
                        break;
                    default:
                        break;
                }

            }
        }
        public void Equip(Equipment equipment)
        {
            if (Inventory.Contains(equipment))
            {
                if (equipment.LevelRequirement <= this.Lvl)
                {
                    if (equipment.Durability > 0)
                    {
                        // Assuming the item has properties like AttackBoost and ArmorBoost  
                        if (equipment is Weapon weapon)
                        {
                            if (EquippedItems.OfType<Weapon>().Any())
                            {
                                EquippedItems.RemoveAll(w => w is Weapon);
                            }
                            Attack += weapon.Attack;

                            Console.WriteLine($"{Name} equipped {weapon.Name} and increased attack by {weapon.Attack}.");
                        }
                        if (equipment is Amulet amulet)
                        {
                            if (EquippedItems.OfType<Amulet>().Any())
                            {
                                EquippedItems.RemoveAll(a => a is Amulet);
                            }
                            MaxHealth += amulet.Health;
                            Console.WriteLine($"{Name} equipped {amulet.Name} and increased max health by {amulet.Health}.");
                        }
                        else if (equipment is Armor armor)
                        {
                            if (EquippedItems.OfType<Armor>().Any())
                            {
                                EquippedItems.RemoveAll(a => a is Armor);
                            }
                            Armor += armor.Defence;
                            Console.WriteLine($"{Name} equipped {armor.Name} and increased armor by {armor.Defence}.");
                        }
                        Inventory.Remove(equipment);
                        EquippedItems.Add(equipment);
                    }
                    else
                    {
                        Console.WriteLine($"{equipment.Name} is broken and cannot be equipped.");
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} does not meet the level requirement to equip {equipment.Name}.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} does not have {equipment.Name} in their inventory.");
            }
        }
    }
}

