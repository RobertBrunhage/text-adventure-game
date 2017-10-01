using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_game.Models
{
    interface IItem
    {

        string Name { get; set; }
        int GoldValue { get; set; }
        int LowDamageBoost { get; set; }
        int StoreID { get; set; }
    }
}
