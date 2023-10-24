using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class shorter_concat_reverse_longer {

    /*

    shorter concat [reverse longer]

    Given 2 strings, a and b, return a string of the form: shorter+reverse(longer)+shorter.

    In other words, the shortest string has to be put as prefix and as suffix of the reverse of the longest.

    Strings a and b may be empty, but not null (In C# strings may also be null. Treat them as if they are empty.).
    If a and b have the same length treat a as the longer producing b+reverse(a)+b

    */


    [TestMethod]
    public void Test() {

        string input_a = "first";
        string input_b = "abcde";
        string expected = "abcdetsrifabcde";

        string actual = ShorterReverseLonger(input_a, input_b);

        Assert.AreEqual(expected, actual);

    }

    public static string ShorterReverseLonger(string a, string b) => string.Format(@"{0}{1}{0}",
        new[] { $"{a}", $"{b}" }
        .OrderBy(x => -x.Length).Reverse()
        .Select((x, ind) => ind == 1 ? new string(x.Reverse().ToArray()) : x)
        .ToArray()
);
}
