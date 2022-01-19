using System;
using System.Threading;

namespace ClockApp.Events
{
    public class Clock
    {
        private int _hour;
        private int _minute;
        private int _second;

        public delegate void clockTickHandler(object clock, TimeInfoEventArgs timeInfo);

        public event clockTickHandler clockTick;

        protected void OnTick(object clock, TimeInfoEventArgs timeInfo)
        {
            if (clockTick != null)
            {
                clockTick(clock, timeInfo);
            }
        }

        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                DateTime now = System.DateTime.Now;

                if (now.Second != _second)
                {
                    TimeInfoEventArgs timeInfo = new TimeInfoEventArgs(now.Hour, now.Minute, now.Second);
                    OnTick(this, timeInfo);
                }
            }
        }
    }
}