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
        public int ArmorCooldown;
        public int Heal;
        public int SpecialID;
        public string level;
        public bool Dropable;
        public int DropChance;

        public Item()
        {

        }
        public Item(Item item)
        {
            Name = item.Name;
            Type = item.Type;
            DmgMax = item.DmgMax;
            DmgMin = item.DmgMin;
            ArmorMaxAm = item.ArmorMaxAm;
            ArmorAm = item.ArmorAm;
            Heal = item.Heal;
            SpecialID = item.SpecialID;
            this.level = item.level;
            Dropable = item.Dropable;
            DropChance = item.DropChance;
        }
        public Item(string name, string type, int dmgMax, int dmgMin,  int specialId, string level, bool dropable)
        {
            Name = name;
            Type = type;
            DmgMax = dmgMax;
            DmgMin = dmgMin;
            SpecialID = specialId;
            this.level = level;
            Dropable = dropable;
        }
        public Item(string name, string type, int dmgMax, int dmgMin, int specialId, string level, bool dropable, int dropChance)
        {
            Name = name;
            Type = type;
            DmgMax = dmgMax;
            DmgMin = dmgMin;
            SpecialID = specialId;
            this.level = level;
            Dropable = dropable;
            DropChance = dropChance;
        }
        public Item(string name, string type, int heal, string level, bool dropable)
        {
            Name =name;
            Type = type;
            Heal = heal;
            this.level = level;
            Dropable = dropable;
        }

        public Item(int armorMaxAm, string name, string type, string level, int dropChance)
        {
            Name = name;
            Type = type;
            ArmorMaxAm = armorMaxAm;
            ArmorAm = armorMaxAm;
            ArmorCooldown = 0;
            this.level = level;
            DropChance = dropChance;
        }
    }
}
