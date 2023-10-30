using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class The_Poet_And_The_Pendulum {

    /*

    The Poet And The Pendulum

    Given an array/list [] of n integers , Arrange them in a way similar to the to-and-fro movement of a Pendulum
    The Smallest element of the list of integers , must come in center position of array/list.
    The Higher than smallest , goes to the right .
    The Next higher number goes to the left of minimum number and So on , in a to-and-fro manner similar to that of a Pendulum.

    Notes

    Array/list size is at least 3 .
    In Even array size , The minimum element should be moved to (n-1)/2 index (considering that indexes start from 0)
    Repetition of numbers in the array/list could occur , So (duplications are included when Arranging).

    Input >> Output Examples:

    pendulum ([6, 6, 8 ,5 ,10]) ==> [10, 6, 5, 6, 8]
    Explanation:
    Since , 5 is the The Smallest element of the list of integers , came in The center position of array/list
    The Higher than smallest is 6 goes to the right of 5 .
    The Next higher number goes to the left of minimum number and So on .
    Remember , Duplications are included when Arranging , Don't Delete Them .

    pendulum ([-9, -2, -10, -6]) ==> [-6, -10, -9, -2]
    Explanation:
    Since , -10 is the The Smallest element of the list of integers , came in The center position of array/list
    The Higher than smallest is -9 goes to the right of it .
    The Next higher number goes to the left of -10 , and So on .
    Remeber , In Even array size , The minimum element moved to (n-1)/2 index (considering that indexes start from 0) .

    pendulum ([11, -16, -18, 13, -11, -12, 3, 18]) ==> [13, 3, -12, -18, -16, -11, 11, 18]
    Explanation:
    Since , -18 is the The Smallest element of the list of integers , came in The center position of array/list
    The Higher than smallest is -16 goes to the right of it .
    The Next higher number goes to the left of -18 , and So on .

    Remember , In Even array size , The minimum element moved to (n-1)/2 index (considering that indexes start from 0) .

    */


    [DataTestMethod]
    [DataRow(new[] { 4, 10, 9 }, new[] { 10, 4, 9 })]
    [DataRow(new[] { 8, 7, 10, 3 }, new[] { 8, 3, 7, 10 })]
    [DataRow(new[] { 6, 6, 8, 5, 10 }, new[] { 10, 6, 5, 6, 8 })]
    [DataRow(new[] { 9, 4, 6, 4, 10, 5 }, new[] { 9, 5, 4, 4, 6, 10 })]
    [DataRow(new[] { 4, 6, 8, 7, 5 }, new[] { 8, 6, 4, 5, 7 })]
    [DataRow(new[] { 10, 5, 6, 10 }, new[] { 10, 5, 6, 10 })]
    [DataRow(new[] { 11, 12, 12 }, new[] { 12, 11, 12 })]
    public void Test(int[] data, int[] expected) {
        Console.WriteLine("data: " + string.Join('*', data));
        var result = Pendulum(data);
        Console.WriteLine("expected: " + string.Join('*', expected) + "\n" + "result: " + string.Join('*', result));
        CollectionAssert.AreEqual(result, expected);
        // v2
        CollectionAssert.AreEqual(Pendulum_v2(data), expected);

    }

    public static int[] Pendulum(int[] values) {
        if (values is null || values.Length == 0) throw new ArgumentException();
        if (values.Length == 1) return values;
        IOrderedEnumerable<int> ordered = values.OrderBy(x => x);
        int center = ordered.First();
        List<int> centerAndRight = ordered.Skip(1).Where((_, ind) => ind % 2 == 0).ToList();
        var leftPart = ordered.Skip(1).Where((_, ind) => ind % 2 != 0).OrderByDescending(x => x).ToList();
        leftPart.Add(center);
        return leftPart.Concat(centerAndRight).ToArray();
    }

    public static int[] Pendulum_v2(int[] values) => values.
        OrderBy(x => x)
        .Aggregate(Enumerable.Empty<int>(), (c, n) => c.Count() % 2 == 0 ? c.Prepend(n) : c.Append(n))
        .ToArray();
    

}
