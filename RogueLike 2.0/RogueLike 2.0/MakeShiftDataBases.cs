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

        public static void InitDBs()
        {
            Items = new Dictionary<int, Item>
            {
                {0, new Item("<Empty>", "empty", 0, 0, 0, 0) },
                {1, new Item(0, "No Armor", "armor", 0)}
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
