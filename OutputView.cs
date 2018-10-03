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
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("| Welkom bij Sokoban                                |");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| betekenis van de symbolen   |  doel van het spel  |");
            Console.WriteLine("| spatie : outerspace         |                     |");
            Console.WriteLine("|      █ : muur               |  duw met de truck   |");
            Console.WriteLine("|      . : vloer              |  de krat(ten)       |");
            Console.WriteLine("|      o : krat               |  naar de bestemming |");
            Console.WriteLine("|      0 : krat op bestemming |                     |");
            Console.WriteLine("|      x : bestemming         |                     |");
            Console.WriteLine("|      @ : truck              |                     |");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("| Controls                                          |");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| <s>      : stop het spel                          |");
            Console.WriteLine("| <omlaag> : verplaats de truck omlaag              |");
            Console.WriteLine("| <omhoog> : verplaats de truck omhoog              |");
            Console.WriteLine("| <links>  : verplaats de truck naar links          |");
            Console.WriteLine("| <richts> : verplaats de truck naar rechts         |");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| overige besturing wordt getoond tijdens het spel  |");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("");
        }
        


        public void showLevelPicker()
        {
            Console.WriteLine("> Kies een doolhof (1-4), s = stop");
        }

        public void showLevel(Floor[] floors,int rowLength)
        {
            char symbol = ' ';
            for (int i = 0; i < floors.Length; i++)
            {
                switch (floors[i].getGameObjectType())
                {
                    case '#':
                        symbol = '█';
                        break;
                    case '@':
                        symbol = '@';
                        break;
                    case 'o':
                        Chest c = (Chest) floors[i].GameObject;
                        if (c.IsOnDestination)
                        {
                            symbol = '0';
                        }
                        else
                        {
                            symbol = 'O';
                        }
                        break;
                    case '!':
                        if (floors[i].isDesitination)
                        {
                            symbol = 'x';
                        }
                        else
                        {
                            symbol = '.';
                        }
                        break;
                }
               
                //printss
            }
        }

        public void showPlayOptions()
        {
            Console.WriteLine("voer een actie in, of druk op <s> op te stoppen");
        }

        public void showWonMessage()
        {
            Console.WriteLine("U hebt gewonnen!");
        }
    }
}