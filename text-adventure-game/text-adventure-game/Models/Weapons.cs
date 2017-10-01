using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    //enum WeaponType
    //{
    //    sword = 1,
    //    axe
    //};

    class Weapons : IItem
    {
        public string Name { get; set; }
        public int GoldValue { get; set; }
        public int LowDamageBoost { get; set; }
        public int HighDamageBoost { get; set; }
        public int StoreID { get; set; }
        public int InventoryID { get; set; }
        public int SlotID { get; set; }
        public string Type { get; set; }

        //public void Buy()
        //{
        //    Console.WriteLine($"{Name} has been bought");
        //}

        //public void Sell()
        //{
        //    Console.WriteLine($"sold for {GoldValue} gold");
        //}

        //public Weapons(WeaponType weaponType)
        //{
        //    switch (weaponType)
        //    {
        //        case WeaponType.sword:
        //            break;
        //        case WeaponType.axe:
        //            break;
        //        default:
        //            break;
        //    }
        //}

    }
}
