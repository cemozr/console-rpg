using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleRpg;
using ConsoleRpg.Characters;
using ConsoleRpg.Characters.Enemy;
using ConsoleRpg.Characters.Npcs;
using ConsoleRpg.Combat;
using ConsoleRpg.Inventory;
using ConsoleRpg.Map;
using Spectre.Console;

namespace ConsoleRpg
{
    public static class Game
    {
        private static Player _currentPlayer;
        public static Player CurrentPlayer
        {
            get => _currentPlayer;
            private set => _currentPlayer = value;
        }

        public static List<Npc> Npcs { get; set; } = NpcFactory.GetAllNpcs();
        private static readonly Npc oldSage =
            Npcs.FirstOrDefault((n) => n.Name == "Old Sage")
            ?? throw new ArgumentNullException("Old Sage NPC not found.");

        // Fix for the invalid declaration of the static field `Locations`
        // Correctly declare the field with its type and initialize it using the `LocationFactory.CreateLocations()` method.
        public static List<Location> Locations = LocationFactory.CreateLocations();

        public static Player CreateCharacter()
        {
            Console.Clear();
            DialogHelper.NpcDialog(
                oldSage,
                "Ah... Another soul steps into the realm of shadows and secrets.\r\n\r\nWelcome, traveler. I have felt your presence long before your feet touched this land.\r\n\r\nThese paths you now walk are not paved with glory, but with trials, sorrow... and fate.\r\n\r\nThe world has changed — kingdoms have fallen, beasts have awakened, and hope flickers like a candle in the wind.\r\n\r\nBut you... there is something different in your eyes. A hunger. A fire.\r\n\r\nPerhaps you are the one the prophecies spoke of... or just another lost wanderer.\r\n\r\nTime will tell.\r\n\r\nNow, choose your path wisely — for every step forward echoes in eternity."
            );
            DialogHelper.ContinueWithNextLine();

            //AnsiConsole.WriteLine();
            //AnsiConsole.WriteLine();
            //AnsiConsole.Write(new Rule("[yellow][/]"));
            //AnsiConsole.WriteLine();
            //AnsiConsole.WriteLine();

            var name = AnsiConsole.Ask<string>(
                "[yellow italic]Tell me, what [green]name[/] do the winds whisper for you?[/]"
            );
            AnsiConsole
                .Status()
                .Spinner(Spinner.Known.Dots)
                .Start(
                    "[green]Hmm...[/]",
                    ctx =>
                    {
                        Thread.Sleep(1000);
                    }
                );
            Console.Clear();
            var age = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]{name}[/], [yellow italic]how many winters have you seen?[/]")
                    .PageSize(5)
                    .AddChoices(new[] { "5-12", "18-25", "25-45", "45-70", "+70" })
            );
            if (age == "5-12")
            {
                DialogHelper.StoryTellerDialog(
                    "He chuckles, stroking his beard with exaggerated concern"
                );
                DialogHelper.NpcDialog(
                    oldSage,
                    "Tell me, brave one — did your mother pack you a lunch? Perhaps a bedtime story too?"
                );
                DialogHelper.ContinueWithNextLine();

                Environment.Exit(0);
            }
            if (age == "+70")
            {
                DialogHelper.StoryTellerDialog("The old man chuckles softly.");
                DialogHelper.NpcDialog(
                    oldSage,
                    "Your bones are weary, traveler.  \r\nThis path is for the young… and the foolish.  \r\nGo home. Rest. You've earned it."
                );

                DialogHelper.ContinueWithNextLine();
                Environment.Exit(0);
            }

            var job = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(
                        "[yellow italic]When the years were few and your heart still unburdened, what path did you walk?[/]"
                    )
                    .PageSize(5)
                    .AddChoices(new[] { "Smith", "Farmer", "Alchemist", "Guard", "Hunter" })
            );
            var story = AnsiConsole.Ask<string>(
                "[yellow italic]Tell me, what is your [green]story[/]? You can tell whatever you want.[/]"
            );
            Console.Clear();
            int lvl;
            switch (age)
            {
                case "18-25":
                    lvl = 1;
                    break;
                case "25-45":
                    lvl = 2;
                    break;
                case "45-70":
                    lvl = 3;
                    break;
                default:
                    lvl = 1;
                    break;
            }

            Item item;

            switch (job)
            {
                case "Smith":
                    item =
                        ItemFactory.CreateWeapons().FirstOrDefault((w) => w.Name == "Rusty Dagger")
                        ?? throw new ArgumentException(
                            "No suitable weapon found for the Smith class."
                        );
                    break;
                case "Farmer":
                    item =
                        ItemFactory.CreateFoods().FirstOrDefault((f) => f.Name == "Elven Bread")
                        ?? throw new ArgumentException(
                            "No suitable food item found for the Farmer class."
                        );
                    break;
                case "Alchemist":
                    item =
                        ItemFactory
                            .CreatePotions()
                            .FirstOrDefault((p) => p.Name == "Greater Healing Potion")
                        ?? throw new ArgumentException(
                            "No suitable potion found for the Alchemist class."
                        );
                    break;
                case "Guard":
                    item =
                        ItemFactory.CreateArmors().FirstOrDefault((a) => a.Name == "Padded Vest")
                        ?? throw new ArgumentException(
                            "No suitable armor found for the Guard class."
                        );
                    break;
                case "Hunter":
                    item =
                        ItemFactory.CreateWeapons().FirstOrDefault((w) => w.Name == "Spear")
                        ?? throw new ArgumentException(
                            "No suitable weapon found for the Hunter class."
                        );
                    break;
                default:
                    item =
                        ItemFactory.CreateWeapons().FirstOrDefault((w) => w.Name == "Rusty Dagger")
                        ?? throw new ArgumentException(
                            "No suitable weapon found for the default class."
                        );
                    break;
            }

            Player player = new Player(name, lvl, story, 100, [item]);
            return player;
        }

        public static void ShowNpcMenu(Npc? npc)
        {
            while (true)
            {
                if (npc != null)
                {
                    DialogHelper.DisplayNpcName(npc.Name, "Npc", npc.Lvl);
                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"[yellow italic]{npc.Dialog}[/]")
                            .PageSize(5)
                            .AddChoices(
                                new[]
                                {
                                    "Ask her/his story",
                                    "Buy Something",
                                    "Sell Something",
                                    "Return To Town Center",
                                }
                            )
                    );
                    switch (choice)
                    {
                        case "Ask her/his story":
                            Console.Clear();
                            DialogHelper.NpcDialog(npc, npc.Description);
                            break;
                        case "Buy Something":
                            Console.Clear();
                            ShopManager.BuyMenu(npc, CurrentPlayer);
                            break;
                        case "Sell Something":
                            Console.Clear();
                            ShopManager.SellMenu(npc, CurrentPlayer);
                            break;
                        case "Return To Town Center":
                            Console.Clear();
                            ShowCityMenu();
                            return;
                        default:
                            AnsiConsole.MarkupLine("[red]Invalid choice, try again.[/]");
                            break;
                    }
                }
                else
                    throw new ArgumentNullException(nameof(npc), "NPC cannot be null.");
            }
        }

        public static void ShowCityMenu()
        {
            while (true)
            {
                if (CurrentPlayer.CurrentLocation.Name == "Newhaven")
                {
                    DialogHelper.StoryTellerDialog(
                        "You are in Newhaven, a peaceful city where you can rest and prepare for your journey ahead."
                    );
                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[blue italic]*What will you do now?*[/]")
                            .PageSize(7)
                            .AddChoices(
                                new[]
                                {
                                    "Check Your Bag",
                                    "Visit Blacksmith",
                                    "Visit Alchemist",
                                    "Visit Tavern",
                                    "Visit Jeweller",
                                    "Visit Healer's Home",
                                    "Start A Journey",
                                }
                            )
                    );
                    Console.Clear();
                    switch (choice)
                    {
                        case "Check Your Bag":
                            CurrentPlayer.ShowPlayerEquipmentAndInventory();
                            AnsiConsole.Clear();
                            break;

                        case "Visit Blacksmith":

                            ShowNpcMenu(Npcs.FirstOrDefault((n) => n.Name == "Thoren Ironhand"));
                            break;
                        case "Visit Alchemist":

                            ShowNpcMenu(Npcs.FirstOrDefault((n) => n.Name == "Elira Vinthel"));
                            break;
                        case "Visit Tavern":

                            ShowNpcMenu(Npcs.FirstOrDefault((n) => n.Name == "Marda Hearthpan"));
                            break;
                        case "Visit Jeweller":

                            ShowNpcMenu(Npcs.FirstOrDefault((n) => n.Name == "Brelgor Gemwright"));
                            break;
                        case "Visit Healer's Home":

                            ShowNpcMenu(Npcs.FirstOrDefault((n) => n.Name == "Brother Eamon"));
                            break;

                        case "Start A Journey":
                            ShowTravelMenu();
                            break;
                        default:
                            AnsiConsole.MarkupLine("[red]Invalid choice, try again.[/]");
                            break;
                    }
                }
                else
                {
                    DialogHelper.StoryTellerDialog(
                        $"You are in [green bold slowblink]{CurrentPlayer.CurrentLocation.Name}[/], a place of mystery and adventure."
                    );
                    DialogHelper.ContinueWithNextLine();
                }
            }
        }

        public static void ShowTravelMenu()
        {
            DialogHelper.StoryTellerDialog(
                "You step out of the city gates, ready to face the unknown challenges that await you in the forsaken lands."
            );
            AnsiConsole.MarkupLine("");
            AnsiConsole.MarkupLine("");
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[blue italic]Where do you want to go?[/]")
                        .PageSize(7)
                        .AddChoices(
                            new[]
                            {
                                "Return To Town Center",
                                "Elderglen Forest",
                                "Frostveil Peaks",
                                "Ashen Wastes",
                                "Miredeep Swamp",
                            }
                        )
                );
                Console.Clear();
                switch (choice)
                {
                    case "Return To Town Center":
                        CurrentPlayer.Travel(
                            Locations.FirstOrDefault((loc) => loc.Name == "Newhaven")
                                ?? throw new ArgumentNullException("location is null")
                        );

                        ShowCityMenu();
                        return;
                    case "Elderglen Forest":
                        CurrentPlayer.Travel(
                            Locations.FirstOrDefault((loc) => loc.Name == "Elderglen Forest")
                                ?? throw new ArgumentException("Location not found.")
                        );

                        AdventureMenu();
                        return;
                    case "Frostveil Peaks":
                        CurrentPlayer.Travel(
                            Locations.FirstOrDefault((loc) => loc.Name == "Frostveil Peaks")
                                ?? throw new ArgumentNullException("location is null")
                        );

                        AdventureMenu();
                        return;
                    case "Ashen Wastes":
                        CurrentPlayer.Travel(
                            Locations.FirstOrDefault((loc) => loc.Name == "Ashen Wastes")
                                ?? throw new ArgumentNullException("location is null")
                        );

                        AdventureMenu();
                        return;
                    case "Miredeep Swamp":
                        CurrentPlayer.Travel(
                            Locations.FirstOrDefault((loc) => loc.Name == "Miredeep Swamp")
                                ?? throw new ArgumentNullException("location is null")
                        );

                        AdventureMenu();
                        return;
                    default:
                        return;
                }
            }
        }

        public static void AdventureMenu()
        {
            DialogHelper.StoryTellerDialog(
                "You found a quiet spot and set down your gear.  \r\nThe tent is up, and a small fire crackles.  \r\nThe flames light the night as calm surrounds you. "
            );
            AnsiConsole.MarkupLine("");
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow italic]*What will you do now?*[/]")
                        .PageSize(5)
                        .AddChoices(new[] { "Open Bag", "Explore the area", "Return To Town" })
                );
                Console.Clear();
                switch (choice)
                {
                    case "Open Bag":
                        CurrentPlayer.ShowPlayerEquipmentAndInventory();
                        DialogHelper.ContinueWithNextLine();
                        break;
                    case "Explore the area":
                        var enemies = CurrentPlayer.CurrentLocation.Enemies;
                        CombatManager.ShowCombatMenu(CurrentPlayer, enemies);
                        DialogHelper.ContinueWithNextLine();
                        break;
                    case "Return To Town Center":
                        CurrentPlayer.Travel(
                            Locations.FirstOrDefault((loc) => loc.Name == "NewHaven")
                                ?? throw new ArgumentNullException("location is null")
                        );
                        ShowCityMenu();
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Invalid choice, try again.[/]");
                        break;
                }
            }
        }

        public static void StartGame()
        {
            //Test code
            Player x = new Player(
                "Test",
                1,
                "Test Story",
                100,
                [
                    ItemFactory.CreateWeapons().FirstOrDefault((w) => w.Name == "Rusty Dagger")
                        ?? throw new ArgumentException(
                            "No suitable weapon found for the test player."
                        ),
                ]
            );
            CurrentPlayer = x;
            Npc innkeeper = NpcFactory.CreateInnkeeper();
            ShowNpcMenu(innkeeper);
            //CurrentPlayer.ShowPlayerEquipmentAndInventory();
            //ShowTravelMenu();
            //Console.Clear();

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();

            AnsiConsole.Write(new FigletText("Forsaken Lands").Centered().Color(Color.Orange1));
            AnsiConsole.Write(
                new Rule("[yellow slowblink]Old School Rpg Experience[/]").Centered()
            );

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow](Select with Up/Down arrow buttons)[/]")
                    .PageSize(5)
                    .AddChoices(new[] { "Start Game", "Exit" })
            );

            if (choice == "Exit")
            {
                AnsiConsole
                    .Status()
                    .Spinner(Spinner.Known.Dots)
                    .Start(
                        "[red]Exiting the game...[/]",
                        ctx =>
                        {
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                        }
                    );
            }

            AnsiConsole
                .Status()
                .Spinner(Spinner.Known.Dots)
                .Start(
                    "[green]Game is starting...[/]",
                    ctx =>
                    {
                        Thread.Sleep(1000);
                        ctx.Status(
                            "[blue italic]Old wise man is preparing his long, boring speech...[/]"
                        );
                        Thread.Sleep(2000);
                        ctx.Status("[blue italic]Practicing his sage voice[/]");
                        Thread.Sleep(2000);
                        ctx.Status("[blue italic]Preparing his pipe[/]");
                        Thread.Sleep(2000);
                        ctx.Status("[blue italic]And now he is ready to speak...[/]");
                        Thread.Sleep(1000);
                    }
                );
            CurrentPlayer = CreateCharacter();

            switch (CurrentPlayer.Lvl)
            {
                case 1:
                    DialogHelper.NpcDialog(
                        oldSage,
                        $"[green]{CurrentPlayer.Name}[/]... You're young, swift... but the road ahead is long.\r\nI see traces of your past—just a spark, but it’s there.\r\nI've left you a small gift.\r\nCheck your bag.\r\nAnd remember:\r\nTrue strength is forged with patience."
                    );
                    break;
                case 2:
                    DialogHelper.NpcDialog(
                        oldSage,
                        $"[green]{CurrentPlayer.Name}[/]... You're no longer a reckless youth, nor an old shadow.\r\nYou're in the heart of your journey—where choices matter most.\r\nYour past has started to shape your steps.\r\nI left something behind for you...\r\nTake a look in your bag.\r\nExperience is the compass of those who know their path."
                    );
                    break;
                case 3:
                    DialogHelper.NpcDialog(
                        oldSage,
                        $"Ah, [green]{CurrentPlayer.Name}[/]... Yours is a name that's carried far.\r\nTime has not worn you down—it has ripened you.\r\nYour past is heavy, yet full of meaning.\r\nSo I left a sign of respect to it.\r\nThere’s something waiting in your bag.\r\nYour strength is no longer in what you see or strike… but in what you sense.\r\n\r\n"
                    );
                    break;
            }
            DialogHelper.ContinueWithNextLine();

            DialogHelper.NpcDialog(
                oldSage,
                "So… the time has come.\r\nThe world outside these woods is stirring. Danger brews, and your name will soon echo through it.\r\nNewhaven is where your path begins — not with glory, but with purpose.\r\nYou won't find answers there, but you'll find the strength to ask the right questions.\r\nHold still now. May your steps be true…"
            );
            DialogHelper.ContinueWithNextLine();
            AnsiConsole
                .Status()
                .Spinner(Spinner.Known.Dots)
                .Start(
                    "[blue italic]*The sage strikes his staff on the ground. A bright burst of light… the screen goes black.*[/]",
                    ctx =>
                    {
                        Thread.Sleep(1000);
                        ctx.Status("[green]...[/]");
                        Thread.Sleep(1000);
                        ctx.Status("[green]...[/]");
                        Thread.Sleep(1000);
                    }
                );

            DialogHelper.StoryTellerDialog(
                "You awaken on a bench near the city’s inner gate. Early morning light filters through stone arches. The sounds of merchants setting up and birds chirping mix with the distant clang of a blacksmith’s hammer."
            );
            DialogHelper.ContinueWithNextLine();
            DialogHelper.DisplayNpcName("Captain Rynn", "Npc", 10);
            DialogHelper.NpcDialog(
                Npcs.FirstOrDefault((n) => n.Name == "Captain Rynn"),
                "Ah, you're awake. That’s good — for a moment I thought we’d have to carry you to the healer.\r\n I’m Rynn, Captain of the city guard here in Newhaven.\r\nYou arrived... well, let’s just say not in the usual way. The sage didn’t offer much, just said you'd need a place to catch your breath.\r\n\r\nThis is Newhaven. Peaceful, quiet — we keep it that way.\r\nNo monsters, no raiders, no trouble. Just honest folk, warm meals, and solid walls.\r\n\r\nTake your time. No one will rush you here. When you're ready, explore the city — meet the people. You'll find they have stories worth hearing."
            );
            AnsiConsole.MarkupLine("");
            AnsiConsole.MarkupLine("");
            DialogHelper.ContinueWithNextLine();
        }

        public static void GameManager() { }
    }
}
