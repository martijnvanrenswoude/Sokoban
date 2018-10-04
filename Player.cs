using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : MovableObject
    {
        private Floor floor;
        public Player(char type, Floor floor)
        {
            ObjectType = type;
            this.floor = floor;
        }

        public override void move(String direction)
        {
            
            switch (direction)
            {
                case "links" :

                    if (floor.West.GameObject is Chest)
                    {
                        Chest c = (Chest)floor.West.GameObject;
                        c.move(direction);
                        swap(direction);
                    }

                    else if (floor.West == null || !(floor.West.getGameObjectType().Equals('#')))
                    {
                        swap(direction);

                    }
                    break;



                case "rechts":

                    if (floor.East.GameObject is Chest)
                    {
                        Chest c = (Chest)floor.West.GameObject;
                        c.move(direction);
                        swap(direction);
                    }

                    else if (floor.East == null || !(floor.East.getGameObjectType().Equals('#')))
                    {
                        swap(direction);
                    }
                    break;

                case "omhoog":

                    if (floor.North.GameObject is Chest)
                    {
                        Chest c = (Chest)floor.North.GameObject;
                        c.move(direction);
                        swap(direction);
                    }

                    else if (floor.North == null || !(floor.North.getGameObjectType().Equals('#')))
                    {
                        swap(direction);
                    }
                    break;

                case "omlaag":

                    if (floor.South.GameObject is Chest)
                    {
                        Chest c = (Chest)floor.South.GameObject;
                        c.move(direction);
                    }

                    else if (floor.South == null || !(floor.South.getGameObjectType().Equals('#')))
                    {
                        swap(direction);
                    }
                    break;
            }
        }

        public override void swap(string direction)
        {
            switch (direction)
            {
                case "links":
                    floor.West.GameObject = this;
                    floor.GameObject = null;
                    floor = floor.West;
                    break;
                case "rechts":
                    floor.East.GameObject = this;
                    floor.GameObject = null;
                    floor = floor.East;
                    break;
                case "omhoog":
                    floor.North.GameObject = this;
                    floor.GameObject = null;
                    floor = floor.North;
                    break;
                case "omlaag":
                    floor.South.GameObject = this;
                    floor.GameObject = null;
                    floor = floor.South;
                    break;
            }
        }


    }
}