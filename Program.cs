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
        }
    }
}
