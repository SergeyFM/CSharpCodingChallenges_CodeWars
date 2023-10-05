using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Most_digits {
    [TestMethod]
    public void Test() {

        /*

        Most digits

        Find the number with the most digits.
        If two numbers in the argument array have the same number of digits, return the first one in the array.

        */

        Assert.AreEqual(100, FindLongest(new int[] { 1, 10, 100 }));
        Assert.AreEqual(8000, FindLongest(new int[] { 8000, 8, 9000 }));
        Assert.AreEqual(900, FindLongest(new int[] { 8, 900, 500 }));

        Assert.AreEqual(100, FindLongest_v2(new int[] { 1, 10, 100 }));
        Assert.AreEqual(8000, FindLongest_v2(new int[] { 8000, 8, 9000 }));
        Assert.AreEqual(900, FindLongest_v2(new int[] { 8, 900, 500 }));
    }

    public static int FindLongest(int[] number) => number
        .MaxBy(x => $"{x}"
                    .Where(c => char.IsDigit(c))
                    .Count()
        );

    public static int FindLongest_v2(int[] number) => number
        .Aggregate(0, (a, b) => $"{a}".Length < $"{b}".Length ? b : a);

}
