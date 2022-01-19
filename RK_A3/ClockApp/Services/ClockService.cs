using System;

namespace ClockApp
{
    class ClockService
    {
        private Clock _clock;
        public ClockService()
        {
            _clock = new Clock(0, 0, 0);
            SetClock();
        }

        public ClockService(uint lapsed)
        {
            _clock = new Clock(0, 0, lapsed);
            SetClock();
        }

        public ClockService(uint hour, uint minute, uint second)
        {
            _clock = new Clock(hour, minute, second);
            SetClock();
        }

        // Convert lower lv time (milisec, sec, min) to higher lv time (sec, min, hours) when greater than threshold
        private Tuple<uint, uint> TimePairCheck(uint timeLapse, uint threshold)
        {
            uint newHigherLvTime = 0;
            uint newLowerLvTime = timeLapse;

            if (newLowerLvTime >= threshold)
            {
                uint overflow = (uint)(newLowerLvTime / threshold);
                newHigherLvTime += overflow;
                newLowerLvTime -= overflow * threshold;
            }

            Tuple<uint, uint> result = new Tuple<uint, uint>(newHigherLvTime, newLowerLvTime);
            return result;
        }

        private Tuple<uint, uint, uint> TimeCheck(uint hour, uint minute, uint second)
        {
            Tuple<uint, uint> minuteSecondPairCheck = TimePairCheck(_clock.TimeLapse, 60);
            Tuple<uint, uint> hourMinutePairCheck = TimePairCheck(minuteSecondPairCheck.Item1, 60);

            Tuple<uint, uint, uint> result = new Tuple<uint, uint, uint>(hourMinutePairCheck.Item1, hourMinutePairCheck.Item2, minuteSecondPairCheck.Item2);
            return result;
        }

        public void Increment()
        {
            _clock.Seconds += 1;
            SetClock();

        }
        public void SetClock()
        {
            Tuple<uint, uint, uint> timeCheck = TimeCheck(_clock.Hours, _clock.Minutes, _clock.Seconds);
            _clock.Hours = timeCheck.Item1;
            _clock.Minutes = timeCheck.Item2;
            _clock.Seconds = timeCheck.Item3;
        }

        public string ShowClock()
        {
            return _clock.ClockTime;
        }
    }
}