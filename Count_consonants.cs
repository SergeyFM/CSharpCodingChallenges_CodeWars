using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Count_consonants {

    /*

    Count consonants

    Complete the function that takes a string of English-language text and returns the number of consonants in the string.

    Consonants are all letters used to write English excluding the vowels a, e, i, o, u.

    */

    [DataTestMethod]
    [DataRow("", 0)]
    [DataRow("aaaaa", 0)]
    [DataRow("Bbbbb", 5)]
    [DataRow("helLo world", 7)]
    [DataRow("h^$&^#$&^elLo world", 7)]
    [DataRow("012456789", 0)]
    [DataRow("012345_Cb", 2)]
    public void Test(string str, int expected) => Assert.AreEqual(expected, ConsonantCount(str));

    public static int ConsonantCount(string str) => str.WhereOnlyConsonants().Count();

}

public static class MyExtensions {
    public static IEnumerable<char> WhereOnlyConsonants(this IEnumerable<char> chars) {
        foreach (char c in chars)
            if (char.IsLetter(c) && !"aeiou".Contains(char.ToLower(c))) yield return c;
    }
}
