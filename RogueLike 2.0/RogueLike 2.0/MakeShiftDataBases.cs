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

        public static void InitDBs()
        {
            Items = new Dictionary<int, Item>
            {
                {0, new Item("<Empty>", "empty",0, 0, 0, "-", 0) },
                {101, new Item("Claw", "weapon", 4, 1, 0, "0-5", true, 10)},
                {102, new Item("Robo-Claw", "weapon", 5, 2, 0,"0-5" ,true, 10)},
                {103, new Item("Spear", "weapon", 7, 4, 0,"2-5" ,true, 10)},
                {104, new Item("Tusk", "weapon", 4, 3, 0,"-" ,false, 0)},
                {105, new Item("Robo-Tusk", "weapon", 6, 4, 0,"-" ,false, 0)},
                {1, new Item(0, "No Armor", "armor", "-", 0)}
            };
            Entities = new Dictionary<string, Entity>
            {
                { "r", new Entity(0, 0, 5, 1, 2, 1, 1, "r", "Rat", Items[101], "0-3") },
                { "R", new Entity(0, 0, 10, 3, 1, 1, 1, "R", "Robo-rat", Items[102], "0-4") },
                { "c", new Entity(0, 0, 11, 2, 1, 1, 3, "c", "Crab", Items[101], "0-4") },
                { "C", new Entity(0, 0, 16, 5, 1, 1, 1, "C", "Robo-Crab", Items[102], "1-4") },
                { "g", new Entity(0, 0, 13, 4, 3, 1, 3, "g", "Goblin", Items[103], "2-5") },
                { "s", new Entity(0, 0, 6, 1, 4, 1, 4, "s", "Small Snake", Items[104], "2-5") },
                { "S", new Entity(0, 0, 10, 3, 4, 1, 3, "S", "Snake", Items[105], "3-5") },

            };
            MessageCodes = new Dictionary<int, string>
            {
                {0, ""},
                {1, "╬"},
                {2, "║"},
                {3, "╦"},
                {4, "╩"}
            };
        }
    }
}
