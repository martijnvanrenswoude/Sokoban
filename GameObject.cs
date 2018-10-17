using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
       abstract class GameObject
    {
        public Square Vierkant { get; set; }
        public bool isDone { get; set; }
        public bool IsFull { get; set; }

        public bool CanMove { get; set; }

        public GameObject()
        { 
        }

        public abstract void move();
    }
}
