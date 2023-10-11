using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Row_Weights {
    [TestMethod]
    public void Test() {

        /*

        Row Weights

        Several people are standing in a row divided into two teams.
        The first person goes into team 1, the second goes into team 2, the third goes into team 1, and so on.

        Task
        Given an array of positive integers (the weights of the people), return a new array/tuple of two integers, 
        where the first one is the total weight of team 1, and the second one is the total weight of team 2.

        Notes
        Array size is at least 1.
        All numbers will be positive.

        Input >> Output Examples
        rowWeights([13, 27, 49])  ==>  return (62, 27)
        Explanation:
        The first element 62 is the total weight of team 1, and the second element 27 is the total weight of team 2.

        */

        var a = "80".Split().Select(int.Parse).ToArray();
        var expected = "80 0".Split().Select(int.Parse).ToArray();
        var res = RowWeights(a);
        Console.WriteLine(string.Join("*", res));
        CollectionAssert.AreEqual(expected, res);

        a = "39 84 74 18 59 72 35 61".Split().Select(int.Parse).ToArray();
        expected = "207 235".Split().Select(int.Parse).ToArray();
        res = RowWeights(a);
        Console.WriteLine(string.Join("*", res));
        CollectionAssert.AreEqual(expected, res);

        a = null;
        expected = new int[] { 0, 0 };
        res = RowWeights(a);
        Console.WriteLine($"When null, count: {res.Count()}");
        CollectionAssert.AreEqual(expected, res);

        a = "80".Split().Select(int.Parse).ToArray();
        expected = "80 0".Split().Select(int.Parse).ToArray();
        res = RowWeights_v2(a);
        Console.WriteLine(string.Join("*", res));
        CollectionAssert.AreEqual(expected, res);

        a = "39 84 74 18 59 72 35 61".Split().Select(int.Parse).ToArray();
        expected = "207 235".Split().Select(int.Parse).ToArray();
        res = RowWeights_v2(a);
        Console.WriteLine(string.Join("*", res));
        CollectionAssert.AreEqual(expected, res);

        a = null;
        expected = new int[] { 0, 0 };
        res = RowWeights_v2(a);
        Console.WriteLine($"When null, count: {res.Count()}");
        CollectionAssert.AreEqual(expected, res);

    }

    public static int[] RowWeights(int[] a) => a?
        .Select((x, ind) => (x, ind))
        .GroupBy(t => t.ind % 2)
        .Select(g => g.Sum(s => s.x))
        .Concat(new[] { 0, 0 })
        .Take(2)
        .ToArray() ?? new int[] { 0, 0 };

    public static int[] RowWeights_v2(int[] a) => "01"
        .Select((_, ind) => a?
                    .Where((_, ind2) => ind2 % 2 == ind)
                    .Sum() ?? 0)
        .ToArray();
}
