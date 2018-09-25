using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Chest : MovableObject
    {
        public bool IsOnDestination { get; set; }

        public Chest(char type)
        {
            ObjectType = type;
        }
        public override void move()
        {
            throw new NotImplementedException();
        }

        public void changeObjectChar()
        {
            if (IsOnDestination)
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