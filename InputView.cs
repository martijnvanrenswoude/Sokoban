using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class InputView
    {
        public int ReadLevelInput()
        {
            String input = readInput();
            int level = -1;
            try{
                level = int.Parse(input);
            }catch (Exception e)
            {
                Console.WriteLine("> Voer aub een getal in");
                return -1;
            }
            if (level > 0 && level <= 4)
            {
                return level;
            }
            else
            {
                Console.WriteLine("> kies aub een valide level");
            }
            return -1;
        }

        private string readInput()
        {
            String input = Console.ReadLine();
            if (input.Equals("s"))
            {
                //shutdown
                Console.WriteLine("shutdown is not implemmented yet");
                return "";
            }

            return input;
        }
    }
}