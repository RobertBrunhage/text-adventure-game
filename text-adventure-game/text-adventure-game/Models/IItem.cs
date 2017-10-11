using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    interface IItem
    {
        //Using this so that Item must have these properties or else we get an error early on.

        bool Equipped { get; set; }          //What item is equipped and not equipped
        string Name { get; set; }            //Name of item
        int GoldValue { get; set; }          //What the item will cost
        int LowDamageBoost { get; set; }     //The damage increase it will do to minimun damage of player
        int HighDamageBoost { get; set; }    //The damage increase it will do to maximum damage of player
        int ID { get; set; }                 //Handles the sorting of items in store and inventory
        string Type { get; set; }            //Helps with printing out for example all axes
        int EquippedSlotID { get; set; }     //Checks if we have a item equipped or not
        string BaseType { get; set; }        //A string of either weapon or armour. Simplifies for user
        int Armour { get; set; }             //The armour of each item
        int HealthIncrease { get; set; }     //The amount of health the item will give
    }
}
