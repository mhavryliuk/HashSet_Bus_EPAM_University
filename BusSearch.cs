using System;
using System.Collections.Generic;
using System.Linq;

namespace _20180327_Task2_Bus
{
    class BusSearch
    {
        public void BusSearching(HashSet<TimeInterval> busSchedule, TimeInterval givenInterval)
        {
            HashSet<TimeInterval> result = new HashSet<TimeInterval>();

            var list = from bus in busSchedule
                       where bus.ArrivalTime >= givenInterval.ArrivalTime && bus.DepartureTime <= givenInterval.DepartureTime
                       select bus;

            foreach (var interval in list)
            {
                result.Add(interval);
            }

            // Outputting to the console information on the number of buses which have arrived and departed at given interval.
            int count = result.Count();

            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere isn't bus which have arrived and departed during that time.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nThere is {count.ToString()} bus which has arrived and departed during that time:");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nThere are {count.ToString()} buses which have arrived and departed during that time:");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // Outputting to the console information about buses which have arrived and departed at given interval.
            foreach (var interval in list)
            {
                Console.WriteLine(interval);
            }
        }
    }
}