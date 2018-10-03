using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sokoban
{
    public class Parser
    {
        public String[] maze;

        public Parser(int level)
        {
            maze = doParsing(level);
        }
        public string[] doParsing(int levelSelection)
        {           
           string filepath = @"C:\Users\Martijn\Documents\GitHub\Sokoban\Doolhof\doolhof" + levelSelection + ".txt";
           return File.ReadAllLines(filepath);
        }

        public int getNumberOfRows()
        {
            return maze.Length;
        }

        public int getColumn()
        {
            return maze[0].Length;
        }

    }
}