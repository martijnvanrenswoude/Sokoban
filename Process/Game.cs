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
        //threads
        private Thread GameTick;

        private Thread Timer;

        private Thread HandleInput;
        //game info vars
        public int Score { get; set; }
        public int TickDuration { get; set; }
        public int TimeTillTick { get; set; }
        //other classes
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
            HandleInput =   new Thread(new ThreadStart(handleInput));      
        }
        public void start()
        {
            //output
            output.showTutuorial();
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick);
            //threads start
            HandleInput.Start();
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
            playField.ship.move();
            if (playField.dock.TransferGold())
            {
                Score++;
            }
            if (playField.ship.isDone)
            {
                Score += 10;
            }
        }

        //thread methods
        private void handleInput()
        {
            while (true)
            {
                int move = input.ReadPlayMove();
                switch (move)
                {
                    case 1:
                        playField.Switches[move-1].doSwitching();
                        break;
                    case 2:
                        playField.Switches[move - 1].doSwitching();
                        break;
                    case 3:
                        playField.Switches[move - 1].doSwitching();
                        break;
                    case 4:
                        playField.Switches[move - 1].doSwitching();
                        break;
                    case 5:
                        playField.Switches[move - 1].doSwitching();
                        break;
                }

            }
        }
        private void TickTimer()
        {
            while(true)
            {
                Thread.Sleep(TickDuration*1000);
                doTick();
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
                output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick);
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
