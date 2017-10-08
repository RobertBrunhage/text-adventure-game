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
            Monster5,
            Boss
        };

        public int MonsterDif { get; set; }
        public int Health { get; set; }
        public int MinGold { get; set; }
        public int MaxGold { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public string Name { get; set; }

        public void ChooseMonster()
        {
            Monsters mapChoice;
            mapChoice = (Monsters)MonsterDif;
            switch (mapChoice)
            {
                case Monsters.Monster1:
                    Health = 20;
                    MinGold = 3;
                    MaxGold = 6;
                    MinDamage = 1;
                    MaxDamage = 5;
                    Name = "Snake";
                    break;
                case Monsters.Monster2:
                    Health = 35;
                    MinGold = 9;
                    MaxGold = 14;
                    MinDamage = 3;
                    MaxDamage = 7;
                    Name = "Wolf";
                    break;
                case Monsters.Monster3:
                    Health = 45;
                    MinGold = 20;
                    MaxGold = 30;
                    MinDamage = 6;
                    MaxDamage = 10;
                    Name = "Bear";
                    break;
                case Monsters.Monster4:
                    Health = 55;
                    MinGold = 25;
                    MaxGold = 35;
                    MinDamage = 7;
                    MaxDamage = 12;
                    Name = "Lion";
                    break;
                case Monsters.Monster5:
                    Health = 65;
                    MinGold = 30;
                    MaxGold = 40;
                    MinDamage = 9;
                    MaxDamage = 14;
                    Name = "Crocodile";
                    break;
                case Monsters.Boss:
                    Health = 100;
                    MinGold = 90;
                    MaxGold = 200;
                    MinDamage = 16;
                    MaxDamage = 30;
                    Name = "Dragon of Doom";
                    break;
                default:
                    break;
            }
        }

        public void TakeDamage(int _dmg)
        {
            Health -= _dmg;
        }

        public void PrintMonsterStats()
        {
            Console.WriteLine($"monster name: {Name}");
            Console.WriteLine($"monster health: {Health}");
            Console.WriteLine($"Monster damage: {MinDamage} - {MaxDamage}");
        }
    }
}
