using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class StandardTrack : Track
    {
        public bool IsDock { get; set; }
        public StandardTrack(char value, Square square, Direction direction)
        {
            ObjectType = value;
            Square = square;
        }
    }
}
