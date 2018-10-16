using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Game
    {
        private Thread GameTick;

        private Thread Seconds;

        public int Score { get; set; }

        public int TickDuration { get; set; }
        public int Time { get; set; }
        private InputView input { get; set; }
        private OutputView output { get; set; }
        public PlayField playField { get; set; }
        public FieldData fieldData { get; set; }

        public Game()
        {
            //threads
            GameTick = new Thread(new ThreadStart(doTick));
            GameTick.Start();
            Seconds = new Thread(new ThreadStart(timer));
            Seconds.Start();
            TickDuration = 5000;
            input = new InputView();
            output = new OutputView();
            fieldData = new FieldData();
            playField = new PlayField(fieldData);
        }
        public void start()
        {
            output.showTutuorial();
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, Time/100);          
        }

        public void doTick()
        {

        }

        public void timer()
        {
            Thread.Sleep(1000);
            if(Time == 0)
            {
                Time = TickDuration;
            }
            
        }
     
    }
}
