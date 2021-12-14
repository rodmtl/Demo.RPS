using Demo.RPS.Models;
using Demo.RPS.Services;
using System;
using System.Collections.Generic;

namespace Demo.RPS
{
    public class RPSController
    {
        public static void RPSGame(int computerBehavior, ref Player player1, ref Player player2, 
            ref List<Weapon> weapons)
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
                    Console.ReadLine();
                }
                else if (gameplayOption == 4)
                {
                    UIGenerator.ShowMessage("\tComputer Random Flag Activated!");
                    computerBehavior = 1;
                    Console.ReadLine();
                }
            }
        }
    }
}
