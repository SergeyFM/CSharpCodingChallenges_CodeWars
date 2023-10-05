using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Switcheroo {
    [TestMethod]
    public void Test() {
        /*

        Switcheroo

        Given a string made up of letters a, b, and/or c, switch the position of letters a and b (change a to b and vice versa). Leave any incidence of c untouched.

        Example:

        'acb' --> 'bca'
        'aabacbaa' --> 'bbabcabb'

        */

        Assert.AreEqual("bac", fnSwitcheroo("abc"));
        Assert.AreEqual("bbbacccabbb", fnSwitcheroo("aaabcccbaaa"));
        Assert.AreEqual("ccccc", fnSwitcheroo("ccccc"));
    }

    public static string fnSwitcheroo(string x) => x
  .Select(c => "ab".Contains(c) ? "ab"[1 - "ab".IndexOf(c)] : c)
  .Aggregate("", (a, b) => $"{a}{b}");
}
