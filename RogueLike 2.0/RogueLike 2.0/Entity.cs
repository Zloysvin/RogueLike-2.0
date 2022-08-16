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
        public string SpawnLevel;
        
        public Entity()
        {

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
        public Entity(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, string name, Item weapopItem, string spawnLevel)
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
            SpawnLevel = spawnLevel;
        }
    }
}
