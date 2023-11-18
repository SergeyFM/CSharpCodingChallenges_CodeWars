using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Is_n_divisible_by__params {

    /*

    Is n divisible by (...)?

    Create a function that checks if the first argument n is divisible by all other arguments (return true if no other arguments)

    Example:

    (6,1,3)--> true because 6 is divisible by 1 and 3
    (12,2)--> true because 12 is divisible by 2
    (100,5,4,10,25,20)--> true
    (12,7)--> false because 12 is not divisible by 7

    */


    [TestMethod]
    public void Test() {

        Assert.IsFalse(IsDivisible(3, 3, 4));
        Assert.IsTrue(IsDivisible(12, 3, 4));
        Assert.IsFalse(IsDivisible(8, 3, 4, 2, 5));
        Assert.IsFalse(IsDivisible(null));

    }

    public static bool IsDivisible(params int[] p) =>
        p?.All(a => p.First() % a == 0)
        ?? false;

}
