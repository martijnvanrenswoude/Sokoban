using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class MovableObject : GameObject
    {


        public abstract void move(String direction);

        public abstract void swap(String direction);

    }
}