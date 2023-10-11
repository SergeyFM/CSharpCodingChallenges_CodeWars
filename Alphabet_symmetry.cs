using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Alphabet_symmetry {
    [TestMethod]
    public void Test() {

        /*

        Alphabet symmetry

        Consider the word "abode". We can see that the letter a is in position 1 and b is in position 2. In the alphabet, a and b are also in positions 1 and 2. Notice also that d and e in abode occupy the positions they would occupy in the alphabet, which are positions 4 and 5.

        Given an array of words, return an array of the number of letters that occupy their positions in the alphabet for each word. For example,

        solve(["abode","ABc","xyzD"]) = [4, 3, 1]
        See test cases for more examples.

        Input will consist of alphabet characters, both uppercase and lowercase. No spaces.

        */


        CollectionAssert.AreEqual(new List<int> { 4, 3, 1 }, Solve(new List<string> { "abode", "ABc", "xyzD" }));
        CollectionAssert.AreEqual(new List<int> { 4, 3, 0 }, Solve(new List<string> { "abide", "ABc", "xyz" }));
        CollectionAssert.AreEqual(new List<int> { 6, 5, 7 }, Solve(new List<string> { "IAMDEFANDJKL", "thedefgh", "xyzDEFghijabc" }));
        CollectionAssert.AreEqual(new List<int> { 1, 3, 1, 3 }, Solve(new List<string> { "encode", "abc", "xyzD", "ABmD" }));

    }

    public static List<int> Solve(List<string> arr) => arr.Select(x => x.ToLower())
        .Select(x => x
                .Where((c, ind) => ind == c - 'a')
                .Count())
        .ToList();
}
