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
            Parser parser = new Parser();
        }

        public void start()
        {
            //introduction
            outputView.showTutuorial();
            while (true)
            {
                outputView.showLevelPicker();

                //playField = new PlayField(parser.doParsing(chooseLevel()));
                while (hasWon()) // make this !hasWon \\
                {
                    doTurn();
                }
                outputView.showWonMessage();
            }
        }

        private bool hasWon()
        {
            Ground[,] ground = new Ground[10, 10];//playField.getGround();\\
            for(int i = 0; i < ground.GetLength(0); i++)
            {
                for(int j =0; j < ground.GetLength(1); j++)
                {
                    if (ground[i,j].GetType() == typeof(Destination)) //what do we do with this
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        private void doTurn()
        {
            outputView.showLevel(null);
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