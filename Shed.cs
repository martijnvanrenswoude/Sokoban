using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Shed : FieldObject
    { 
        public Shed(char value, Square square)
        {
            ObjectType = value;
            Square = square;
        }


        public void createCart()
        {
            GameObject cart = new Cart(Square.East);
            if(Square.East.fieldObject is Track)
            {
                Track d = (Track)Square.East.fieldObject;
                d.GameObject = cart;
            }
        }
    }
}
