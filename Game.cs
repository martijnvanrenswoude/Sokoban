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

                while (hasWon()) // make this !hasWon \\
                {
                    doTurn();
                }
                outputView.showWonMessage();
            }
        }

        private bool hasWon()
        {
            
            return true;

        }

        private void doTurn()
        {
            outputView.showLevel(playField.First);
            outputView.showPlayOptions();
            doAction(inputView.ReadPlayMove());
        }

        private bool doAction(String action)
        {
            if (action.Equals(""))
            {
                return false;
            }
            Console.WriteLine("Moves are not implemented yet");
            return true;
            
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