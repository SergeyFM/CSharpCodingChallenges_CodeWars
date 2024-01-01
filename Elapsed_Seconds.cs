using System;

namespace CodingChallenges;
[TestClass]
public class Elapsed_Seconds {

    [TestMethod]
    public void Test() {

        /*

        Elapsed Seconds

        Complete the function so that it returns the number of seconds that have elapsed between the start and end times given.

        Tips:
        The start/end times are given as Date (JS/CoffeeScript), DateTime (C#), Time (Nim), datetime(Python) and Time (Ruby) instances.
        The start time will always be before the end time.
        */

        Assert.AreEqual(0, ElapsedSeconds(new DateTime(2016, 2, 8, 16, 42, 45), new DateTime(2016, 2, 8, 16, 42, 45)));
        Assert.AreEqual(-5, ElapsedSeconds(new DateTime(2016, 2, 8, 16, 42, 50), new DateTime(2016, 2, 8, 16, 42, 45)));
        Assert.AreEqual(86399, ElapsedSeconds(new DateTime(2016, 2, 8, 16, 42, 45), new DateTime(2016, 2, 9, 16, 42, 44)));

    }

    public static int ElapsedSeconds(DateTime startDate, DateTime endDate) =>
        (int)endDate.Subtract(startDate).TotalSeconds;
    
}
