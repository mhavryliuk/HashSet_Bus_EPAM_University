## :oncoming_bus: Bus task

We are given a list of arriving and departing **schedule at a bus station**. 
Write a program, using the **HashSet< T >** class, which by given **interval (start, end)** returns the number of buses, 
which have arrived and departed during that time.

#### Example:
We have the data of the following buses: [08:24-08:33], [08:20-09:00], [08:32-08:37], [09:00-09:15]. 
We are given the range [08:22-09:05]. The number of buses, arriving and departing during that time is 2.

#### Recommendation:
The obvious solution is to check for all the buses whether they arrive or depart in the given range. 
However, according to the task terms we have to use **HashSet< T >**. Let us think how. 

With a linear scan (a for-loop), we can find **all buses arriving after the beginning** of the range and 
find **all buses departing before the end** of the range. These are **two separate sets**, right? 
The intersection of these sets should give us the set of buses we need.

If **TimeInterval** is a class, keeping the schedule of a bus (**arriveHour**, **arriveMinute**, **departureHour**, **departureMinute**), 
the intersection could be efficiently found by **HashSet< TimeInterval >** with correctly defined **GetHashCode()** and **Equals()**.

Another, **efficient solution** is to use **SortedSet< T >** and its method **GetViewBetween (< start >, < end >)**, 
but this contradicts to the problem description (recall that we are assigned to use **HashSet< T >**).
