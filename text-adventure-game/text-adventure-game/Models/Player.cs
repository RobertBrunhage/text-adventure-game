﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Player
    {
        //Main things
        public int MaxHealth { get; set; }
        private int _Health;
        public int Health
        {
            get
            {
                return _Health;
            }
            set
            {
                if(_Health < 0)
                {
                    _Health = 0;
                }
                else if(_Health > 200)
                {
                    _Health = 200;
                }
                else
                {
                    _Health = value;
                }
            }
        }
        public int LowestDamage { get; set; }
        public int HigestDamage { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public int Gold { get; set; }

        //Player Stats
        public int Armour { get; set; }
        public int MaxArmour { get; set; }

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
                            MaxHealth = Health;
                            LowestDamage = 1;
                            Armour = 0;
                            Gold = 0;
                            break;
                        case 2:
                            Health = 100;
                            MaxHealth = Health;
                            LowestDamage = 1;
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
                            HigestDamage = 2;
                            Armour += 10;
                            MaxArmour = Armour;
                            break;
                        case 2:
                            Class = "Mage";
                            HigestDamage = 3;
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
        public void AskAge()
        {
            bool ageDone = false;
            int userInput;
            Console.Clear();
            Console.WriteLine("What is your age?\n");
            do
            {
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    Age = userInput;
                    ageDone = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input your age");
                    Console.ReadKey();
                }
            } while (ageDone == false);


        }
        public void PrintStats()
        {
            Console.Clear();
            Console.WriteLine($"|HP {Health}                Name: {Name}         Age: {Age}");
            Console.WriteLine($"|Damage: {LowestDamage} - {HigestDamage}         Armour: {Armour}");
            Console.WriteLine($"|Gold: {Gold}");
            Console.WriteLine("|_________________________________________________________");
        }
    }
}
