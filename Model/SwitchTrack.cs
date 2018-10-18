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

        public void setObjectType()
        {
            if(ObjectType == '8'){
                if(TrackOne.Next == this)
                {
                    ObjectType = '9';
                }
            } else if(ObjectType == '9')
            {
                if(this.Next == TrackOne)
                {
                    ObjectType = '8';
                }
            }
        }

        private void toggleObjectType()
        {
            if(ObjectType == '8')
            {
                ObjectType = '9';
            }else if(ObjectType == '9')
            {
                ObjectType = '8';
            }
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
            toggleObjectType();
            
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
