using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public class Player : Entity
    {
        public int level;
        public int PlayerLevel;
        public int XP;
        public int LimitXP;
        public int Gold;
        public int MaxHP;
        public int Dodge;

        public Item Armor;

        public Item[] Inventory = new Item[10];

        public Player(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, string name, int level, int playerLevel, int xp, int gold, int maxHp, Item armor) : base(y, x, hp, strength, agility, endurance, luck, symbol, name)
        {
            this.level = level;
            PlayerLevel = playerLevel;
            XP = xp;
            Gold = gold;
            MaxHP = maxHp;
            Armor = armor;
            Dodge = Convert.ToInt32(Math.Ceiling(1.0 + 4.0 / 3.0 * Agility + Luck * 1.5));
            UpdateCharacter();
        }

        public void SetInventory()
        {
            for (int i = 0; i < 10; i++)
            {
                Inventory[i] = MakeShiftDataBases.Items[0];
            }
        }

        public void UpdateCharacter()
        {
            LimitXP = Convert.ToInt32(100 * Math.Pow(1.2, PlayerLevel - 1));
            Dodge = Convert.ToInt32(Math.Ceiling(1.0 + 4.0 / 3.0 * Agility + Luck * 1.5));
        }
    }
}
