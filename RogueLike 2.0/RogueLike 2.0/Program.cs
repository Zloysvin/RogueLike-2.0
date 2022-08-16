using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLike_2._0_
{
    internal class Program
    {
        public static string[,] Map = new string[30, 30];
        public static Player Player;
        public static Entity[] Entities = new Entity[10];

        public static ConsoleKeyInfo cki;

        public static int Y = 0;
        public static int X = 0;

        public static int count = 0;

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 40);

            InitMap();
            MakeShiftDataBases.InitDBs();
            Player = new Player(0, 0, 10, 10, 10, 10, 10, "&", "player", 3, 1, 0, 0, 10, MakeShiftDataBases.Items[1]);
            InitEntities();
            Player.SetInventory();
            Player.Inventory[0] = MakeShiftDataBases.Items[102];
            Player.Inventory[1] = MakeShiftDataBases.Items[102];

            RenderFunctions.InitColors();
            RenderFunctions.RenderMap(Map);
            RenderFunctions.RenderUI();
            RenderFunctions.UpdateSliderUI(Player);
            RenderFunctions.UpdateInventoryUI(Player);
            RenderFunctions.UpdateCharacterUI(Player);
            RenderFunctions.UpdateFooter(Player);
            RenderFunctions.InitLog();

            Console.TreatControlCAsInput = true;
            while (true)
            {
                Movement();
                count++;
                if (count == 10)
                {
                    RenderFunctions.UpdateLogUI("Log test 1", 1);
                }

                if (count == 20)
                {
                    RenderFunctions.UpdateLogUI("Log test 2", 4);
                    Player.Gold = 2786;
                    RenderFunctions.UpdateFooter(Player);
                }

                if (count == 25)
                {
                    RenderFunctions.UpdateLogUI("Log test 3", 2);
                }

                if (count == 30)
                {
                    RenderFunctions.UpdateLogUI("Log test 4", 2);
                }
                if (count == 35)
                {
                    RenderFunctions.UpdateLogUI("Log test 5", 3);
                }
            }
        }

        static void InitMap()
        {
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Map[i, j] = "&";
                    }
                    else
                    {
                        int c = rnd.Next(0, 10);
                        if (c > 7)
                            Map[i, j] = "#";
                        else
                            Map[i, j] = ".";
                    }
                }
            }
        }

        static void Movement()
        {
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.UpArrow)
            {
                if (!Collision(Y - 1, X)) RenderFunctions.RenderMovement(Y, X, --Y, X);
            }

            if (cki.Key == ConsoleKey.RightArrow)
            {
                if (!Collision(Y, X + 1)) RenderFunctions.RenderMovement(Y, X, Y, ++X);
            }

            if (cki.Key == ConsoleKey.DownArrow)
            {
                if (!Collision(Y + 1, X)) RenderFunctions.RenderMovement(Y, X, ++Y, X);
            }

            if (cki.Key == ConsoleKey.LeftArrow)
            {
                if (!Collision(Y, X - 1)) RenderFunctions.RenderMovement(Y, X, Y, --X);
            }
        }

        static bool Collision(int newY, int newX)
        {
            if (newY == 30 || newY < 0 || newX == 30 || newX < 0)
            {
                return true;
            }

            if (MakeShiftDataBases.Collisions.Contains(Map[newY, newX]))
            {
                return true;
            }

            return false;
        }

        static void InitEntities()
        {
            List<Entity> availableEntities = new List<Entity>();
            foreach (var entity in MakeShiftDataBases.Entities)
            {
                string[] leveles = entity.Value.SpawnLevel.Split("-");
                if (Player.level >= Convert.ToInt32(leveles[0]) && Player.level <= Convert.ToInt32(leveles[1]))
                {
                    availableEntities.Add(entity.Value);
                }
            }               
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Entities[i] = availableEntities[rnd.Next(availableEntities.Count)];
                int y = rnd.Next(30);
                int x = rnd.Next(30);
                Entities[i].X = x;
                Entities[i].Y = y;
                Map[y, x] = Entities[i].Symbol;
            }
        }
    }
}