using ConsoleRpg.Characters;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public static class Game
    {
      

        public static void CreateCharacter()
        {

            Console.Clear();

            AnsiConsole.MarkupLine("[yellow italic]Ah... Another soul steps into the realm of shadows and secrets.\r\n\r\nWelcome, traveler. I have felt your presence long before your feet touched this land.\r\n\r\nThese paths you now walk are not paved with glory, but with trials, sorrow... and fate.\r\n\r\nThe world has changed — kingdoms have fallen, beasts have awakened, and hope flickers like a candle in the wind.\r\n\r\nBut you... there is something different in your eyes. A hunger. A fire.\r\n\r\nPerhaps you are the one the prophecies spoke of... or just another lost wanderer.\r\n\r\nTime will tell.\r\n\r\nNow, choose your path wisely — for every step forward echoes in eternity.[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule("[yellow][/]"));
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
           

            var name = AnsiConsole.Ask<string>("[yellow italic]Tell me, what [green]name[/] do the winds whisper for you?[/]");
            AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start("[green]Hmm...[/]", ctx => {
            Thread.Sleep(1000);
            });
            Console.Clear();
            var age = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title("[yellow italic]How many winters have you witnessed, traveler?[/]")
                   .PageSize(5)
                   .AddChoices(new[] {
                            "5-12",
                            "18-25",
                            "25-45",
                            "45-70",
                            "+70"
                   }));
            if (age == "5-12")
            {
                AnsiConsole.MarkupLine("[red][italic]*He chuckles, stroking his beard with exaggerated concern*[/].\r\n\r\nTell me, brave one — did your mother pack you a lunch? Perhaps a bedtime story too?[/]");
                Thread.Sleep(3000);
                return;
            }
                if (age == "+70")
            {
                AnsiConsole.MarkupLine("[red italic]*The old man chuckles softly.*\r\n\r\n\"Your bones are weary, traveler.  \r\nThis path is for the young… and the foolish.  \r\nGo home. Rest. You've earned it.\"[/]");
                Thread.Sleep(3000);
                return; 
            }

            var job = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
                  .Title("[yellow italic]When the years were few and your heart still unburdened, what path did you walk?[/]")
                  .PageSize(5)
                  .AddChoices(new[] {
                            "Smith",
                            "Farmer",
                            "Alchemist",
                            "Guard",
                            "Hunter"
                  }));
            var story = AnsiConsole.Ask<string>("[yellow italic]Tell me what is your [green]story[/][/]? You can tell whatever you want.");
            
            AnsiConsole.MarkupLine($"[yellow]Character Created:[/] Name: {name}, Age: {age}, Story: {story}, Job: {job}");    

        }


        public static void StartGame()
        {

            Console.Clear();

           
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();

            
            AnsiConsole.Write(
                new FigletText("Forsaken Lands")
                    .Centered()
                    .Color(Color.Orange1)
            );
            AnsiConsole.Write(
         new Rule("[yellow slowblink]Old School Rpg Experience[/]")
             .Centered()
     );
           
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();

           
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow](Select with Up/Down arrow buttons)[/]")
                    .PageSize(5)
                    .AddChoices(new[] {
                            "Start Game",
                            "Exit"
                    })
            );

          
           if (choice == "Exit")
            {
               
                AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start("[red]Exiting the game...[/]", ctx => {   
                Thread.Sleep(1000);
                Environment.Exit(0);
            });
               
            }
  
          //  AnsiConsole.Status()
          //.Spinner(Spinner.Known.Dots)
          //.Start("[green]Game is starting...[/]", ctx => {
          //    Thread.Sleep(1000);
          //    ctx.Status("[green]Old wise man is preparing his long, boring speech...[/]");   
          //    Thread.Sleep(2000);
          //    ctx.Status("[green]Practicing his sage voice[/]");
          //    Thread.Sleep(2000);
          //    ctx.Status("[green]Preparing his pipe[/]");
          //    Thread.Sleep(2000);
          //    ctx.Status("[green]And now he is ready to speak...[/]");
          //    Thread.Sleep(1000);
          //});
            CreateCharacter();

        }
    }
}
