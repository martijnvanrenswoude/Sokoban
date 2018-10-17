using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class CollectionTrack : Track
    {
        public CollectionTrack(char value, Square square, Direction direction)
        {
            ObjectType = value;
            Square = square;
        }
    }
}
