using System;
using ClockApp.Events;

namespace ClockApp.Views
{
    class DisplayClock
    {
        public void Subscribe(Clock clock)
        {
            clock.clockTick += new Clock.clockTickHandler(ShowClock);
        }

        public void ShowClock(object clock, TimeInfoEventArgs timeInfo)
        {
            Console.WriteLine("Current Time: " + timeInfo.hour + ":" + timeInfo.minute + ":" + timeInfo.second);
        }
    }
}