using Demo.RPS.Models;
using System;
using System.Collections.Generic;


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
                RPSController.RPSGame(computerBehavior, ref player1, ref player2, ref weapons);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t\tOoops. something went wrong.");
                Console.WriteLine($"\t\tDetails\n{ex}");
                throw;
            }
        }       

           
    }
}
