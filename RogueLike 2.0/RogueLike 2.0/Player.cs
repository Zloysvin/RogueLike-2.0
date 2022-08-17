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
        private int baseHP;

        public Item Armor;

        public Item[] Inventory = new Item[10];

        public Player(int y, int x, int hp, int strength, int agility, int endurance, int luck, string symbol, string name, int level, int playerLevel, int xp, int gold, int maxHp, Item armor) : base(y, x, hp, strength, agility, endurance, luck, symbol, name)
        {
            this.level = level;
            PlayerLevel = playerLevel;
            XP = xp;
            Gold = gold;
            baseHP = maxHp;
            MaxHP = Convert.ToInt32(baseHP + 10 * Math.Pow(1.2, Endurance / 2 + PlayerLevel));
            HP = MaxHP;
            Armor = armor;
            Dodge = Convert.ToInt32(Math.Ceiling(1.0 + 4.0 / 3.0 * Agility + Luck * 1.5));
            SetInventory();
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
            if (PlayerLevel != 1)
                Endurance += Convert.ToInt32(Math.Sqrt(PlayerLevel));

            LimitXP = Convert.ToInt32(100 * Math.Pow(1.2, PlayerLevel - 1));
            Dodge = Convert.ToInt32(Math.Ceiling(1.0 + 4.0 / 3.0 * Agility + Luck * 1.5));
            MaxHP = Convert.ToInt32(baseHP + 10 * Math.Pow(1.2, Endurance/2+PlayerLevel));
            if (HP < MaxHP)
            {
                HP += MaxHP / 3;
                if(HP > MaxHP)
                    HP = MaxHP;
            }
            RenderFunctions.UpdateCharacterUI(this);
        }
    }
}
