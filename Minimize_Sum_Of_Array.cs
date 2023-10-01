using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Minimize_Sum_Of_Array {
    [TestMethod]
    public void Test() {
        /*
        Minimize Sum Of Array (Array Series #1)

        Given an array of integers , Find the minimum sum which is obtained from summing each Two integers product .

        Notes
        Array/list will contain positives only .
        Array/list will always have even size

        Input >> Output Examples
        minSum({5,4,2,3}) ==> return (22) 
        Explanation:
        The minimum sum obtained from summing each two integers product ,  5*2 + 3*4 = 22
        minSum({12,6,10,26,3,24}) ==> return (342)
        Explanation:
        The minimum sum obtained from summing each two integers product ,  26*3 + 24*6 + 12*10 = 342
        minSum({9,2,8,7,5,4,0,6}) ==> return (74)
        Explanation:
        The minimum sum obtained from summing each two integers product ,  9*0 + 8*2 +7*4 +6*5 = 74

        */
        Assert.AreEqual(2, MinSum(new int[] { 1, 2 }));
        Assert.AreEqual(22, MinSum(new int[] { 5, 4, 2, 3 }));
        Assert.AreEqual(342, MinSum(new int[] { 12, 6, 10, 26, 3, 24 }));
        Assert.AreEqual(74, MinSum(new int[] { 9, 2, 8, 7, 5, 4, 0, 6 }));

        Assert.AreEqual(2, MinSum_v2(new int[] { 1, 2 }));
        Assert.AreEqual(22, MinSum_v2(new int[] { 5, 4, 2, 3 }));
        Assert.AreEqual(342, MinSum_v2(new int[] { 12, 6, 10, 26, 3, 24 }));
        Assert.AreEqual(74, MinSum_v2(new int[] { 9, 2, 8, 7, 5, 4, 0, 6 }));
    }

    public static int MinSum(int[] a) {

        Array.Sort(a);
        int ind1 = 0;
        int ind2 = a.Length - 1;
        int sum = 0;
        while (ind1 < ind2)
            sum += a[ind1++] * a[ind2--];
        return sum;

    }

    public static int MinSum_v2(int[] a) => a
        .OrderBy(n => n)
        .Skip(a.Length / 2)
        .Zip(a.OrderByDescending(n => n).Skip(a.Length / 2), (x, y) => x * y)
        .Sum();
    

}
