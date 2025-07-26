using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Inventory;
using Spectre.Console;

namespace ConsoleRpg.Characters.Npcs
{
    public class Npc : Character
    {
        public string Dialog { get; set; }

        public Npc(
            string name,
            int lvl,
            string description,
            int gold,
            List<Item> inventory,
            string dialog
        )
            : base(name, lvl, description, gold, inventory)
        {
            Dialog = dialog;
        }

        public void BuyMenu()
        {
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]You break it, you buy it. Otherwise—enjoy browsing.[/]")
                        .AddChoices(new[] { "item1", "item2", "item3", "Leave" })
                );
                switch (choice)
                {
                    case "item1":
                        // Logic for buying item1
                        AnsiConsole.MarkupLine("[green]You bought item1![/]");
                        break;
                    case "item2":
                        // Logic for buying item2
                        AnsiConsole.MarkupLine("[green]You bought item2![/]");
                        break;
                    case "item3":
                        // Logic for buying item3
                        AnsiConsole.MarkupLine("[green]You bought item3![/]");
                        break;
                    case "Leave":
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Invalid choice, please try again.[/]");
                        break;
                }
            }
        }

        public void SellMenu()
        {
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Let’s see what kind of treasures you’re parting with.[/]")
                        .AddChoices(new[] { "item1", "item2", "item3", "Leave" })
                );
                switch (choice)
                {
                    case "item1":
                        // Logic for selling item1
                        AnsiConsole.MarkupLine("[green]You sold item1![/]");
                        break;
                    case "item2":
                        // Logic for selling item2
                        AnsiConsole.MarkupLine("[green]You sold item2![/]");
                        break;
                    case "item3":
                        // Logic for selling item3
                        AnsiConsole.MarkupLine("[green]You sold item3![/]");
                        break;
                    case "Leave":
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Invalid choice, please try again.[/]");
                        break;
                }
            }
        }
    }
}
