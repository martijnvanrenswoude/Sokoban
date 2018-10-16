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


        }

        public override void move()
        {
            Track tempTrack = (Track)Vierkant.fieldObject;
            while (tempTrack.Next != null)
            {
                if (tempTrack.Next is Track)
                {
                    tempTrack.Next.GameObject = this;
                    tempTrack.GameObject = null;
                }
            }
        }
    }
}
