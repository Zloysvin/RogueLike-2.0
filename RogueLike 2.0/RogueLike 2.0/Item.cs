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
        public int ArmorMaxAm;
        public int ArmorAm;
        public int Heal;
        public int SpecialID;
        public int level;

        public Item(string name, string type, int dmgMax, int dmgMin,  int specialId, int level)
        {
            Name = name;
            Type = type;
            DmgMax = dmgMax;
            DmgMin = dmgMin;
            SpecialID = specialId;
            this.level = level;
        }
        public Item(string name, string type, int heal, int level)
        {
            Name =name;
            Type = type;
            Heal = heal;
            this.level = level;
        }

        public Item(int armorMaxAm, string name, string type, int level)
        {
            Name = name;
            Type = type;
            ArmorMaxAm = armorMaxAm;
            ArmorAm = armorMaxAm;
            this.level = level;
        }
    }
}
