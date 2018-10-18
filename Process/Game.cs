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


        public int Score { get; set; }
        public int TickDuration { get; set; }

        public int TimeTillTick { get; set; }
        public int SpawnInterval {get;set;}
        private InputView input { get; set; }
        private OutputView output { get; set; }
        public PlayField playField { get; set; }
        public FieldData fieldData { get; set; }

        public Game()
        {
            //vars
            TickDuration = 5;
            TimeTillTick = TickDuration;
            //instances
            input =     new InputView();
            output =    new OutputView();
            fieldData = new FieldData();
            playField = new PlayField(fieldData);
            
            //threads
            GameTick =      new Thread(new ThreadStart(TickTimer));
            Timer =         new Thread(new ThreadStart(timer));
            ViewRefresh =   new Thread(new ThreadStart(Draw));      
        }
        public void start()
        {
            //output
            output.showTutuorial();
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick);
            //threads start
            ViewRefresh.Start();
            GameTick.Start();
            Timer.Start();
        }

        private void SpawnCart()
        {
            Random r = new Random();
            int factor = r.Next(6);
            if(factor <= 2)
            {
                Shed s = (Shed)playField.Sheds[r.Next(3)];
                s.createCart();
            }
        }



        public void doTick()
        {
            moveAllCarts();
            SpawnCart();
        }

        //thread methods
        private void Draw()
        {
            while (true)
            {
                Thread.Sleep(1000);
                output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick);
            }
        }

        private void TickTimer()
        {
            while(true)
            {
                Thread.Sleep(TickDuration*1000);
                doTick();
                Score++;
            }
        }

        private void timer()
        {
         //   TimeTillTick++;
            while (true)
            {
                Thread.Sleep(1000);
                if (TimeTillTick <= 1)
                {
                    TimeTillTick = TickDuration+1;
                }
                TimeTillTick -= 1;
            }
        }

        private void moveAllCarts()
        {
            FieldObject s;
            Cart[] c = playField.FindCarts();
            for(int i=0; i<c.Length; i++)
            {
                s = c[i].Vierkant.fieldObject;
                c[i].move();
            }
        }
    }
}
