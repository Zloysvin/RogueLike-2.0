using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public static class MakeShiftDataBases
    {
        public static Dictionary<string, Entity> Entities;
        public static Dictionary<int, Item> Items;
        public static Dictionary<int, string> MessageCodes;

        public static string[] Collisions = new[] { "#", "r", "R", "c", "C", "g", "s", "S" };
        public static string[] Enemies = new[] { "r", "R", "c", "C", "g", "s", "S" };

        public static void InitDBs()
        {
            Items = new Dictionary<int, Item>
            {
                {0, new Item("<Empty>", "empty",0, 0, 0, "-", false) },
                {1, new Item("Short Sword", "weapon", 6, 3, 0, "0-3", true)},
                {101, new Item("Claw", "weapon", 4, 1, 0, "0-5", true, 10)},
                {102, new Item("Robo-Claw", "weapon", 5, 2, 0,"0-5" ,true, 10)},
                {103, new Item("Spear", "weapon", 7, 4, 0,"2-5" ,true, 10)},
                {104, new Item("Tusk", "weapon", 4, 3, 0,"-" ,false, 0)},
                {105, new Item("Robo-Tusk", "weapon", 6, 4, 0,"-" ,false, 0)},
                {666, new Item("Admin Sword", "weapon", 250, 10, 0, "-", false)},
                {201, new Item(0, "No Armor", "armor", "-", 0)}
            };
            Entities = new Dictionary<string, Entity>
            {//y, x, hp, str, agl, end, lck
                { "r", new Entity(0, 0, 5, 1, 5, 1, 5, "r", "Rat", Items[101], "0-3", 10, 30) },
                { "R", new Entity(0, 0, 10, 3, 7, 1, 8, "R", "Robo-rat", Items[102], "0-4", 15, 50) },
                { "c", new Entity(0, 0, 11, 2, 7, 1, 9, "c", "Crab", Items[101], "0-4", 25, 40) },
                { "C", new Entity(0, 0, 16, 5, 8, 1, 10, "C", "Robo-Crab", Items[102], "1-4", 35, 75) },
                { "g", new Entity(0, 0, 13, 2, 10, 1, 10, "g", "Goblin", Items[103], "2-5", 50, 90) },
                { "s", new Entity(0, 0, 6, 6, 7, 1, 15, "s", "Small Snake", Items[104], "2-5", 30, 50) },
                { "S", new Entity(0, 0, 10, 3, 13, 1, 17, "S", "Snake", Items[105], "3-5", 40, 80) },

            };
            MessageCodes = new Dictionary<int, string>
            {
                {0, ""},
                {1, "╬"},
                {2, "║"},
                {3, "╦"},
                {4, "╩"},
                {5, "╠"},
                {6, "?"}
            };
        }
    }
}
