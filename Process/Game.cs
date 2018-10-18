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
        public int TickNumber { get; set; }

        private bool hasWon;
        //other classes
        private InputView input { get; set; }
        private OutputView output { get; set; }
        public PlayField playField { get; set; }
        public FieldData fieldData { get; set; }

        public Game()
        {
            //vars
            TickDuration = 3000;
            TimeTillTick = TickDuration;
            TickNumber = 0;
            hasWon = false;
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
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick,TickNumber);
            //threads start
            HandleInput.Start();
            GameTick.Start();
            Timer.Start();

        }

        private void SpawnCart()
        {
            Random r = new Random();
            int CartFactor = r.Next(18);
            if(CartFactor <= 2)
            {
                Shed s = (Shed)playField.Sheds[CartFactor];
                s.createCart();
            }
            int ShipFactor = r.Next(25);
            ShipFactor = 13;
            if(ShipFactor == 13)
            {
                Water w = (Water)playField.First.South.fieldObject;
                w.generateShip();
            }

            
        }
               
        public void doTick()
        {
            moveAllCarts();
            SpawnCart();

            for (int i = 0; i < playField.Ships.Length; i++)
            {
                if (playField.Ships[i] != null)
                {
                    playField.Ships[i].move();

                    if (playField.dock.TransferGold())
                    {
                        Score++;
                    }
                    if (playField.Ships[i].isDone)
                    {
                        Score += 10;
                    }
                }
            }

            TickNumber++;
        }

        //thread methods
        private void handleInput()
        {
            while (true)
            {
                int move = input.ReadPlayMove();
                if (!hasWon)
                {
                    switch (move)
                    {
                        case 1:
                            playField.Switches[move - 1].doSwitching();
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
        }
        private void TickTimer()
        {
            int factor = 0;
            while(!hasWon)
            {
                Thread.Sleep(TickDuration-factor);
                doTick();
                if(factor <= TickDuration / 4)
                {
                    factor = 50 * Score;
                }                
            }            
        }

        private void timer()
        {
            while (!hasWon)
            {
                Thread.Sleep(1000);
                if (TimeTillTick <= 1000)
                {
                    TimeTillTick = TickDuration+1000;
                }
                TimeTillTick -= 1000;
                output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick, TickNumber);
            }
            output.endGameMessage(Score);
        }

        private void moveAllCarts()
        {
            List<Cart> carts = playField.FindCarts().ToList<Cart>();
            while (carts.Count > 0)
            {
                {
                    for (int i = 0; i < carts.Count; i++)
                    {
                        Track t = (Track)carts[i].Vierkant.fieldObject;
                        if (!carts[i].move())
                        {
                           endGame();
                        }
                        else
                        {
                            carts.Remove(carts[i]);
                        }
                    }
                }

            }
        }

        private void endGame()
        {
            hasWon = true;
            
        }
    }
}
