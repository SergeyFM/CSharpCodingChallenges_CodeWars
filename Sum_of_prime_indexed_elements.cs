using System;
using System.Collections.Generic;

namespace CodingChallenges;
[TestClass]
public class Sum_of_prime_indexed_elements {

    /*

    Sum of prime-indexed elements

    In this Kata, you will be given an integer array and your task is to return the sum of elements occupying prime-numbered indices.

    The first element of the array is at index 0.

    Good luck!


    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual(0, solve(new int[] { }));
        Assert.AreEqual(7, solve(new int[] { 1, 2, 3, 4 }));
        Assert.AreEqual(13, solve(new int[] { 1, 2, 3, 4, 5, 6 }));
        Assert.AreEqual(47, solve(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }));
    }

    public static int solve(int[] arr) {
        int sum = 0;
        foreach (int primeIndex in GetPrimesFromRange()) {
            if (primeIndex >= arr.Length) break;
            sum += arr[primeIndex];
        }
        return sum;
    }
    private static IEnumerable<int> GetPrimesFromRange(int min = 2, int max = int.MaxValue) {
        for (int i = min; i <= max; i++) {
            bool isPrime = true;
            for (int j = 2; j <= Math.Floor(Math.Sqrt(i)); j++) {
                if (i % j == 0) {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) yield return i;
        }
    }
}
