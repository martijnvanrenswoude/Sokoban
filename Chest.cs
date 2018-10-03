using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Chest : MovableObject
    {

        private Floor floor;
        public bool IsOnDestination { get; set; }

        public Chest(char type, Floor floor)
        {
            ObjectType = type;
            this.floor = floor;
        }
        public override void move(String direction)
        {

            switch (direction)
            {
                case "links":

                    if (floor.West == null || !(floor.West.getGameObjectType().Equals('#')))
                    {
                        swap(direction);

                    }
                    break;
                case "rechts":
                    if (floor.East == null || !(floor.East.getGameObjectType().Equals('#')))
                    {
                        swap(direction);

                    }
                    break;

                case "omhoog":
                    if (floor.North == null || !(floor.North.getGameObjectType().Equals('#')))
                    {
                        swap(direction);

                    }
                    break;

                case "omlaag":
                    if (floor.South == null || !(floor.South.getGameObjectType().Equals('#')))
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
        public void changeObjectChar()
        {
            if (!IsOnDestination)
            {
                ObjectType = 'o';
            }
            else
            {
                ObjectType = '0';
            }
        }
    }
}