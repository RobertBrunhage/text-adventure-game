using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Sword : Weapons
    {
        public Sword(string name, int goldValue, int damageBoost, int storeID)
        {
            base.Name = name;
            base.GoldValue = goldValue;
            base.DamageBoost = damageBoost;
            base.StoreID = storeID;
        }
    }
}
