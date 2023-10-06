using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Divide_and_Conquer {
    [TestMethod]
    public void Test() {

        /*

        Divide and Conquer

        Given a mixed array of number and string representations of integers, 
        add up the non-string integers and subtract the total of the string integers.

        Return as a number.

        */

        Assert.AreEqual(2, DivCon(new object[] { 9, 3, "7", "3" }));
        Assert.AreEqual(14, DivCon(new object[] { "5", "0", 9, 3, 2, 1, "9", 6, 7 }));
        Assert.AreEqual(13, DivCon(new object[] { "3", 6, 6, 0, "5", 8, 5, "6", 2, "0" }));
        Assert.AreEqual(11, DivCon(new object[] { "1", "5", "8", 8, 9, 9, 2, "3" }));
        Assert.AreEqual(61, DivCon(new object[] { 8, 0, 0, 8, 5, 7, 2, 3, 7, 8, 6, 7 }));
        Assert.AreEqual(-6, DivCon(new object[] { "0", "1", "2", "3" }));
        Assert.AreEqual(6, DivCon(new object[] { 0, 1, 2, 3 }));
        Assert.AreEqual(0, DivCon(new object[] { 1, "1" }));
        Assert.AreEqual(-2, DivCon(new object[] { -1, "1" }));
        Assert.AreEqual(2, DivCon(new object[] { 1, "-1" }));
        Assert.AreEqual(1, DivCon(new object[] { 1 }));
        Assert.AreEqual(-1, DivCon(new object[] { "1" }));
        Assert.AreEqual(0, DivCon(new object[] { }));

        Assert.AreEqual(2, DivCon_v2(new object[] { 9, 3, "7", "3" }));
        Assert.AreEqual(14, DivCon_v2(new object[] { "5", "0", 9, 3, 2, 1, "9", 6, 7 }));


    }

    public static int DivCon(Object[] objArray) {
        int sum = 0;
        foreach (Object o in objArray) {
            if (o is string) sum -= int.TryParse(o as string, out var res) ? res : 0;
            if (o is int) sum += (int)o;
        }
        return sum;
    }

    public static int DivCon_v2(object[] objArray) => objArray.Sum(o => (o is int ? 1 : -1) * int.Parse($"{o}"));
    
}
