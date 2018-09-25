using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sokoban
{
    public class Parser
    {

        public Parser()
        {

        }

        public void doParsing(int levelSelection)
        {
            string filepath = @"C:\Users\Martijn\Documents\GitHub\Sokoban\Doolhof\doolhof" + levelSelection + ".txt";
            char[] maze = File.ReadAllText(filepath).ToCharArray();

            foreach(char square in maze)
            {
                if (square == '#')
                {
                    //krijgt in constructor nog character mee, voor de zekerheid
                    Wall wall = new Wall();
                }
                else if (square == '.')
                {
                    Floor floor = new Floor();
                }
                else if (square == 'x')
                {
                    Destination destination = new Destination();
                }
                else if (square == 'o')
                {
                    Chest chest = new Chest();
                }
                else if(square == '@')
                {
                    Player player = new Player();
                }

            }
            
        }

        public char[][] getLocationArray()
        {
            return null;
        }

        public int getHeight()
        {
            return -1;
        }

        public int getWidht()
        {
            return -1;
        }

    }
}