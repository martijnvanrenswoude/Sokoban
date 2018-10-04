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
                    if (floor.West .GameObject is UnmovableObject)
                    {
                        break;
                    }
                    if (floor.West.GameObject is Chest && !floor.West.West.getGameObjectType().Equals('#'))
                    {
                        Chest c = (Chest)floor.West.GameObject;
                        c.move(direction);
                        swap(direction);
                    }

                    else if (floor.West.GameObject == null)
                    {
                        swap(direction);

                    }
                    break;



                case "rechts":

                    if (floor.East.GameObject is UnmovableObject)
                    {
                        break;
                    }

                    else if (floor.East.GameObject is Chest && !floor.East.East.getGameObjectType().Equals('#'))
                    {
                        Chest c = (Chest)floor.East.GameObject;
                        c.move(direction);
                        swap(direction);
                    }

                    else if (floor.East.GameObject == null)
                    {
                        swap(direction);
                    }
                    break;


                case "omhoog":

                    if(floor.North.GameObject is UnmovableObject)
                    {
                        break;
                    }
                    else if (floor.North.GameObject is Chest && !(floor.North.North.GameObject is UnmovableObject))
                    {
                        Chest c = (Chest)floor.North.GameObject;
                        c.move(direction);
                        swap(direction);
                        
                    }

                    else if (floor.North.GameObject == null)
                    {
                        swap(direction);
                    }
                    break;


                case "omlaag":

                    if (floor.South.GameObject is UnmovableObject)
                    {
                        break;
                    }

                    if (floor.South.GameObject is Chest && !floor.South.South.getGameObjectType().Equals('#'))
                    {
                        Chest c = (Chest)floor.South.GameObject;
                        c.move(direction);
                        swap(direction);
                    }

                    else if (floor.South.GameObject == null)
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