using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Frameworks;

namespace CodingChallenges;
[TestClass]
public class Array_Deep_Count {

    /*

    Array Deep Count

    You are given an array. Complete the function that returns the number of ALL elements within an array, including any nested arrays.

    Examples
    []                   -->  0
    [1, 2, 3]            -->  3
    ["x", "y", ["z"]]    -->  4
    [1, 2, [3, 4, [5]]]  -->  7
    The input will always be an array.

    */

    [DataTestMethod]
    [DataRow(new object[] { }, 0)]
    [DataRow(new object[] { 1, 2, 3 }, 3)]
    [DataRow(new object[] { "x", "y", new object[] { "z" } }, 4)]
    [DataRow(new object[] { 1, 2, new object[] { 3, 4, new object[] { 5 } } }, 7)]
    [DataRow(new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { } } } } } } } } }, 8)]
    public void Test(object data, int expected) {

        Assert.AreEqual(expected, DeepCount(data));
        Assert.AreEqual(expected, DeepCount_v2(data));

    }

    public static int DeepCount(object a) {

        int count = 0;
        bool isArray = typeof(Array).IsAssignableFrom(a.GetType());
        if (isArray) {
            var b = a as object[];
            count = b.Length;
            foreach (var o in b) count += DeepCount(o);
        }
        else
            return 0;

        return count;
    }

    public static int DeepCount_v2(object a) => ((object[])a)
        .Aggregate(0, (s, n) => s + ((n is Array) ? 1 + DeepCount((object[])n) : 1));
}
