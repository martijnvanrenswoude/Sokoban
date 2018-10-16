using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Game
    {
        public int Score { get; set; }

        public int Time { get; set; }
        private InputView input { get; set; }
        private OutputView output { get; set; }
        public PlayField playField { get; set; }
        public FieldData fieldData { get; set; }

        public Game()
        {
            input = new InputView();
            output = new OutputView();
            fieldData = new FieldData();
            playField = new PlayField(fieldData);
        }
        public void start()
        {
            output.showTutuorial();
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, Time);          
        }
    }
}
