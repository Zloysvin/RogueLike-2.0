using System;
using System.Collections.Generic;
using System.Numerics;

namespace RogueLike_2._0_
{
    public static class RenderFunctions
    {
        private static Dictionary<string, ConsoleColor> ConsoleElements;

        private static LogMessage[] LogMessages = new LogMessage[5];

        public static void InitColors()
        {
            ConsoleElements = new Dictionary<string, ConsoleColor>()
            {
                {"&", ConsoleColor.Yellow},
                {"r", ConsoleColor.DarkGreen},
                {"R", ConsoleColor.DarkGreen},
                {"c", ConsoleColor.DarkCyan},
                {"C", ConsoleColor.DarkCyan},
                {"g", ConsoleColor.DarkBlue},
                {"s", ConsoleColor.Green},
                {"S", ConsoleColor.Green},

                {"#", ConsoleColor.White},
                {".", ConsoleColor.DarkGray},
                {"_", ConsoleColor.Black},
                {"<", ConsoleColor.Cyan},
                {"/", ConsoleColor.Cyan},

                {"░", ConsoleColor.Red},
                {"▒", ConsoleColor.Gray},
                {"╬", ConsoleColor.Blue},
                {"║", ConsoleColor.Red},
                {"╩", ConsoleColor.Red},
                {"╦", ConsoleColor.Red},
                {"╠", ConsoleColor.Blue},
                {"?", ConsoleColor.Yellow}

            }; 
        }

        public static void InitLog()
        {
            for (int i = 0; i < 5; i++)
            {
                LogMessages[i] = new LogMessage();
            }

            LogMessages[0] = new LogMessage("Log Initialized", 1);
            UpdateLogUI();
        }

        public static void RenderMovement(int oldY, int oldX, int newY, int newX)
        {
            Console.SetCursorPosition(oldX, oldY);
            RenderElement(".");
            Console.SetCursorPosition(newX, newY);
            RenderElement("&");
            Console.SetCursorPosition(0, 30);
        }
        
        private static void RenderElement(string element)
        {
            Console.ForegroundColor = ConsoleElements[element];
            Console.Write(element);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ReplaceExactElement(int Y, int X, string[,] Map)
        {
            Console.SetCursorPosition(X, Y);
            RenderElement(Map[Y, X]);
            Console.SetCursorPosition(0, 30);
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
            for (int i = 21; i < 26; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write(" ║                                                          ");
            }
            Console.SetCursorPosition(30, 26);
            Console.Write(" ╚══════════════════════════════════════════════════════════");
            Console.SetCursorPosition(30, 27);
            Console.Write("                                                            ");
            Console.SetCursorPosition(31, 27);
            Console.Write("Dungeon Level 0");
            Console.SetCursorPosition(84, 27);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("0 g");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 28);
            Console.Write(" Character Level 0");
        }

        #region Characteristic Sliders

        public static void UpdateSliderUI(Player player)
        {
            UpdateSliders(2, ConsoleColor.Red, "░", player.HP, player.MaxHP, "HP");
            UpdateSliders(4, ConsoleColor.Gray, "▒", player.Armor.ArmorAm, player.Armor.ArmorMaxAm, "AP");
            Console.SetCursorPosition(63, 4);
            Console.Write("                           ");
            Console.SetCursorPosition(63, 4);
            Console.Write($"Your Armor: {player.Armor.Name}");
            UpdateSliders(6, ConsoleColor.Green, "░", player.XP, Convert.ToInt32(100*Math.Pow(1.2, player.PlayerLevel-1)), "XP");
        }

        private static void UpdateSliders(int y, ConsoleColor color, string element, int amount,
            int maxAmount, string amountName)
        {
            Console.SetCursorPosition(33, y);
            Console.BackgroundColor = color;
            Console.ForegroundColor = color;
            int HPToBlock = 0;
            if (maxAmount != 0)
                HPToBlock = Convert.ToInt32((double)amount / ((double)maxAmount / 100.0 * 5.0));

            if(HPToBlock == 0)
                Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 1; i <= 20; i++)
            {
                Console.Write("░");
                if (i == HPToBlock)
                    Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.SetCursorPosition(53, y);
            Console.Write("                                     ");
            Console.SetCursorPosition(53, y);
            Console.Write($"{amount}/{maxAmount} {amountName}");
            Console.SetCursorPosition(0, 30);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion

        #region Inventory

        public static void UpdateInventoryUI(Player player)
        {
            Console.SetCursorPosition(32, 9);
            Console.Write("                ");
            Console.SetCursorPosition(32, 9);
            Console.Write($"1) {player.Inventory[0].Name}");
            Console.SetCursorPosition(48, 9);
            Console.Write("[selected]");
            Console.SetCursorPosition(64, 9);
            Console.Write("                ");
            Console.SetCursorPosition(64, 9);
            Console.Write($"6) {player.Inventory[5].Name}");
            UpdateInventoryRows(10, 1, player);
            UpdateInventoryRows(11, 2, player);
            UpdateInventoryRows(12, 3, player);
            UpdateInventoryRows(13, 4, player);
        }

        private static void UpdateInventoryRows(int y, int index, Player player)
        {
            Console.SetCursorPosition(32, y);
            Console.Write("                ");
            Console.SetCursorPosition(32, y);
            Console.Write($"{index+1}) {player.Inventory[index].Name}");
            Console.SetCursorPosition(64, y);
            Console.Write("                ");
            Console.SetCursorPosition(64, y);
            Console.Write($"{index+6}) {player.Inventory[index+5].Name}");
        }

        #endregion

        public static void UpdateCharacterUI(Player player)
        {
            //73
            Console.SetCursorPosition(32, 16);
            Console.Write("                                                          ");
            Console.SetCursorPosition(32, 16);
            Console.Write("Strength: ");
            Console.SetCursorPosition(43, 16);
            Console.Write(player.Strength);
            Console.SetCursorPosition(64, 16);
            Console.Write("Agility: ");
            Console.SetCursorPosition(73, 16);
            Console.Write(player.Agility);

            Console.SetCursorPosition(32, 17);
            Console.Write("                                                          ");
            Console.SetCursorPosition(32, 17);
            Console.Write("Endurance: ");
            Console.SetCursorPosition(43, 17);
            Console.Write(player.Endurance);
            Console.SetCursorPosition(64, 17);
            Console.Write("Luck: ");
            Console.SetCursorPosition(73, 17);
            Console.Write(player.Luck);

            Console.SetCursorPosition(32, 18);
            Console.Write("                                                          ");
            Console.SetCursorPosition(32, 18);
            Console.Write("Damage: ");
            Console.SetCursorPosition(43, 18);
            Console.Write($"{player.Damage + player.Inventory[0].DmgMin}-{player.Damage + player.Inventory[0].DmgMax}");
            Console.SetCursorPosition(64, 18);
            Console.Write("Dodge: ");
            Console.SetCursorPosition(73, 18);
            Console.Write($"{player.Dodge}%");
        }

        #region LOG

        public static void UpdateLogUI(string message, int messageCode)
        {
            LogMessage messageL = new LogMessage(message, messageCode);
            LogMessage buffer = new LogMessage();
            for (int i = 21; i < 26; i++)
            {
                buffer = LogMessages[i - 21];
                LogMessages[i - 21] = messageL;
                messageL = buffer;
                RenderLogMessage(i, LogMessages[i-21]);
            }
        }
        public static void UpdateLogUI()
        {
            for (int i = 21; i < 26; i++)
            {
                RenderLogMessage(i, LogMessages[i-21]);  
            }
        }

        private static void RenderLogMessage(int y, LogMessage message)
        {
            if (message.MessageCode != 0)
            {
                Console.SetCursorPosition(33, y);
                Console.Write("                                                        ");
                Console.SetCursorPosition(33, y);
                Console.Write("[");
                RenderElement(MakeShiftDataBases.MessageCodes[message.MessageCode]);
                Console.Write($"] {message.Text}");
            }
        }

        #endregion

        public static void UpdateFooter(Player player)
        {
            Console.SetCursorPosition(30, 27);
            Console.Write("                                                            ");
            Console.SetCursorPosition(31, 27);
            Console.Write($"Dungeon Level {player.level}");
            Console.SetCursorPosition(82, 27);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{player.Gold} g");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, 28);
            Console.Write("                                                            ");
            Console.SetCursorPosition(30, 28);
            Console.Write($" Character Level {player.PlayerLevel}");
        }
    }
}
