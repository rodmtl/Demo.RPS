using Demo.RPS.Models;
using Demo.RPS.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.RPS
{
    /// <summary>
    /// Rock paper scissors (RPS) - Console game
    /// Rodrigo Riveros - 2021
    /// </summary>
    class Program
    {
        private static Player player1 = new Player();
        private static Player player2;
        public static List<Weapon> weapons;

        static void Main(string[] args)
        {
            /// <summary>
            /// 0 - Beats Previous Selection, 1 - Random Option
            /// </summary>
            int computerBehavior = 0;
            try
            {                
                Game(computerBehavior);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tOoops. something went wrong.");
                Console.WriteLine($"\t\tDetails\n{ex}");
                throw;
            }
        }       

        private static void Game(int computerBehavior)
        {
            int gameplayOption = int.MaxValue;
            while (gameplayOption != 0)
            {
                GameConfiguration.LoadGame(ref player1, ref weapons);
                gameplayOption = UIGenerator.GetMenuOption();
                if (gameplayOption == 1)
                {
                    UIGenerator.ShowMessage("\t\tSingle Player Mode");
                    //Configure Computer Player
                    player2 = new Player() { Id = 2, Wins = 0, PlayerType = 1 };
                    GamePlay.Battle(computerBehavior, ref player1, ref player2, ref weapons);
                }
                else if (gameplayOption == 2)
                {
                    UIGenerator.ShowMessage("\t\tMulti Player Mode");
                    //Configure Computer Player
                    player2 = new Player() { Id = 2, Wins = 0, PlayerType = 0 };
                    GamePlay.Battle(computerBehavior, ref player1, ref player2, ref weapons);
                }
                else if (gameplayOption == 3)
                {
                    UIGenerator.ShowMessage("\t\tAdd Weapons");
                    //TODO: create method to Add weapon to the list
                }
                else if (gameplayOption == 3)
                {
                    UIGenerator.ShowMessage("\t\tEnable Computer Random Flag Activated!");
                    computerBehavior = 1;
                    Console.ReadLine();
                }
            }
        }     
    }
}
