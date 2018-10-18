using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class SwitchTrack : Track
    {
        public StandardTrack TrackOne { get; set; }
        public StandardTrack TrackTwo { get; set; }

        public SwitchTrack(char value, Square square, Direction direction)
        {
            ObjectType = value;
            Square = square;
            this.direction = direction;
        }

        public void doSwitching()
        {
            switch (direction)
            {
                case Direction.N:
                    doSwitchNorth();
                    break;

                case Direction.E:
                    doSwitchEast();
                    break;

            }
            
        }

        private void doSwitchNorth()
        {
            if(Next == TrackOne)
            {
                Next = TrackTwo;
            }
            else
            {
                Next = TrackTwo;
            }
        }

        private void doSwitchEast()
        {
            StandardTrack tempTrackOne = (StandardTrack)Square.North.fieldObject;
            StandardTrack tempTrackTwo = (StandardTrack)Square.South.fieldObject;
            if (tempTrackOne.Next == this)
            {
                tempTrackOne.Next = null;
                tempTrackTwo.Next = this;
            }
            else if (tempTrackTwo.Next == this)
            {
                tempTrackOne.Next = this;
                tempTrackTwo.Next = null;
            }
        }

    }
}
