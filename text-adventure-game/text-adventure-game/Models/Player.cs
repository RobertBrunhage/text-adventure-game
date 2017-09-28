using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Player
    {
        //Main things
        public int Health { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Gold { get; set; }

        //Player Stats
        public int Armour { get; set; }

        public void AskGender()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Are you a boy or a girl\n");
                Console.WriteLine("1. Boy");
                Console.WriteLine("2. Girl");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Health = 100;
                            Damage = 1;
                            Armour = 0;
                            Gold = 0;
                            break;
                        case 2:
                            Health = 100;
                            Damage = 1;
                            Armour = 0;
                            Gold = 0;
                            break;
                    }
                }
            } while (userInput <= 0 || userInput > 2);
        }
        public void AskClass()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("What class would you like to play?\n");
                Console.WriteLine("1. Warrior");
                Console.WriteLine("2. Mage");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Class = "Warrior";
                            Damage += 1;
                            Armour += 10;
                            break;
                        case 2:
                            Class = "Mage";
                            Damage += 2;
                            break;
                    }
                }
            } while (userInput <= 0 || userInput > 2);
        }
        public void AskName()
        {
            string answer = string.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine($"Hello fellow {Class} what is your name?");
                Name = Console.ReadLine();
                Console.WriteLine($"Are you sure that you are satisfied with the name: {Name} yes/no");
                answer = Console.ReadLine();
            } while (answer.ToLower() != "yes");
        }
        public void PrintStats()
        {
            Console.Clear();
            Console.WriteLine($"|HP {Health}               Name: {Name}");
            Console.WriteLine($"|Damage: {Damage}          Armour: {Armour}");
            Console.WriteLine($"|Gold: {Gold}");
            Console.WriteLine("|_________________________________________________________");
        }
    }
}
