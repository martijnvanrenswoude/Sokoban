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
        public Thread SpawnCarts;
        private int cartInterval;
        public Shed(char value, Square square)
        {
            cartInterval = 7000;
            ObjectType = value;
            Square = square;
            SpawnCarts = new Thread(new ThreadStart(SpawnTimer))
        }


        private void createCarts()
        {
            GameObject cart = new Cart(Square.East);
            if(Square.East.fieldObject is Track)
            {
                Track d = (Track)Square.East.fieldObject;
                d.gameObject = cart;
            }
        }

    }
}
