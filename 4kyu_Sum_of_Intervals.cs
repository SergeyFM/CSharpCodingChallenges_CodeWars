using System.Linq;
using Interval = System.ValueTuple<int, int>;

namespace CodingChallenges;
[TestClass]
public class _4kyu_Sum_of_Intervals {

    /*

    Sum of Intervals

    Write a function called sumIntervals/sum_intervals that accepts an array of intervals, 
    and returns the sum of all the interval lengths. Overlapping intervals should only be counted once.

    Intervals
    Intervals are represented by a pair of integers in the form of an array. The first value of the interval 
    will always be less than the second value. Interval example: 
    [1, 5] is an interval from 1 to 5. The length of this interval is 4.

    Overlapping Intervals
    List containing overlapping intervals:

    [
       [1, 4],
       [7, 10],
       [3, 5]
    ]
    The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, 
    we can treat the interval as [1, 5], which has a length of 4.

    Examples:
    sumIntervals( [
       [1, 2],
       [6, 10],
       [11, 15]
    ] ) => 9

    sumIntervals( [
       [1, 4],
       [7, 10],
       [3, 5]
    ] ) => 7

    sumIntervals( [
       [1, 5],
       [10, 20],
       [1, 6],
       [16, 19],
       [5, 11]
    ] ) => 19

    sumIntervals( [
       [0, 20],
       [-100000000, 10],
       [30, 40]
    ] ) => 100000030
    Tests with large intervals
    Your algorithm should be able to handle large intervals. 
    All tested intervals are subsets of the range [-1000000000, 1000000000].

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual(0, SumIntervals(new Interval[] { }));
        Assert.AreEqual(0, SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        Assert.AreEqual(9, SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) }));
        Assert.AreEqual(11, SumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) }));
        Assert.AreEqual(7, SumIntervals(new Interval[] { (-1, 4), (-5, -3) }));
        Assert.AreEqual(78, SumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        Assert.AreEqual(54, SumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) }));
        Assert.AreEqual(23, SumIntervals(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        Assert.AreEqual(7, SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
        Assert.AreEqual(6, SumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
        Assert.AreEqual(19, SumIntervals(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        Assert.AreEqual(13, SumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
        Assert.AreEqual(1234, SumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
        Assert.AreEqual(158, SumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        Assert.AreEqual(2_000_000_000, SumIntervals(new Interval[] { (-1_000_000_000, 1_000_000_000) }));
        Assert.AreEqual(100_000_030, SumIntervals(new Interval[] { (0, 20), (-100_000_000, 10), (30, 40) }));

    }

    /*
    [
       [1, 4],
       [7, 10],
       [3, 5]
    ]
    The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, 
    we can treat the interval as [1, 5], which has a length of 4.

    sort by first
    [1, 4], [3, 5], [7, 10]
    for each
        if second < first second=first
        if second exists && second > next.first next.first=second
        sum += second-first

    */

    public static int SumIntervals((int, int)[] intervals) {

        Interval[] sortedIntervals = intervals.OrderBy(x => x.Item1).ToArray();
        int len = sortedIntervals.Length;
        int sum = 0;
        for (int i = 0; i < len; i++) {
            (int first, int second) = sortedIntervals[i];
            if (second < first) second = first;
            if (i < len - 1) {
                (int nextFirst, int nextSecond) = sortedIntervals[i + 1];
                if (second > nextFirst) sortedIntervals[i + 1].Item1 = second;
            }
            sum += second - first;
        }
        return sum;
    }

}
