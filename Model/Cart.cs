using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Cart : GameObject
    {
        public Cart(Square square)
        {
            Vierkant = square;
            IsFull = true;
            CanMove = true;

        }

        public override void move()
        {
            Track currentTrack = (Track)Vierkant.fieldObject;
            if (currentTrack.Next != null)
            {
                currentTrack.Next.GameObject = this;
                currentTrack.GameObject = null;
                
            }


            /*
            Track tempTrack = (Track)Vierkant.fieldObject;
            if (tempTrack.Next != null && !CheckCollision())
            {
                CanMove = true;
                if (tempTrack.Next is Track)
                {
                    tempTrack.Next.GameObject = this;
                    tempTrack.GameObject = null;
                    Vierkant = tempTrack.Square;
                }
            }
            else
            {
                CanMove = false;
            }*/
        }

        public bool CheckCollision()
        {
            Track tempTrack = (Track)Vierkant.fieldObject;
            if (tempTrack.Next.GameObject != null && !tempTrack.Next.GameObject.CanMove)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
