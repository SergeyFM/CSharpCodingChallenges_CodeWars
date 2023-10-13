using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Sort_by_Last_Char {
    [TestMethod]
    public void Test() {

        /*

        Sort by Last Char

        Given a string of words (x), you need to return an array of the words, sorted alphabetically by the final character in each.

        If two words have the same last letter, they returned array should show them in the order they appeared in the given string.

        All inputs will be valid.

        */

        CollectionAssert.AreEqual(new[] { "cba", "cab", "abc" }, Last("abc cba cab"));
        CollectionAssert.AreEqual(new[] { "aaa", "bbb", "ccc", "ddd" }, Last("bbb ccc aaa ddd"));
        CollectionAssert.AreEqual(new[] { "wa", "de", "co", "rs" }, Last("co de wa rs"));
        CollectionAssert.AreEqual(new[] { "axa", "ava", "asa" }, Last("axa ava asa"));

        CollectionAssert.AreEqual(new[] { "a", "need", "ubud", "i", "taxi", "man", "to", "up" },
            Last("man i need a taxi up to ubud"));

        CollectionAssert.AreEqual(new[] { "time", "are", "we", "the", "climbing", "volcano", "up", "what" },
            Last("what time are we climbing up the volcano"));

        CollectionAssert.AreEqual(new[] { "take", "me", "semynak", "to" }, Last("take me to semynak"));

        CollectionAssert.AreEqual(new[] { "massage", "massage", "massage", "yes", "yes" },
            Last("massage yes massage yes massage"));

        CollectionAssert.AreEqual(new[] { "a", "and", "take", "dance", "please", "bintang" },
            Last("take bintang and a dance please"));

    }

    public static string[] Last(string x) => x
        .Split(" ")
        .OrderBy(w => char.ToLower(w.LastOrDefault()))
        .ToArray();

}
