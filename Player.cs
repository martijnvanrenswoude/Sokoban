﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : MovableObject
    {
        public Player(char type)
        {
            ObjectType = type;
        }

        public override void move(String direction)
        {
            
        }
    }
}