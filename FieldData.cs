using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class FieldData
    {
        public String[] data = new String[] {       "111111111111",
                                                    "211111111111",
                                                    "777777777377",
                                                    "ccccccccccc4",
                                                    "b556c55556c4",
                                                    "ccc859ccc854",
                                                    "b554c56c54cc",
                                                    "cccccc859ccc",
                                                    "b555554c6556",
                                                    "aaaaaaaa7777" };
        // water           --> 1
        //ship             --> 2
        //dock             --> 3
        //track_north      --> 4
        //track_east       --> 5
        //track_south      --> 6
        //track_west       --> 7
        //switch_to_right  --> 8
        //switch_to_left   --> 9
        //collection_track --> a
        //shed             --> b
        //space            --> c
        
        public String[] getData()
        {
            return data;
        }

        public String getDataWithIndex(int i)
        {
            return data[i];
        }

        public char getDataWithIndexIndex(int i, int j)
        {
            return data[i][j];
        }


        public int numberOfItems()
        {
            return data[0].Length * data.Length;
        }

        public int numberOfRows()
        {
            return data.Length;
        }

        public int numberOfColumns()
        {
            return data[0].Length;
        }
    }
}
