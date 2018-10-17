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
        Thread SpawnCarts;
        private int cartInterval;
        public Shed(char value, Square square)
        {
            cartInterval = 7000;
            SpawnCarts = new Thread(new ThreadStart(SpawnTimer));
            SpawnCarts.Start();
            ObjectType = value;
            Square = square;
            
        }

        private void SpawnTimer()
        {
            Random r = new Random();
            while (true)
            {
                Thread.Sleep(cartInterval);
                Thread.Sleep(r.Next(cartInterval/10));
                createCarts();
                cartInterval -= 200;
            }
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
