using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Pants : Item
    {
        public Pants(string name, int goldValue, int lowDamageBoost, int highDamageBoost, int armour, int healthIncrease)
        {
            base.Name = name;
            base.HealthIncrease = healthIncrease;
            base.GoldValue = goldValue;
            base.LowDamageBoost = lowDamageBoost;
            base.HighDamageBoost = highDamageBoost;
            base.ID = 0;
            base.SlotID = 4;
            base.Armour = armour;
            base.Type = "Pants";
            base.BaseType = "Pants";
        }
    }
}
