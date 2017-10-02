using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Axe : Item
    {
        public Axe(string name, int goldValue, int lowDamageBoost, int highDamageBoost)
        {
            base.Name = name;
            base.GoldValue = goldValue;
            base.LowDamageBoost = lowDamageBoost;
            base.HighDamageBoost = highDamageBoost;
            base.StoreID = 0;
            base.SlotID = 1;
            base.Type = "Axe";
            base.BaseType = "Weapon";
        }
    }
}
