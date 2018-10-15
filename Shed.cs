using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Shed : FieldObject
    {
        public Shed(char value, Square square)
        {
            ObjectType = value;
        }

        private void createCarts()
        {

        }
    }
}
