using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Item : IItem
    {
        public string Name { get; set; }            //Name of item
        public int GoldValue { get; set; }          //What the item will cost
        public int LowDamageBoost { get; set; }     //The damage increase it will do to minimun damage of player
        public int HighDamageBoost { get; set; }    //The damage increase it will do to maximum damage of player
        public int ID { get; set; }                 //Handles the sorting of items in store and inventory
        public string Type { get; set; }            //Helps with printing out for example all axes
        public int SlotID { get; set; }             //Checks if we have a item equipped or not
        public string BaseType { get; set; }        //A string of either weapon or armour. Simplifies for user
        public int Armour { get; set; }             //The armour of each item
        public int HealthIncrease { get; set; }
    }
}
