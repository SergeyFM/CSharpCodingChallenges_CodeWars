using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenges;
[TestClass]
public class Form_The_Minimum {
    [TestMethod]
    public void Test() {
        /*
        Given a list of digits, return the smallest number that could be formed from these digits, using the digits only once (ignore duplicates).

        Notes:
        Only positive integers will be passed to the function (> 0 ), no negatives or zeros.
        Input >> Output Examples
        minValue ({1, 3, 1})  ==> return (13)
        Explanation: (13) is the minimum number could be formed from {1, 3, 1} , Without duplications
        */

        Assert.AreEqual(13, MinValue(new int[] { 1, 3, 1 }));
        Assert.AreEqual(457, MinValue(new int[] { 4, 7, 5, 7 }));
        Assert.AreEqual(148, MinValue(new int[] { 4, 8, 1, 4 }));
        Assert.AreEqual(579, MinValue(new int[] { 5, 7, 9, 5, 7 }));
        Assert.AreEqual(678, MinValue(new int[] { 6, 7, 8, 7, 6, 6 }));
        Assert.AreEqual(45679, MinValue(new int[] { 5, 6, 9, 9, 7, 6, 4 }));
        Assert.AreEqual(134679, MinValue(new int[] { 1, 9, 1, 3, 7, 4, 6, 6, 7 }));
        Assert.AreEqual(356789, MinValue(new int[] { 3, 6, 5, 5, 9, 8, 7, 6, 3, 5, 9 }));

    }

    public static long MinValue(int[] a) => a
      .Distinct()
      .OrderByDescending(x => x)
      .Select((x, ind) => x * int.Parse("1" + new string('0', ind)))
      .Sum();
}
