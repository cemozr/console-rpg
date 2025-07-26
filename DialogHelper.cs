using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Characters.Npcs;
using Spectre.Console;

namespace ConsoleRpg
{
    public static class DialogHelper
    {
        public static void DisplayNpcName(string name, string title, int lvl)
        {
            var color = title == "Npc" ? "aqua" : "red";
            var panel = new Panel($"[{color} bold] {name} lvl.{lvl}[/]")
            {
                Border = BoxBorder.Rounded,
                Padding = new Padding(1, 0, 1, 0),
            }
                .Header($"[{color} bold]{title}[/]", Justify.Center)
                .BorderStyle(new Style(Color.Yellow));

            AnsiConsole.Write(panel);
        }

        public static void ContinueWithNextLine(
            string message = "[green slowblink]Press any key to continue...[/]"
        )
        {
            AnsiConsole.MarkupLine("");
            AnsiConsole.MarkupLine("");
            AnsiConsole.MarkupLine(message);
            Console.ReadKey(true);
            Console.Clear();
        }

        //public static void NpcDialog(Npc? npc, string dialog)
        //{
        //    if (npc != null)
        //    {

        //            AnsiConsole.MarkupLine(
        //                $"[aqua bold]{npc.Name}[/] says: [yellow italic]{dialog}[/]"
        //            );

        //        AnsiConsole.MarkupLine("");
        //        AnsiConsole.MarkupLine("");
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException(nameof(npc), "NPC cannot be null.");
        //    }
        //}

        public static void NpcDialog(Npc? npc, string dialog, int delay = 30)
        {
            if (npc == null)
                throw new ArgumentNullException(nameof(npc), "NPC cannot be null.");

            AnsiConsole.Markup($"[aqua bold]{npc.Name}[/] says: ");
            foreach (char c in dialog)
            {
                string escapedChar = Markup.Escape(c.ToString());
                AnsiConsole.Markup($"[yellow italic]{escapedChar}[/]");
                Thread.Sleep(delay);
            }

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }

        public static void StoryTellerDialog(string dialog)
        {
            AnsiConsole.MarkupLine($"[blue bold]*{dialog}*[/]");
        }
    }
}
