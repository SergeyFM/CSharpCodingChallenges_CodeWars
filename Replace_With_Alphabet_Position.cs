using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;

[TestClass]
public class Replace_With_Alphabet_Position {
    [TestMethod]
    public void Test() {

        /*
        given a string, replace every letter with its position in the alphabet.
        If anything in the text isn't a letter, ignore it and don't return it.
        */


        Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", AlphabetPosition("The sunset sets at twelve o' clock."));
        Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", AlphabetPosition("The narwhal bacons at midnight."));
    }

    public static string AlphabetPosition(string text) {
        int a = (int)'a' - 1;
        IEnumerable<int> lst = text.ToLower().Where(c => Char.IsLetter(c)).Select(c => (int)c - a);
        return String.Join(" ", lst);
    }


}