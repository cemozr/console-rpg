using ConsoleRpg.Characters;
using ConsoleRpg.Inventory;
using Spectre.Console;

namespace ConsoleRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MusicPlayer.PlayMusic("Resources/bgm.mp3");
            Game.StartGame();
            Game.ShowCityMenu();
            //Game.ShowNpcMenu(Game.Npcs.FirstOrDefault((n) => n.Name == "Thoren Ironhand"));
        }
    }
}
