using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Wall: UnmovableObject
    {
        public Wall(char type)
        {
            ObjectType = type;
        }
    }
}