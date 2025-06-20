using ConsoleRpg.Characters;

namespace ConsoleRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string? name;

            Console.WriteLine("Hello adventurer! I'm the story teller Archus -_- (old man voice acting). What is your name?");
            while (true) {
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                Console.WriteLine("Don't be shy tell me your name -_-");
            }
            while (true) { 
            
            }
      

            int test = 1;
            Player player = new Player(name, 0, "", 100, 0, 5, 0, []);
        }
    }
}
