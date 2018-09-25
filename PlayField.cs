using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayField
    {
        public char[] Maze { get; set; }

        public PlayField(char[] maze)
        {
            Maze = maze;
        }


        private void setLocations(int height, int width, char[][] loc)
        {
            
        }

        private void initializeGameObjects()
        {

            foreach (char square in Maze)
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
                else if (square == '@')
                {
                    Player player = new Player();
                }

            }
        }


    }
}