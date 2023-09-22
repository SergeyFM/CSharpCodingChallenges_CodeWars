using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Remove_duplicate_words {
    [TestMethod]
    public void Test() {

        /*
        Your task is to remove all duplicate words from a string, leaving only single (first) words entries.

        Example:
        Input: 'alpha beta beta gamma gamma gamma delta alpha beta beta gamma gamma gamma delta'
        Output: 'alpha beta gamma delta'
        */

        Assert.AreEqual("alpha beta gamma delta", RemoveDuplicateWords("alpha beta beta gamma gamma gamma delta alpha beta beta gamma gamma gamma delta"));
        Assert.AreEqual("alpha beta gamma delta", RemoveDuplicateWords_v2("alpha beta beta gamma gamma gamma delta alpha beta beta gamma gamma gamma delta"));


    }

    public static string RemoveDuplicateWords(string s) {
        HashSet<string> dic = new();
        List<string> result = new();
        s.Split(" ").ToList().ForEach(word => {
            if (!dic.Contains(word)) result.Add(word);
            dic.Add(word);
        });
        return String.Join(" ", result);
    }

    public static string RemoveDuplicateWords_v2(string s) =>
        string.Join(" ", s.Split(" ").Distinct());
    

}
