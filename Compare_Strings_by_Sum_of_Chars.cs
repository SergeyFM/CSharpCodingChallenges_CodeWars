using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Compare_Strings_by_Sum_of_Chars {

    /*

    Compare Strings by Sum of Chars

    Compare two strings by comparing the sum of their values (ASCII character code).

    For comparing treat all letters as UpperCase
    null/NULL/Nil/None should be treated as empty strings
    If the string contains other characters than letters, treat the whole string as it would be empty
    Your method should return true, if the strings are equal and false if they are not equal.

    Examples:
    "AD", "BC"  -> equal
    "AD", "DD"  -> not equal
    "gf", "FG"  -> equal
    "zz1", ""   -> equal (both are considered empty)
    "ZzZz", "ffPFF" -> equal
    "kl", "lz"  -> not equal
    null, ""    -> equal


    */


    [TestMethod]
    public void Test() {

        Assert.AreEqual(true, Compare("AD", "BC"));
        Assert.AreEqual(false, Compare("AD", "DD"));

    }

    public static bool Compare(string s1, string s2) =>
        string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) ||
        (s1 + s2).Where(c => !char.IsLetter(c)).Count() != 0 ||
        s1.Select(c => (int)char.ToUpper(c)).Sum() == s2.Select(c => (int)char.ToUpper(c)).Sum();

}

