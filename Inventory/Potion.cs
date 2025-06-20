using ConsoleRpg.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Potion : Item
    {
        public string EffectType {  get; private set; }
        public int EffectValue { get; private set; }
        public Potion(string name, string description, int price,string effectType,int effectValue) :base(name,description,price) {
        
            EffectType = effectType;
            EffectValue = effectValue;
        
        }
        public void Effect( Player player)
        {
          switch (EffectType)
            {
                case "heal":
                    if (player.Health != player.MaxHealth)
                    {
                        player.Health += EffectValue;
                        break;
                    }
                    else break;
                case "increase attack":
                    player.Attack += EffectValue;
                    break;
                case "increase armor":
                    player.Armor += EffectValue;
                    break;
                default: break;
            }
        }
    }
}
