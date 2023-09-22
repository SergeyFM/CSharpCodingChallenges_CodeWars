using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Categorize_New_Member {
    [TestMethod]
    public void Test() {

        /*
        The Western Suburbs Croquet Club has two categories of membership, Senior and Open. 
        They would like your help with an application form that will tell prospective members 
        which category they will be placed.
        To be a senior, a member must be at least 55 years old and have a handicap greater than 7. 
        In this croquet club, handicaps range from -2 to +26; 
        the better the player the lower the handicap.
        */

        CollectionAssert.AreEqual(new[] { "Open", "Senior", "Open", "Senior" }, (System.Collections.ICollection)OpenOrSenior(new[] { new[] { 45, 12 }, new[] { 55, 21 }, new[] { 19, 2 }, new[] { 104, 20 } }));
        CollectionAssert.AreEqual(new[] { "Open", "Open", "Open", "Open" }, (System.Collections.ICollection)OpenOrSenior(new[] { new[] { 3, 12 }, new[] { 55, 1 }, new[] { 91, -2 }, new[] { 54, 23 } }));
        CollectionAssert.AreEqual(new[] { "Senior", "Open", "Open", "Open" }, (System.Collections.ICollection)OpenOrSenior(new[] { new[] { 59, 12 }, new[] { 45, 21 }, new[] { -12, -2 }, new[] { 12, 12 } }));

        CollectionAssert.AreEqual(new[] { "Open", "Senior", "Open", "Senior" }, (System.Collections.ICollection)OpenOrSenior_v2(new[] { new[] { 45, 12 }, new[] { 55, 21 }, new[] { 19, 2 }, new[] { 104, 20 } }));
        CollectionAssert.AreEqual(new[] { "Open", "Open", "Open", "Open" }, (System.Collections.ICollection)OpenOrSenior_v2(new[] { new[] { 3, 12 }, new[] { 55, 1 }, new[] { 91, -2 }, new[] { 54, 23 } }));
        CollectionAssert.AreEqual(new[] { "Senior", "Open", "Open", "Open" }, (System.Collections.ICollection)OpenOrSenior_v2(new[] { new[] { 59, 12 }, new[] { 45, 21 }, new[] { -12, -2 }, new[] { 12, 12 } }));


    }

    public static IEnumerable<string> OpenOrSenior(int[][] data) =>
         data.Select(m => m.ToList()).ToList().Select(member =>
            (member.First() >= 55 && member.Last() > 7) ? "Senior" : "Open"
         ).ToArray();

    public static IEnumerable<string> OpenOrSenior_v2(int[][] data) =>
         data.Select(member=> member[0] >= 55 && member[1] > 7 ? "Senior" : "Open").ToArray();
    


}
