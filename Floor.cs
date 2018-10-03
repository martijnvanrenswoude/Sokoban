using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor
    {
        public GameObject GameObject { get; set; }

        public Boolean isDesitination { get; set; }
        public Floor North {get; set;}
        public Floor South {get; set;}
        public Floor West {get; set;}
        public Floor East {get; set;}

    }
}