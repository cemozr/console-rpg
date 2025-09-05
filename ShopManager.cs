using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleRpg.Characters;
using ConsoleRpg.Characters.Npcs;
using ConsoleRpg.Inventory;
using Spectre.Console;

namespace ConsoleRpg
{
    public static class ShopManager
    {
        public static void CreateShopTable(Npc character, string shopTitle, Player player)
        {
            var inventoryTable = new Table().RoundedBorder();
            inventoryTable.Title($"[blue bold blink]{shopTitle}[/]");
            inventoryTable.AddColumn("[yellow]Name[/]");
            inventoryTable.AddColumn("[yellow]Type[/]");
            inventoryTable.AddColumn("[yellow]Detail[/]");
            inventoryTable.AddColumn("[yellow]Effect[/]");
            inventoryTable.AddColumn("[yellow]Durability[/]");
            inventoryTable.AddColumn("[yellow]Lvl[/]");
            inventoryTable.AddColumn("[yellow]Price[/]");

            foreach (var item in character.Inventory)
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

                string effect = item switch
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

                string itemName = item switch
                {
                    Equipment eq => eq.LevelRequirement < 3 ? $"[green]{item.Name}[/]"
                    : eq.LevelRequirement < 6 ? $"[aqua]{item.Name}[/]"
                    : $"[purple]{item.Name}[/]",
                    Potion p => p.Name,
                    Food f => f.Name,
                    _ => "-",
                };

                inventoryTable.AddRow(
                    itemName,
                    type,
                    item.Description,
                    effect,
                    durability,
                    level,
                    item.Price.ToString() + "[yellow] g[/]"
                );
            }

            AnsiConsole.Write(inventoryTable);
            AnsiConsole.MarkupLine("");
            AnsiConsole.MarkupLine($"[yellow]You have {player.Gold} g[/]\n");
        }

        public static void BuyMenu(Npc npc, Player player)
        {
            while (true)
            {
                CreateShopTable(npc, "Items For Sale", player);

                var itemChoices = npc.Inventory.Select(item => item.Name).Append("Leave");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]You break it, you buy it. Otherwise—enjoy browsing.[/]")
                        .PageSize(12)
                        .AddChoices(itemChoices)
                );
                if (choice == "Leave")
                {
                    Console.Clear();
                    return;
                }
                var selectedItem = npc.Inventory.FirstOrDefault((i) => i.Name == choice);
                player.Buy(
                    selectedItem
                        ?? throw new ArgumentNullException("Item not found in NPC inventory."),
                    npc
                );
                AnsiConsole.MarkupLine(
                    $"[green]{player.Name} bought [yellow slowblink]{selectedItem.Name}[/] from {npc.Name} for [yellow slowblink]{selectedItem.Price}[/] golds.[/]"
                );
            }
        }

        public static void SellMenu(Npc npc, Player player)
        {
            while (true)
            {
                CreateShopTable(npc, "Inventory", player);
                var items = player.Inventory.Select(item => item.Name).Append("Leave");
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]What do you want to sell?[/]")
                        .PageSize(12)
                        .AddChoices(items)
                );
                if (choice == "Leave")
                {
                    Console.Clear();
                    return;
                }
                var selectedItem = player.Inventory.FirstOrDefault((i) => i.Name == choice);
                player.Sell(
                    selectedItem
                        ?? throw new ArgumentNullException("Item not found in player inventory."),
                    npc
                );
                AnsiConsole.MarkupLine(
                    $"[green]{player.Name} sold [underline]{selectedItem.Name}[/] to {npc.Name} for {selectedItem.Price} golds.[/]"
                );
            }
        }
    }
}
