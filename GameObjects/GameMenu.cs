using System.Net.Security;
using Spectre.Console;
namespace GameObjects
{
    public class Menu
    {
        public static Table LadyElara(Table gamemenu, Table table)
        {
            gamemenu.AddColumn(new TableColumn("")).HideHeaders();
            gamemenu.AddColumn(new TableColumn("")).HideHeaders();

            var ladyelara = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Silver);
            ladyelara.AddColumn(new TableColumn("[bold green]LADY ELARA [/]")).Centered();
            ladyelara.AddRow(@"         w*W*W*W*w       ");
            ladyelara.AddRow(@"          \'.'.'/        ");
            ladyelara.AddRow(@"           //`\\         ");
            ladyelara.AddRow(@"          (/a a\)        ");
            ladyelara.AddRow(@"          (\_-_/)        ");
            ladyelara.AddRow(@"         .-~'='~-.       ");
            ladyelara.AddRow(@"        /`~`'Y'`~`\      ");
            ladyelara.AddRow(@"       / /(_ * _)\ \     ");
            ladyelara.AddRow(@"      / /  )   (  \ \    ");
            ladyelara.AddRow(@"      \ \_/\\_//\_/ /    ");
            ladyelara.AddRow(@"       \/_) '*' (_\/     ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"     w * W * W * W * w   ");

            gamemenu.AddRow(ladyelara, table);
            return gamemenu;
        }
        public static void HeroDialogue(Hero hero, string s)
        {
            var dialogue = new Table()
            .RoundedBorder();
            dialogue.AddColumn(new TableColumn("[bold #000000]" + hero.icon + "[/]").Centered());
            dialogue.AddColumn(new TableColumn("[bold blue]> [/]" + s).Centered());
            AnsiConsole.Write(dialogue);

        }
        public static void PrintDirections()
        {
            var table = new Table()
               .NoBorder();
            var w = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("W ⬆ above").Centered());

            var a = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("A ⬅ left").Centered());

            var s = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("S ⬇ below").Centered());

            var d = new Table()
            .Border(TableBorder.Double)
            .BorderColor(Color.SandyBrown)
            .AddColumn(new TableColumn("D ➡ right").Centered());

            var back = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Red3)
                .AddColumn(new TableColumn("[bold]TAB[/] [bold red]Cancelar[/]"));

            table.AddColumn(new TableColumn("").Centered()).NoBorder();
            table.AddColumn(new TableColumn(w).Centered()).NoBorder();
            table.AddColumn(new TableColumn(back).Centered()).NoBorder();

            table.AddRow(a.Centered(), s.Centered(), d.Centered());
            AnsiConsole.Write(table);
        }
        public static void KeyToContinue()
        {
            var table = new Table()
            .RoundedBorder();
            table.AddColumn(new TableColumn("[#91e4f2] Press a key to continue [/]").Centered());
            AnsiConsole.Write(table);
            Console.ReadKey(true);

        }
        public static void HeroSelection(Table a, Table b, Table c)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
            var HeroSelectionTable = Menu.CreateTable("[bold #ff1e00] _____                        _____     _         _   _         [/]\n[bold #ff3800]|  |  |___ ___ ___ ___ ___   |   __|___| |___ ___| |_|_|___ ___ [/]\n[bold #ff4e00]|     | -_|  _| . | -_|_ -|  |__   | -_| | -_|  _|  _| | . |   |[/]\n[bold #ff6400]|__|__|___|_| |___|___|___|  |_____|___|_|___|___|_| |_|___|_|_|[/]\n");
            HeroSelectionTable.Centered();
            AnsiConsole.Write(HeroSelectionTable);
            Console.WriteLine();
            var menu = new Table()
            .NoBorder();
            a.Expand();
            c.Expand();
            menu.AddColumn(new TableColumn(a).Centered());
            menu.AddColumn(new TableColumn(b).Centered());
            menu.AddColumn(new TableColumn(c).Centered());
            menu.Centered();
            menu.Expand();
            AnsiConsole.Write(menu);

        }
        public static void KeyToContinueCentered()
        {
            var table = new Table()
            .RoundedBorder();
            table.AddColumn(new TableColumn("[#91e4f2] Press a key to continue [/]").Centered());
            table.Centered();
            AnsiConsole.Write(table);
            Console.ReadKey(true);

        }
        public static Table CreateTable(string col)
        {
            var table = new Table()
            .RoundedBorder();
            table.AddColumn(new TableColumn(col).Centered());
            return table;
        }
        public static void WriteTable(string col)
        {
            var table = new Table()
            .RoundedBorder();
            table.AddColumn(new TableColumn(col).Centered());
            AnsiConsole.Write(table);
        }
        public static void LadyElaraAskname(Table gamemenu, Table table)
        {
            gamemenu.AddColumn(new TableColumn("")).HideHeaders();
            gamemenu.AddColumn(new TableColumn("")).HideHeaders();

            var ladyelara = new Table();
            ladyelara.AddColumn(new TableColumn("[bold]LADY ELARA [/]")).Centered();
            ladyelara.AddRow(@"         w*W*W*W*w       ");
            ladyelara.AddRow(@"          \'.'.'/        ");
            ladyelara.AddRow(@"           //`\\         ");
            ladyelara.AddRow(@"          (/a a\)        ");
            ladyelara.AddRow(@"          (\_-_/)        ");
            ladyelara.AddRow(@"         .-~'='~-.       ");
            ladyelara.AddRow(@"        /`~`'Y'`~`\      ");
            ladyelara.AddRow(@"       / /(_ * _)\ \     ");
            ladyelara.AddRow(@"      / /  )   (  \ \    ");
            ladyelara.AddRow(@"      \ \_/\\_//\_/ /    ");
            ladyelara.AddRow(@"       \/_) '*' (_\/     ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"         |       |       ");
            ladyelara.AddRow(@"     w * W * W * W * w   ");

            gamemenu.AddRow(ladyelara, table);
            gamemenu.Centered();
            AnsiConsole.Write(gamemenu);
        }


        public static void GetMainMenu(Table gamemenu)
        {
            var gametitle = new Table()
            .BorderColor(Color.Black);

            gametitle.AddColumn(new TableColumn("[bold #012df4] ___      _______  _______  __   __  ______    ___   __    _  _______  __   __      _______  _______    _______  __   __  _______ [/]\n[bold #4b01f4]|   |    |   _   ||  _    ||  | |  ||    _ |  |   | |  |  | ||       ||  | |  |    |       ||       |  |       ||  | |  ||       |[/]\n[bold #7701f4]|   |    |  |_|  || |_|   ||  |_|  ||   | ||  |   | |   |_| ||_     _||  |_|  |    |   _   ||    ___|  |_     _||  |_|  ||    ___|[/]\n[bold #9101f4]|   |    |       ||       ||       ||   |_||_ |   | |       |  |   |  |       |    |  | |  ||   |___     |   |  |       ||   |___ [/]\n[bold #ae01f4]|   |___ |       ||  _   | |_     _||    __  ||   | |  _    |  |   |  |       |    |  |_|  ||    ___|    |   |  |       ||    ___|[/]\n[bold #c801f4]|       ||   _   || |_|   |  |   |  |   |  | ||   | | | |   |  |   |  |   _   |    |       ||   |        |   |  |   _   ||   |___ [/]\n[bold #e201f4]|_______||__| |__||_______|  |___|  |___|  |_||___| |_|  |__|  |___|  |__| |__|    |_______||___|        |___|  |__| |__||_______|[/]\n \n[bold #f401da] ___      ___   __    _  ___   _  _______  ______       _     _  _______  ______    ___      ______   _______ [/]\n[bold #f40186]|   |    |   | |  |  | ||   | | ||       ||      |     | | _ | ||       ||    _ |  |   |    |      | |       |[/]\n[bold #f40186]|   |    |   | |   |_| ||   |_| ||    ___||  _    |    | || || ||   _   ||   | ||  |   |    |  _    ||  _____|[/]\n[bold #f4016f]|   |    |   | |       ||      _||   |___ | | |   |    |       ||  | |  ||   |_||_ |   |    | | |   || |_____ [/]\n[bold #f40156]|   |___ |   | |  _    ||     |_ |    ___|| |_|   |    |       ||  |_|  ||    __  ||   |___ | |_|   ||_____  |[/]\n[bold #f40138]|       ||   | | | |   ||    _  ||   |___ |       |    |   _   ||       ||   |  | ||       ||       | _____| |[/]\n[bold #f40101]|_______||___| |_|  |__||___| |_||_______||______|     |__| |__||_______||___|  |_||_______||______| |_______|[/]\n")).Centered();
            gamemenu.AddColumn(new TableColumn(gametitle)).Centered();
            gamemenu.Expand();


            //Play or Exit
            var playselected = new Table()
            .Border(TableBorder.Heavy)
            .BorderColor(Color.BlueViolet);
            var gameplayselected = new Table()
            .Border(TableBorder.Markdown)
            .BorderColor(Color.SteelBlue);
            gameplayselected.AddColumn(new TableColumn("[bold] _____ __    _____ __ __ [/]\n[bold]|  _  |  |  |  _  |  |  |[/]\n[bold]|   __|  |__|     |_   _|[/]\n[bold]|__|  |_____|__|__| |_|  [/]\n ")).Centered();
            playselected.AddColumn(new TableColumn(gameplayselected));
            playselected.Centered();



            var gameplay = new Table()
            .Border(TableBorder.Markdown)
            .BorderColor(Color.SteelBlue);
            gameplay.AddColumn(new TableColumn("[bold] _____ __    _____ __ __ [/]\n[bold]|  _  |  |  |  _  |  |  |[/]\n[bold]|   __|  |__|     |_   _|[/]\n[bold]|__|  |_____|__|__| |_|  [/]\n ")).Centered();


            var exitselected = new Table()
            .Border(TableBorder.Heavy)
            .BorderColor(Color.BlueViolet);
            var gameexitselected = new Table()
            .Border(TableBorder.Markdown)
            .BorderColor(Color.SteelBlue);
            gameexitselected.AddColumn(new TableColumn("[bold] _____ __ __ _____ _____ [/]\n[bold]|   __|  |  |     |_   _|[/]\n[bold]|   __|-   -|-   -| | |  [/]\n[bold]|_____|__|__|_____| |_|  [/]\n ")).Centered();
            exitselected.AddColumn(new TableColumn(gameexitselected));
            exitselected.Centered();

            var gameexit = new Table()
            .Border(TableBorder.Markdown)
            .BorderColor(Color.SteelBlue);
            gameexit.AddColumn(new TableColumn("[bold] _____ __ __ _____ _____ [/]\n[bold]|   __|  |  |     |_   _|[/]\n[bold]|   __|-   -|-   -| | |  [/]\n[bold]|_____|__|__|_____| |_|  [/]\n ")).Centered();


            gamemenu.AddEmptyRow();
            gamemenu.AddEmptyRow();
            if (Player.play == true)
            {
                gamemenu.AddRow(playselected);
                gamemenu.AddEmptyRow();
                gamemenu.AddRow(gameexit);
                AnsiConsole.Write(gamemenu);
            }
            if (Player.exit == true)
            {
                gamemenu.AddRow(gameplay);
                gamemenu.AddEmptyRow();
                gamemenu.AddRow(exitselected);
                AnsiConsole.Write(gamemenu);
            }
        }

    }
}
