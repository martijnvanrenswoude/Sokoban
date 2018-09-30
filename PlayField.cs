using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayField
    {
        public string[] Maze { get; set; }
        public Ground[,] ground { get; set; }

        public Ground First { get; set; }

        public PlayField(string[] maze)
        {
            Maze = maze;
            First = new Ground();
        }


        private void setLocations(int height, int width, char[][] loc)
        {
            
        }

        private void initField()
        {

            foreach (string temp in Maze)
            {

                for (int i = 0; i < Maze.Length; i++)
                {
                    for (int j = 0; j < Maze[j].Length; j++)
                    {
                        if (ground == null)
                        {
                            ground = new Ground[Maze.Length, Maze[i].Length];
                        }
                        char tempCharacter = Maze[i][j];

                        Ground tempGround = ground[Maze.Length, Maze[i].Length] = new Ground();
                        tempGround.GameObject = createGameObject(tempCharacter);
                    }
                }
            }

        }

        public void initFieldPartTwo()
        {
            Ground tempHorizontal = First, tempVertical = First;



            for(int i = 0; i < Maze.Length; i++)
            {
                if(i > 0)
                {
                  
                }

                for(int j = 0; j < Maze[i].Length; j++)
                {
                    tempHorizontal.East = new Ground();
                    tempHorizontal.East.West = tempHorizontal;
                    tempHorizontal = tempHorizontal.East;


                }
            }

        }

        private GameObject createGameObject(char type)
        {
            switch (type)
            {
                case '#':
                    Wall wall = new Wall('#');
                    return wall;
                case '.':
                    Floor floor = new Floor('.');
                    return floor;
                case '@':
                    Player player = new Player('@');
                    return player;
                case 'o':
                    Chest chest = new Chest('o');
                    return chest;
                case 'x':
                    Destination destination = new Destination('x');
                    return destination;

                default:
                    return null;
            }

        }


    }
}