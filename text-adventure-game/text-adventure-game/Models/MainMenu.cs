using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Clear();
            Console.WriteLine($"|HP {player.Health}               Mana: {player.Mana}");
            Console.WriteLine($"|Strengh: {player.Strenght}     Knowledge: {player.Knowledge}");
            Console.WriteLine($"|Damage: {player.Damage}");

        }
    }
}
