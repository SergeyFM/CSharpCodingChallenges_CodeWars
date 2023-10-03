using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Square_Every_Digit {
    [TestMethod]
    public void Test() {
        /*

        Square Every Digit

        Welcome. You are asked to square every digit of a number and concatenate them.
        For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1. (81-1-1-81)
        Example #2: An input of 765 will/should return 493625 because 72 is 49, 62 is 36, and 52 is 25. (49-36-25)
        Note: The function accepts an integer and returns an integer.
        */

        Assert.AreEqual(811181, SquareDigits(9119));
        Assert.AreEqual(0, SquareDigits(0));

        Assert.AreEqual(811181, SquareDigits_v2(9119));
        Assert.AreEqual(0, SquareDigits_v2(0));

    }

    public static int SquareDigits(int ൠ) => $"{ൠ}"
      .Select(c => c - '0')
      .Select(d => $"{d * d}")
      .Aggregate((a, b) => $"{a}{b}")
      .ToInt();

    public static int SquareDigits_v2(int ൠ) => $"{ൠ}"
   .Select(c => (c - '0') * (c - '0'))
   .Aggregate("", (a, b) => $"{a}{b}")
   .ToInt();
}

public static class Square_Every_Digit_Extensions {
    public static int ToInt(this string str) => int.TryParse(str, out int result) ? result : int.MinValue;
}
