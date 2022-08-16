using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public class Item
    {
        public string Name;
        public string Type;

        public int DmgMax;
        public int DmgMin;
        public int Heal;
        public int SpecialID;
        public int level;

        public Item(string name, string type, int dmgMax, int dmgMin, int heal, int specialId, int level)
        {
            Name = name;
            Type = type;
            DmgMax = dmgMax;
            DmgMin = dmgMin;
            Heal = heal;
            SpecialID = specialId;
            this.level = level;
        }
    }
}
