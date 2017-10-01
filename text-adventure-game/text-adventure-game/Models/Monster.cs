using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Monster
    {
        enum Monsters
        {
            Monster1 = 1,
            Monster2,
            Monster3,
            Monster4,
            Boss
        };

        public int MonsterDif { get; set; }
        public int Health { get; set; }
        public int GoldValue { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }

        public void ChooseMonster()
        {
            Monsters mapChoice;
            mapChoice = (Monsters)MonsterDif;
            switch (mapChoice)
            {
                case Monsters.Monster1:
                    Health = 20;
                    GoldValue = 10;
                    Damage = 4;
                    Name = "Snake";
                    break;
                case Monsters.Monster2:
                    Health = 35;
                    GoldValue = 15;
                    Damage = 8;
                    Name = "Wolf";
                    break;
                case Monsters.Monster3:
                    Health = 45;
                    GoldValue = 30;
                    Damage = 12;
                    Name = "Bear";
                    break;
                case Monsters.Monster4:
                    break;
                case Monsters.Boss:
                    break;
                default:
                    break;
            }
        }

        public void PrintMonsterStats()
        {
            Console.WriteLine($"monster name: {Name}");
            Console.WriteLine($"monster health: {Health}");
        }
    }
}
