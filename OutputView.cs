using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class OutputView
    {

        public void showTutuorial()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("| Welkom bij Sokoban                                |");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| betekenis van de symbolen   |  doel van het spel  |");
            Console.WriteLine("| spatie : outerspace         |                     |");
            Console.WriteLine("|      # : muur               |  duw met de truck   |");
            Console.WriteLine("|      . : vloer              |  de krat(ten)       |");
            Console.WriteLine("|      o : krat               |  naar de bestemming |");
            Console.WriteLine("|      0 : krat op bestemming |                     |");
            Console.WriteLine("|      x : bestemming         |                     |");
            Console.WriteLine("|      @ : truck              |                     |");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("");
        }

        public void showLevelPicker()
        {
            Console.WriteLine("> Kies een doolhof (1-4), s = stop");
        }
    }
}