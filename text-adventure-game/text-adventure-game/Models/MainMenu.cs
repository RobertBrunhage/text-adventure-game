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
                            Menu();
                            break;
                        case 2:
                            //Exit Game
                            break;
                    }
                }
            } while (userInput <= 0 || userInput > 2); 
        }

        public void Menu()
        {
            //Console.WriteLine($"|HP {player.Health}               Name: {player.Name}");
            //Console.WriteLine($"|Damage: {player.Damage}          Armour: {player.Armour}");
            //Console.WriteLine("|_________________________________________________________");

            //Introduction
            string text = ($"Welcome to the world of Adventure's and Pixel's. In this world there is all kinds of magical and explorious adventures. " +
                $"You as a {player.Class} will now be guided by the creator (me....IT's A ME....MARIO) all jokes aside let us begin your adventure, {player.Name} \n");
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.ReadKey();

            Console.WriteLine("\nThe game menu will look like this:\n"); 
            Console.WriteLine("1. Adventure");
            Console.WriteLine("2. Inventory");
            Console.WriteLine("3. Store"); // In the future we can make it so that this one disapears until we have done the first adventure
            Console.WriteLine("4. Tavern");
            Console.WriteLine("Simple right? well I won't bore you with this so it's up to you to start your adventure!");
            Console.ReadKey();

            //Main Menu
            int userChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"|HP {player.Health}               Name: {player.Name}");
                Console.WriteLine($"|Damage: {player.Damage}          Armour: {player.Armour}");
                Console.WriteLine("|_________________________________________________________");

                Console.WriteLine("1. Adventure");
                Console.WriteLine("2. Inventory");
                Console.WriteLine("3. Store");
                Console.WriteLine("4. Tavern");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            //AdventureStart();
                            break;
                        case 2:
                            //Open Inventory
                            break;
                        case 3:
                            //Open Store
                            break;
                        case 4:
                            //Enter Tavern
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Sorry that is not a choice. Hit enter to try again.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 4);
            Console.Clear();
        }
    }
}
