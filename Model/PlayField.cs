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
        public SwitchTrack[] Switches { get; set; }

        public Shed[] Sheds { get; set; }
        public PlayField(FieldData fieldData)
        {
            this.fieldData = fieldData;
            makeItems();
            setAllRows();
            Switches = new SwitchTrack[5];
            setSwitches();
            Sheds = new Shed[3];
            setSheds();
            setNextTracks();
            setSwitchData();
            Track[] tracks = getAllTracks();
            
        }

        private void makeItems()
        {
            field = new Square[fieldData.numberOfItems()]; //maak de array
            for (int i = 0; i < field.Length; i++)         // vul de array met objecten
            {
                field[i] = new Square();
            }
            First = field[0];
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


        public Track[] getAllTracks()
        {
            List<Track> tracks = new List<Track>();
            int rows = fieldData.numberOfRows();
            int columns = fieldData.numberOfColumns();

            Square holder = First;
            Square temp = First;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // do shit voor elke square
                    if (temp.fieldObject != null && temp.fieldObject is Track)
                    {
                        //doe shit voor elke track
                        tracks.Add((Track)temp.fieldObject);
                    }
                    temp = temp.East;
                }
                temp = holder.South;
                holder = holder.South;
            }
            Track[] t = tracks.ToArray();
            return t;

        }
        private void setNextTracks()
        {
            Track[] tracks = getAllTracks();
            for (int i = 0; i < tracks.Length; i++)
            {
                if (tracks[i].direction == Track.Direction.N)
                {
                    if (tracks[i].Square.North != null && tracks[i].Square.North.fieldObject is Track)
                    {
                        tracks[i].Next = (Track)tracks[i].Square.North.fieldObject;
                    }
                }
                if (tracks[i].direction == Track.Direction.S)
                {
                    if (tracks[i].Square.South != null && tracks[i].Square.South.fieldObject is Track)
                    {
                        tracks[i].Next = (Track)tracks[i].Square.South.fieldObject;
                    }
                }
                if (tracks[i].direction == Track.Direction.E)
                {
                    if (tracks[i].Square.East != null && tracks[i].Square.East.fieldObject is Track)
                    {
                        tracks[i].Next = (Track)tracks[i].Square.East.fieldObject;
                    }
                }
                if (tracks[i].direction == Track.Direction.W)
                {
                    if (tracks[i].Square.West != null && tracks[i].Square.West.fieldObject is Track)
                    {
                        tracks[i].Next = (Track)tracks[i].Square.West.fieldObject;
                    }
                }


            }
        
    


            /*
            int rows = fieldData.numberOfRows()-2;
            int columns = fieldData.numberOfColumns();

            Square temp = First.South.South;
            Square holder = First.South.South;
            Track tempTrack = (Track)First.South.South.fieldObject;
            Track newTempTrack;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (tempTrack != null)
                    {
                        if (tempTrack.direction == Track.Direction.N)
                        {
                            if (temp.North != null && temp.North.fieldObject is Track)
                            {
                                newTempTrack = (Track)temp.North.fieldObject;
                                tempTrack.Next = newTempTrack;
                            }

                        }
                        if (tempTrack.direction == Track.Direction.S)
                        {
                            if (temp.South != null && temp.South.fieldObject is Track)
                            {
                                newTempTrack = (Track)temp.South.fieldObject;
                                tempTrack.Next = newTempTrack;
                            }

                        }
                        if (tempTrack.direction == Track.Direction.W)
                        {
                            if (temp.West != null && temp.West.fieldObject is Track)
                            {
                                newTempTrack = (Track)temp.West.fieldObject;
                                tempTrack.Next = newTempTrack;
                            }

                        }
                        if (tempTrack.direction == Track.Direction.E)
                        {
                            if (temp.East != null && temp.East.fieldObject is Track)
                            {
                                newTempTrack = (Track)temp.East.fieldObject;
                                tempTrack.Next = newTempTrack;
                            }

                        }
                    }
                    temp = temp.East;
                    if (temp !=  null)
                    {
                        tempTrack = (Track)temp.fieldObject;
                    }
                    else
                    {
                        tempTrack = null;
                    }
                }
                temp = holder.South;
                if (temp.fieldObject is Track)
                {
                    tempTrack = (Track)temp.fieldObject;
                }
                else
                {
                    tempTrack = null;
                }
                holder = holder.South;
            }*/
        }

        public void setSwitches()
        {
            int rows = fieldData.numberOfRows();
            int columns = fieldData.numberOfColumns();
            Square temp = First;
            Square holder = First;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (temp.fieldObject is SwitchTrack)
                    {
                        SwitchTrack tempObject = (SwitchTrack)temp.fieldObject;
                        addSwitch(tempObject);
                    }
                    temp = temp.East;
                }
                temp = holder.South;
                holder = holder.South;
            }
        }

        private void addSwitch(SwitchTrack wissel)
        {

            for (int i = 0; i < Switches.Length; i++)
            {
                if(Switches[i] == null)
                {
                    Switches[i] = wissel;
                    break;
                }
            }

        }

        public void setSheds()
        {
            int rows = fieldData.numberOfRows();
            int columns = fieldData.numberOfColumns();
            Square temp = First;
            Square holder = First;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (temp.fieldObject is Shed)
                    {
                        Shed tempObject = (Shed)temp.fieldObject;
                        addShed(tempObject);
                    }
                    temp = temp.East;
                }
                temp = holder.South;
                holder = holder.South;
            }
        }

        private void addShed(Shed schuur)
        {
            for (int i = 0; i < Sheds.Length; i++)
            {
                if (Sheds[i] == null)
                {
                    Sheds[i] = schuur;
                    break;
                }
            }
        }

        public Cart[] FindCarts()
        {
            int rows = fieldData.numberOfRows();
            int columns = fieldData.numberOfColumns();
            Square temp = First;
            Square holder = First;
            List<Cart> carts = new List<Cart>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(temp.fieldObject != null && temp.fieldObject.GameObject is Cart)
                    {
                        Cart tempObject = (Cart)temp.fieldObject.GameObject;
                        carts.Add(tempObject);
                    }              
                    temp = temp.East;
                }
                temp = holder.South;
                holder = holder.South;
            }
            Cart[] c = carts.ToArray();
            return c;
        }

        private void setSwitchData()
        {
            for (int i = 0; i < Switches.Length; i++)
            {
                if (Switches[i].direction == Track.Direction.N)
                {
                    Square tempSquare = Switches[i].Square;

                    if (tempSquare.North.fieldObject is Track && tempSquare.South.fieldObject is Track)
                    {
                        StandardTrack a = (StandardTrack)tempSquare.North.fieldObject;
                        StandardTrack b = (StandardTrack)tempSquare.South.fieldObject;
                        Switches[i].TrackOne = a;
                        Switches[i].TrackTwo = b;
                        Switches[i].Next = a;
                    }

                }
                else if (Switches[i].direction == Track.Direction.E)
                {
                    Square tempSquare = Switches[i].Square;
                    if (tempSquare.North.fieldObject is Track && tempSquare.South.fieldObject is Track)
                    {
                        StandardTrack a = (StandardTrack)tempSquare.North.fieldObject;
                        StandardTrack b = (StandardTrack)tempSquare.South.fieldObject;
                        Switches[i].TrackOne = a;
                        Switches[i].TrackTwo = b;
                        b.Next = null;
                        a.Next = Switches[i];
                    }
                }
            }
        }
    }
}
