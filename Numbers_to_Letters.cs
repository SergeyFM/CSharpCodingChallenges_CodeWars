using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Numbers_to_Letters {
    [TestMethod]
    public void Test() {

        /*

        Numbers to Letters

        Given an array of numbers (in string format), you must return a string. 
        The numbers correspond to the letters of the alphabet in reverse order: a=26, z=1 etc. 
        You should also account for '!', '?' and ' ' that are represented by '27', '28' and '29' respectively.

        All inputs will be valid.
        */

        string expected = "btswmdsbd kkw";

        string actual = Switcher(new string[] { "25", "7", "8", "4", "14", "23", "8", "25", "23", "29", "16", "16", "4" });

        Assert.AreEqual(expected, actual);
    }

    public static string Switcher(string[] x) {
        char[] charTable = (new[] { ' ', '?', '!' }).Concat(
          Enumerable.Range(97, 26).Select(c => (char)c)
        ).Reverse().ToArray();

        return string.Concat(
          x.Select(n => int.TryParse(n, out int num) ? num : -1)
           .Where(num => num > 0 && num <= charTable.Length)
           .Select(num => charTable[num - 1])
        );
    }
}
