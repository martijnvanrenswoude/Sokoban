﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayField
    {
        public Parser Parser { get; private set; }
        public Floor[] floors { get; set; }
        public Floor First { get; set; }

        public PlayField(Parser parser)
        {
            Parser = parser;
            makeItems();
            setAllRows();
        } 


        private void makeItems()
        {
            floors = new Floor[Parser.getNumberOfItems()]; //maak de array
            for (int i = 0; i < floors.Length; i++)         // vul de array met objecten
            {
                floors[i] = new Floor();
            }
            First = floors[0];
        } // maak het item array

        private void setAllRows()
        {
            for (int i = 0; i < Parser.getNumberOfRows(); i++)
            {
                setRow(i, Parser.getDataWithIndex(i));
            }
        } //loop door alle rows heen en vul die in

        private void setRow(int rowNumber, String value)
        {
            int index; //maak een index aan voor de vertaling naar het array
            for (int i = 0; i < value.Length; i++) //de lengte van de String is de grootte van een rij
            {
                index = CalcultateIndex(i, rowNumber);  // vertaal de coordinaat naar een index
                floors[index].setContent(value[i]);      // set de juiste waarde in het item
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
                floors[index].North = floors[CalcultateIndex(column, row - 1)];
            }
            else
            {
                floors[index].North = null;
            }
        } //set de noord referentie van een Link

        private void setSouth(int row, int column, int index)
        {
            if (row < Parser.getNumberOfRows() - 1)
            {
                floors[index].South = floors[CalcultateIndex(column, row + 1)];
            }
            else
            {
                floors[index].South = null;
            }
        } //set de zuid referentie van een Link

        private void setWest(int row, int column, int index)
        {
            if (column > 0)
            {
                floors[index].West = floors[CalcultateIndex(column - 1, row)];
            }
            else
            {
                floors[index].West = null;
            }
        } //set de west referentie van een Link

        private void setEast(int row, int column, int index)
        {
            if (column < Parser.getNumberColumn() - 1)
            {
                floors[index].East = floors[CalcultateIndex(column + 1, row)];
            }
            else
            {
                floors[index].East = null;
            }
        } //set de oost referentie van een Link

        private int CalcultateIndex(int column, int row)
        {
            return column + (row * Parser.getNumberColumn());
        } //convert de kolom en de rij naar de index in het item array


        public Player getPlayer()
        {
            int rows = Parser.getNumberOfRows();
            int columns = Parser.getNumberColumn();
            Floor temp = First;
            Floor holder = First;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (temp.GameObject is Player)
                    {
                        return (Player) temp.GameObject;
                    }
                    temp = temp.East;
                }
                temp = holder.South;
                holder = holder.South;
            }
            return null;
        }
    }
}