using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class OutputView
    {
        public void showTutuorial()
        {
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("| Welkom bij GoudKoorts                             |");
            Console.WriteLine("| betekenis van de symbolen   |  doel van het spel  |");
            Console.WriteLine("|    ~  : water               |                     |");
            Console.WriteLine("|  <0>  : schip               |  behaal zo veel     |");
            Console.WriteLine("|  <8>  : vol schip           |  mogelijk punten    |");
            Console.WriteLine("|    K  : Kade                |  door het schip vol |");
            Console.WriteLine("|    o  : wagen               |  weg te sturen      |");
            Console.WriteLine("|    0  : wagen met inhoud    |                     |");
            Console.WriteLine("|    #  : loods               |                     |");
            Console.WriteLine("|    →  : baanvak met richting|                     |");
            Console.WriteLine("|    /  : wissel omhoog       |                     |");
            Console.WriteLine("|    \\  : wissel omlaag       |                     |");
            Console.WriteLine("|    <  : rangeerterrein      |                     |");
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("| Besturing                                         |");
            Console.WriteLine("| <s>   : stop het spel                             |");
            Console.WriteLine("| <1>   : zet de 1e wissel om                       |");
            Console.WriteLine("| <2>   : zet de 2e wissel om                       |");
            Console.WriteLine("| <3>   : zet de 3e wissel om                       |");
            Console.WriteLine("| <4>   : zet de 4e wissel om                       |");
            Console.WriteLine("| <5>   : zet de 5e wissel om                       |");
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
        }

        public void showLevel(Square first, int rows,int columns)
        {
            char symbol = ' ';
            Square holder = first;
            Square temp = first;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch (temp.fieldObject.ObjectType)
                    {
                        case 'w':
                            symbol = '~';
                            break;
                        case 'b':
                            symbol = '@';
                            break;
                        case 'd':
                            symbol = 'K';
                            break;
                        case 's':
                            
                            break;
                      /*  case 'v':
                            symbol = '';
                            break;
                        case 'l':
                            symbol = '';
                            break;
                        case 'c':
                            symbol = '';
                            break;
                        case ' ':
                            symbol = '';
                            break;*/
                    }
                    Console.Write(symbol);
                    temp = temp.East;
                }
                Console.WriteLine();
                temp = holder.South;
                holder = holder.South;
            }
        }
    }
}
