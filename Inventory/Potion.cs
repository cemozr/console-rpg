using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Characters;

namespace ConsoleRpg.Inventory
{
    public class Potion : Item
    {
        public string EffectType { get; private set; }
        public int EffectValue { get; private set; }

        public Potion(
            string name,
            string description,
            int price,
            string effectType,
            int effectValue
        )
            : base(name, description, price)
        {
            EffectType = effectType;
            EffectValue = effectValue;
        }

        public void ApplyEffect(Player player)
        {
            switch (EffectType)
            {
                case "heal":
                    if (player.Health != player.MaxHealth)
                    {
                        player.Health += EffectValue;
                        if (player.Health > player.MaxHealth)
                        {
                            player.Health = player.MaxHealth; // Ensure health does not exceed max health
                        }
                        Console.WriteLine(
                            $"{player.Name} drank {Name} and gained {EffectValue} health."
                        );
                    }
                    else
                    {
                        Console.WriteLine($"{player.Name} is already at full health.");
                    }
                    break;
                case "increase attack":
                    player.Attack += EffectValue;
                    Console.WriteLine(
                        $"{player.Name} drank {Name} and increased attack by {EffectValue}."
                    );
                    break;
                case "increase armor":
                    player.Armor += EffectValue;
                    Console.WriteLine(
                        $"{player.Name}  drank  {Name}  and increased armor by  {EffectValue}."
                    );
                    break;
                default:
                    break;
            }
        }
    }
}
