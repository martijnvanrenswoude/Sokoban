using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Water : FieldObject
    {
        public Water(char value, Square square)
        {
            ObjectType = value;
            Square = square;
        }
    }
}
