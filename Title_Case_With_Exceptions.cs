using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Title_Case_With_Exceptions {
    [TestMethod]
    public void Test() {
        /*

        Title Case

        A string is considered to be in title case if each word in the string is either (a) capitalised (that is, only the first letter of the word is in upper case) or (b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.

        Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same way even if the case of the minor word string is changed.

        */

        Assert.AreEqual("A Clash of Kings", TitleCase("a clash of KINGS", "a an the of"));
        Assert.AreEqual("The Wind in the Willows", TitleCase("THE WIND IN THE WILLOWS", "The In"));
        Assert.AreEqual("The Wind In The Willows", TitleCase("The Wind in the Willows", null));

    }

    public static string TitleCase(string title, string minorWords = "") {
        string[] exc = (string.IsNullOrWhiteSpace(minorWords) ? "" : minorWords)
            .Split(" ")
            .Select(w => w.ToLower())
            .ToArray();
        return string.IsNullOrWhiteSpace(title) ? "" : title
          .Split(" ")
          .Select(w => w.ToLower())
          .Select((w, ind) => exc.Contains(w) && ind != 0 ? w : (char.ToUpper(w.FirstOrDefault()) + w[1..]))
          .Aggregate((a, b) => $"{a} {b}");
    }
}
