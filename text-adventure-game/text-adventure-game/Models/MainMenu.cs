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
        public int userChoice = 0;
        public Player player = new Player();
        public Monster monster = new Monster();
        public Weapons weapons = new Weapons();

        public List<Weapons> Store { get; set; }
        public List<Weapons> Inventory { get; set; }

        public MainMenu()
        {
            Inventory = new List<Weapons>();

            Store = new List<Weapons>()
            {
                //Swords
                new Sword("Sword of swaggins", 30, 2, 1),

                //Axes
                new Axe("Axe of Swaggins", 100, 7, 1)
            };
        }

        private string _mapName1 = "The glimting forest";
        private string _mapName2 = "Map 2";
        private string _mapName3 = "Map 3";
        private string _mapName4 = "Map 4";
        private string _mapName5 = "Map 5";
        private bool gameOn = true;

        public void StartProgram()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("This is the main menu. Select from the menu below:\n");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Exit Game");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            player.AskGender();
                            player.AskClass();
                            player.AskName();
                            //player.AskAge();
                            Console.Clear();
                            Introduction();
                            GameStart();
                            break;
                        case 2:
                            //Exit Game
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 2);

        } // Player Creation

        public void Introduction()
        {
            //Introduction
            string text = ($"Welcome to the world of Adventure of Pixel's. In this world there is all kinds of magical and explorious adventures. " +
                $"You as a {player.Class} will now be guided by the creator (me....IT's A ME....MARIO) all jokes aside let us begin your adventure, {player.Name}. \n");
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
            Console.WriteLine("Simple right? well I won't bore you with this so it's up to you to start your adventure! Press any key so you can go to the town!");
            Console.ReadKey();
        }

        public void GameStart() //Returning here all the time
        {
            //Main Menu
            do
            {
                player.PrintStats();

                Console.WriteLine("1. Adventure");
                Console.WriteLine("2. Inventory");
                Console.WriteLine("3. Store");
                Console.WriteLine("4. Inventory");
                Console.WriteLine("5. Tavern");
                Console.WriteLine("6. Exit Game");

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
                            break;
                        case 3:
                            player.PrintStats();
                            ItemStore();
                            break;
                        case 4:
                            player.PrintStats();
                            PrintInventory();
                            Console.ReadKey();
                            break;
                        case 5:
                            //Enter Tavern
                            break;
                        case 6:
                            gameOn = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"{player.Name}, to the left of each word you can see a number. Enter the number for where you want to go.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 5 || gameOn == true);
            Console.Clear();
        }

        public void AskAdventure()
        {
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
                            // Returning to menu
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
            monster.MonsterDif = 1;
            monster.ChooseMonster();

            string text;
            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"You have entered the portal to: {_mapName1}... It's a vast world, you can see the wind blowing through the trees... But what is that! Something sparkled in the bushes.. And you can hear a sound coming from the left...\n");
            Console.WriteLine($"Would you like to go to the bushes, or go to the left\n");
            Console.WriteLine("1. To the bushes");
            Console.WriteLine("2. To the left");
            do
            {
                if(int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("You are at a bush...");
                            Console.ReadKey();
                            Console.WriteLine($"A {monster.Name} has appeared...");
                            Console.ReadKey();
                            Console.Clear();

                            CombatMonster(); //If we lose the battle or press run we return to StartGame();
                            //Tell a story then return to GameStart();
                            // Returning to menu
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                player.PrintStats();
                                Console.WriteLine($"You walk slowly to the left, trying to hide as much as possible but you see a {monster.Name}... do you wish to attack or run back to the town?");
                                Console.WriteLine($"1. Attack the snake");
                                Console.WriteLine($"2. Run back to town");
                                if (int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    if (userChoice == 1)
                                    {
                                        CombatMonster();
                                        text = "A huge monster appeared that you are not able to fight. You run back as fast as you can and through the portal again...";
                                        foreach (char c in text)
                                        {
                                            Console.Write(c);
                                            Thread.Sleep(30);
                                        }
                                        
                                        Console.ReadKey();
                                        Console.Clear();
                                        player.PrintStats();

                                        Console.WriteLine("1. Adventure");
                                        Console.WriteLine("2. Inventory");
                                        Console.WriteLine("3. Store");
                                        Console.WriteLine("4. Tavern");
                                        text = "\nWhat was that...?";
                                        foreach (char c in text)
                                        {
                                            Console.Write(c);
                                            Thread.Sleep(30);
                                        }
                                        Console.ReadKey();
                                        GameStart();
                                    }
                                    else if (userChoice == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You see a big rock, running as fast as you can. You hide and wait...." +
                                            "You can see the portal back to town and make a run for it. Just as the monster was about to attack you jump through the portal");
                                        Console.ReadKey();
                                        // Returning to menu
                                    }
                                    break;
                                }
                            } while (userChoice < 1 || userChoice > 2);
                            break;
                    }
                }
            } while ((userChoice < 1 || userChoice > 2));
        }

        void CombatMonster()
        {
            Random rndPlayerDamage = new Random();

            Random rndMonsterDamage = new Random();
            Random rndMonsterGold = new Random();

            do
            {
                Console.Clear();
                player.PrintStats();
                monster.PrintMonsterStats();
                if (player.Class.ToLower() == "mage")
                {
                    Console.WriteLine("\n1. Fire ball");
                    Console.WriteLine("2. run");
                }
                else if (player.Class.ToLower() == "warrior")
                {
                    Console.WriteLine("\n1. Quick Attack");
                    Console.WriteLine("2. run");
                }

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            int playerDamage = rndPlayerDamage.Next(1, player.Damage + 1);
                            int monsterDamage = rndMonsterDamage.Next(1, monster.Damage + 1);

                            monster.Health -= playerDamage;
                            Console.WriteLine($"\nYou did {playerDamage} damage on the monster");
                            player.Health -= monsterDamage;
                            Console.WriteLine($"The monster did {monsterDamage} damage on you");
                            Console.ReadKey();
                            break;
                        case 2:
                            //break out of the switch
                            break;
                        default:
                            break;
                    }
                }
                if (userChoice == 2)
                {
                    break; // Break out of the do while loop
                }
            } while (monster.Health > 0 && player.Health > 0);
            Console.Clear();
            if (monster.Health <= 0)
            {
                int monsterGold = rndMonsterGold.Next(3, monster.GoldValue + 1);
                Console.WriteLine("Monster has been defeated!");
                Console.WriteLine($"You have been awarded {monsterGold} gold");
                player.Gold += monsterGold;
                Console.ReadKey();
                Console.Clear();
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine("You have died");
                Console.ReadKey();
                // Returning to menu
            }
            else if (userChoice == 2)
            {
                Console.WriteLine("You will now be returned to the menu");
                Console.ReadKey();
                // Returning to menu
            }
        }

        public void ItemStore()
        {

            //WeaponType weaponType;

            Console.WriteLine("1. Swords");
            Console.WriteLine("2. Axes");

            do
            {
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            Console.Clear();
                            player.PrintStats();
                            PrintSwords();
                            BuySword();
                            break;
                        case 2:
                            Console.Clear();
                            player.PrintStats();
                            PrintAxes();
                            BuyAxe();
                            break;
                        default:
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 2);
        }

        public void PrintSwords()
        {
            foreach (Weapons weapon in Store.OfType<Sword>())
            {
                Console.WriteLine($"1. {weapon.Name}");
                Console.WriteLine($"Price: {weapon.GoldValue} gold");
                Console.WriteLine($"stats: {weapon.DamageBoost} damage increase\n");
            }
            Console.WriteLine("Press 0 to exit store");
        }

        public void PrintAxes()
        {
            foreach (Weapons weapon in Store.OfType<Axe>())
            {
                Console.WriteLine($"1. {weapon.Name}");
                Console.WriteLine($"Price: {weapon.GoldValue} gold");
                Console.WriteLine($"stats: {weapon.DamageBoost} damage increase\n");
            }
        }

        public void BuySword()
        {
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 0)
                {
                    //Exit store
                }
                else
                {
                    foreach (Weapons weapon in Store.OfType<Sword>())
                    {
                        if (userChoice == weapon.StoreID && player.Gold >= weapon.GoldValue)
                        {
                            Inventory.Add(weapon);
                            player.Gold -= weapon.GoldValue;
                            Console.Clear();
                            Console.WriteLine($"{weapon.Name} has been added to your inventory");
                            Console.ReadKey();
                        }

                        else if (userChoice == weapon.StoreID && player.Gold < weapon.GoldValue)
                        {
                            Console.Clear();
                            Console.WriteLine("You do not have enough gold. You can get gold by defeating monsters in adventure");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void BuyAxe()
        {
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 0)
                {
                    //Exit store
                }
                else
                {
                    foreach (Weapons weapon in Store.OfType<Axe>())
                    {
                        if (userChoice == weapon.StoreID && player.Gold >= weapon.GoldValue)
                        {
                            Inventory.Add(weapon);
                            player.Gold -= weapon.GoldValue;
                            Console.Clear();
                            Console.WriteLine($"{weapon.Name} has been added to your inventory");
                            Console.ReadKey();
                        }

                        else if (userChoice == weapon.StoreID && player.Gold < weapon.GoldValue)
                        {
                            Console.Clear();
                            Console.WriteLine("You do not have enough gold. You can get gold by defeating monsters in adventure");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void PrintInventory()
        {
            foreach (Weapons weapon in Inventory)
            {
                Console.WriteLine($"{weapon.Name}");
                Console.WriteLine($"stats: {weapon.DamageBoost} damage increase\n");
            }
        }
    }
}
//Equip items to the get stats to character
//-Sort the Inventory by the Inventory ID
//-choose item to be moved to EquipInventory
//-EquipInventory List
//-This list can only hold 1 of each classType
//-Loop through all types in the EquipInventory list and add all the stats to player

//Unequip sends the item the user chooses back to inventory //have to choose item by InventoryID and sort by InventoryID
