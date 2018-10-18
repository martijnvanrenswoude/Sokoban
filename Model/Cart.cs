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

        public override void move()
        {
            Track currentTrack = (Track)Vierkant.fieldObject;
            if (currentTrack.Next != null)
            {
                currentTrack.Next.GameObject = this;
                currentTrack.GameObject = null;
                Vierkant = currentTrack.Next.Square;
                HasMoved = true;
            }
            if(currentTrack.Next == null && currentTrack is StandardTrack)
            {
                currentTrack.GameObject = null;
                HasMoved = true;
            }
            if((currentTrack.Next.GameObject != null && currentTrack is CollectionTrack)){
                return;
            }
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
