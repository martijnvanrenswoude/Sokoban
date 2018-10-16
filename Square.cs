using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Square
    {
        public FieldObject fieldObject;
        public Square North { get; set; }
        public Square South { get; set; }
        public Square West { get; set; }
        public Square East { get; set; }

        public Square()
        {

        }

        public void setContent(char value)
        {
            switch (value)
            {
                // Track Creation
                case '4':
                    fieldObject = new StandardTrack('4', this, Track.Direction.N);
                    break;
                case '6':
                    fieldObject = new StandardTrack('6', this, Track.Direction.S);
                    break;
                case '5':
                    fieldObject = new StandardTrack('5', this, Track.Direction.E);
                    break;
                case '7':
                    fieldObject = new StandardTrack('7', this, Track.Direction.W);
                    break;
                case '3':
                    fieldObject = new StandardTrack('3', this, Track.Direction.W);

                    if(fieldObject is StandardTrack)
                    {
                        StandardTrack track = (StandardTrack)fieldObject;
                        track.IsDock = true;
                    }
                    break;

                case '8':
                    fieldObject = new SwitchTrack('8', this, Track.Direction.E);
                    break;
                case '9':
                    fieldObject = new SwitchTrack('9', this, Track.Direction.N);
                    break;

                case 'a':
                    fieldObject = new CollectionTrack('a', this, Track.Direction.W);
                    break;


                case 'b':
                    fieldObject = new Shed('b', this);
                    break;

                case '1':
                    fieldObject = new Water('1', this);
     
               break;  
            }
        }
    }
}
