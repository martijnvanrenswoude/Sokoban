﻿using System;
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

        public int ShedInterval { get; set; }
        public int TimeTillTick { get; set; }
        public int SpawnInterval {get;set;}
        private InputView input { get; set; }
        private OutputView output { get; set; }
        public PlayField playField { get; set; }
        public FieldData fieldData { get; set; }

        public Game()
        {
            //vars
            ShedInterval = 7000;
            TickDuration = 5000;
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
            CartSpawn =     new Thread(new ThreadStart(SpawnTimer));            
        }
        public void start()
        {
            //output
            output.showTutuorial();
            output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick);
            //thread startss
            ViewRefresh.Start();
            GameTick.Start();
            Timer.Start();
            CartSpawn.Start();            
        }

        private void SpawnTimer()
        {
            Random r = new Random();
            Shed s;
            while (true)
            {
                Thread.Sleep(ShedInterval);
                s = (Shed)playField.Sheds[r.Next(3)];
                s.createCart();
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
                output.showLevel(playField.First, fieldData.numberOfRows(), fieldData.numberOfColumns(), Score, TimeTillTick/1000);
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
                if (TimeTillTick - 100 <= 0)
                {
                    TimeTillTick = TickDuration;
                }
                TimeTillTick -= 100;
            }
        }
    }
}
