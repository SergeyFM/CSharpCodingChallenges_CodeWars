using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Two_Sum {
    [TestMethod]
    public void Test() {
        /*
        Write a function that takes an array of numbers (integers for the tests) and a target number. It should find two different items in the array that, when added together, give the target value. The indices of these items should then be returned in a tuple / list (depending on your language) like so: (index1, index2).

        Some tests may have multiple answers; any valid solution will be accepted.

        The input will always be valid (numbers will be an array of length 2 or greater, and all of the items will be numbers; target will always be the sum of two different items from that array).

        two_sum([1, 2, 3], 4) == {0, 2}

        */

        CollectionAssert.AreEqual(new[] { 0, 1 }, TwoSum(new[] { 2, 2, 3 }, 4).OrderBy(a => a).ToArray());
        CollectionAssert.AreEqual(new[] { 0, 2 }, TwoSum(new[] { 1, 2, 3 }, 4).OrderBy(a => a).ToArray());
        CollectionAssert.AreEqual(new[] { 1, 2 }, TwoSum(new[] { 1234, 5678, 9012 }, 14690).OrderBy(a => a).ToArray());


    }

    public static int[] TwoSum(int[] numbers, int target) {

        for (int i = 0; i < numbers.Length; i++) {
            int cur = numbers[i];
            int aim = target - cur;
            for (int j = 0; j < numbers.Length && aim >= 0; j++)
                if (numbers[j] == aim && i != j) return new int[] { i, j };
        }
        return new int[0];
    }
}
