using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Find_the_middle_element {
    [TestMethod]
    public void Test() {

        /*

        Find the middle element

        As a part of this challenge, you need to create a function that when provided with a triplet, returns the index of the numerical element that lies between the other two elements.

        The input to the function will be an array of three distinct numbers.

        For example:

        gimme([2, 3, 1]) => 0
        2 is the number that fits between 1 and 3 and the index of 2 in the input array is 0.

        Another example (just to make sure it is clear):

        gimme([5, 10, 14]) => 1
        10 is the number that fits between 5 and 14 and the index of 10 in the input array is 1.

        */

        Assert.AreEqual(0, Gimme(new double[] { 2, 3, 1 }));
        Assert.AreEqual(1, Gimme(new double[] { 5, 10, 14 }));

        Assert.AreEqual(0, Gimme_v2(new double[] { 2, 3, 1 }));
        Assert.AreEqual(1, Gimme_v2(new double[] { 5, 10, 14 }));

    }

    public static int Gimme(double[] inputArray) => inputArray
      .Select((a, i) => (a, i))
      .OrderBy(x => x.Item1)
      .Select(x => x.Item2)
      .Skip(1)
      .FirstOrDefault();

    public static int Gimme_v2(double[] inputArray) => inputArray
      .Select((a, i) => (a, i))
      .OrderBy(x => x.a)
      .Skip(1)
      .FirstOrDefault()
      .i;
}
