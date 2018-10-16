using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Ship : GameObject
    {

        public Ship(Square square)
        {
            Vierkant = square;
        }


        public override void move()
        {
            FieldObject tempWater = (Water)Vierkant.fieldObject;
            //if (Vierkant.fieldObject is Water)
            //{
            //    tempWater = (Water)Vierkant.fieldObject;
            //}
            while (Vierkant.East != null)
            {
                if(Vierkant.East.fieldObject is Water)
                {
                    FieldObject w = (Water)Vierkant.East.fieldObject;
                    w.GameObject = this;
                    tempWater.GameObject = null;
                }
            }
            if(Vierkant.East == null)
            {
                isDone = true;
            }
        }
    }
}
