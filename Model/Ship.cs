using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Ship : GameObject
    {
        public int content { get; set; }
        public Ship(Square square)
        {
            int content = 0;
            Vierkant = square;
            CanMove = true;
        }


        public override void move()
        {
            FieldObject tempWater = (Water)Vierkant.fieldObject;

            if (Vierkant.East != null && !isDocked())
            {
                if(Vierkant.East.fieldObject is Water)
                {
                    FieldObject w = (Water)Vierkant.East.fieldObject;
                    w.GameObject = this;
                    tempWater.GameObject = null;
                    Vierkant = Vierkant.East;
                }
            }
            if(Vierkant.East == null)
            {
                isDone = true;
            }
        }

        private bool isDocked()
        {
            StandardTrack tempTrack = (StandardTrack)Vierkant.South.fieldObject;
            if (tempTrack.IsDock && !IsFull) {
               return true;
            }
            else
            {
                return false;
            }
        }

        public void AddGold()
        {
            content++;
            if(content >= 8)
            {
                IsFull = true;
            }
             
        }
    }
}
