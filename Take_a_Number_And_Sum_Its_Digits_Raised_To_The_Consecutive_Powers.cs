using System;
using System.Collections.Generic;

namespace CodingChallenges;
[TestClass]
public class Take_a_Number_And_Sum_Its_Digits_Raised_To_The_Consecutive_Powers {
    [TestMethod]
    public void Test() {
        /*
        The number 89 is the first integer with more than one digit that fulfills the property partially introduced in the title of this kata. 
        What's the use of saying "Eureka"? Because this sum gives the same number:  89 = 8^1 + 8^2

        We need a function to collect these numbers, that may receive two integers a, b 
        that defines the range [a,b] (inclusive) and outputs a list of the sorted numbers in the range 
        that fulfills the property described above.

        1, 10  --> [1, 2, 3, 4, 5, 6, 7, 8, 9]
        1, 100 --> [1, 2, 3, 4, 5, 6, 7, 8, 9, 89]
        90, 100 --> []

        */

        CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SumDigPow(1, 10));
        CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 89 }, SumDigPow(1, 100));
        CollectionAssert.AreEqual(new long[] { }, SumDigPow(90, 90));

    }

    public static long[] SumDigPow(long a, long b) {
        List<long> result = new();
        for (long i = a; i <= b; i++)
            if (CalcPowersSum(i)) result.Add(i);
        return result.ToArray();
    }

    public static bool CalcPowersSum(long n) {
        long initialNumber = n;
        long sum = 0;
        long currPower = $"{n}".Length;
        while (n > 0) {
            long d = n % 10;
            sum += (long)Math.Pow(d, currPower);
            currPower--;
            n /= 10;
        }
        return sum == initialNumber;
    }

}
