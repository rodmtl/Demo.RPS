using Demo.RPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.RPS.Services
{
    public class GamePlay
    {
        public static int ComputeWinner(List<Weapon> weapons, int p1Choice, int p2Choice)
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

        public static void Battle(int computerBehavior, ref Player player1, ref Player player2,
            ref List<Weapon> weapons)
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
                    //Computer Random Choice
                    else
                    {
                        Random r = new Random();
                        p2Choice = r.Next(0, weapons.Count - 1);
                    }
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
    }
}
