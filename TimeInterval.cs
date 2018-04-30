using System;

namespace _20180327_Task2_Bus
{
    class TimeInterval
    {
        string direction;
        TimeSpan arrivalTime;
        TimeSpan departureTime;

        public TimeInterval(byte arriveHour, byte arriveMinute, byte departureHour, byte departureMinute, string direction = "none")
        {
            this.direction = direction;
            ArrivalTime = new TimeSpan(arriveHour, arriveMinute, 0);
            DepartureTime = new TimeSpan(departureHour, departureMinute, 0);
        }

        public string Direction
        {
            get => direction;
            set => direction = value;
        }

        public TimeSpan ArrivalTime
        {
            get => arrivalTime;
            set => arrivalTime = value;
        }

        public TimeSpan DepartureTime
        {
            get => departureTime;

            set => departureTime = value;
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is TimeInterval)
            {
                if (arrivalTime == ((TimeInterval)obj).arrivalTime &&
                    departureTime == ((TimeInterval)obj).departureTime)
                    return true;
                else
                    return false;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // Override ToString
        public override String ToString()
        {
            return String.Format("   {0,-14} [{1:hh\\:mm} - {2:hh\\:mm}]", direction, ArrivalTime, DepartureTime);
        }
    }
}