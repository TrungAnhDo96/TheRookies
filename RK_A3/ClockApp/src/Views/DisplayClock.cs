using System;
using ClockApp.Events;

namespace ClockApp.Views
{
    class DisplayClock
    {
        public void Subscribe(Clock clock)
        {
            clock.clockTick += new Clock.clockTickHandler(showClock);
        }

        public void showClock(object clock, TimeInfoEventArgs timeInfo)
        {
            Console.WriteLine("Current Time: " + timeInfo.hour + ":" + timeInfo.minute + ":" + timeInfo.second);
        }
    }
}