using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Correct_the_time_string {

    /*

    Correct the time-string

    You have to create a method, that corrects a given time string.
    There was a problem in addition, so many of the time strings are broken.
    Time is formatted using the 24-hour clock, so from 00:00:00 to 23:59:59.
    Examples
    "09:10:01" -> "09:10:01"  
    "11:70:10" -> "12:10:10"  
    "19:99:99" -> "20:40:39"  
    "24:01:01" -> "00:01:01"  
    If the input-string is null or empty return exactly this value! (empty string for C++) If the time-string-format is invalid, return null. 

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual(null, Correct("001122"));
        Assert.AreEqual(null, Correct("00;11;22"));
        Assert.AreEqual(null, Correct("0a:1c:22"));
        Assert.AreEqual("09:10:01", Correct("09:10:01"));
        Assert.AreEqual("12:10:10", Correct("11:70:10"));
        Assert.AreEqual("20:40:39", Correct("19:99:99"));
        Assert.AreEqual("00:01:01", Correct("24:01:01"));
        Assert.AreEqual("04:01:01", Correct("52:01:01"));

        Assert.AreEqual(null, Correct_v2("001122"));
        Assert.AreEqual(null, Correct_v2("00;11;22"));
        Assert.AreEqual(null, Correct_v2("0a:1c:22"));
        Assert.AreEqual("09:10:01", Correct_v2("09:10:01"));
        Assert.AreEqual("12:10:10", Correct_v2("11:70:10"));
        Assert.AreEqual("20:40:39", Correct_v2("19:99:99"));
        Assert.AreEqual("00:01:01", Correct_v2("24:01:01"));
        Assert.AreEqual("04:01:01", Correct_v2("52:01:01"));

    }

    public static string? Correct(string timeString) {
        if (string.IsNullOrWhiteSpace(timeString)) return timeString;
        int[] threeNums = timeString
          .Split(":")
          .Select(s => int.TryParse(s, out int n) ? n : int.MinValue)
          .Reverse().ToArray();
        if (threeNums.Count() != 3 || threeNums.Any(x => x == int.MinValue)) return null;
        int prevReminder = 0;
        int[] threeNumsProcessed = threeNums.Select((n, ind) => {
            int newN = n + prevReminder;
            prevReminder = newN / 60;
            return ind < 2 ? newN % 60 : newN % 24;
        }).Reverse().ToArray();

        return string.Join(':', threeNumsProcessed
          .Select(n => $"{n}".PadLeft(2, '0')));
    }

    public static string? Correct_v2(string timeString) {
        if (string.IsNullOrWhiteSpace(timeString)) return timeString;
        int[] threeNums = timeString
          .Split(":")
          .Select(s => int.TryParse(s, out int n) ? n : int.MinValue)
          .ToArray();
        if (threeNums.Count() != 3 || threeNums.Any(x => x == int.MinValue)) return null;
        return new TimeSpan(threeNums[0], threeNums[1], threeNums[2]).ToString(@"hh\:mm\:ss");
    }

}
