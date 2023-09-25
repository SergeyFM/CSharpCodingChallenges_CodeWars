using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Sum_of_a_sequence {
    [TestMethod]
    public void Test() {
        /*
        
        Your task is to write a function which returns the sum of a sequence of integers.
        The sequence is defined by 3 non-negative values: begin, end, step.
        If begin value is greater than the end, your function should return 0. 
        If end is not the result of an integer number of steps, then don't add it to the sum. 
        
        */

        /*
        I think what it's trying to say is that you have the lowest possible value of the range, which it refers to as 'begin'. This begin is the first number in the sequence. Then you have the highest possible value in the range, which they call 'end'. This is the second number in the sequence. Then they say the third number is called the 'step'. Its pretty much just how much you jump from number to number by. Lets say we have a sequence 1, 4, 2. The lowest possible value (which is also the number we start at) is 1, while 4, the second value, is the highest possible number we can go to. Then we have 2. Put it simply, 2 is the number we count by. So for this sequence, the answer would be 1, 1+2(3), 3+2(5) oops, 5 is higher than 4! So 1 + 1+2(3) = 4 would be the answer for the sequence 1, 4, 2. (negafu)
        */

        Assert.AreEqual(12, SequenceSum(2, 6, 2));
        Assert.AreEqual(15, SequenceSum(1, 5, 1));
        Assert.AreEqual(5, SequenceSum(1, 5, 3));
        Assert.AreEqual(45, SequenceSum(0, 15, 3));
        Assert.AreEqual(0, SequenceSum(16, 15, 3));
        Assert.AreEqual(26, SequenceSum(2, 24, 22));
        Assert.AreEqual(2, SequenceSum(2, 2, 2));
        Assert.AreEqual(2, SequenceSum(2, 2, 1));
        Assert.AreEqual(35, SequenceSum(1, 15, 3));
        Assert.AreEqual(0, SequenceSum(15, 1, 3));


        Assert.AreEqual(12, SequenceSum_v2(2, 6, 2));
        Assert.AreEqual(15, SequenceSum_v2(1, 5, 1));
        Assert.AreEqual(5, SequenceSum_v2(1, 5, 3));
        Assert.AreEqual(45, SequenceSum_v2(0, 15, 3));
        Assert.AreEqual(0, SequenceSum_v2(16, 15, 3));
        Assert.AreEqual(26, SequenceSum_v2(2, 24, 22));
        Assert.AreEqual(2, SequenceSum_v2(2, 2, 2));
        Assert.AreEqual(2, SequenceSum_v2(2, 2, 1));
        Assert.AreEqual(35, SequenceSum_v2(1, 15, 3));
        Assert.AreEqual(0, SequenceSum_v2(15, 1, 3));

    }

    public static int SequenceSum(int start, int end, int step) =>
        (start > end) ? 0 : GetIntRange(start, end, step).Sum();


    private static IEnumerable<int> GetIntRange(int start, int end, int step) {
        while (start <= end) {
            yield return start;
            start += step;
        }
    }

    public static int SequenceSum_v2(int start, int end, int step) =>
        start > end ? 0 : Enumerable.Repeat(start, (end - start) / step + 1).Select((x, index) => x + step * index).Sum();
    

}
