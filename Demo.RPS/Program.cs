using Demo.RPS.Services;
using System;

namespace Demo.RPS
{
    /// <summary>
    /// Rock paper scissors - console game
    /// Rodrigo Riveros - 2021
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GamePlay();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tOoops. something went wrong.");
                Console.WriteLine($"\t\tDetails\n{ex}");
                throw;
            }
        }

        private static void GamePlay()
        {

            int gameplayOption = UIGenerator.GetMenuOption();
            if (gameplayOption == 1)
            {
                Console.Clear();
                Console.WriteLine("\t\tSingle Player Mode");
            }
            else if (gameplayOption == 2)
            {
                Console.Clear();
                Console.WriteLine("\t\tMulti Player Mode");
            }
            else if(gameplayOption == 3)
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
        private int Battle()
        {
            int round = 1;
            int winner = 0;
            do
            {

                round++;
            } while (winner == 0 && round < 4);
            return winner;
        }
    }
}
