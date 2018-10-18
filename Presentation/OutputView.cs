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
            Console.WriteLine("|    >  : baanvak met richting|                     |");
            Console.WriteLine("|    /  : wissel omhoog       |                     |");
            Console.WriteLine("|    \\  : wissel omlaag       |                     |");
            Console.WriteLine("|    _  : rangeerterrein      |                     |");
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
            Console.ReadKey();
            Console.Clear();

        }

        private char setSymbol(Square c)
        {
            if(c.fieldObject == null)
            {
                return ' ';
            }
            if(c.fieldObject.GameObject != null)
            {
                if(c.fieldObject.GameObject is Ship)
                {
                    Ship temp = (Ship)c.fieldObject.GameObject;
                    char[] t = temp.content.ToString().ToCharArray();
                    return t[0];
                    
                }
                if (c.fieldObject.GameObject is Cart)
                {
                    Cart temp = (Cart)c.fieldObject.GameObject;
                    if (temp.IsFull)
                    {
                        return '0';
                    }
                    return 'O';
                }
            }
            else
            {
                switch (c.fieldObject.ObjectType)
                {
                    case '1':
                        return '~';
                    case '3':
                        return 'K';
                    case '4':
                        return '^';
                    case '5':
                        return '>';
                    case '6':
                        return 'v';
                    case '7':
                        return '<';
                    case '8':
                        return '/';
                    case '9':
                        return '\\';

                    case 'a':
                        return '_';
                    case 'b':
                        return '#';
                  
                }
            }
            return 'X';
        }
        private void showMap(Square first, int rows,int columns)
        {
            Square holder = first;
            Square temp = first;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {                   
                    Console.Write(setSymbol(temp));
                    temp = temp.East;
                }
                Console.WriteLine();
                temp = holder.South;
                holder = holder.South;
            }
        }

        public void showLevel(Square first, int rows, int columns, int score, int time)
        {
            Console.Clear();
            Console.WriteLine("Score: " + score + " || Time: " + time);
            showMap(first, rows, columns);
        }
    }
}
