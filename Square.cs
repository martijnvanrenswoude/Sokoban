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

        private void setContent(char value)
        {
            switch (value)
            {

                case 's':
                    fieldObject = new StandardTrack('s', this);
                    break;
                case 'l':
                    fieldObject = new Shed('l', this);
                    break;

                case 'o':
                    fieldObject = new Water('w', this);
                    break;

                case 'v':
                    fieldObject = new SwitchTrack('v', this);
                    break;

                case 'c':
                    fieldObject = new CollectionTrack('c', this);
                    break;
            }
        }
    }
}
