﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayField
    {
        public Parser Parser { get; private set; }
        public Floor[,] ground { get; set; }
        public Floor[] floor { get; set; }
        public Floor First { get; set; }

        public PlayField(Parser parser)
        {
            Parser = parser;
            First = new Floor();
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
                            ground = new Floor[Maze.Length, Maze[i].Length];
                        }
                        char tempCharacter = Maze[i][j];

                        Floor tempGround = ground[Maze.Length, Maze[i].Length] = new Floor();
                        tempGround.GameObject = createGameObject(tempCharacter);
                    }
                }
            }

        }

        public void initFieldPartTwo()
        {
            Floor tempHorizontal = First, tempVertical = First;



            for(int i = 0; i < Maze.Length; i++)
            {
                if(i > 0)
                {
                  
                }

                for(int j = 0; j < Maze[i].Length; j++)
                {
                    tempHorizontal.East = new Floor();
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

        private void makeItems()
        {
            floor = new Floor[parser.numberOfItems()]; //maak de array
            for (int i = 0; i < floor.Length; i++)         // vul de array met objecten
            {
                floor[i] = new Floor();
            }
        } // maak het item array




    }
}