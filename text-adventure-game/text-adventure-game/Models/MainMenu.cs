using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class MainMenu
    {
        public void StartProgram()
        {
            Console.WriteLine("Please choose:\n");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Exit Game");

            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                switch (userInput)
                {
                    case 1:
                        //New Game
                        break;
                    case 2:
                        //Exit Game
                        break;
                }
            }
        }
    }
}
