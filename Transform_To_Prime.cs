using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;

/*

Transform To Prime

Given a List [] of n integers , find minimum number to be inserted in a list, so that sum of all elements of list should equal the closest prime number .

Notes
List size is at least 2 .
List's numbers will only positives (n > 0) .
Repetition of numbers in the list could occur .

The newer list's sum should equal the closest prime number .

Input >> Output Examples
1- minimumNumber ({3,1,2}) ==> return (1)
Explanation:
Since , the sum of the list's elements equal to (6) , the minimum number to be inserted to transform the sum to prime number is (1) , which will make the sum of the List equal the closest prime number (7) .
2-  minimumNumber ({2,12,8,4,6}) ==> return (5)
Explanation:
Since , the sum of the list's elements equal to (32) , the minimum number to be inserted to transform the sum to prime number is (5) , which will make the sum of the List equal the closest prime number (37) .
3- minimumNumber ({50,39,49,6,17,28}) ==> return (2)
Explanation:
Since , the sum of the list's elements equal to (189) , the minimum number to be inserted to transform the sum to prime number is (2) , which will make the sum of the List equal the closest prime number (191) .

*/

[TestClass]
public class Transform_To_Prime {
    [TestMethod]
    public void Test() {

        Assert.AreEqual(1, MinimumNumber(new int[] { 3, 1, 2 }));
        Assert.AreEqual(0, MinimumNumber(new int[] { 5, 2 }));
        Assert.AreEqual(0, MinimumNumber(new int[] { 1, 1, 1 }));
        Assert.AreEqual(5, MinimumNumber(new int[] { 2, 12, 8, 4, 6 }));
        Assert.AreEqual(2, MinimumNumber(new int[] { 50, 39, 49, 6, 17, 28 }));

    }

    public static int MinimumNumber(int[] numbers) {
        int numbresSum = numbers.Sum();
        IEnumerable<int> primes = GetPrimesFromRange(numbresSum, numbresSum * 2 + 1);
        int bestPrime = primes.FirstOrDefault();
        int diff = bestPrime - numbresSum;
        return diff;
    }

    private static IEnumerable<int> GetPrimesFromRange(int min, int max) {
        if (min <= 0) min = 1;
        bool no = false;
        for (int i = min; i <= max; i++) {
            no = false;
            for (int j = 2; j < i; j++) {
                if (i % j == 0) {
                    no = true;
                    break;
                }
            }
            if (!no) yield return i;
        }
    }

}
