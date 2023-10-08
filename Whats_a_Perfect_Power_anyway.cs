using System;

namespace CodingChallenges;
[TestClass]
public class Whats_a_Perfect_Power_anyway {
    [TestMethod]
    public void Test() {

        /*

        What's a Perfect Power anyway?

        A perfect power is a classification of positive integers:

             In mathematics, a perfect power is a positive integer that can be expressed as an integer power of another positive integer. 
             More formally, n is a perfect power if there exist natural numbers m > 1, and k > 1 such that mk = n.

        Your task is to check wheter a given integer is a perfect power. If it is a perfect power, return a pair m and k with mk = n as a proof. 
        Otherwise return Nothing, Nil, null, NULL, None or your language's equivalent.

        Note: For a perfect power, there might be several pairs. For example 81 = 3^4 = 9^2, so (3,4) and (9,2) are valid solutions. 
        However, the tests take care of this, so if a number is a perfect power, return any pair that proves it.

        */

        Assert.AreEqual((2, 3), IsPerfectPower(8), "8 = 2^3");
        Assert.AreEqual((3, 2), IsPerfectPower(9), "9 = 3^2");
        Assert.IsNull(IsPerfectPower(0), "0 is not a perfect number");
        Assert.IsNull(IsPerfectPower(1), "1 is not a perfect number");
        Assert.IsNull(IsPerfectPower(2), "2 is not a perfect number");
        Assert.IsNull(IsPerfectPower(3), "3 is not a perfect number");
        Assert.AreEqual((2, 2), IsPerfectPower(4), "4 = 2^2");
        Assert.IsNull(IsPerfectPower(5), "5 is not a perfect power");


        var pp = new int[] { 4, 8, 9, 16, 25, 27, 32, 36, 49, 64, 81, 100, 121, 125, 128, 144, 169, 196, 216, 225, 243, 256, 289, 324, 343, 361, 400, 441, 484 };
        foreach (var i in pp)
            Assert.IsNotNull(IsPerfectPower(i), $"{i} is a perfect power");

    }

    public static (int, int)? IsPerfectPower_v1(int n) {  // Execution Timed Out
        for (double m = Math.Ceiling(Math.Sqrt(n)); m >= 2; m--) {
            for (double k = 2; k <= n; k++) {
                int candidate = (int)Math.Pow(m, k);
                if (candidate > n) break;
                if (candidate == n) return ((int)m, (int)k);
            }
        }
        return null;
    }

    public static (int, int)? IsPerfectPower(int n) {
        for (var m = 2; m * m <= n; m++)
            for (var k = 2; Math.Pow(m, k) <= n; k++)
                if (Math.Pow(m, k) == n) return ((int)m, (int)k);
        return null;
    }

}
