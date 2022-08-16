using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public class Player : Entity
    {
        public new int level;
        public new int gold;
        public new int MaxHP;

        public Item[] Inventory = new Item[10];

        public Player(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, int damage, int level, int gold, int maxHp) : base(y, x, hp, strength, agility, endurance, luck, symbol, damage)
        {
            this.level = level;
            this.gold = gold;
            MaxHP = maxHp;
        }

        public new void SetInventory()
        {
            for (int i = 0; i < 10; i++)
            {
                Inventory[i] = MakeShiftDataBases.items[0];
            }
        }
    }
}
