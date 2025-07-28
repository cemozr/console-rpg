using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Characters.Npcs;
using ConsoleRpg.Inventory;
using ConsoleRpg.Map;
using Spectre.Console;

namespace ConsoleRpg.Characters
{
    public class Player : Character
    {
        public List<Equipment> EquippedItems { get; set; } = new List<Equipment>();
        public Weapon? EquippedWeapon => EquippedItems.OfType<Weapon>().FirstOrDefault();
        public Armor? EquippedArmor => EquippedItems.OfType<Armor>().FirstOrDefault();
        public Amulet? EquippedAmulet => EquippedItems.OfType<Amulet>().FirstOrDefault();

        public int Exp { get; set; } = 0;

        public Location CurrentLocation { get; private set; } =
            LocationFactory.CreateLocations().FirstOrDefault(m => m.Name == "Newhaven")
            ?? throw new InvalidOperationException("Default location 'Newhaven' not found.");

        public Player(string name, int lvl, string description, int gold, List<Item> inventory)
            : base(name, lvl, description, gold, inventory) { }

        public void Eat(Food food)
        {
            if (Inventory.Contains(food))
            {
                food.ApplyEffect(this);
                Inventory.Remove(food);
                AnsiConsole.MarkupLine(
                    $"[green]{Name} ate {food.Name} and gained {food.Nutrition} health.[/]"
                );
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
                AnsiConsole.MarkupLine(
                    $"[green]{Name} drank {potion.Name} and gained {potion.EffectValue} {potion.EffectType}.[/]"
                );
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
                Console.WriteLine(
                    $"{Name} does not meet the level requirement to equip {equipment.Name}."
                );
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
            if (Inventory.Contains(item) && npc.Gold >= item.Price)
            {
                Inventory.Remove(item);
                Gold += item.Price;
                npc.Gold -= item.Price;
                npc.Inventory.Add(item);
                Console.WriteLine($"{Name} sold {item.Name} to {npc.Name} for {item.Price} golds.");
            }
        }

        public static void ShowPlayerEquipmentAndInventory(Player player)
        {
            // Ekipman tablosu
            var equippedTable = new Table().RoundedBorder();
            equippedTable.Title("[green]Equipped Items[/]");
            equippedTable.AddColumn("Slot");
            equippedTable.AddColumn("Item");
            equippedTable.AddColumn("Stats");
            equippedTable.AddColumn("Durability");
            equippedTable.AddColumn("Lvl");
            equippedTable.AddColumn("Price");

            var weapon = player.EquippedItems.OfType<Weapon>().FirstOrDefault();
            var armor = player.EquippedItems.OfType<Armor>().FirstOrDefault();
            var amulet = player.EquippedItems.OfType<Amulet>().FirstOrDefault();

            equippedTable.AddRow(
                "Weapon",
                weapon?.Name ?? "[grey]None[/]",
                weapon != null ? $"+{weapon.Attack} ATK" : "-",
                weapon != null
                    ? weapon.Durability > 0
                        ? weapon.Durability.ToString()
                        : "[red]Broken[/]"
                    : "-",
                weapon?.LevelRequirement.ToString() ?? "-",
                weapon?.Price.ToString() ?? "-"
            );
            equippedTable.AddRow(
                "Armor",
                armor?.Name ?? "[grey]None[/]",
                armor != null ? $"+{armor.Defence} DEF" : "-",
                armor != null
                    ? armor.Durability > 0
                        ? armor.Durability.ToString()
                        : "[red]Broken[/]"
                    : "-",
                armor?.LevelRequirement.ToString() ?? "-",
                armor?.Price.ToString() ?? "-"
            );
            equippedTable.AddRow(
                "Amulet",
                amulet?.Name ?? "[grey]None[/]",
                amulet != null ? $"+{amulet.MaxHealth} HP" : "-",
                amulet != null
                    ? amulet.Durability > 0
                        ? amulet.Durability.ToString()
                        : "[red]Broken[/]"
                    : "-",
                amulet?.LevelRequirement.ToString() ?? "-",
                amulet?.Price.ToString() ?? "-"
            );

            AnsiConsole.Write(equippedTable);

            // Envanter tablosu
            var inventoryTable = new Table().RoundedBorder();
            inventoryTable.Title("[blue]Inventory[/]");
            inventoryTable.AddColumn("Name");
            inventoryTable.AddColumn("Type");
            inventoryTable.AddColumn("Details");
            inventoryTable.AddColumn("Durability");
            inventoryTable.AddColumn("Lvl");
            inventoryTable.AddColumn("Price");

            foreach (var item in player.Inventory)
            {
                string type = item switch
                {
                    Weapon => "Weapon",
                    ConsoleRpg.Inventory.Armor => "Armor",
                    Amulet => "Amulet",
                    Potion => "Potion",
                    Food => "Food",
                    _ => "Misc",
                };

                string detail = item switch
                {
                    Weapon w => $"+{w.Attack} ATK",
                    Armor a => $"+{a.Defence} DEF",
                    Amulet am => $"+{am.MaxHealth} MAX HP",
                    Potion p => $"{p.EffectType} +{p.EffectValue}",
                    Food f => $"+{f.Nutrition} HP",
                    _ => "-",
                };
                string level = item switch
                {
                    Equipment eq => eq.LevelRequirement.ToString(),
                    _ => "-",
                };
                string durability = item switch
                {
                    Equipment eq => eq.Durability > 0 ? eq.Durability.ToString() : "[red]Broken[/]",
                    _ => "-",
                };

                inventoryTable.AddRow(
                    item.Name,
                    type,
                    detail,
                    durability,
                    level,
                    item.Price.ToString()
                );
            }

            AnsiConsole.Write(inventoryTable);

            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold yellow]Choose an action[/]")
                        .AddChoices("Equip an Item", "Eat Food", "Drink Potion", "Exit")
                );

                switch (choice)
                {
                    case "Equip an Item":
                        ShowEquipMenu(player);
                        break;
                    case "Eat Food":
                        ShowEatMenu(player);
                        break;
                    case "Drink Potion":
                        ShowDrinkMenu(player);
                        break;
                    case "Exit":
                        return;
                }

                AnsiConsole.Clear();
                ShowPlayerEquipmentAndInventory(player);
                return;
            }
        }

        private static void ShowEquipMenu(Player player)
        {
            var equippableItems = player
                .Inventory.OfType<Equipment>()
                .Where(eq => eq.LevelRequirement <= player.Lvl && eq.Durability > 0)
                .ToList();
            equippableItems.Add(null);

            if (!equippableItems.Any())
            {
                AnsiConsole.MarkupLine("[red]You have no equippable items.[/]");
                return;
            }

            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<Equipment>()
                    .Title("[yellow]Choose an item to equip:[/]")
                    .UseConverter(item =>
                        item == null
                            ? "Return"
                            : $"{item.Name} [dim](Lvl {item.LevelRequirement})[/]"
                    )
                    .AddChoices(equippableItems)
            );
            if (selected == null)
            {
                return;
            }
            else
                player.Equip(selected);
        }

        private static void ShowEatMenu(Player player)
        {
            var foodItems = player.Inventory.OfType<Food>().ToList();
            foodItems.Add(null);
            if (!foodItems.Any())
            {
                AnsiConsole.MarkupLine("[red]You have no food items.[/]");
                return;
            }

            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<Food>()
                    .Title("[yellow]Choose food to eat:[/]")
                    .UseConverter(item =>
                        item == null
                            ? "Return"
                            : $"{item.Name} [dim](Nutrition: {item.Nutrition})[/]"
                    )
                    .AddChoices(foodItems)
            );
            if (selected == null)
            {
                return;
            }
            else
                player.Eat(selected);
        }

        private static void ShowDrinkMenu(Player player)
        {
            var potionItems = player.Inventory.OfType<Potion>().ToList();
            potionItems.Add(null);
            if (!potionItems.Any())
            {
                AnsiConsole.MarkupLine("[red]You have no potions.[/]");
                return;
            }
            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<Potion>()
                    .Title("[yellow]Choose potion to drink:[/]")
                    .UseConverter(item =>
                        item == null
                            ? "Return"
                            : $"{item.Name} [dim](Effect: {item.EffectType} +{item.EffectValue})[/]"
                    )
                    .AddChoices(potionItems)
            );
            if (selected == null)
            {
                return;
            }
            else
                player.Drink(selected);
        }

        public void Travel(Location location)
        {
            if (location == CurrentLocation)
            {
                AnsiConsole.MarkupLine($"[red]{Name} is already in {location.Name}.[/]");
            }
            else
            {
                CurrentLocation = location;
                AnsiConsole.MarkupLine(
                    $"[green]{Name} has traveled to {location.Name}\r\n [yellow italic]{location.Description}.[/][/]"
                );
            }
        }
    }
}
