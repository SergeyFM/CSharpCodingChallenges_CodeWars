using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class The_Office_II_Boredom_Score {
    [TestMethod]
    public void Test() {
        /*

        The Office II - Boredom Score

        Each department has a different boredom assessment score, as follows:

        accounts = 1
        finance = 2
        canteen = 10
        regulation = 3
        trading = 6
        change = 6
        IS = 8
        retail = 5
        cleaning = 4
        pissing about = 25

        Depending on the cumulative score of the team, return the appropriate sentiment:

        <=80: 'kill me now'
        < 100 & > 80: 'i can handle this'
        100 or over: 'party time!!'

        */

        Assert.AreEqual("kill me now", Boredom(new Dictionary<string, string>() { { "Tim", "accounts" }, { "Jim", "trading" }, { "Sandy", "regulation" }, { "Andy", "accounts" }, { "Katie", "finance" }, { "Laura", "IS" } }));
        Assert.AreEqual("i can handle this", Boredom(new Dictionary<string, string>() { { "Jim", "pissing about" }, { "Tim", "regulation" }, { "Andy", "IS" }, { "Laura", "pissing about" }, { "Alex", "canteen" }, { "John", "canteen" } }));
        Assert.AreEqual("party time!!", Boredom(new Dictionary<string, string>() { { "Andy", "pissing about" }, { "Tim", "accounts" }, { "Smith", "pissing about" }, { "Randy", "pissing about" }, { "Sandy", "IS" }, { "Laura", "pissing about" } }));

    }

    public static string Boredom(Dictionary<string, string> staff) =>
        @"accounts = 1
        finance = 2
        canteen = 10
        regulation = 3
        trading = 6
        change = 6
        IS = 8
        retail = 5
        cleaning = 4
        pissing about = 25".Split("\n")
                           .Select(s => s.Split("="))
                           .Select(s => (s.First().Trim(), int.Parse(s.Last())))
        .Select(x => (staff.Count(d=> d.Value==x.Item1) * x.Item2))
        .Sum() switch {
            <= 80 => "kill me now",
            < 100 => "i can handle this",
            _ => "party time!!"
        };



}
