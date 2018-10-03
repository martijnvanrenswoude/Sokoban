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
            
        }

        public override void swap(string direction)
        {
            switch (direction)
            {
                //case "links": 

            }
        }


    }
}