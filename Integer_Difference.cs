using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Integer_Difference {
    /*

    Integer Difference

    Write a function that accepts two arguments: an array/list of integers and another integer (n).

Determine the number of times where two integers in the array have a difference of n.

For example:

[1, 1, 5, 6, 9, 16, 27], n=4  -->  3  # (1,5), (1,5), (5,9)
[1, 1, 3, 3], n=2             -->  4  # (1,3), (1,3), (1,3), (1,3)


    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual(3, IntDiff(new int[] { 1, 1, 5, 6, 9, 16, 27 }, 4));
        Assert.AreEqual(4, IntDiff(new int[] { 1, 1, 3, 3 }, 2));
        Assert.AreEqual(3, IntDiff_v2(new int[] { 1, 1, 5, 6, 9, 16, 27 }, 4));
        Assert.AreEqual(4, IntDiff_v2(new int[] { 1, 1, 3, 3 }, 2));
    }


    public static int IntDiff(int[] arr, int n) => n < 0 ? 0 : arr
        .OrderBy(x => x)
        .Select((d, ind) => arr
                            .OrderBy(x => x)
                            .Skip(ind + 1)
                            .Select(d2 => d2 - d)
                            .Where(d3 => d3 == n)
                            .Count())
        .Sum();

    public static int IntDiff_v2(int[] arr, int n) => arr
      .Select((x, ind) => arr
                            .Skip(ind + 1)
                            .Count(y => x - y == n || x - y == -n))
      .Sum();

}
