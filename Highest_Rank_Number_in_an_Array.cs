using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Highest_Rank_Number_in_an_Array {
    [TestMethod]
    public void Test() {

        /*

        Highest Rank Number in an Array

        Complete the method which returns the number which is most frequent in the given input array. If there is a tie for most frequent number, return the largest number among them.

        Note: no empty arrays will be given.

        Examples
        [12, 10, 8, 12, 7, 6, 4, 10, 12]              -->  12
        [12, 10, 8, 12, 7, 6, 4, 10, 12, 10]          -->  12
        [12, 10, 8, 8, 3, 3, 3, 3, 2, 4, 10, 12, 10]  -->   3

        */

        var arr = new int[] { 10, 12, 8, 12, 7, 6, 4, 10, 10, 12 };
        Assert.AreEqual(12, HighestRank(arr));
        arr = new int[] { 10 };
        Assert.AreEqual(10, HighestRank(arr));
        arr = new int[] { };
        Assert.AreEqual(0, HighestRank(arr));
        arr = null;
        Assert.AreEqual(0, HighestRank(arr));


    }

    public static int HighestRank(int[] arr) => arr?
        .GroupBy(x => x)
        .OrderByDescending(x => x.Count())
        .ThenByDescending(x => x.Key)
        .FirstOrDefault()?.Key ?? 0;

}
