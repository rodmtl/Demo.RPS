using Demo.RPS.Models;
using System.Collections.Generic;


namespace Demo.RPS.Services
{
    /// <summary>
    /// Service to configure the inital gameplay modes
    /// </summary>
    public class GameConfiguration
    {
        public static void LoadGame(ref Player player1, ref List<Weapon> weapons)
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
    }
}