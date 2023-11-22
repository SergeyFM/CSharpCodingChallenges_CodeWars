using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Number_Pairs {

    /*

    Number Pairs

    The aim is to compare each pair of integers from 2 arrays, and return a new array of large numbers.

    Note: Both arrays have the same dimensions.

    Example:

    arr1 = new int[] { 13, 64, 15, 17, 88 };
    arr2 = new int[] { 23, 14, 53, 17, 80 };

    getLargerNumbers(arr1, arr2); // Returns {23, 64, 53, 17, 88}


    */

    [TestMethod]
    public void Test() {

        int[] arr1 = new int[] { 13, 64, 5, 7, 88 };
        int[] arr2 = new int[] { 23, 4, 53, 17, 80 };
        CollectionAssert.AreEqual(new int[] { 23, 64, 53, 17, 88 }, getLargerNumbers(arr1, arr2));
        CollectionAssert.AreEqual(new int[] { 23, 64, 53, 17, 88 }, getLargerNumbers_v2(arr1, arr2));

    }

    public static int[] getLargerNumbers(int[] a, int[] b) => a.Zip(b)
        .Select(t => Math.Max(t.First, t.Second))
        .ToArray();

    public static int[] getLargerNumbers_v2(int[] a, int[] b) =>
        a.Zip(b, (x,y) => Math.Max(x,y)).ToArray();

}
