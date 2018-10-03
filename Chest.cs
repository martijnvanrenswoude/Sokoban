using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Chest : MovableObject
    {
        public bool IsOnDestination { get; set; }

        public Chest(char type)
        {
            ObjectType = type;
        }
        public override void move(String direction)
        {
            //In deze methode wordt een soort van swap uitgevoerd met de gekozen richting van de speler.
            throw new NotImplementedException();
        }
        public override void swap(string direction)
        {
            throw new NotImplementedException();
        }
        public void changeObjectChar()
        {
            if (!IsOnDestination)
            {
                ObjectType = 'o';
            }
            else
            {
                ObjectType = '0';
            }
        }
    }
}