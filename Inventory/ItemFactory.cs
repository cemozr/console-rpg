using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public static class ItemFactory
    {
        public static List<Armor> CreateArmors()
        {
            return new List<Armor>
            {
                new Armor(
                    name: "Cloth Tunic",
                    description: "Basic fabric clothing, provides almost no protection.",
                    price: 5,
                    defence: 1,
                    levelRequirement: 1
                ),
                new Armor(
                    name: "Padded Vest",
                    description: "A thick vest with padding, absorbs light blows.",
                    price: 15,
                    defence: 3,
                    levelRequirement: 1
                ),
                new Armor(
                    name: "Leather Armor",
                    description: "Lightweight armor made from treated animal hide.",
                    price: 30,
                    defence: 6,
                    levelRequirement: 2
                ),
                new Armor(
                    name: "Studded Leather",
                    description: "Leather reinforced with metal studs for extra protection.",
                    price: 50,
                    defence: 9,
                    levelRequirement: 3
                ),
                new Armor(
                    name: "Chainmail",
                    description: "Interlocking metal rings form a flexible barrier.",
                    price: 80,
                    defence: 13,
                    levelRequirement: 4
                ),
                new Armor(
                    name: "Scale Armor",
                    description: "Overlapping metal scales provide balanced protection.",
                    price: 100,
                    defence: 15,
                    levelRequirement: 5
                ),
                new Armor(
                    name: "Iron Plate Armor",
                    description: "Heavy armor offering superior physical protection.",
                    price: 120,
                    defence: 18,
                    levelRequirement: 6
                ),
                new Armor(
                    name: "Hardened Steel Armor",
                    description: "Expertly crafted steel plates for elite soldiers.",
                    price: 160,
                    defence: 22,
                    levelRequirement: 7
                ),
            };
        }

        public static List<Amulet> CreateAmulets()
        {
            return new List<Amulet>
            {
                new Amulet(
                    name: "Amulet of Vitality",
                    description: "Increases the wearer's maximum health.",
                    price: 100,
                    maxHealth: 50,
                    levelRequirement: 2
                ),
                new Amulet(
                    name: "Heartstone Amulet",
                    description: "A gem that pulses with life energy, boosting max health.",
                    price: 150,
                    maxHealth: 75,
                    levelRequirement: 4
                ),
                new Amulet(
                    name: "Guardian's Pendant",
                    description: "Worn by protectors, it strengthens the body’s resilience.",
                    price: 200,
                    maxHealth: 100,
                    levelRequirement: 6
                ),
                new Amulet(
                    name: "Lifeweaver's Charm",
                    description: "A mystical charm that weaves vitality into the soul.",
                    price: 250,
                    maxHealth: 125,
                    levelRequirement: 8
                ),
                new Amulet(
                    name: "Eternal Heart Amulet",
                    description: "An ancient talisman rumored to grant near-immortal endurance.",
                    price: 400,
                    maxHealth: 200,
                    levelRequirement: 10
                ),
                new Amulet(
                    name: "Bloodbond Amulet",
                    description: "Forged in blood rituals, it binds more life to its bearer.",
                    price: 300,
                    maxHealth: 150,
                    levelRequirement: 7
                ),
            };
        }

        public static List<Weapon> CreateWeapons()
        {
            return new List<Weapon>
            {
                new Weapon("Rusty Dagger", "A worn and dull dagger. Not very effective.", 10, 4, 1),
                new Weapon("Short Sword", "A balanced sword favored by novices.", 25, 8, 2),
                new Weapon("Warhammer", "Heavy hammer that delivers powerful blows.", 50, 15, 4),
                new Weapon("Longbow", "A bow with great range and accuracy.", 40, 12, 3),
                new Weapon("Battle Axe", "A brutal axe that cleaves armor and bone.", 60, 18, 5),
                new Weapon("Spear", "A versatile pole weapon for thrusting attacks.", 30, 10, 2),
                new Weapon("Crossbow", "A mechanical bow with strong bolts.", 55, 14, 4),
                new Weapon(
                    "Greatsword",
                    "A massive sword that requires strength to wield.",
                    100,
                    25,
                    7
                ),
                new Weapon(
                    "Flail",
                    "A spiked ball on a chain, deadly and unpredictable.",
                    70,
                    17,
                    5
                ),
                new Weapon("Magic Staff", "A staff imbued with arcane power.", 80, 20, 6),
            };
        }

        public static List<Food> CreateFoods()
        {
            return new List<Food>
            {
                new Food(
                    name: "Red Apple",
                    description: "A fresh red apple. Simple but nourishing.",
                    price: 5,
                    nutrition: 10
                ),
                new Food(
                    name: "Roasted Meat",
                    description: "A hearty piece of meat, still warm from the fire.",
                    price: 20,
                    nutrition: 25
                ),
                new Food(
                    name: "Elven Bread",
                    description: "A small loaf of Lembas. Fills the stomach quickly.",
                    price: 50,
                    nutrition: 40
                ),
                new Food(
                    name: "Glowing Mushroom",
                    description: "An odd mushroom that glows faintly. Tastes weird, but works.",
                    price: 15,
                    nutrition: 18
                ),
                new Food(
                    name: "Hearty Stew",
                    description: "A bowl of thick, spicy stew. Restores health and warms the soul.",
                    price: 30,
                    nutrition: 30
                ),
            };
        }

        public static List<Potion> CreatePotions()
        {
            return new List<Potion>
            {
                new Potion(
                    name: "Lesser Healing Potion",
                    description: "Restores a small amount of health.",
                    price: 10,
                    effectType: "heal",
                    effectValue: 20
                ),
                new Potion(
                    name: "Greater Healing Potion",
                    description: "Restores a large amount of health.",
                    price: 30,
                    effectType: "heal",
                    effectValue: 50
                ),
                new Potion(
                    name: "Superior Healing Elixir",
                    description: "A rare potion that fully revitalizes.",
                    price: 60,
                    effectType: "heal",
                    effectValue: 100
                ),
                new Potion(
                    name: "Potion of Might",
                    description: "Slightly increases your attack power.",
                    price: 15,
                    effectType: "increase attack",
                    effectValue: 5
                ),
                new Potion(
                    name: "Elixir of Fury",
                    description: "Greatly enhances your combat strength.",
                    price: 35,
                    effectType: "increase attack",
                    effectValue: 10
                ),
                new Potion(
                    name: "Berserker's Brew",
                    description: "Temporarily grants immense power.",
                    price: 50,
                    effectType: "increase attack",
                    effectValue: 15
                ),
                new Potion(
                    name: "Stone Skin Potion",
                    description: "Slightly hardens your skin.",
                    price: 12,
                    effectType: "increase armor",
                    effectValue: 4
                ),
                new Potion(
                    name: "Shielding Elixir",
                    description: "Fortifies your body for better defense.",
                    price: 28,
                    effectType: "increase armor",
                    effectValue: 8
                ),
                new Potion(
                    name: "Dragonhide Tonic",
                    description: "Temporarily grants near-impenetrable protection.",
                    price: 45,
                    effectType: "increase armor",
                    effectValue: 12
                ),
            };
        }
    }
}
