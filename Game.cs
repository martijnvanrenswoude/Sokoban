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

        }

        public void start()
        {
            //introduction
            outputView.showTutuorial();
            outputView.showLevelPicker();
            //level selection
            int level = inputView.ReadLevelInput();
            while(level == -1)
            {
                level = inputView.ReadLevelInput();
            }
            //level is selected
            outputView.showLevel(null);
            outputView.showPlayOptions();

            /*
             * make the playfield
             * with parser and all
            */
        }
    }
}