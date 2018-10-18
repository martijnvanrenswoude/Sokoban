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
            this.direction = direction;
        }

        public void TransferGold()
        {
            Ship ship = (Ship)Square.North.fieldObject.GameObject;
            if (this.GameObject != null && ship != null)
            {
                this.GameObject.IsFull = false;
                ship.AddGold();
            }
        }
    }
}
