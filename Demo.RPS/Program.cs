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
                GamePlay(computerBehavior);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tOoops. something went wrong.");
                Console.WriteLine($"\t\tDetails\n{ex}");
                throw;
            }
        }

        private static void LoadGame()
        {
            //Load Player 1
            player1.Id = 1;
            player1.Wins = 0;
            player1.PlayerType = 0;

            //Load Weapons
            if (weapons == null)
            {
                //Load Basic Weapons
                weapons = new List<Weapon>()
                {
                    new Weapon
                    {
                        Id = 0,
                        Name = "Rock",
                        Beats = new List<int> { 2 }
                    },
                    new Weapon
                    {
                        Id = 1,
                        Name = "Paper",
                        Beats = new List<int> { 0 }
                    },
                    new Weapon
                    {
                        Id = 2,
                        Name = "Scissors",
                        Beats = new List<int> { 1 }
                    }
                };

            }
        }

        private static void GamePlay(int computerBehavior)
        {
            int gameplayOption = int.MaxValue;
            while (gameplayOption != 0)
            {
                LoadGame();
                gameplayOption = UIGenerator.GetMenuOption();
                if (gameplayOption == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tSingle Player Mode");
                    //Configure Computer Player
                    player2 = new Player() { Id = 2, Wins = 0, PlayerType = 1 };
                    Battle(computerBehavior);
                }
                else if (gameplayOption == 2)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tMulti Player Mode");
                    //Configure Computer Player
                    player2 = new Player() { Id = 2, Wins = 0, PlayerType = 0 };
                    Battle(computerBehavior);
                }
                else if (gameplayOption == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tAdd Weapons");
                }
                else if (gameplayOption == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tEnable Random ComputerMode");
                }
            }
        }
        public static void Battle(int computerBehavior)
        {
            int round = 1;
            int computerPreviuosChoice = int.MinValue;
            int winner;
            do
            {
                //P1 choice: Show avalaible weapons & Get Selection
                int p1Choice = UIGenerator.GetWeaponOption(round, weapons, 1, player1.Wins, player2.Wins);

                //P2 choice
                int p2Choice = 0;
                //Check if human or computer
                if (player2.PlayerType == 0)
                {
                    //If human: Show avalaible weapons & Get Selection
                    p2Choice = UIGenerator.GetWeaponOption(round, weapons, 2, player1.Wins, player2.Wins);
                }
                //Computer player
                else
                {
                    //Previous choice
                    if (computerBehavior == 0)
                    {
                        if (computerPreviuosChoice == int.MinValue)
                        {
                            p2Choice = computerPreviuosChoice = 0;
                        }
                        else
                        {
                            foreach (var weapon in weapons)
                            {
                                if (weapon.Beats.Contains(computerPreviuosChoice))
                                {
                                    p2Choice = computerPreviuosChoice = weapon.Id;
                                    break;
                                }
                            }
                        }
                    }
                    //TODO: Random Choice
                    UIGenerator.ShowComputerWeaponOption(round, weapons, p2Choice, 2, player1.Wins, player2.Wins);
                }
                //Compute Winner:
                winner = ComputeWinner(weapons, p1Choice, p2Choice);
                if (winner == 0)
                {
                    round--;
                }
                else if (winner == 1)
                {
                    player1.Wins++;
                }
                else
                {
                    player2.Wins++;
                }
                UIGenerator.ShowStageWinner(winner, round, player1.Wins, player2.Wins);
                round++;
            } while (player1.Wins < 3 && player2.Wins < 3);

            UIGenerator.ShowFinalWinner(player1.Wins, player2.Wins);
        }

        private static int ComputeWinner(List<Weapon> weapons, int p1Choice, int p2Choice)
        {
            if (p1Choice == p2Choice)
            {
                return 0; //draw
            }
            else if (weapons.Where(w => w.Id == p1Choice).FirstOrDefault().Beats.Contains(p2Choice))
            {
                return 1; //p1 beats p2 choice
            }
            else
            {
                return 2; //p2 wins
            }
        }
    }
}
