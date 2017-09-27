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
        public int Mana { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }

        //Player Stats
        public int Strenght { get; set; }
        public int Knowledge { get; set; }
        public int SwordDamage { get; set; }
        public int BowDamage { get; set; }

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
                            MaleBaseStats();
                            break;
                        case 2:
                            FemaleBaseStats();
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
                Console.WriteLine("2. Archer");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            SwordDamage = 1;
                            Damage += SwordDamage;
                            Class = "Warrior";
                            break;
                        case 2:
                            BowDamage = 1;
                            Damage += SwordDamage;
                            Class = "Archer";
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
        public void MaleBaseStats()
        {
            Health = 100;
            Mana = 100;
            Damage = 1;

            Strenght = 1;
        }
        public void FemaleBaseStats()
        {
            Health = 100;
            Mana = 100;
            Damage = 1;

            Knowledge = 1;
        }
    }
}
