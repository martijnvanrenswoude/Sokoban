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
            String input = Console.ReadLine();
            int level = -1;
            try{
                level = int.Parse(input);
            }catch (Exception e)
            {
                Console.WriteLine("Voer aub een getal in");
            }
            if (level > 0 && level <= 4)
            {
                return level;
            }
            else
            {
                Console.WriteLine("kies aub een valide level");
            }
        }
    }
}