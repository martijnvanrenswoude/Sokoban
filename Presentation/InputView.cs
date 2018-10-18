using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class InputView
    {
        public ConsoleKey readInput()
        {
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.S )
            {
                System.Environment.Exit(1);
            }
            return input;
        }

        public int ReadPlayMove()
        {
            ConsoleKey input = readInput();
            switch (input)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
                case ConsoleKey.D4:
                    return 4;
                case ConsoleKey.D5:
                    return 5;
                default:
                    return -1;
            }
        }
    }
}
