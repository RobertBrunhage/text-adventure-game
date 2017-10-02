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
        //public int weaponID;
        //public int HelmetID;
        public bool run = false;

        public Player player = new Player();
        public Monster monster = new Monster();
        public Item weapons = new Item();

        public List<Item> Store { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Item> EquipInventory { get; set; }

        private string _mapName1 = "The glimting forest";
        private string _mapName2 = "The reversed forest";
        private string _mapName3 = "the black forest";
        private string _mapName4 = "Map 4";
        private string _mapName5 = "Map 5";
        private int sort = 0; // Print and buy method will use this variable
        private int mapComplete = 0;
        private bool gameOn = true;

        public MainMenu()
        {
            Inventory = new List<Item>();

            EquipInventory = new List<Item>();

            Store = new List<Item>()
            {
                //Swords
                new Sword("Vorpal Blade", 30, 1, 2),
                new Sword("Dragon Slayer", 70, 2, 3),
                new Sword("Sword of Judgment", 120, 2, 4),

                //Axes
                new Axe("Blight's Plight", 50, 2, 2),
                new Axe("The Grim Cleaver", 90, 2, 4),
                new Axe("Harbringer of Death", 150, 3, 5),

                //Maces
                new Mace("Skull Smasher", 30, 1, 2),
                new Mace("Blood Shedder", 100, 3, 4),
                new Mace("Harvester", 700, 10, 20),

                //Helmet
                new Helmet("Helm of protection", 40, 1, 1, 1),
                new Helmet("Helm of salvation", 60, 1, 1, 2)
            };
        }

        public void StartProgram()
        {
            int userChoice = 0;
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
                            //Introduction(); // Glöm inte speed på att den skriver ut
                            GameStart();
                            userChoice = 1;
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
            Console.WriteLine("There will be a total of 5 worlds. But you can not go to the second world right away, nononononoooo. You will have to find keys to open the portals " +
                "They are hidden in each world you will not find them right away. We really do not know what these keys do yet because no person has ever gotten even one!..Well good luck!");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("The town will look like this below\n");
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
            int userChoice = 0;
            do
            {
                if (player.Health <= 0)
                {
                    Tavern();
                }
                Console.Clear();
                player.PrintStats();

                Console.WriteLine("1. Adventure");
                Console.WriteLine("2. Store");
                Console.WriteLine("3. Inventory");
                Console.WriteLine("4. Equipped Items");
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
                            player.Gold = 1000; // cheat for testing
                            player.PrintStats();
                            ItemStore();
                            break;
                        case 3:
                            player.PrintStats();
                            PrintInventory();
                            break;
                        case 4:
                            player.PrintStats();
                            PrintEquippedInventory();
                            break;
                        case 5:
                            Tavern();
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
            } while (gameOn == true);
            Console.Clear();
        }

        public void Tavern()
        {
            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"Welcome {player.Name}! I will now begin restoring your HP. This will take about 10 sec. Please wait...");
            Thread.Sleep(10000);
            player.Health = player.MaxHealth;
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
                            if (mapComplete >= 0)
                            {
                                Map1();
                            }
                            break;
                        case 2:
                            if (mapComplete >= 1)
                            {
                                Map2();
                            }
                            break;
                        case 3:
                            if (mapComplete >= 2)
                            {
                                Map3();
                            }
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
            } while (userChoice < 1 || userChoice > 6);
            Console.Clear();
        }

        public void Map1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            monster.MonsterDif = 1;
            monster.ChooseMonster();
            int userChoice = 0;
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

                            CombatMonster();
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
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        if(monster.Health <= 0)
                                        {
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
                                        }
                                        Console.ResetColor();
                                        // Returning to menu

                                        mapComplete++;
                                        Console.Clear();
                                        Console.WriteLine($"You unlocked {_mapName2}");
                                        Console.ReadKey();
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

        public void Map2()
        {
            int userChoice = 0;

            string text;
            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"You have entered the portal to: {_mapName2}... This is a dark forest guarded by higher tier monsters. But what are they guarding you may ask? Well jesus I don't know " +
                $"you will have to find out! I won't be holding your hand the whole game...There are two roads the left road leads to an even darker side of the forest while the right leads to a lighter part. " +
                $"which way would you like to go?\n");
            Console.WriteLine("1. Through the left road");
            Console.WriteLine("2. Through the right road");
            do
            {
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            monster.MonsterDif = 1;
                            monster.ChooseMonster();
                            Console.WriteLine("What is that...? You can't be serious???");
                            Console.ReadKey();
                            Console.WriteLine($"A {monster.Name} has appeared...But this is a darker dark forest.");
                            Console.ReadKey();
                            Console.Clear();

                            CombatMonster();
                            if(monster.Health <= 0)
                            {
                                Console.Clear();
                                player.PrintStats();

                                Console.WriteLine("1. Adventure");
                                Console.WriteLine("2. Inventory");
                                Console.WriteLine("3. Store");
                                Console.WriteLine("4. Tavern");
                                text = "\nWell that was a bit boring right? You should probably go to the right next time...";
                                foreach (char c in text)
                                {
                                    Console.Write(c);
                                    Thread.Sleep(30);
                                }
                                Console.ReadKey();
                            }
                            // Returning to menu
                            break;
                        case 2:
                            monster.MonsterDif = 2;
                            monster.ChooseMonster();
                            do
                            {
                                Console.Clear();
                                player.PrintStats();
                                Console.WriteLine($"As you walk, the forest becomes more lit up for each step you take. Ohh look it's a happy little cow down the road!...But wait...It's running away " +
                                    $"from something... you can see a {monster.Name} chasing it. Do you want to save the cow?");
                                Console.WriteLine($"1. Save the cow and attack the {monster.Name}");
                                Console.WriteLine($"2. Run away like a coward");
                                if (int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    if (userChoice == 1)
                                    {
                                        CombatMonster();
                                        if (monster.Health <= 0)
                                        {
                                            text = "You saved the cow!! You must be damn proud of yourself!";
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
                                            text = "\nYou are probably more proud of defeating the monster then saving the cow...right?";
                                            foreach (char c in text)
                                            {
                                                Console.Write(c);
                                                Thread.Sleep(30);
                                            }
                                            Console.ReadKey();
                                        }
                                        // Returning to menu
                                        mapComplete++;
                                        Console.Clear();
                                        Console.WriteLine($"You unlocked {_mapName3}");
                                        Console.ReadKey();
                                    }
                                    else if (userChoice == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You walk back the road again, leaving the scared cow as you return to town...");
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

        public void Map3()
        {
            int userChoice = 0;
            monster.MonsterDif = 3;
            monster.ChooseMonster();

            string text;
            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"Wow you sure have come a long way if you are already here! No {player.Class} has even gotten this far... good job {player.Name}! " +
                $"This place is called {_mapName3} and the monsters here are stronger than the monsters from {_mapName1} and {_mapName2} combined! This forest though...Is really dark and I can't describe " +
                $"your options for where you can go so you will have to guess! \n");
            Console.WriteLine("1. Go forward");
            Console.WriteLine("2. Stay");
            do
            {
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                player.PrintStats();
                                Console.WriteLine($"As you walk forward you trip and a stone...careful it's dark I said... On the ground you notice that there is a big whole. Would you like to crawl " +
                                    $"in to the dark hole or jump over it?");
                                Console.WriteLine($"1. Crawl in to the dark hole");
                                Console.WriteLine($"2. Jump over the hole");
                                if (int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    if (userChoice == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"A {monster.Name} was sleeping inside the whole and woke up as you crawled. It saw you and went for attack");
                                        Console.ReadKey();

                                        CombatMonster();
                                        if (monster.Health <= 0)
                                        {
                                            text = $"You slayed the {monster.Name} though this was a magical bear you got teleported back to town...";
                                            foreach (char c in text)
                                            {
                                                Console.Write(c);
                                                Thread.Sleep(30);
                                            }
                                            Console.ReadKey();
                                            mapComplete++;
                                        }
                                    }
                                    else if (userChoice == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"You jumped over the whole but there was a {monster.Name} running towards you!");
                                        Console.ReadKey();
                                        CombatMonster();
                                        if(monster.Health <= 0)
                                        {
                                            Console.WriteLine($"After the fight with the {monster.Name} you see another portal and as you head through it you come back to town...");

                                            Console.ReadKey();
                                        }
                                        // Returning to menu
                                        //mapComplete++;
                                        //Console.Clear();
                                        //Console.WriteLine($"You unlocked {_mapName3}");
                                        //Console.ReadKey();
                                    }
                                    break;
                                }
                            } while (userChoice < 1 || userChoice > 2);
                            break;
                        case 2:
                            Console.WriteLine("What is that...?");
                            Console.ReadKey();
                            Console.WriteLine($"A {monster.Name} has appeared...");
                            Console.ReadKey();
                            Console.Clear();

                            CombatMonster();
                            if(run == false)
                            {
                                Console.Clear();
                                player.PrintStats();

                                Console.WriteLine("1. Adventure");
                                Console.WriteLine("2. Inventory");
                                Console.WriteLine("3. Store");
                                Console.WriteLine("4. Tavern");
                                text = "\nWell that was a bit boring right? Next time try to go forward instead of just standing there... This is an adventure and a stayventure... HAHAHAH... Okay I will stop";
                                foreach (char c in text)
                                {
                                    Console.Write(c);
                                    Thread.Sleep(30);
                                }
                                Console.ReadKey();

                            }
                            run = false;
                            // Returning to menu
                            break;
                    }
                }
            } while ((userChoice < 1 || userChoice > 2));
        }

        void CombatMonster()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int userChoice = 0;
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
                            int playerDamage = rndPlayerDamage.Next(player.LowestDamage, player.HigestDamage + 1);
                            int monsterDamage = rndMonsterDamage.Next(monster.MinDamage, monster.MaxDamage + 1);

                            monster.Health -= playerDamage;
                            Console.WriteLine($"\nYou did {playerDamage} damage on the monster");
                            player.Health -= monsterDamage;
                            Console.WriteLine($"The monster did {monsterDamage} damage on you");
                            Console.ReadKey();
                            break;
                        case 2:
                            run = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (monster.Health > 0 && player.Health > 0 && run == false);
            Console.Clear();
            Console.ResetColor();
            if (monster.Health <= 0)
            {
                int monsterGold = rndMonsterGold.Next(monster.MinGold, monster.MaxGold + 1);
                Console.WriteLine("Monster has been defeated!");
                Console.WriteLine($"You have been awarded {monsterGold} gold");
                player.Gold += monsterGold;
                Console.ReadKey();
                Console.Clear();
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine("You have died");
                player.Health = 0;
                Console.ReadKey();
                Console.Clear();
                // Returning to menu
            }
            else if (userChoice == 2)
            {
                Console.WriteLine("You will now be returned to the menu");
                Console.ReadKey();
                Console.Clear();
                // Returning to menu
            }
        }

        public void ItemStore()
        {
            int userChoice = 0;
            //WeaponType weaponType;

            Console.WriteLine("Weapons: \n");
            Console.WriteLine("1. Swords");
            Console.WriteLine("2. Axes");
            Console.WriteLine("3. Maces\n");

            Console.WriteLine("Armour\n");
            Console.WriteLine("4. Helmet");

            do
            {
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            Console.Clear();
                            player.PrintStats();
                            sort = 1;
                            PrintWeapons();
                            BuyWeapons();
                            break;
                        case 2:
                            Console.Clear();
                            player.PrintStats();
                            sort = 2;
                            PrintWeapons();
                            BuyWeapons();
                            break;
                        case 3:
                            Console.Clear();
                            player.PrintStats();
                            sort = 3;
                            PrintWeapons();
                            BuyWeapons();
                            break;
                        case 4:
                            Console.Clear();
                            player.PrintStats();
                            sort = 4;
                            PrintWeapons();
                            BuyWeapons();
                            break;
                        default:
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 4);
        }

        public void PrintWeapons()
        {
            string type = string.Empty;
            var StoreCopy = Store.Where(m => m.Type.ToLower() == type.ToLower());
            switch (sort)
            {
                case 1:
                    type = "Sword";
                    StoreCopy = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 2:
                    type = "Axe";
                    StoreCopy = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 3:
                    type = "Mace";
                    StoreCopy = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 4:
                    type = "Helmet";
                    StoreCopy = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 5:
                    break;
                default:
                    break;

            }
            int iD = 1;

            foreach (Item item in StoreCopy)
            {
                item.StoreID = iD;
                Console.WriteLine($"{item.StoreID}. {item.Name}");
                Console.WriteLine($"Price: {item.GoldValue} gold");
                if (item.LowDamageBoost >= 1 && item.HighDamageBoost >= 1)
                {
                    Console.WriteLine($"Damage: {item.LowDamageBoost} - {item.HighDamageBoost} damage increase");
                }
                if (item.Armour > 0)
                {
                    Console.WriteLine($"Armour: {item.Armour}");
                }
                Console.WriteLine();
                iD++;
            }
            
        }

        public void BuyWeapons()
        {
            int userChoice = 0;

            string type = string.Empty;
            var SortedStore = Store.Where(m => m.Type == type);
            switch (sort)
            {
                case 1:
                    type = "Sword";
                    SortedStore = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 2:
                    type = "Axe";
                    SortedStore = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 3:
                    type = "Mace";
                    SortedStore = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 4:
                    type = "Helmet";
                    SortedStore = Store.Where(m => m.Type.ToLower() == type.ToLower());
                    break;
                case 5:
                    break;
                default:
                    break;

            }
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item item in SortedStore)
                {
                    if (userChoice == item.StoreID && player.Gold >= item.GoldValue)
                    {
                        if (Inventory.Contains(item))
                        {
                            Console.Clear();
                            Console.WriteLine("You already have this item in your inventory");
                            Console.ReadKey();
                        }
                        else if (EquipInventory.Contains(item))
                        {
                            Console.Clear();
                            Console.WriteLine("You already have this item equipped");
                            Console.ReadKey();
                        }
                        else
                        {
                            Inventory.Add(item);
                            player.Gold -= item.GoldValue;
                            Console.Clear();
                            Console.WriteLine($"{item.Name} has been added to your inventory");
                            Console.ReadKey();
                        }
                    }
                    else if (userChoice == item.StoreID && player.Gold < item.GoldValue)
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold. You can get gold by defeating monsters in adventure");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Returning to town...");
                Console.ReadKey();
            }
        }

        public void PrintInventory()
        {
            var sortedInventoryByName = Inventory.OrderBy(x => x.Name);
            int userChoice = 0;
            int iD = 1;
            Console.WriteLine("Inventory         To equip an item press the key that correspons with the item\n");
            foreach (Item item in sortedInventoryByName)
            {
                item.InventoryID = iD;
                Console.WriteLine($"{item.InventoryID}. {item.Name}");
                Console.WriteLine($"Price: {item.GoldValue} gold");
                if (item.LowDamageBoost >= 1 && item.HighDamageBoost >= 1)
                {
                    Console.WriteLine($"Damage: {item.LowDamageBoost} - {item.HighDamageBoost} damage increase");
                }
                if(item.Armour > 0)
                {
                    Console.WriteLine($"Armour: {item.Armour}");
                }
                Console.WriteLine();
                iD++;
            }
            Console.WriteLine("Type number of item to equipp or press enter to search for item type\n");
            if(int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item item in Inventory)
                {
                    if (userChoice == item.InventoryID)
                    {
                        //weaponID = item.SlotID;
                        EquipInventory.Add(item);
                        player.LowestDamage += item.LowDamageBoost;
                        player.HigestDamage += item.HighDamageBoost;
                        player.Armour += item.Armour;
                        Inventory.Remove(item);
                        Console.Clear();
                        Console.WriteLine($"{item.Name} has been equipped");
                        //Console.ReadKey();
                        break;
                    }
                    //else if(weaponID == 1)
                    //{
                    //    Console.Clear();
                    //    Console.WriteLine("You already have a weapon equipped. Enter Equipped items to remove it");
                    //    Console.ReadKey();
                    //}
                }
                //Loop through armour and equip etc
            }
            else
            {
                iD = 1;
                Console.WriteLine("Search for a weapon / armour type you would like to find. Ex Sword or Helmet");
                string type = Console.ReadLine();
                var Name = Inventory.Where(m => m.Type.ToLower() == type.ToLower());
                Console.Clear();
                player.PrintStats();
                if (Name.Any())
                {
                    foreach (Item item in Name)
                    {
                        item.InventoryID = iD;
                        Console.WriteLine($"{item.StoreID}. {item.Name}");
                        Console.WriteLine($"Price: {item.GoldValue} gold");
                        if (item.LowDamageBoost >= 1 && item.HighDamageBoost >= 1)
                        {
                            Console.WriteLine($"Damage: {item.LowDamageBoost} - {item.HighDamageBoost} damage increase");
                        }
                        if (item.Armour > 0)
                        {
                            Console.WriteLine($"Armour: {item.Armour}\n");
                        }
                        iD++;
                    }
                }
            }

            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item item in Inventory)
                {
                    if (userChoice == item.InventoryID)
                    {
                        //weaponID = item.SlotID;
                        EquipInventory.Add(item);
                        player.LowestDamage += item.LowDamageBoost;
                        player.HigestDamage += item.HighDamageBoost;
                        Inventory.Remove(item);
                        Console.Clear();
                        Console.WriteLine($"{item.Name} has been equipped");
                        Console.ReadKey();
                        break;
                    }
                    //else if (weaponID == 1)
                    //{
                    //    Console.Clear();
                    //    Console.WriteLine($"You already have a weapon equipped. Enter Equipped items to remove it");
                    //    Console.ReadKey();
                    //}
                }
                //Loop through armour and equip etc
            }
        }

        public void PrintEquippedInventory()
        {
            var sortedInventoryByName = EquipInventory.OrderBy(x => x.Name);
            int userChoice = 0;
            int iD = 1;
            Console.WriteLine("Inventory         To unequip an item press the key that correspons with the item\n");
            foreach (Item weapon in sortedInventoryByName)
            {
                weapon.InventoryID = iD;
                Console.WriteLine($"{weapon.InventoryID}. {weapon.Name}");
                Console.WriteLine($"stats: {weapon.LowDamageBoost} damage increase\n");
                iD++;
            }
            Console.WriteLine("Type number of item to unequipp or press enter to search for item type\n");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item item in EquipInventory)
                {
                    if (userChoice == item.InventoryID)
                    {
                        //weaponID = 0;
                        EquipInventory.Remove(item);
                        player.LowestDamage -= item.LowDamageBoost;
                        player.HigestDamage -= item.HighDamageBoost;
                        player.Armour -= item.Armour;
                        Inventory.Add(item);
                        Console.Clear();
                        Console.WriteLine($"{item.Name} has been unequipped");
                        break;
                    }
                }
            }
            else
            {
                iD = 1;
                Console.WriteLine("Search for a weapon / armour type you would like to find. Ex Sword");
                string type = Console.ReadLine();
                var Name = EquipInventory.Where(m => m.Type.ToLower() == type.ToLower());
                Console.Clear();
                player.PrintStats();
                if (Name.Any())
                {
                    foreach (Item weapon in Name)
                    {
                        weapon.InventoryID = iD;
                        Console.WriteLine($"{weapon.InventoryID}. {weapon.Name}");
                        Console.WriteLine($"stats: {weapon.LowDamageBoost} damage increase\n");
                        iD++;
                    }
                }
            }

            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item weapon in EquipInventory)
                {
                    if (userChoice == weapon.InventoryID)
                    {
                        //weaponID = 0;
                        EquipInventory.Remove(weapon);
                        player.LowestDamage -= weapon.LowDamageBoost;
                        player.HigestDamage -= weapon.HighDamageBoost;
                        Inventory.Add(weapon);
                        Console.Clear();
                        Console.WriteLine($"{weapon.Name} has been unequipped");
                        Console.ReadKey();
                        break;
                    }
                }
                //Loop through armour and equip etc
            }
        }
    }
}

