using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Gloves : Item
    {
        public Gloves(string name, int goldValue, int lowDamageBoost, int highDamageBoost, int armour, int healthIncrease)
        {
            base.Name = name;
            base.HealthIncrease = healthIncrease;
            base.GoldValue = goldValue;
            base.LowDamageBoost = lowDamageBoost;
            base.HighDamageBoost = highDamageBoost;
            base.ID = 0;
            base.SlotID = 5;
            base.Armour = armour;
            base.Type = "Gloves";
            base.BaseType = "Gloves";
        }
    }
}
