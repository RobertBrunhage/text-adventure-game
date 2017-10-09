using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace text_adventure_game.Models
{
    class MainMenu
    {
        #region Private Variables
        //Used to see what items are equipped

        //Name of adventure maps
        private string _mapName1 = "The glimting forest";
        private string _mapName2 = "The reversed forest";
        private string _mapName3 = "the black forest";
        private string _mapName4 = "The mysterious castle";

        private int _sort = 0; // Print and buy method will use this variable for sorting items
        private int _mapComplete = 0; //Enables us to only play the map we are supposed to untill we finish all maps
        private bool _gameOn = true;

        private SoundPlayer _menuLoopSound = new SoundPlayer(text_adventure_game.Properties.Resources.MenuLoop);
        private SoundPlayer _map1Sound = new SoundPlayer(text_adventure_game.Properties.Resources.Map1);
        private SoundPlayer _map2Sound = new SoundPlayer(text_adventure_game.Properties.Resources.Map2);
        private SoundPlayer _map3Sound = new SoundPlayer(text_adventure_game.Properties.Resources.Map3);
        private SoundPlayer _map4Sound = new SoundPlayer(text_adventure_game.Properties.Resources.Map4);
        private SoundPlayer _combatSound = new SoundPlayer(text_adventure_game.Properties.Resources.CombatSound);

        private bool _menuLoopOn = false;

        //Prints different text in adventure 
        private bool _run = false;
        private bool _bossDefeated = false;
        #endregion

        private Player player = new Player();
        private Monster monster = new Monster();
        private Item weapons = new Item();

        public List<Item> Store { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Item> EquipInventory { get; set; }

        public MainMenu()
        {
            Inventory = new List<Item>();

            EquipInventory = new List<Item>();

            Store = new List<Item>()
            {
                //Swords
                new Weapon("Sword", 1, "Vorpal Blade", 5, 2, 2),
                new Weapon("Sword", 1, "Dragon Slayer", 25, 4, 4),
                new Weapon("Sword", 1, "Sword of Judgment", 70, 7, 7),

                //Axes
                new Weapon("Axe", 1, "Blight's Plight", 10, 2, 3),
                new Weapon("Axe", 1, "The Grim Cleaver", 75, 7, 8),
                new Weapon("Axe", 1, "Harbringer of Death", 150, 9, 16),

                //Maces
                new Weapon("Mace", 1, "Skull Smasher", 15, 3, 3),
                new Weapon("Mace", 1, "Blood Shedder", 35, 5, 5),
                new Weapon("Mace", 1, "Harvester", 700, 30, 30),

                //Staff
                new Weapon("Staff", 1, "Staff of tree", 300, 10, 20),

                //Helmet
                new Armour("Helmet", 2, "Helm of protection", 30, 1, 1, 10, 10),
                new Armour("Helmet", 2, "Helm of salvation", 60, 2, 2, 40, 25),

                //Chestplate
                new Armour("Chestplate", 3, "Chest of survival", 20, 1, 2, 20, 10),
                new Armour("Chestplate", 3, "Chest of doom", 40, 2, 2, 30, 20),

                //Pants
                new Armour("Pants", 4, "Pants of protection", 15, 1, 1, 10, 10),

                //Gloves
                new Armour("Gloves", 5, "Glove of swiftness", 20, 1, 1, 10, 10)
            };
        }

        public void StartProgram()
        {
            int userChoice = 0;
            do
            {
                _menuLoopSound.PlayLooping();
                _menuLoopOn = true;
                Console.Clear();
                Console.WriteLine(@" _______     _                                                     ___    ______ _             _ _     ");
                Console.WriteLine(@"(_______)   | |                   _                               / __)  (_____ (_)           | ( )    ");
                Console.WriteLine(@" _______  __| |_   _ _____ ____ _| |_ _   _  ____ _____     ___ _| |__    _____) ) _   _ _____| |/ ___ ");
                Console.WriteLine(@"|  ___  |/ _  | | | | ___ |  _ (_   _) | | |/ ___) ___ |   / _ (_   __)  |  ____/ ( \ / ) ___ | | /___)");
                Console.WriteLine(@"| |   | ( (_| |\ V /| ____| | | || |_| |_| | |   | ____|  | |_| || |     | |    | |) X (| ____| ||___ |");
                Console.WriteLine(@"|_|   |_|\____| \_/ |_____)_| |_| \__)____/|_|   |_____)   \___/ |_|     |_|    |_(_/ \_)_____)\_|___/ ");
                Console.WriteLine(@"                                                                                                       ");
                    
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Exit Game");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            
                            player.AskGender();
                            player.AskClass();
                            player.AskAge();
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
            } while (userChoice < 1 || userChoice > 2);

        } // Player Creation

        public void Introduction()
        {
            //Introduction
            Console.WriteLine($"Welcome to the world of Adventure of Pixel's. \nIn this world there is all kinds of magical and explorious adventures. " +
                $"\nYou as a {player.Class} will now be guided by the creator (me....IT's A ME....MARIO). \nAll jokes aside let us begin your adventure, {player.Name}. \n");

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("There will be a total of 4 worlds. You can not go to the second world right away, nononononoooo. \nYou will have to find keys to open the portals. " +
                "They are hidden in each world and you will not find them right away. \nWe really do not know what these keys do yet because no person has ever gotten even one!..Well good luck!");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("The town will look like this below\n");
            Console.WriteLine("1. Adventure");
            Console.WriteLine("2. Store");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("4. Equipped Items");
            Console.WriteLine("5. Tavern");
            Console.WriteLine("6. Exit Game\n");
            Console.WriteLine("Simple right? well I won't bore you with this so it's up to you to start your adventure!\nPress any key so you can go to the town!");
            Console.ReadKey();
        }

        public void GameStart() //Returning here all the time
        {     

            //Main Menu
            int userChoice = 0;
            do
            {
                if (_menuLoopOn == false)
                {
                    _menuLoopSound.PlayLooping();
                    _menuLoopOn = true;
                }
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
                            //player.Gold = 1000;
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
                            _gameOn = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"{player.Name}, to the left of each word you can see a number. Enter the number for where you want to go.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (_gameOn == true);
            Console.Clear();
        }

        public void Tavern()
        {
            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"Welcome {player.Name}! I will now begin restoring your HP and Armour. This will take about 3 sec. Please wait...");
            Thread.Sleep(3000);
            player.Health = player.MaxHealthFromItems;
            player.Armour = player.MaxArmour;
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
                Console.WriteLine($"5. Go back to menu");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            if (_mapComplete >= 0)
                            {
                                Map1();
                            }
                            break;
                        case 2:
                            if (_mapComplete >= 1)
                            {
                                Map2();
                            }
                            //Map2();
                            break;
                        case 3:
                            if (_mapComplete >= 2)
                            {
                                Map3();
                            }
                            break;
                        case 4:
                            if(_mapComplete >= 3)
                            {
                                Map4();
                            }
                            break;
                        case 5:
                            //returning to menu
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"{player.Name}, to the left of each word you can see a number. Enter the number for where you want to go.");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userChoice < 1 || userChoice > 5);
            Console.Clear();
        }

        public void Map1()
        {
            _menuLoopSound.Stop();
            _menuLoopOn = false;
            _map1Sound.PlayLooping();

            Console.ForegroundColor = ConsoleColor.Green;
            monster.MonsterDif = 1;
            monster.ChooseMonster();
            int userChoice = 0;

            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"You have entered the portal to: {_mapName1}... It's a vast world, you can see the wind blowing through the trees... \nBut what is that! Something sparkled in the bushes.. \nAnd you can hear a sound coming from the left...\n");
            Console.WriteLine($"Would you like to go to the bushes, or follow the sound?\n");
            Console.WriteLine("1. To the bushes");
            Console.WriteLine("2. Follow the sound");
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
                            _map1Sound.PlayLooping();

                            Console.Clear();
                            Console.WriteLine("Returning to town");
                            Console.ReadKey();
                            // Returning to menu
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                player.PrintStats();
                                Console.WriteLine($"You walk slowly to the sound, trying to hide as much as possible but you see a {monster.Name}... \ndo you wish to attack or run back to the town?");
                                Console.WriteLine($"1. Attack the {monster.Name}");
                                Console.WriteLine($"2. Run back to town");
                                if (int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    if (userChoice == 1)
                                    {
                                        CombatMonster();
                                        _map1Sound.PlayLooping();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        if(monster.Health <= 0 && _bossDefeated == false)
                                        {
                                            Console.WriteLine("A huge monster appeared that you are not able to fight. \nYou run back as fast as you can and through the portal again...");

                                            Console.ReadKey();
                                            Console.Clear();
                                            Console.ResetColor();
                                            player.PrintStats();

                                            Console.WriteLine("1. Adventure");
                                            Console.WriteLine("2. Store");
                                            Console.WriteLine("3. Inventory");
                                            Console.WriteLine("4. Equipped Items");
                                            Console.WriteLine("5. Tavern");
                                            Console.WriteLine("6. Exit Game\n");
                                            Console.WriteLine("\nWhat was that...?");

                                            Console.ReadKey();
                                        }
                                        // Returning to menu
                                        if(_mapComplete == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            _mapComplete = 1;
                                            Console.Clear();
                                            Console.WriteLine($"You unlocked {_mapName2} and found the first key!");
                                            Console.ReadKey();
                                        }

                                    }
                                    else if (userChoice == 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Clear();
                                        Console.WriteLine("You see a big rock, running as fast as you can. \nYou hide and wait...." +
                                            "You can see the portal that goes back to town and you make a run for it. \nJust as the monster was about to attack you jump through the portal");
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
            Console.ResetColor();
            _map1Sound.Stop();

        }

        public void Map2()
        {
            _menuLoopSound.Stop();
            _menuLoopOn = false;
            _map2Sound.PlayLooping();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int userChoice = 0;

            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"You have entered the portal to: {_mapName2}... \nThis is a weird forest that is guarded by higher tier monsters. But what are they guarding you may ask? \nWell jesus I don't know... " +
                $"You will have to find out! I won't be holding your hand the whole game...\n\nThere are two roads the left road leads to a dark side of the forest while the right leads to a lighter part. \n" +
                $"Which way would you like to go?\n");
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
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("What is that...? You can't be serious???");
                            Console.ReadKey();
                            Console.WriteLine($"A {monster.Name} has appeared...But this is a was supposed to be the dark part of the forest...");
                            Console.ReadKey();
                            Console.Clear();

                            CombatMonster();
                            _map2Sound.PlayLooping();
                            if (monster.Health <= 0 && player.Health > 0)
                            {
                                Console.ResetColor();
                                Console.Clear();
                                player.PrintStats();

                                Console.WriteLine("1. Adventure");
                                Console.WriteLine("2. Store");
                                Console.WriteLine("3. Inventory");
                                Console.WriteLine("4. Equipped Items");
                                Console.WriteLine("5. Tavern");
                                Console.WriteLine("6. Exit Game\n");
                                Console.WriteLine("\nWell that was a bit boring right? You should probably go to the right next time...");

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
                                Console.WriteLine($"As you walk, the forest becomes more lit up for each step you take. \nOhh look it's a happy little cow down the road!...But wait...It's running away " +
                                    $"from something... \nYou can see a {monster.Name} chasing it. Do you want to save the cow?");
                                Console.WriteLine($"1. Save the cow and attack the {monster.Name}");
                                Console.WriteLine($"2. Run away like a coward");
                                if (int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    if (userChoice == 1)
                                    {
                                        CombatMonster();
                                        _map2Sound.PlayLooping();
                                        if (monster.Health <= 0)
                                        {
                                            Console.WriteLine("You saved the cow!! You must be damn proud of yourself!");

                                            Console.ReadKey();
                                            Console.Clear();
                                            player.PrintStats();

                                            Console.WriteLine("1. Adventure");
                                            Console.WriteLine("2. Store");
                                            Console.WriteLine("3. Inventory");
                                            Console.WriteLine("4. Equipped Items");
                                            Console.WriteLine("5. Tavern");
                                            Console.WriteLine("6. Exit Game\n");
                                            Console.WriteLine("\nYou are probably more proud of defeating the monster then saving the cow...right?");

                                            Console.ReadKey();
                                            if(_mapComplete == 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                _mapComplete = 2;
                                                Console.Clear();
                                                Console.WriteLine($"You unlocked {_mapName3} and found the second key!");
                                                Console.ReadKey();
                                            }
                                        }
                                        // Returning to menu
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
            Console.ResetColor();
            _map2Sound.Stop();
        }

        public void Map3()
        {
            _menuLoopSound.Stop();
            _menuLoopOn = false;
            _map3Sound.PlayLooping();

            Console.ForegroundColor = ConsoleColor.Magenta;
            int userChoice = 0;
            monster.MonsterDif = 3;
            monster.ChooseMonster();

            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"Wow you sure have come a long way if you are already here! \nNo {player.Class} has even gotten this far... Good job {player.Name}! " +
                $"\nThis place is called {_mapName3} and the monsters here are stronger than the monsters from {_mapName1} and {_mapName2}! \nThis forest though...Is really dark and I can't describe " +
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
                                Console.WriteLine($"As you walk forward you trip and a stone...careful it's dark I said... \nOn the ground you notice that there is a big hole. Would you like to crawl " +
                                    $"in to the dark hole or jump over it?");
                                Console.WriteLine($"1. Crawl in to the dark hole");
                                Console.WriteLine($"2. Jump over the hole");
                                if (int.TryParse(Console.ReadLine(), out userChoice))
                                {
                                    if (userChoice == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"A {monster.Name} was sleeping inside the hole and it woke up as you crawled. It saw you and went for attack");
                                        Console.ReadKey();

                                        CombatMonster();
                                        _map3Sound.PlayLooping();
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        if (monster.Health <= 0)
                                        {
                                            Console.WriteLine($"You slayed the {monster.Name} though this was a magical bear you got teleported back to town...");

                                            Console.ReadKey();
                                            if(_mapComplete == 2)
                                            {
                                                _mapComplete = 3;
                                                Console.Clear();
                                                Console.WriteLine($"You have completed {_mapName3} and found the last key!");
                                                Console.ReadKey();
                                            }

                                        }
                                    }
                                    else if (userChoice == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"You jumped over the hole but there was a {monster.Name} running towards you!");
                                        Console.ReadKey();
                                        CombatMonster();
                                        _map3Sound.PlayLooping();
                                        Console.ForegroundColor = ConsoleColor.Magenta;

                                        if (monster.Health <= 0)
                                        {
                                            Console.WriteLine($"After the fight with the {monster.Name} you see another portal and as you head through it you come back to town...No key here");

                                            Console.ReadKey();
                                        }
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
                            _map3Sound.PlayLooping();
                            Console.ResetColor();
                            if (_run == false && player.Health > 0)
                            {
                                Console.Clear();
                                player.PrintStats();

                                Console.WriteLine("1. Adventure");
                                Console.WriteLine("2. Store");
                                Console.WriteLine("3. Inventory");
                                Console.WriteLine("4. Equipped Items");
                                Console.WriteLine("5. Tavern");
                                Console.WriteLine("6. Exit Game\n");
                                Console.WriteLine("\nWell that was a bit boring right? Next time try to go forward instead of just standing there... \nThis is an adventure and a stayventure... HAHAHAH... Okay I will stop. But srsly no key");

                                Console.ReadKey();

                            }
                            _run = false;
                            // Returning to menu
                            break;
                    }
                }
            } while ((userChoice < 1 || userChoice > 2));
            Console.ResetColor();
            _map3Sound.Stop();
        }

        public void Map4()
        {
            _menuLoopSound.Stop();
            _menuLoopOn = false;
            _map4Sound.PlayLooping();

            Console.ForegroundColor = ConsoleColor.Yellow;
            int userChoice = 0;
            monster.MonsterDif = 4;
            monster.ChooseMonster();

            Console.Clear();
            player.PrintStats();
            Console.WriteLine($"You have entered the {_mapName4}. Now you can finally understand what the keys you have gathered are supposed to do! \nYou see a huge castle with a big door. On the door there are 3 key holes..." +
                $" \nDo you want to try to slam your way in or use the keys?\n");
            Console.WriteLine("1. Use the keys");
            Console.WriteLine("2. Slam the door");
            do
            {
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            
                            monster.MonsterDif = 4;
                            monster.ChooseMonster();
                            Console.Clear();
                            player.PrintStats();
                            Console.WriteLine($"As the door opens a {monster.Name} appears!");
                            Console.ReadKey();
                            CombatMonster();
                            _map4Sound.PlayLooping();
                            if (_run == false && player.Health > 0)
                            {
                                monster.MonsterDif = 5;
                                monster.ChooseMonster();
                                Console.WriteLine($"You are fatigued but you keep going forward and then up the long staircase...\nThere is a another big door but a strong {monster.Name} defends it you run towards it to attack!");
                                Console.ReadKey();
                                CombatMonster();
                                _map4Sound.PlayLooping();
                            }

                            if (_run == false && player.Health > 0)
                            {
                                if (_bossDefeated == false)
                                {
                                    Console.WriteLine($"Now there is no going back... You go forward to the door and opened it! \nIt's the monster from {_mapName1} that were chasing you! You can see that it guards something... " +
                                    $"\nThe monster saw you and runs towards you!");
                                    Console.ReadKey();
                                    monster.MonsterDif = 6;
                                    monster.ChooseMonster();
                                    CombatMonster();
                                    _map4Sound.PlayLooping();

                                    if (_run == false && monster.Health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Hey it's me again...the creater...\n " +
                                            $"Pretty cool that you actually defeated {monster.Name}. \nThe dragon defended a great treasure and that is the treasure of " +
                                            $"Sucess! \nYou may now feel awesome and cool because you have defeated the danger that once was here. \nThanks for playing the game the world is now at peace");
                                        _bossDefeated = true;
                                        Console.ReadKey();
                                    }
                                    if (player.Health <= 0 && monster.Health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Wow you actually killed each other though.. Pretty rare. Happily for you I can revive you, \ncya at the tavern!");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("There is nothing here. You have already defeated the boss");
                                    Console.ReadKey();
                                }
                            }
                            break;
                        case 2:
                            Random rndMonster = new Random();
                            Console.Clear();
                            Console.WriteLine("You try to slam the door but it only atracts low level monster from around the castle...Be prepered!");
                            Console.ReadKey();
                            monster.MonsterDif = rndMonster.Next(1, 4);
                            monster.ChooseMonster();
                            CombatMonster();
                            _map4Sound.PlayLooping();

                            while (_run == false && player.Health > 0)
                            {
                                monster.MonsterDif = rndMonster.Next(1, 4);
                                monster.ChooseMonster();
                                Console.Clear();
                                switch (monster.MonsterDif)
                                {
                                    case 1:
                                        Console.WriteLine("It's more coming!!!");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.WriteLine("It just keeps coming more");
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.WriteLine("This one is pretty strong");
                                        Console.ReadKey();
                                        break;
                                    default:
                                        break;
                                }
                                CombatMonster();
                            }
                            _run = false;
                            break;
                    }
                }
            } while ((userChoice < 1 || userChoice > 2));
            Console.ResetColor();
            _map4Sound.Stop();
        }

        void CombatMonster()
        {
            _combatSound.PlayLooping();
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

                            monster.TakeDamage(playerDamage);
                            Console.WriteLine($"\nYou did {playerDamage} damage on the monster");
                            player.TakeDamage(monsterDamage);
                            Console.WriteLine($"The monster did {monsterDamage} damage on you");
                            Console.ReadKey();
                            break;
                        case 2:
                            if(player.HigestDamage > monster.MaxDamage)
                            {
                                _run = true;
                            }
                            else
                            {
                                Console.WriteLine($"You can't run from {monster.Name} you need more damage");
                                Console.ReadKey();
                            }
                            break;
                        default:
                            break;
                    }
                }
            } while (monster.Health > 0 && player.Health > 0 && _run == false);
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
            if (player.Health <= 0)
            {
                Console.WriteLine("You have died");
                player.Health = 0;
                Console.ReadKey();
                Console.Clear();
                // Returning to menu
            }
            else if (_run == true)
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
            bool exitStore = false;

            do
            {
                Console.Clear();
                player.PrintStats();
                Console.WriteLine("Weapons: \n");
                Console.WriteLine("1. Swords");
                Console.WriteLine("2. Axes");
                Console.WriteLine("3. Maces");
                Console.WriteLine("4. Staff\n");

                Console.WriteLine("Armour\n");
                Console.WriteLine("5. Helmet");
                Console.WriteLine("6. Checkplate");
                Console.WriteLine("7. Pants");
                Console.WriteLine("8. Gloves");
                Console.WriteLine("9. Exit Store");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            _sort = 1;
                            PrintItems();
                            BuyItems();
                            break;
                        case 2:
                            _sort = 2;
                            PrintItems();
                            BuyItems();
                            break;
                        case 3:
                            _sort = 3;
                            PrintItems();
                            BuyItems();
                            break;
                        case 4:
                            _sort = 4;
                            PrintItems();
                            BuyItems();
                            break;
                        case 5:
                            _sort = 5;
                            PrintItems();
                            BuyItems();
                            break;
                        case 6:
                            _sort = 6;
                            PrintItems();
                            BuyItems();
                            break;
                        case 7:
                            _sort = 7;
                            PrintItems();
                            BuyItems();
                            break;
                        case 8:
                            _sort = 8;
                            PrintItems();
                            BuyItems();
                            break;
                        case 0:
                            exitStore = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (exitStore == false);
        }

        public void PrintItems()
        {
            Console.Clear();
            player.PrintStats();

            string type = string.Empty;
            var SortedStoreByType = Store.Where(m => m.Type.ToLower() == type.ToLower()); // No items will be displayed
            switch (_sort)
            {
                case 1:
                    type = "Sword";
                    break;
                case 2:
                    type = "Axe";
                    break;
                case 3:
                    type = "Mace";
                    break;
                case 4:
                    type = "Staff";
                    break;
                case 5:
                    type = "Helmet";
                    break;
                case 6:
                    type = "Chestplate";
                    break;
                case 7:
                    type = "Pants";
                    break;
                case 8:
                    type = "Gloves";
                    break;
                default:
                    break;

            }
            SortedStoreByType = Store.Where(m => m.Type.ToLower() == type.ToLower()); // Sorts out all the other items that are not the wanted type

            int iD = 1;
            foreach (Item item in SortedStoreByType)
            {
                item.ID = iD;
                Console.WriteLine($"{item.ID}. {item.Type}");
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"Price: {item.GoldValue} gold");
                if (item.HealthIncrease > 0)
                {
                    Console.WriteLine($"Health: {item.HealthIncrease} increase");
                }
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

        public void BuyItems()
        {
            int userChoice = 0;

            string type = string.Empty;
            var SortedStore = Store.Where(m => m.Type == type);
            switch (_sort)
            {
                case 1:
                    type = "Sword";                  
                    break;
                case 2:
                    type = "Axe";                   
                    break;
                case 3:
                    type = "Mace";                  
                    break;
                case 4:
                    type = "Staff";                  
                    break;
                case 5:
                    type = "Helmet";              
                    break;
                case 6:
                    type = "Chestplate";
                    break;
                case 7:
                    type = "Pants";
                    break;
                case 8:
                    type = "Gloves";
                    break;
                default:
                    break;

            }
            SortedStore = Store.Where(m => m.Type.ToLower() == type.ToLower());
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item item in SortedStore)
                {
                    if (userChoice == item.ID && player.Gold >= item.GoldValue)
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
                    else if (userChoice == item.ID && player.Gold < item.GoldValue)
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have enough gold. You can get gold by defeating monsters in adventure");
                        Console.ReadKey();
                    }
                }
            }
        }

        public void PrintInventory()
        {
            var sortedInventoryByName = Inventory.OrderBy(x => x.EquippedSlotID);
            int userChoice = 0;
            int iD = 1;
            Console.WriteLine($"Greetings {player.Name}!");
            Console.WriteLine("Inventory         To equip an item press the key that correspons with the item\n");
            foreach (Item item in sortedInventoryByName) //Print out all the items in the inventory
            {
                item.ID = iD;
                Console.WriteLine($"{item.ID}. {item.Type}");
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"Price: {item.GoldValue} gold");
                if (item.HealthIncrease > 0)
                {
                    Console.WriteLine($"Health: {item.HealthIncrease} increase");
                }
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

            Console.WriteLine("Type number of item to equip\n");
            if(int.TryParse(Console.ReadLine(), out userChoice)) //If I pick an item add it to equipInventory and add stats
            {
                foreach (Item item in Inventory)
                {
                    if (userChoice == item.ID)
                    {
                        player.PrintStats();
                        Console.Clear();
                        Console.WriteLine($"1. Equip Item");
                        Console.WriteLine($"2. Sell item for half price: {item.GoldValue / 2} gold");
                        if (int.TryParse(Console.ReadLine(), out userChoice))
                        {
                            if(userChoice == 1)
                            {
                                if (!IsEquipped("Sword") && !IsEquipped("Axe") && !IsEquipped("Mace") && !IsEquipped("Staff") && item.EquippedSlotID == 1)
                                {
                                    item.Equipped = true;
                                }
                                else if (!IsEquipped("Helmet") && item.EquippedSlotID == 2)
                                {
                                    item.Equipped = true;
                                }
                                else if (!IsEquipped("Chestplate") && item.EquippedSlotID == 3)
                                {
                                    item.Equipped = true;
                                }
                                else if (!IsEquipped("Pants") && item.EquippedSlotID == 4)
                                {
                                    item.Equipped = true;
                                }
                                else if (!IsEquipped("Gloves") && item.EquippedSlotID == 5)
                                {
                                    item.Equipped = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"You already have a {item.Type} equipped");
                                    Console.ReadKey();
                                    break;
                                }

                                EquipInventory.Add(item);
                                player.LowestDamage += item.LowDamageBoost;
                                player.HigestDamage += item.HighDamageBoost;
                                player.MaxArmour += item.Armour;
                                player.MaxHealthFromItems += item.HealthIncrease;
                                Inventory.Remove(item);
                                Console.Clear();
                                Console.WriteLine($"{item.Name} has been equipped");
                                Console.ReadKey();
                                break;
                            }
                            else if(userChoice == 2)
                            {
                                Console.Clear();
                                player.Gold += item.GoldValue / 2;
                                Console.WriteLine($"You have sold the item for {item.GoldValue / 2} gold");
                                Inventory.Remove(item);
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void PrintEquippedInventory()
        {
            var sortedInventoryByName = EquipInventory.OrderBy(x => x.EquippedSlotID);
            int userChoice = 0;
            int iD = 1;
            Console.WriteLine($"Greetings {player.Name}!");
            Console.WriteLine("Inventory         To unequip an item press the key that correspons with the item\n");
            foreach (Item item in sortedInventoryByName)
            {
                item.ID = iD;
                Console.WriteLine($"{item.ID}. {item.Type}");
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"Price: {item.GoldValue} gold");
                if(item.HealthIncrease > 0)
                {
                    Console.WriteLine($"Health: {item.HealthIncrease} increase");
                }
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

            Console.WriteLine("Type number of item to unequip\n");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                foreach (Item item in EquipInventory)
                {
                    if (userChoice == item.ID)
                    {
                        if (IsEquipped("Sword") && IsEquipped("Axe") && IsEquipped("Mace") && IsEquipped("Staff") && item.EquippedSlotID == 1)
                        {
                            item.Equipped = false;
                        }
                        else if (IsEquipped("Helmet") && item.EquippedSlotID == 2)
                        {
                            item.Equipped = false;
                        }
                        else if (IsEquipped("Chestplate") && item.EquippedSlotID == 3)
                        {
                            item.Equipped = false;
                        }
                        else if (IsEquipped("Pants") && item.EquippedSlotID == 4)
                        {
                            item.Equipped = false;
                        }
                        else if (IsEquipped("Gloves") && item.EquippedSlotID == 5)
                        {
                            item.Equipped = false;
                        }
                        EquipInventory.Remove(item);
                        player.LowestDamage -= item.LowDamageBoost;
                        player.HigestDamage -= item.HighDamageBoost;
                        player.MaxArmour -= item.Armour;
                        player.MaxHealthFromItems -= item.HealthIncrease;
                        Inventory.Add(item);
                        Console.Clear();
                        Console.WriteLine($"{item.Name} has been unequipped");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }

        public bool IsEquipped(string type)
        {
            foreach (Item item in EquipInventory)
            {
                if(item.Type.ToLower() == type.ToLower() && item.Equipped == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

