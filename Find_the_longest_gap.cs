using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Find_the_longest_gap {

    /*

    Find the longest gap!

        A binary gap within a positive number num is any sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of num.
    For example:
    9 has binary representation 1001 and contains a binary gap of length 2.
    529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3.
    20 has binary representation 10100 and contains one binary gap of length 1.
    15 has binary representation 1111 and has 0 binary gaps.
    Write function gap(num) that,  given a positive num,  returns the length of its longest binary gap.
    The function should return 0 if num doesn't contain a binary gap.

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual(2, Gap(9), "Not working for 9");
        Assert.AreEqual(4, Gap(529), "Not working for 529");
        Assert.AreEqual(1, Gap(20), "Not working for 20");
        Assert.AreEqual(0, Gap(15), "Not working for 15");
        Assert.AreEqual(0, Gap(0), "What if zero is passed?");


        Assert.AreEqual(2, Gap_v2(9), "Not working for 9");
        Assert.AreEqual(4, Gap_v2(529), "Not working for 529");
        Assert.AreEqual(1, Gap_v2(20), "Not working for 20");
        Assert.AreEqual(0, Gap_v2(15), "Not working for 15");
        Assert.AreEqual(0, Gap_v2(0), "What if zero is passed?");
    }

    public static int Gap(int num) => Convert.ToString(num, 2)
            .Reverse()
            .SkipWhile(c => c == '0')
            .Reverse()
            .Aggregate("", (a, b) => $"{a}{b}")
            .Split('1')
            .Where(x => x.Length > 0)
            .OrderByDescending(x => x.Length)
            .FirstOrDefault("")
            .Length;

    public static int Gap_v2(int num) => Convert.ToString(num, 2)
            .Trim('0')
            .Split('1')
            .Select(s => s.Length)
            .Max();

}
