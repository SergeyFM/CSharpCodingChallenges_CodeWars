using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Partial_Word_Searching {

    /*

        Partial Word Searching

        Write a method that will search an array of strings for all strings that contain another string, ignoring capitalization. Then return an array of the found strings.

        The method takes two parameters, the query string and the array of strings to search, and returns an array.

        If the string isn't contained in any of the strings in the array, the method returns an array containing a single string: "Empty" (or Nothing in Haskell, or "None" in Python and C)

        Examples
        If the string to search for is "me", and the array to search is ["home", "milk", "Mercury", "fish"], the method should return ["home", "Mercury"].


    */

    [TestMethod]
    public void Test() {
        
        CollectionAssert.AreEqual(new string[] { "ab", "abc", "zab" }, WordSearch("ab", new string[] { "za", "ab", "abc", "zab", "zbc" }));
        CollectionAssert.AreEqual(new string[] { "ab", "abc", "zab" }, WordSearch("aB", new string[] { "za", "ab", "abc", "zab", "zbc" }));
        CollectionAssert.AreEqual(new string[] { "aB", "Abc", "zAB" }, WordSearch("ab", new string[] { "za", "aB", "Abc", "zAB", "zbc" }));
        CollectionAssert.AreEqual(new string[] { "Empty" }, WordSearch("abcd", new string[] { "za", "aB", "Abc", "zAB", "zbc" }));
    }

    public static string[] WordSearch(string query, string[] seq) {
        string[] filtered = seq
        .Where(s => s.Contains(query, System.StringComparison.OrdinalIgnoreCase))
        .ToArray();
        return filtered.Length > 0 ? filtered : new string[] { "Empty" };
    }
}
