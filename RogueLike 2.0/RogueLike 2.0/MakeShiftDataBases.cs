using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public static class MakeShiftDataBases
    {
        public static Dictionary<string, Entity> entities;
        public static Dictionary<int, Item> items;

        public static void InitDBs()
        {
            items = new Dictionary<int, Item>
            {
                {0, new Item("<Empty>", "empty", 0, 0, 0, 0, 0) }
            };
        }
    }
}
