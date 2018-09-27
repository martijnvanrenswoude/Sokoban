using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor : UnmovableObject
    {
        public Floor(char type)
        {
            ObjectType = type;
        }
    }
}