
using System;

namespace CodingChallenges;
[TestClass]
public class Array_Helpers {

    [TestMethod]
    public void Test() {
        /*

            Array Helpers

            This kata is designed to test your ability to extend the functionality of built-in classes. In this case, we want you to extend the built-in Array class with the following methods: square(), cube(), average(), sum(), even() and odd().

            Explanation:

            square() must return a copy of the array, containing all values squared
            cube() must return a copy of the array, containing all values cubed
            average() must return the average of all array values; on an empty array must return NaN (note: the empty array is not tested in Ruby!)
            sum() must return the sum of all array values
            even() must return an array of all even numbers
            odd() must return an array of all odd numbers
            Note: the original array must not be changed in any case!

            Example
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            numbers.Square(); // must return [1, 4, 9, 16, 25]
            numbers.Cube(); // must return [1, 8, 27, 64, 125]
            numbers.Average(); // must return 3
            numbers.Sum(); // must return 15
            numbers.Even(); // must return [2, 4]
            numbers.Odd(); // must return [1, 3, 5]


            */

        int[] array = new[] { 1, 2, 3, 4, 5 };

        Console.WriteLine("Square()");
        CollectionAssert.AreEqual(new[] { 1, 4, 9, 16, 25 }, array.Square(), "Square should work correctly");
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
        Assert.IsTrue(array.Square() is int[], "Square should return an array");

        Console.WriteLine("Cube()");
        CollectionAssert.AreEqual(new[] { 1, 8, 27, 64, 125 }, array.Cube(), "Cube should work correctly");
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
        Assert.IsTrue(array.Cube() is int[], "Cube should return an array");

        Console.WriteLine("Sum()");
        Assert.AreEqual(15, array.Sum(), "Sum should work correctly");
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");

        Console.WriteLine("Average()");
        Assert.AreEqual(3, array.Average(), "Average should work correctly");
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");

        Console.WriteLine("Even()");
        CollectionAssert.AreEqual(new[] { 2, 4 }, array.Even(), "Even should work correctly");
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
        Assert.IsTrue(array.Even() is int[], "Even should return an array");

        Console.WriteLine("Odd()");
        CollectionAssert.AreEqual(new[] { 1, 3, 5 }, array.Odd(), "Odd should work correctly");
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, array, "Original array should not be modified");
        Assert.IsTrue(array.Odd() is int[], "Odd should return an array");

    }
}

static class Array_Extensions {

    public static int[] Square(this int[] arr) {
        int len = arr.Length;
        int[] result = new int[len];
        for (int i = 0; i < len; i++) 
            result[i] = arr[i] * arr[i];
        return result;
    }

    public static int[] Cube(this int[] arr) {
        int len = arr.Length;
        int[] result = new int[len];
        for (int i = 0; i < len; i++) 
            result[i] = arr[i] * arr[i] * arr[i];
        return result;
    }

    public static int Sum(this int[] arr) {
        int sum = 0;
        foreach (int i in arr) sum += i;
        return sum;
    }

    public static double Average(this int[] arr) {
        int count = arr.Length;
        if (count == 0) return double.NaN;
        double sum = 0;
        foreach (int i in arr) sum += i;
        return sum / count;
    }

    public static int[] Even(this int[] arr) {
        int found = 0;
        int[] result = new int[arr.Length];
        foreach (int i in arr)
            if (i % 2 == 0) result[found++] = i;
        Array.Resize(ref result, found);
        return result;
    }

    public static int[] Odd(this int[] arr) {
        int found = 0;
        int[] result = new int[arr.Length];
        foreach (int i in arr)
            if (i % 2 != 0) result[found++] = i;
        Array.Resize(ref result, found);
        return result;
    }

}
