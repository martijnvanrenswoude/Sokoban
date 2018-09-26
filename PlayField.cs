using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayField
    {
        public string[] Maze { get; set; }
        public Ground[,] ground;

        public PlayField(string[] maze)
        {
            Maze = maze;
        }


        private void setLocations(int height, int width, char[][] loc)
        {
            
        }

        private void initField()
        {

            foreach (string temp in Maze)
            {

               
                //if (square == '#')
                //{
                //    //krijgt in constructor nog character mee, voor de zekerheid
                //    Wall wall = new Wall('#');
                //}
                //else if (square == '.')
                //{
                //    Floor floor = new Floor('.');
                //}
                //else if (square == 'x')
                //{
                //    Destination destination = new Destination('x');
                //}
                //else if (square == 'o')
                //{
                //    Chest chest = new Chest('o');
                //}
                //else if (square == '@')
                //{
                //    Player player = new Player('@');
                //}


            for(int i = 0; i < Maze.Length; i++)
                {
                    for(int j = 0; j < Maze[j].Length; j++)
                    {
                        if(ground == null)
                        {
                            ground = new Ground[Maze.Length, Maze[i].Length];
                        }
                        char tempCharacter = Maze[i][j];

                        Ground tempGround = ground[Maze.Length, Maze[i].Length] = new Ground();
                        tempGround.GameObject = new GameObject 
                    }
                }
            }
        }


    }
}