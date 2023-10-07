namespace CodingChallenges;
[TestClass]
public class Sum_of_Triangular_Numbers {
    [TestMethod]
    public void Test() {

        /*

        Sum of Triangular Numbers

        Your task is to return the sum of Triangular Numbers up-to-and-including the nth Triangular Number.

        Triangular Number: "any of the series of numbers (1, 3, 6, 10, 15, etc.) obtained by continued summation of the natural numbers 1, 2, 3, 4, 5, etc."

        [01]
        02 [03]
        04 05 [06]
        07 08 09 [10]
        11 12 13 14 [15]
        16 17 18 19 20 [21]
        e.g. If 4 is given: 1 + 3 + 6 + 10 = 20.

        Triangular Numbers cannot be negative so return 0 if a negative number is given.

        */

        Assert.AreEqual(56, SumTriangularNumbers(6));
        Assert.AreEqual(7140, SumTriangularNumbers(34));
        Assert.AreEqual(0, SumTriangularNumbers(-291));
        Assert.AreEqual(140205240, SumTriangularNumbers(943));
        Assert.AreEqual(0, SumTriangularNumbers(-971));

    }

    public static int SumTriangularNumbers(int n) =>
        /*
            T(n)=(n(n+1)(n+2))/6
        */
        n > 0 ? n * (n + 1) * (n + 2) / 6 : 0;
}
