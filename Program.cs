using ConsoleRpg.Characters;
using ConsoleRpg.Inventory;

namespace ConsoleRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string? name;

            //Console.WriteLine("Hello adventurer! I'm the story teller Archus -_- (old man voice acting). What is your name?");
            //while (true) {
            //    name = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(name))
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Don't be shy tell me your name -_-");
            //}
            //while (true) { 

            //}


            //int test = 1;
            Player player = new Player("asd", 0, "", 100, 0, 5, 0, []);
            Potion pot = new Potion("atk", "atks", 30, "increase attack", 10);
            pot.Effect(player);
            Console.WriteLine(player.Attack);
        }
    }
}
