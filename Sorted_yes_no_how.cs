using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Sorted_yes_no_how {
    [TestMethod]
    public void Test() {
        /*

        Sorted? yes? no? how?

        Complete the method which accepts an array of integers, and returns one of the following:

        "yes, ascending" - if the numbers in the array are sorted in an ascending order
        "yes, descending" - if the numbers in the array are sorted in a descending order
        "no" - otherwise
        You can assume the array will always be valid, and there will always be one correct answer.


        */

        Assert.AreEqual("yes, ascending", IsSortedAndHow(new[] { 1, 2 }));
        Assert.AreEqual("yes, descending", IsSortedAndHow(new[] { 15, 7, 3, -8 }));
        Assert.AreEqual("no", IsSortedAndHow(new[] { 4, 2, 30 }));
    }

    public static string IsSortedAndHow(int[] array) {
        string[] repl = new string[] { "no", "yes, ascending", "yes, descending" };
        int replInd = 0;
        IEnumerable<int> cloned;

        if (array.First() <= array.Last()) {
            // ascending or all items are equal
            cloned = array.OrderBy(x => x).ToArray();
            replInd = 1;
        }
        else {
            // descending
            cloned = array.OrderByDescending(x => x).ToArray();
            replInd = 2;
        }

        if (!cloned.SequenceEqual(array)) replInd = 0;

        return repl[replInd];
    }


}
