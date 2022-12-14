using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RogueLike_2._0_
{
    internal class Program
    {
        public static string[,] Map = new string[30, 30];
        public static Player Player;
        public static Entity[] Entities = new Entity[10];

        public static ConsoleKeyInfo cki;


        public static int count = 0;

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 40);

            MakeShiftDataBases.InitDBs();
            Player = new Player(0, 0, 5, 3, 3, 3, 3, "&", "player", 1, 1, 0, 0, 10, MakeShiftDataBases.Items[201]); 
            Console.Clear();
            InitMap();
            InitEntities();
            Player.Inventory[0] = MakeShiftDataBases.Items[1];
            Player.Inventory[1] = MakeShiftDataBases.Items[202];

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
                KeyPress();
                count++;
            }
        }

        static void InitMap()
        {
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (i == Player.Y && j == Player.X)
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

            Map[rnd.Next(30), rnd.Next(30)] = "<";
            for (int i = 0; i < 5; i++)
            {
                Map[rnd.Next(30), rnd.Next(30)] = "/";
            }
        }

        static void KeyPress()
        {
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    if (!Collision(Player.Y - 1, Player.X)) RenderFunctions.RenderMovement(Player.Y, Player.X, --Player.Y, Player.X);
                    if (Player.Armor.ArmorCooldown != 0 && Player.Armor != MakeShiftDataBases.Items[201])
                    {
                        Player.Armor.ArmorCooldown++;
                        if (Player.Armor.ArmorCooldown >= 0)
                            Player.Armor.ArmorAm = Player.Armor.ArmorMaxAm;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (!Collision(Player.Y, Player.X + 1)) RenderFunctions.RenderMovement(Player.Y, Player.X, Player.Y, ++Player.X);
                    if (Player.Armor.ArmorCooldown != 0 && Player.Armor != MakeShiftDataBases.Items[201])
                    {
                        Player.Armor.ArmorCooldown++;
                        if (Player.Armor.ArmorCooldown >= 0)
                            Player.Armor.ArmorAm = Player.Armor.ArmorMaxAm;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (!Collision(Player.Y + 1, Player.X)) RenderFunctions.RenderMovement(Player.Y, Player.X, ++Player.Y, Player.X);
                    if (Player.Armor.ArmorCooldown != 0 && Player.Armor != MakeShiftDataBases.Items[201])
                    {
                        Player.Armor.ArmorCooldown++;
                        if (Player.Armor.ArmorCooldown >= 0)
                            Player.Armor.ArmorAm = Player.Armor.ArmorMaxAm;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (!Collision(Player.Y, Player.X - 1)) RenderFunctions.RenderMovement(Player.Y, Player.X, Player.Y, --Player.X);
                    if (Player.Armor.ArmorCooldown != 0 && Player.Armor != MakeShiftDataBases.Items[201])
                    {
                        Player.Armor.ArmorCooldown++;
                        if (Player.Armor.ArmorCooldown >= 0)
                            Player.Armor.ArmorAm = Player.Armor.ArmorMaxAm;
                    }
                    break;
                case ConsoleKey.NumPad2:
                    ReplaceInvemtory(1);
                    break;
                case ConsoleKey.NumPad3:
                    ReplaceInvemtory(2);
                    break;
                case ConsoleKey.NumPad4:
                    ReplaceInvemtory(3);
                    break;
                case ConsoleKey.NumPad5:
                    ReplaceInvemtory(4);
                    break;
                case ConsoleKey.NumPad6:
                    ReplaceInvemtory(5);
                    break;
                case ConsoleKey.NumPad7:
                    ReplaceInvemtory(6);
                    break;
                case ConsoleKey.NumPad8:
                    ReplaceInvemtory(7);
                    break;
                case ConsoleKey.NumPad9:
                    ReplaceInvemtory(8);
                    break;
                case ConsoleKey.NumPad0:
                    ReplaceInvemtory(9);
                    break;
            }
        }

        private static void ReplaceInvemtory(int target)
        {
            Item buffer = new Item();
            if(Player.Inventory[target].Type == "weapon")
            {
                buffer = Player.Inventory[0];
                Player.Inventory[0] = Player.Inventory[target];
                Player.Inventory[target] = buffer;
                RenderFunctions.UpdateInventoryUI(Player);
                RenderFunctions.UpdateCharacterUI(Player);
            }
            else if (Player.Inventory[target].Type == "armor")
            {
                if (Player.Armor != MakeShiftDataBases.Items[201])
                {
                    buffer = Player.Armor;
                    Player.Armor = Player.Inventory[target];
                    Player.Inventory[target] = buffer;
                    RenderFunctions.UpdateInventoryUI(Player);
                    RenderFunctions.UpdateSliderUI(Player);
                }
                else
                {
                    Player.Armor = Player.Inventory[target];
                    Player.Inventory[target] = new Item(MakeShiftDataBases.Items[0]);
                    RenderFunctions.UpdateInventoryUI(Player);
                    RenderFunctions.UpdateSliderUI(Player);
                }
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
                if (MakeShiftDataBases.Enemies.Contains(Map[newY, newX]))
                {
                    Battle(newY, newX);
                }
                return true;
            }

            if (Map[newY, newX] == "<")
            {
                Player.level++;
                Console.Clear();
                InitMap();
                InitEntities();
                RenderFunctions.RenderMap(Map);
                RenderFunctions.RenderUI();
                RenderFunctions.UpdateSliderUI(Player);
                RenderFunctions.UpdateInventoryUI(Player);
                RenderFunctions.UpdateCharacterUI(Player);
                RenderFunctions.UpdateFooter(Player);
                RenderFunctions.UpdateLogUI();
            }
            else if (Map[newY, newX] == "/")
            {
                List<Item> availableItems = new List<Item>();
                foreach (var item in MakeShiftDataBases.Items)
                {
                    if(item.Value.level != "-")
                    {
                        string[] levels = item.Value.level.Split("-");
                        if (Convert.ToInt32(levels[0]) <= Player.level && Player.level <+ Convert.ToInt32(levels[1]))
                        {
                            availableItems.Add(item.Value);
                        }
                    }
                }

                Random rnd = new Random();
                for (int i = 1; i < 10; i++)
                {
                    if (Player.Inventory[i].Type == "empty")
                    {
                        Player.Inventory[i] = new Item(availableItems[rnd.Next(availableItems.Count)]);
                        RenderFunctions.UpdateInventoryUI(Player);
                        RenderFunctions.UpdateCharacterUI(Player);
                        break;
                    }
                }
            }

            return false;
        }

        static void Battle(int enemY, int enemX)
        {
            Random rnd = new Random();
            for (int i = 0; i < Entities.Length; i++)
            {
                if (Entities[i].Y == enemY)
                {
                    if (Entities[i].X == enemX)
                    {
                        int damage = 0;
                        if (rnd.Next(101) > Entities[i].Dodge)
                        {
                            damage = rnd.Next(Player.Inventory[0].DmgMin + Player.Damage,
                                Player.Inventory[0].DmgMax + Player.Damage + 1);
                            Entities[i].HP -= damage;
                            RenderFunctions.UpdateLogUI($"{damage} Damage Was Dealt To {Entities[i].Name} By Player",
                                2);
                        }
                        else
                        {
                            RenderFunctions.UpdateLogUI($"Player Missed",
                                5);
                        }

                        if (Entities[i].HP > 0)
                        {
                            if (rnd.Next(101) > Player.Dodge)
                            {
                                damage = rnd.Next(Entities[i].WeaponItem.DmgMin + Entities[i].Damage,
                                    Entities[i].WeaponItem.DmgMax + Entities[i].Damage + 1);
                                if(Player.Armor.ArmorAm < 0 || Player.Armor.Name == MakeShiftDataBases.Items[201].Name)
                                {
                                    Player.HP -= damage;
                                    if (Player.HP < 0)
                                        Player.HP = 0;
                                }
                                else
                                {
                                    Player.Armor.ArmorAm -= damage;
                                    if (Player.Armor.ArmorAm < 0)
                                    {
                                        Player.Armor.ArmorAm = 0;
                                        Player.Armor.ArmorCooldown = -5;
                                    }
                                }
                                RenderFunctions.UpdateLogUI(
                                    $"{damage} Damage Was Dealt To Player By {Entities[i].Name}", 2);
                                RenderFunctions.UpdateSliderUI(Player);
                            }
                            else
                            {
                                RenderFunctions.UpdateLogUI($"{Entities[i].Name} Missed",
                                    5);
                            }
                        }
                        else
                        {
                            Player.XP += GetEnemy(enemY, enemX).XP;
                            if (Player.XP >= Player.LimitXP)
                            {
                                Player.PlayerLevel++;
                                Player.XP -= Player.LimitXP;
                                Player.UpdateCharacter();
                            }

                            Player.Gold += Entities[i].DropGold;
                            RenderFunctions.UpdateSliderUI(Player);
                            RenderFunctions.UpdateFooter(Player);
                            RenderFunctions.UpdateLogUI($"{Entities[i].Name} Was Killed", 3);
                            RenderFunctions.UpdateLogUI($"Gained {Entities[i].DropGold} Gold And {Entities[i].XP} Experience", 6);
                            Map[enemY, enemX] = ".";
                            RenderFunctions.ReplaceExactElement(enemY, enemX, Map);
                        }
                    }
                }
            }
        }

        static void InitEntities()
        {
            StringBuilder sb = new StringBuilder();
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
            for (int i = 0; i < Entities.Length; i++)
            {
                Entities[i] = new Entity(availableEntities[rnd.Next(availableEntities.Count)]); 
                int y = rnd.Next(30);
                int x = rnd.Next(30);
                Entities[i].X = x;
                Entities[i].Y = y;
                Map[y, x] = Entities[i].Symbol;
            }
        }

        static Entity GetEnemy(int y, int x)
        {
            foreach (var entity in Entities)
            {
                if (entity.Y == y)
                {
                    if (entity.X == x)
                    {
                        return entity;
                    }
                }
            }

            return null;
        }
    }
}