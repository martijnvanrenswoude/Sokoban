﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Destination : Ground
    {

        public Destination(char type)
        {
            floorType = type;
        }
    }
}