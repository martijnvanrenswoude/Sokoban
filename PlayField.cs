using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class PlayField
    {
        public FieldData fieldData;
        Square[] field;
        public Square First;


        public PlayField(FieldData fieldData)
        {
            this.fieldData = fieldData;
            field = new Square[fieldData.numberOfItems()];
        }

        private void makeItems()
        {
            field = new Square[fieldData.numberOfItems()]; //maak de array
            for (int i = 0; i < field.Length; i++)         // vul de array met objecten
            {
                field[i] = new Square();
            }
        } // maak het item array

        private void setAllRows()
        {
            for (int i = 0; i < fieldData.numberOfRows(); i++)
            {
                setRow(i, fieldData.getDataWithIndex(i));
            }
        } //loop door alle rows heen en vul die in
        private void setRow(int rowNumber, String value)
        {
            int index; //maak een index aan voor de vertaling naar het array
            for (int i = 0; i < value.Length; i++) //de lengte van de String is de grootte van een rij
            {
                index = CalcultateIndex(i, rowNumber);  // vertaal de coordinaat naar een index
                field[index].setContent(value[i]);      // set de juiste waarde in het item
                //vul de referenties\\
                //set north
                setNorth(rowNumber, i, index);
                //set south
                setSouth(rowNumber, i, index);
                //set west
                setWest(rowNumber, i, index);
                //set east
                setEast(rowNumber, i, index);
            }
        } //vul een rij in
        private void setNorth(int row, int column, int index)
        {
            if (row > 0)
            {
                field[index].North = field[CalcultateIndex(column, row - 1)];
            }
            else
            {
                field[index].North = null;
            }
        } //set de noord referentie van een Link
        private void setSouth(int row, int column, int index)
        {
            if (row < fieldData.numberOfRows() - 1)
            {
                field[index].South = field[CalcultateIndex(column, row + 1)];
            }
            else
            {
                field[index].South = null;
            }
        } //set de zuid referentie van een Link
        private void setWest(int row, int column, int index)
        {
            if (column > 0)
            {
                field[index].West = field[CalcultateIndex(column - 1, row)];
            }
            else
            {
                field[index].West = null;
            }
        } //set de west referentie van een Link
        private void setEast(int row, int column, int index)
        {
            if (column < fieldData.numberOfColumns() - 1)
            {
                field[index].East = field[CalcultateIndex(column + 1, row)];
            }
            else
            {
                field[index].East = null;
            }
        } //set de oost referentie van een Link
        private int CalcultateIndex(int column, int row)
        {
            return column + (row * fieldData.numberOfColumns());
        } //convert de kolom en de rij naar de index in het item array



    }
}
