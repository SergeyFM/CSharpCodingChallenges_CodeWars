using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Best_travel {
    [TestMethod]
    public void Test() {

        /*

        Best travel

        John and Mary want to travel between a few towns A, B, C ... Mary has on a sheet of paper a list of distances between these towns. 
        ls = [50, 55, 57, 58, 60]. John is tired of driving and he says to Mary that he doesn't want to drive more than t = 174 miles and he will visit only 3 towns.

        Which distances, hence which towns, they will choose so that the sum of the distances is the biggest possible to please Mary and John?

        Example:
        With list ls and 3 towns to visit they can make a choice between: 
        [50,55,57],[50,55,58],[50,55,60],[50,57,58],[50,57,60],[50,58,60],[55,57,58],[55,57,60],[55,58,60],[57,58,60].

        The sums of distances are then: 162, 163, 165, 165, 167, 168, 170, 172, 173, 175.

        The biggest possible sum taking a limit of 174 into account is then 173 and the distances of the 3 corresponding towns is [55, 58, 60].

        The function chooseBestSum (or choose_best_sum or ... depending on the language) will take as parameters t (maximum sum of distances, integer >= 0), k (number of towns to visit, k >= 1) and ls (list of distances, all distances are positive or zero integers and this list has at least one element). The function returns the "best" sum ie the biggest possible sum of k distances less than or equal to the given limit t, if that sum exists, or otherwise null.

        Examples:
        ts = [50, 55, 56, 57, 58] choose_best_sum(163, 3, ts) -> 163

        xs = [50] choose_best_sum(163, 3, xs) -> null

        ys = [91, 74, 73, 85, 73, 81, 87] choose_best_sum(230, 3, ys) -> 228

        */

        List<int> ts = new List<int> { 100, 76, 56, 44, 89, 73, 68, 56, 64, 123, 2333, 144, 50, 132, 123, 34, 89 };
        int? n = chooseBestSum(880, 8, ts);
        Assert.AreEqual(876, n);

        ts = new List<int> { 50, 55, 56, 57, 58 };
        n = chooseBestSum(163, 3, ts);
        Assert.AreEqual(163, n);

        ts = new List<int> { 50 };
        n = chooseBestSum(163, 3, ts);
        Assert.AreEqual(null, n);

        ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
        n = chooseBestSum(230, 3, ts);
        Assert.AreEqual(228, n);


        ts = new List<int> { 100, 76, 56, 44, 89, 73, 68, 56, 64, 123, 2333, 144, 50, 132, 123, 34, 89 };
        n = chooseBestSum_v2(880, 8, ts);
        Assert.AreEqual(876, n);

        ts = new List<int> { 50, 55, 56, 57, 58 };
        n = chooseBestSum_v2(163, 3, ts);
        Assert.AreEqual(163, n);

        ts = new List<int> { 50 };
        n = chooseBestSum_v2(163, 3, ts);
        Assert.AreEqual(null, n);

        ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
        n = chooseBestSum_v2(230, 3, ts);
        Assert.AreEqual(228, n);



    }

    public static int? chooseBestSum(int t, int k, List<int> ls) {
        IEnumerable<int> lsAsc = ls.Where(x => x <= t).OrderBy(x => x);
        IEnumerable<int> combinations = GetCombinations(lsAsc, k).Select(x => x.Sum());
        int bestSum = combinations.Where(x => x <= t).OrderByDescending(x => x).FirstOrDefault();
        return bestSum > 0 ? bestSum : null;

    }

    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> elements, int k) {
        return k == 0 ? new[] { new T[0] } :
          elements.SelectMany((e, i) =>
            GetCombinations(elements.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));
    }

    public static int? chooseBestSum_v2(int t, int k, List<int> ls) {
        var _ls = ls.Where(x => x <= t);
        return _ls.Count() == 0 ? null : _ls
            .Select((x, i) => x + (k > 1 ? chooseBestSum(t - x, k - 1, _ls.Skip(i + 1).ToList()) : 0))
            .Max();
    }

}

