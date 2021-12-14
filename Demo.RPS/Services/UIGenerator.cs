using Demo.RPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.RPS.Services
{
    /// <summary>
    /// Service Class in charge to display Menus and Messages 
    /// </summary>
    public class UIGenerator
    {
        /// <summary>
        /// Get Main menu option
        /// </summary>
        /// <returns>Menu option number</returns>
        public static int GetMenuOption()
        {
            int menuOption = int.MaxValue;
            do
            {
                //Game Header
                Console.Clear();
                Console.WriteLine("\t\t\t----------------------------------");
                Console.WriteLine("\t\t\t----- Rock Paper Scissors --------");
                Console.WriteLine("\t\t\t----------------------------------");
                //Menu
                Console.WriteLine("\t\t1. Single Player");
                Console.WriteLine("\t\t2. Multiplayer");
                Console.WriteLine("\t\t3. Add Weapons");
                Console.WriteLine("\t\t4. Enable Computer Random Play");
                Console.WriteLine("\n\n\tExit with 0");
                string option = Console.ReadLine();
                Console.WriteLine($"Option Selected: {option}");
                if (!int.TryParse(option, out menuOption) || menuOption < 0)
                {
                    menuOption = int.MaxValue;
                }

            } while (menuOption == int.MaxValue);
            return menuOption;
        }

        public static void ShowComputerWeaponOption(int round, List<Weapon> weapons, int computerWeapon, int player,
            int p1Score, int p2Score)
        {
            //Game Header
            Console.Clear();
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\t----- Rock Paper Scissors --------");
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\t-----  Score: P1:{p1Score} P2:{p2Score}  -------");
            Console.WriteLine($"\t\t\t+ Round {round}");
            Console.WriteLine($"\t\t\t+ Player{player} turn");
            Console.WriteLine($"\t\t\t----------------------------------");
            //Menu
            foreach (var weapon in weapons)
            {
                Console.WriteLine($"\t\t{weapon.Id}. {weapon.Name}");
            }
            Console.WriteLine($"Option Selected: {computerWeapon}");
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\tPress enter to continue");
            Console.ReadLine();
        }

        public static int GetWeaponOption(int round, List<Weapon> weapons, int player, int p1Score, int p2Score)
        {
            int chosenOption = int.MaxValue;
            do
            {
                //Game Header
                Console.Clear();
                Console.WriteLine($"\t\t\t----------------------------------");
                Console.WriteLine($"\t\t\t----- Rock Paper Scissors --------");
                Console.WriteLine($"\t\t\t----------------------------------");
                Console.WriteLine($"\t\t\t-----  Score: P1:{p1Score} P2:{p2Score}  -------");
                Console.WriteLine($"\t\t\t+ Round {round}");
                Console.WriteLine($"\t\t\t+ Player{player} turn");
                Console.WriteLine($"\t\t\t----------------------------------");
                //Menu
                foreach (var weapon in weapons)
                {
                    Console.WriteLine($"\t\t{weapon.Id}. {weapon.Name}");
                }
                string option = Console.ReadLine();
                Console.WriteLine($"Option Selected: {option}");
                if (!int.TryParse(option, out chosenOption)
                    || chosenOption < 0
                    || weapons.Where(o => o.Id == chosenOption).FirstOrDefault() == null)
                {
                    chosenOption = int.MaxValue;
                }

            } while (chosenOption == int.MaxValue);
            return chosenOption;
        }
        public static void ShowStageWinner(int playerNumber, int round, int p1Score, int p2Score)
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\t----- Rock Paper Scissors --------");
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\t-----  Score:  P1: {p1Score} P2: {p2Score}  -------");
            Console.WriteLine($"\t\t\t+ Round {round}");
            if (playerNumber == 0)
            {
                Console.WriteLine($"\t\t\t+ DRAW, restarting round!!!");
            }
            else
            {
                Console.WriteLine($"\t\t\t+ Player{playerNumber} WINS!!!");
            }
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\tPress enter to continue");
            Console.ReadLine();
        }
        public static void ShowFinalWinner(int p1Score, int p2Score)
        {
            int playerNumber = 1;
            if (p2Score > p1Score)
            {
                playerNumber = 2;
            }

            Console.Clear();
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\t----- Rock Paper Scissors --------");
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\t----- FINAL Score: P1: {p1Score} P2: {p2Score} -------");
            Console.WriteLine($"\t\t\t+ Player{playerNumber} WINS!!!");
            Console.WriteLine($"\t\t\t----------------------------------");
            Console.WriteLine($"\t\t\tPress enter to continue");
            Console.ReadLine();
        }
    }
}
