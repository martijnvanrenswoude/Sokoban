using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class SwitchTrack : Track
    {

        public SwitchTrack(char value, Square square)
        {
            ObjectType = value;
            Square = square;
        }
    }
}
