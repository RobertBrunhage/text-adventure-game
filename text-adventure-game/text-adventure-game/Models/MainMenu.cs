using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace text_adventure_game.Models
{
    class MainMenu
    {
        public Player player = new Player();
        public Monster monster = new Monster();
        private string _mapName1 = "Map 1";
        private string _mapName2 = "Map 2";
        private string _mapName3 = "Map 3";
        private string _mapName4 = "Map 4";
        private string _mapName5 = "Map 5";

        public void StartProgram()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("This is the main menu. Select from the menu below:\n");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Exit Game");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            player.AskGender();
                            player.AskClass();
                            player.AskName();
                            Console.Clear();
                            Introduction();
                            GameStart();
                            break;
                        case 2:
                            //Exit Game
                            break;
                    }
                }
            } while (userInput < 1 || userInput > 2);

        } // Player Creation

        public void Introduction()
        {
            //Introduction
            string text = ($"Welcome to the world of Adventure's and Pixel's. In this world there is all kinds of magical and explorious adventures. " +
                $"You as a {player.Class} will now be guided by the creator (me....IT's A ME....MARIO) all jokes aside let us begin your adventure, {player.Name} \n");
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("The game menu will look like this below, but also show your stats\n");
            Console.WriteLine("1. Adventure");
            Console.WriteLine("2. Inventory");
            Console.WriteLine("3. Store");
            Console.WriteLine("4. Tavern\n");
            Console.WriteLine("Simple right? well I won't bore you with this so it's up to you to start your adventure! Press any key to continue");
            Console.ReadKey();
        }

        public void GameStart() // Will host most of the game
        {
            //Main Menu
            int userChoice = 0;
            do
            {
                player.PrintStats();

                Console.WriteLine("1. Adventure");
                Console.WriteLine("2. Inventory");
                Console.WriteLine("3. Store");
                Console.WriteLine("4. Tavern");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            player.PrintStats();
                            AskAdventure();
                            break;
                        case 2:
                            player.PrintStats();
                            //Open Inventory
                            break;
                        case 3:
                            player.PrintStats();
                            //Open Store
                            break;
                        case 4:
                            player.PrintStats();
                            //Enter Tavern
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"{player.Name}, to the left of each word you can see a number. Enter the number for where you want to go.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 4);
            Console.Clear();
        }

        public void AskAdventure()
        {
            int userChoice = 0;
            do
            {
                player.PrintStats();

                Console.WriteLine($"1. {_mapName1}");
                Console.WriteLine($"2. {_mapName2}");
                Console.WriteLine($"3. {_mapName3}");
                Console.WriteLine($"4. {_mapName4}");
                Console.WriteLine($"5. {_mapName5}");
                Console.WriteLine($"6. Go back to menu");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            Map1();
                            break;
                        case 2:
                            //Map 2
                            break;
                        case 3:
                            //Map 3
                            break;
                        case 4:
                            //Map 4
                            break;
                        case 5:
                            //Boss Map
                            break;
                        case 6:
                            GameStart();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"{player.Name}, to the left of each word you can see a number. Enter the number for where you want to go.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 4);
            Console.Clear();
        }

        public void Map1()
        {
            int userChoice;

            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"You have entered the portal to: {_mapName1}... It's a vast world with rocks n shit. You see a glimt at a rock but you also see shit at poop\n");
            Console.WriteLine($"Would you like to go to the rock, or to the poop\n");
            //Console.SetCursorPosition(20, 0);
            Console.WriteLine("1. To the rock");
            //Console.SetCursorPosition(20, 2);
            Console.WriteLine("2. To the poop");
            do
            {
                if(int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            rock();
                            break;
                        case 2:
                            Poop();
                            break;
                        default:
                            break;
                    }
                }
            } while ((userChoice < 1 || userChoice > 2));

            void rock()
            {
                Console.WriteLine("You are at a rock...");
                Console.ReadKey();
                monster.MonsterDif = 1;
                monster.ChooseMonster();

                
                
            }

            void Poop()
            {
                Console.WriteLine("You are at a poop...");
                Console.ReadKey();
            }
        }
    }
}
