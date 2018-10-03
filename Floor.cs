using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Ground
    {
        public GameObject GameObject { get; set; }

        public Boolean isDesitination { get; set; }
        public Ground North {get; set;}
        public Ground South {get; set;}
        public Ground West {get; set;}
        public Ground East {get; set;}

    }
}