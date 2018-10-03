using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Game
    {
        //vars
        InputView inputView;
        OutputView outputView;
        Parser parser;
        PlayField playField;

        //constructor
        public Game()
        {
            inputView = new InputView();
            outputView = new OutputView();
            Parser parser;
        }

        public void start()
        {
            //introduction
            outputView.showTutuorial();
            while (true)
            {
                outputView.showLevelPicker();
                parser = new Parser(chooseLevel());
                playField = new PlayField(parser);

                while (!hasWon(playField.First,parser.getNumberOfRows(),parser.getNumberColumn())) 
                {
                    doTurn();
                }
                outputView.showWonMessage();
            }
        }

        private bool hasWon(Floor first,int rows,int columns)
        {
            Chest c;
            Floor holder = first;
            Floor temp = first;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(temp.GameObject is Chest)
                    {
                        c = (Chest)temp.GameObject;
                        if (!c.IsOnDestination)
                        {
                            return false;
                        }
                    }
                    temp = temp.East;
                }
                temp = holder.South;
                holder = holder.South;
            }
            return true;
        }

        private void doTurn()
        {
            outputView.showLevel(playField.First,parser.getNumberOfRows(), parser.getNumberColumn());
            outputView.showPlayOptions();
            doAction(inputView.ReadPlayMove());
        }

        private void doAction(String action)
        {
            playField.getPlayer().move(action);            
        }

        private int chooseLevel()
        {
            int level = inputView.ReadLevelInput();
            while (level == -1)
            {
                level = inputView.ReadLevelInput();
            }
            return level;
        }
    }
}