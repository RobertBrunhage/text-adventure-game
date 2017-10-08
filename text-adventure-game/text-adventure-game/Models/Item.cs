using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    class Item : IItem
    {
        public string Name { get; set; }           
        public int GoldValue { get; set; }         
        public int LowDamageBoost { get; set; }    
        public int HighDamageBoost { get; set; }   
        public int ID { get; set; }                 
        public string Type { get; set; }            
        public int EquippedSlotID { get; set; }             
        public string BaseType { get; set; }        
        public int Armour { get; set; }             
        public int HealthIncrease { get; set; }
    }
}
