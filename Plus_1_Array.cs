using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Plus_1_Array {
    [TestMethod]
    public void Test() {

        /*

        +1 Array

        Given an array of integers of any length, return an array that has 1 added to the value represented by the array.
            * the array can't be empty
            * only non-negative, single digit integers are allowed
        Return nil (or your language's equivalent) for invalid inputs.

        Examples

        Valid arrays
        [4, 3, 2, 5] would return [4, 3, 2, 6]
        [1, 2, 3, 9] would return [1, 2, 4, 0]
        [9, 9, 9, 9] would return [1, 0, 0, 0, 0]
        [0, 1, 3, 7] would return [0, 1, 3, 8]

        Invalid arrays
        [1, -9] is invalid because -9 is not a non-negative integer
        [1, 2, 33] is invalid because 33 is not a single-digit integer

        */

        var num = new int[] { 2, 3, 9 };
        var newNum = new int[] { 2, 4, 0 };
        var result = UpArray(num);
        foreach (var item in result) { Console.WriteLine(item); }
        CollectionAssert.AreEqual(newNum, result);

        num = new int[] { 4, 3, 2, 5 };
        newNum = new int[] { 4, 3, 2, 6 };
        CollectionAssert.AreEqual(newNum, UpArray(num));

        num = new int[] { 9, 9 };
        newNum = new int[] { 1, 0, 0 };
        CollectionAssert.AreEqual(newNum, UpArray(num));

        num = new int[] { 9, 2, 2, 3, 3, 7, 2, 0, 3, 6, 8, 5, 4, 7, 7, 5, 8, 0, 7, 5, 3, 2, 6, 7, 8, 4, 2, 4, 2, 6, 7, 8, 7, 4, 5, 2, 1 };
        newNum = new int[] { 9, 2, 2, 3, 3, 7, 2, 0, 3, 6, 8, 5, 4, 7, 7, 5, 8, 0, 7, 5, 3, 2, 6, 7, 8, 4, 2, 4, 2, 6, 7, 8, 7, 4, 5, 2, 2 };
        CollectionAssert.AreEqual(newNum, UpArray(num));


        num = new int[] { 9, 2, 2, 3, 3, 7, 2, 0, 3, 6, 8, 5, 4, 7, 7, 5, 8, 0, 7, 5, 3, 2, 6, 7, 8, 4, 2, 4, 2, 6, 7, 8, 7, 4, 5, 2, 1 };
        newNum = new int[] { 9, 2, 2, 3, 3, 7, 2, 0, 3, 6, 8, 5, 4, 7, 7, 5, 8, 0, 7, 5, 3, 2, 6, 7, 8, 4, 2, 4, 2, 6, 7, 8, 7, 4, 5, 2, 2 };
        CollectionAssert.AreEqual(newNum, UpArray_v2(num));

    }

    public static int[] UpArray(int[] num) {
        if (num is null || num.Length < 1 || num.Any(num => num < 0 || num > 9)) return null;
        var nums = new List<int>(num);
        int ind = num.Length - 1;
        int theRest = 0;
        do {
            int newVal = nums[ind] + 1;
            if (newVal < 10) {
                theRest = 0;
                nums[ind] = newVal;
                break;
            }
            else {
                theRest = 1;
                nums[ind] = 0;
            };
        } while (--ind >= 0);
        if (theRest > 0) nums.Insert(0, theRest);
        return nums.ToArray();
    }

    public static int[] UpArray_v2(int[] num) {
        if (num is null || num.Length < 1 || num.Any(num => num < 0 || num > 9)) return null;
        for (int ind = num.Length - 1; ind >= 0; ind--) {
            num[ind] += 1;
            if (num[ind] < 10) return num;
            else num[ind] %= 10;
        }
        return new[] { 1 }.Concat(num).ToArray();
    }
}
