using ConsoleRpg.Characters;
using ConsoleRpg.Inventory;
using Spectre.Console;

namespace ConsoleRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string? name;

            AnsiConsole.Markup("[underline strikethrough red]Hello adventurer! I'm the story teller Archus -_- (old man voice acting). What is your name?[/]");
            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                Console.WriteLine("Don't be shy tell me your name -_-");
            }
          



        }
    }
}
