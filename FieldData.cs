using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class FieldData
    {
        public String[] data = new string[] { "1aeim", "2bfjn", "3cgko", " dhlp" };

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
