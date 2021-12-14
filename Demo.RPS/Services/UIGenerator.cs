using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.RPS.Services
{
    public static class UIGenerator
    {
        public static int GetMenuOption()
        {
            int menuOption = int.MaxValue;
            do
            {
                //Game Header
                Console.Clear();
                Console.WriteLine("\t----------------------------------");
                Console.WriteLine("\t----- Rock Paper Scissors --------");
                Console.WriteLine("\t----------------------------------");
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
    }
}
