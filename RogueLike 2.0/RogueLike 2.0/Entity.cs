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
        public int Damage;
        public int gold;
        public int level;
        public int MaxHP;

        public Entity()
        {

        }
        public Entity(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, int damage)
        {
            Y = y;
            X = x;
            HP = hp;
            Strength = strength;
            Agility = agility;
            Endurance = endurance;
            Luck = luck;
            Symbol = symbol;
            Damage = damage;
        }

        public void SetInventory()
        {
        }
    }
}
