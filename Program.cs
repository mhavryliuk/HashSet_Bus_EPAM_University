using System;
using System.Collections.Generic;

/* Нам дают список прибытия и отъезда из графика в автобусной станции. 
 * Напишите программу, используя класс HashSet<T>, который по заданному интервалу (начало, конец) возвращает количество автобусов, 
 * которые прибыли и ушли за это время.
 * 
 * Пример:
 * У нас есть данные следующих автобусов: [08:24-08:33], [08:20-09:00], [08:32-08:37], [09:00-09:15]. 
 * Мы дали диапазон [08:22 - 09:05]. Количество автобусов, прибывающих и выезжающих за это время, равно 2.
 * 
 * Рекомендации. Очевидным решением является проверка всех автобусов независимо от того, прибывают они или уходят в заданном диапазоне.
 * Но в соответствии с условиями задачи мы должны использовать HashSet<T>. Давайте подумаем, как.
 * 
 * При линейном сканировании (для цикла) мы можем найти все автобусы, прибывающие после начала диапазона, и найти все автобусы, 
 * отходящие до конца диапазона. Это два отдельных набора, не так ли? Пересечение этих множеств должно дать нам набор автобусов, 
 * которые нам нужны.
 * 
 * Если TimeInterval является классом, сохраняя расписание автобуса (arriveHour, arriveMinute, departureHour, departureMinute), 
 * пересечение может быть эффективно найдено через HashSet<TimeInterval> с правильно определенными GetHashCode() и Equals().
 * 
 * Другим эффективным решением является использование SortedSet<T> и его метод GetViewBetween (<start>, <end>), 
 * но это противоречит описанию проблемы(напомним, что нам назначено использование HashSet<T>). */

namespace _20180327_Task2_Bus
{
    class Program
    {
        static void Main()
        {
            // Bus schedule
            HashSet<TimeInterval> busSchedule = new HashSet<TimeInterval>
            {
                new TimeInterval(08, 24, 08, 33, "Kyiv - Lviv"),
                new TimeInterval(08, 20, 09, 00, "Lutsk - Kyiv"),
                new TimeInterval(08, 32, 08, 37, "Rivne - Kyiv"),
                new TimeInterval(09, 00, 09, 15, "Kyiv - Dnipro")
            };

            // Given interval
            TimeInterval givenInterval = new TimeInterval(08, 22, 09, 05);

            // Outputting to the console of the current schedule.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bus schedule:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (TimeInterval time in busSchedule)
            {
                Console.WriteLine("{0}", time);
            }

            // Finding information about buses which have arrived and departed at given interval.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nGiven interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{givenInterval}");

            BusSearch search = new BusSearch();
            
            search.BusSearching(busSchedule, givenInterval);            

            Console.ReadKey();
        }
    }
}