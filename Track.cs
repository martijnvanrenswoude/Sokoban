using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    abstract class Track : FieldObject
    {
        public enum Direction {N, S, E, W }
        public Direction direction { get; set; }
        public GameObject gameObject { get; set; }
        public Track Next { get; set; }
        

    }
}
