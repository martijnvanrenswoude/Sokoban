using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Water : FieldObject
    {

        public bool CanGenerateShip { get; set; }
        public Water(char value, Square square,bool ship)
        {
            CanGenerateShip = ship;
            ObjectType = value;
            Square = square;
        }

        public void generateShip()
        {   
            if (CanGenerateShip && this.GameObject != null)
            {
                Ship ship = new Ship(Square);
                this.GameObject = ship;
            }
        }
    }
}
