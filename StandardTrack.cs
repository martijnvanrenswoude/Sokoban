using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class StandardTrack : Track
    {
        public StandardTrack(char value, Square square, Direction direction)
        {
            ObjectType = value;
            Square = square;
        }
    }
}
