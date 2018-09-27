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

        public string[] doParsing(int levelSelection)
        {
           
            string filepath = @"C:\Users\Martijn\Documents\GitHub\Sokoban\Doolhof\doolhof" + levelSelection + ".txt";
            string[] maze = File.ReadAllLines(filepath);

            return maze;
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