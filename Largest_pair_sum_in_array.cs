using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Largest_pair_sum_in_array {
    [TestMethod]
    public void Test() {
        /*
        Largest pair sum in array

        Given a sequence of numbers, find the largest pair sum in the sequence.

        For example

        [10, 14, 2, 23, 19] -->  42 (= 23 + 19)
        [99, 2, 2, 23, 19]  --> 122 (= 99 + 23)
        Input sequence contains minimum two elements and every element is an integer.

        */

        Assert.AreEqual(-16, LargestPairSum(new int[] { -8, -8, -16, -18, -19 }));
        Assert.AreEqual(0, LargestPairSum(new int[] { -100, -29, -24, -19, 19 }));
        Assert.AreEqual(10, LargestPairSum(new int[] { 1, 2, 3, 4, 6, -1, 2 }));
        Assert.AreEqual(42, LargestPairSum(new int[] { 10, 14, 2, 23, 19 }));
        Assert.AreEqual(2, LargestPairSum(new int[] { 2 }));
    }

    public static int LargestPairSum(int[] n) => n
        .OrderByDescending(x => x)
        .Take(2)
        .Sum();
}
