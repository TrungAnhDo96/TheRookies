namespace ClockApp
{
    class Clock
    {
        public Clock(uint hours, uint minutes, uint seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public uint Hours { get; set; }

        public uint Minutes { get; set; }

        public uint Seconds { get; set; }

        public string ClockTime
        {
            get
            {
                return Hours + ":" + Minutes + ":" + Seconds;
            }
        }

        public uint TimeLapse
        {
            get
            {
                return Hours * 60 * 60 + Minutes * 60 + Seconds;
            }
        }
    }
}