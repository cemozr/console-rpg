using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg;
using ConsoleRpg.Characters;
using ConsoleRpg.Characters.Enemy;
using Spectre.Console;

namespace ConsoleRpg.Combat
{
    public static class CombatManager
    {
        public static Enemy Combat(Player player, Enemy enemy)
        {
            if (player == null || enemy == null)
            {
                throw new ArgumentNullException("Player or Enemy cannot be null");
            }
            while (true)
            {
                //player attacks enemy
                int playerDamage = Math.Max(0, player.Attack - enemy.Armor);
                enemy.Health -= playerDamage;

                if (enemy.Health <= 0)
                {
                    player.Gold += enemy.Gold;
                    player.Exp += enemy.Exp;
                    AnsiConsole.MarkupLine("");
                    AnsiConsole.MarkupLine(
                        $"[green]{enemy.Name}[/] has been defeated! You gain [green]{enemy.Exp}[/] EXP and [yellow]{enemy.Gold}[/] Gold!"
                    );
                    return enemy;
                }
                //enemy attacks player
                int enemyDamage = Math.Max(0, enemy.Attack - player.Armor);
                player.Health -= enemyDamage;

                AnsiConsole
                    .Status()
                    .Spinner(Spinner.Known.Star)
                    .Start(
                        "[blue bold]The battle continues...[/]",
                        ctx =>
                        {
                            Thread.Sleep(300); // Simulate some work being done
                            AnsiConsole.MarkupLine(
                                $"[green bold]{player.Name}[/] attacks [red bold]{enemy.Name}[/] for [red rapidblink]{playerDamage}[/] damage!"
                            );
                            Thread.Sleep(300);
                            AnsiConsole.MarkupLine(
                                $"[red bold]{enemy.Name}[/] attacks [green bold]{player.Name}[/] for [red rapidblink]{enemyDamage}[/] damage!"
                            );
                            Thread.Sleep(300);
                        }
                    );

                if (player.Health <= 0)
                {
                    player.Death();
                }
            }
        }

        public static void Flee(Player player, List<Enemy> enemies, Enemy enemy)
        {
            Boolean success = new Random().Next(0, 2) == 0; // 50% chance to flee successfully
            if (success)
            {
                DialogHelper.StoryTellerDialog("You successfully fled the battle!");
                return;
            }
            else
            {
                DialogHelper.StoryTellerDialog(
                    $"You failed to flee! The [red]{enemy}[/] attacks you!"
                );
                var defeatedEnemy = Combat(player, enemy);
                enemy.Death(enemies, enemy);
            }
        }

        public static void CombatTable(Player player, Enemy enemy)
        {
            var table = new Table();

            table.AddColumn("[yellow]Stats[/]");
            table.AddColumn($"[green]{player.Name}[/]");
            table.AddColumn($"[red]{enemy.Name}[/]");

            table.AddRow("[yellow]Level[/]", player.Lvl.ToString(), enemy.Lvl.ToString());
            table.AddRow(
                "[yellow]Health[/]",
                $"[red]{player.Health}/{player.MaxHealth}[/]",
                $"[red]{enemy.Health}/{enemy.MaxHealth}[/]"
            );
            table.AddRow("[yellow]Attack[/]", player.Attack.ToString(), enemy.Attack.ToString());
            table.AddRow("[yellow]Armor[/]", player.Armor.ToString(), enemy.Armor.ToString());

            AnsiConsole.Write(table);
        }

        public static void ShowCombatMenu(Player player, List<Enemy> enemies)
        {
            var enemy = enemies[0];

            CombatTable(player, enemy);

            AnsiConsole.MarkupLine(
                $"[yellow][red]{enemy.Name} lvl.{enemy.Lvl}[/] appeared!\r\n {enemy.Description}[/]"
            );
            AnsiConsole.MarkupLine("");
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue italic]What will you do now?[/]")
                        .PageSize(5)
                        .AddChoices(new[] { "Open Bag", "Attack", "Try to flee" })
                );
                switch (choice)
                {
                    case "Open Bag":
                        player.ShowPlayerEquipmentAndInventory();
                        break;
                    case "Attack":
                        AnsiConsole.MarkupLine("[red]You chose to attack![/]");
                        var defeatedEnemy = Combat(player, enemy);
                        enemy.Death(enemies, defeatedEnemy);
                        return;
                    case "Try to flee":
                        Flee(player, enemies, enemy);
                        return;
                }
            }
        }
    }
}
