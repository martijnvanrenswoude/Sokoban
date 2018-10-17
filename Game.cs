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

        private Thread Timer;

        private Thread ViewRefresh;

        private Thread CartSpawn;
        public int Score { get; set; }

        public int TickDuration { get; set; }
        public int Time { get; set; }
        private InputView input { get; set; }
        private OutputView output { get; set; }
        public PlayField playField { get; set; }
        public FieldData fieldData { get; set; }

        public Game()
        {
            //vars
            TickDuration = 5000;
            Time = TickDuration;
            //instances
            input = new InputView();
            output = new OutputView();
            fieldData = new FieldData();
            playField = new PlayField(fieldData);
            //threads
            GameTick = new Thread(new ThreadStart(TickTimer));
            Timer = new Thread(new ThreadStart(timer));
            ViewRefresh = new Thread(new ThreadStart(Draw));

            
        }
        public void start()
        {
            //output
            output.showTutuorial();
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, Time);
            //thread startss
            ViewRefresh.Start();
            GameTick.Start();
            Timer.Start();
            
        }

        private void SpawnTimer()
        {
            Random r = new Random();
            while (true)
            {
                Thread.Sleep(cartInterval);
                Thread.Sleep(r.Next(cartInterval / 10));

                cartInterval -= 200;
            }
        }

        public void doTick()
        {
            
        }

        //thread methods
        private void Draw()
        {
            while (true)
            {
                Thread.Sleep(1000);
                output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, Time/1000);
            }
        }

        private void TickTimer()
        {
            while (true)
            {
                Thread.Sleep(TickDuration);
                TickDuration -= 50;
                Score++;
            }
        }

        private void timer()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (Time - 100 <= 0)
                {
                    Time = TickDuration;
                }
                Time -= 100;
            }
        }
    }
}
