using System.Linq;

namespace CodingChallenges;
[TestClass]
public class What_dominates_your_array {

    /*

    
        What dominates your array?

            A zero-indexed array arr consisting of n integers is given. The dominator of array arr is the value that occurs in more than half of the elements of arr.
        For example, consider array arr such that arr = [3,4,3,2,3,1,3,3]
        The dominator of arr is 3 because it occurs in 5 out of 8 elements of arr and 5 is more than a half of 8.
        Write a function dominator(arr) that, given a zero-indexed array arr consisting of n integers, returns the dominator of arr. The function should return −1 if array does not have a dominator. All values in arr will be >=0.

    */
    [TestMethod]
    public void Test() {

        Assert.AreEqual(3, WhoDominates(new int[] { 3, 4, 3, 2, 3, 1, 3, 3 }));
        Assert.AreEqual(-1, WhoDominates(new int[] { 1, 2, 3, 4, 5 }));
        Assert.AreEqual(-1, WhoDominates(new int[] { 1, 1, 1, 2, 2, 2 }));
        Assert.AreEqual(2, WhoDominates(new int[] { 1, 1, 1, 2, 2, 2, 2 }));

        Assert.AreEqual(3, WhoDominates_v2(new int[] { 3, 4, 3, 2, 3, 1, 3, 3 }));
        Assert.AreEqual(-1, WhoDominates_v2(new int[] { 1, 2, 3, 4, 5 }));
        Assert.AreEqual(-1, WhoDominates_v2(new int[] { 1, 1, 1, 2, 2, 2 }));
        Assert.AreEqual(2, WhoDominates_v2(new int[] { 1, 1, 1, 2, 2, 2, 2 }));

    }

    public static int WhoDominates(int[] array) {
        var numbers = array
          .GroupBy(x => x)
          .Where(g => g.Count() > 0 ? (double)array.Count() / g.Count() < 2.0d : false);
        return numbers.Count() > 0 ? numbers.Select(g => g.Key).First() : -1;
    }

    public static int WhoDominates_v2(int[] array) => array
      .GroupBy(x => x)
      .FirstOrDefault(g => g.Count() > array.Length / 2)?
      .Key ?? -1;

}
