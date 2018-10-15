using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class InputView
    {
        private string readInput()
        {
            String input = Console.ReadLine().ToLower();
            if (input.Equals("s"))
            {
                System.Environment.Exit(1);
            }
            return input;
        }

        public int ReadPlayMove()
        {
            String input = readInput();
            if (char.IsNumber(input[0]) && input[0] <= 5)
            {
                return int.Parse(Char.ToString(input[0]));
            }
            return -1;
        }
    }
}
