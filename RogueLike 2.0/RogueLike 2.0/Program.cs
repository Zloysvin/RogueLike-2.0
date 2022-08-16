using System;
using System.Collections.Generic;

namespace RogueLike_2._0_
{
    internal class Program
    {
        public static string[,] Map = new string[30, 30];
        public static Entity[] Entities = new Entity[10];


        public static ConsoleKeyInfo cki;

        public static int Y = 0;
        public static int X = 0;

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 40);

            Entities[0] = new Player(0, 0, 10, 10, 10, 10, 10, "&", 0, 1, 0, 10);
            Entities[0].SetInventory();
            RenderFunctions.InitColors();
            InitMap();
            RenderFunctions.RenderMap(Map);
            RenderFunctions.RenderUI();

            Console.TreatControlCAsInput = true;
            while (true)
            {
                Movement();
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
                if (!Collision(Y - 1, X))
                    RenderFunctions.RenderMovement(Y, X, --Y, X);
            }

            if (cki.Key == ConsoleKey.RightArrow)
            {
                if (!Collision(Y, X + 1))
                    RenderFunctions.RenderMovement(Y, X, Y, ++X);
            }

            if (cki.Key == ConsoleKey.DownArrow)
            {
                if (!Collision(Y + 1, X))
                    RenderFunctions.RenderMovement(Y, X, ++Y, X);
            }

            if (cki.Key == ConsoleKey.LeftArrow)
            {
                if (!Collision(Y , X - 1))
                    RenderFunctions.RenderMovement(Y, X, Y, --X);
            }
        }
        static bool Collision(int newY, int newX)
        {
            if (newY == 30 || newY < 0 || newX == 30 || newX < 0)
            {
                return true;
            }

            if (Map[newY, newX] == "#")
            {
                return true;
            }
            return false;
        }

        static void InitEntities()
        {

        }
    }
}
