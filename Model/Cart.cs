using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Cart : GameObject
    {
        public bool HasMoved{get;set;}
        public Cart(Square square)
        {
            Vierkant = square;
            IsFull = true;
            CanMove = true;
        }

        public override bool move()
        {
            Track currentTrack = (Track)Vierkant.fieldObject;
            if (CheckCollision())
            {
                return false;
            }

            if (currentTrack.Next != null && currentTrack.Next.GameObject == null)
            {
                currentTrack.Next.GameObject = this;
                currentTrack.GameObject = null;
                Vierkant = currentTrack.Next.Square;
                HasMoved = true;
            }
            if(currentTrack.Next == null && currentTrack is StandardTrack && currentTrack.direction == Track.Direction.W)
            {
                currentTrack.GameObject = null;
                HasMoved = true;
            }
            if(currentTrack.Next == null)
            {
                CanMove = false; 
            }
            return true;
        }

        public bool CheckCollision()
        {
            Track tempTrack = (Track)Vierkant.fieldObject;
            if (!(tempTrack is CollectionTrack) && tempTrack.Next != null &&  tempTrack.Next.GameObject != null &&  !tempTrack.Next.GameObject.CanMove)
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
