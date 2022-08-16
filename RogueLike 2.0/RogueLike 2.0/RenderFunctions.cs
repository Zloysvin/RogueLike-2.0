using System;
using System.Collections.Generic;

namespace RogueLike_2._0_
{
    public static class RenderFunctions
    {
        public static Dictionary<string, ConsoleColor> ConsoleElements;

        public static void InitColors()
        {
            ConsoleElements = new Dictionary<string, ConsoleColor>()
            {
                {"&", ConsoleColor.Yellow},
                {"#", ConsoleColor.White},
                {".", ConsoleColor.DarkGray},
                {"░", ConsoleColor.Red},
                {"▒", ConsoleColor.Gray}
            };
        }

        public static void RenderMovement(int oldY, int oldX, int newY, int newX)
        {
            Console.SetCursorPosition(oldX, oldY);
            RenderElement(".");
            Console.SetCursorPosition(newX, newY);
            RenderElement("&");
            Console.SetCursorPosition(30, 29);
        }

        private static void RenderElement(string element)
        {
            Console.ForegroundColor = RenderFunctions.ConsoleElements[element];
            Console.Write(element);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RenderMap(string[,] Map)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    RenderElement(Map[i, j]);
                }

                if (i != 29)
                    Console.WriteLine();
            }
        }

        public static void RenderUI()
        {
            Console.SetCursorPosition(30, 1);
            Console.Write(" ╔══════════════════════════════════════════════════════════");
            Console.SetCursorPosition(30, 2);
            Console.Write(" ║ "); //32 2
            for (int i = 0; i < 20; i++)
            {
                RenderElement("░");
            }//52, 2
            Console.Write("0/0 HP");
            Console.SetCursorPosition(30, 3);
            Console.Write(" ╟──────────────────────────────────────────────────────────");
            Console.SetCursorPosition(30, 4);
            Console.Write(" ║ "); //32 4
            for (int i = 0; i < 20; i++)
            {
                RenderElement("▒");
            }//52, 4
            Console.Write("0/0 AP");
            Console.SetCursorPosition(30, 5);
            Console.Write(" ╟──────────────────────────────────────────────────────────");
            Console.SetCursorPosition(30, 6);
            Console.Write(" ║ "); //32 6
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 20; i++)
            {
                Console.Write("░");
            }//52, 6

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("0/0 XP");
            Console.SetCursorPosition(30, 7);
            Console.Write(" ╠══════════════════════════════════════════════════════════");
            Console.SetCursorPosition(30, 8);
            Console.Write(" ║                                                          ");
            Console.SetCursorPosition(55, 8);
            Console.Write("INVENTORY");
            for (int i = 9; i < 14; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write(" ║                                                          ");
            }
            Console.SetCursorPosition(30, 14);
            Console.Write(" ╠══════════════════════════════════════════════════════════");
            Console.SetCursorPosition(30, 15);
            Console.Write(" ║                                                          ");
            Console.SetCursorPosition(55, 15);
            Console.Write("CHARACTER");
            for (int i = 16; i < 19; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write(" ║                                                          ");
            }
            Console.SetCursorPosition(30, 19);
            Console.Write(" ╠══════════════════════════════════════════════════════════");
            Console.SetCursorPosition(30, 20);
            Console.Write(" ║                                                          ");
            Console.SetCursorPosition(58, 20);
            Console.Write("LOG");
            for (int i = 21; i < 25; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write(" ║                                                          ");
            }
            Console.SetCursorPosition(30, 25);
            Console.Write(" ╚══════════════════════════════════════════════════════════");
            Console.SetCursorPosition(30, 26);
            Console.Write("                                                            ");
            Console.SetCursorPosition(31, 26);
            Console.Write("Dungeon Level 0");
            Console.SetCursorPosition(84, 26);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("0 g");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 27);
            Console.Write(" Character Level 0");
        }
    }
}
