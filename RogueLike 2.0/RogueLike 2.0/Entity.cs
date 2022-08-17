using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public class Entity
    {
        public int Y;
        public int X;

        public int HP;

        public int Strength;
        public int Agility;
        public int Endurance;
        public int Luck;

        public string Symbol;
        public string Name;
        public int Damage;
        public Item WeaponItem;
        public string SpawnLevel;
        public int XP;
        public int Dodge;
        public int DropGold;

        public Entity()
        {

        }
        public Entity(Entity entity)
        {
            Y = 0;
            X = 0;

            HP = entity.HP;
            Strength = entity.Strength;
            Agility = entity.Agility;
            Endurance = entity.Endurance;
            Luck = entity.Luck;
            Symbol = entity.Symbol;
            Name = entity.Name;
            Damage = entity.Damage;
            WeaponItem = entity.WeaponItem;
            SpawnLevel = entity.SpawnLevel;
            XP = entity.XP;
            Dodge = Agility + Luck;
            DropGold = entity.DropGold;
        }
        public Entity(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, string name)
        {
            Y = y;
            X = x;
            HP = hp;
            Strength = strength;
            Agility = agility;
            Endurance = endurance;
            Luck = luck;
            Symbol = symbol;
            Damage = strength / 3;
            Name = name;
        }
        public Entity(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, string name, Item weaponItem, string spawnLevel, int xp, int dropGold)
        {
            Y = y;
            X = x;
            HP = hp;
            Strength = strength;
            Agility = agility;
            Luck = luck;
            Symbol = symbol;
            Damage = strength / 3;
            Name = name;
            WeaponItem = weaponItem;
            SpawnLevel = spawnLevel;
            XP = xp;
            Dodge = Agility + Luck;
            DropGold = dropGold;
        }
    }
}
