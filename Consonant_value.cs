using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Consonant_value {
    [TestMethod]
    public void Test() {

        /*

        Consonant value

        Given a lowercase string that has alphabetic characters only and no spaces, return the highest value of consonant substrings. Consonants are any letters of the alphabet except "aeiou".

        We shall assign the following values: a = 1, b = 2, c = 3, .... z = 26.

        For example, for the word "zodiacs", let's cross out the vowels. We get: "z o d ia cs"

        -- The consonant substrings are: "z", "d" and "cs" and the values are z = 26, d = 4 and cs = 3 + 19 = 22. The highest is 26.
        solve("zodiacs") = 26

        For the word "strength", solve("strength") = 57
        -- The consonant substrings are: "str" and "ngth" with values "str" = 19 + 20 + 18 = 57 and "ngth" = 14 + 7 + 20 + 8 = 49. The highest is 57.
               
        
        */
        Assert.AreEqual(26, Solve("zodiac"));
        Assert.AreEqual(80, Solve("chruschtschov"));
        Assert.AreEqual(38, Solve("khrushchev"));
        Assert.AreEqual(57, Solve("strength"));
        Assert.AreEqual(73, Solve("catchphrase"));
        Assert.AreEqual(103, Solve("twelfthstreet"));
        Assert.AreEqual(80, Solve("mischtschenkoana"));

        Assert.AreEqual(26, Solve_v2("zodiac"));
        Assert.AreEqual(80, Solve_v2("chruschtschov"));
        Assert.AreEqual(38, Solve_v2("khrushchev"));
        Assert.AreEqual(57, Solve_v2("strength"));
        Assert.AreEqual(73, Solve_v2("catchphrase"));
        Assert.AreEqual(103, Solve_v2("twelfthstreet"));
        Assert.AreEqual(80, Solve_v2("mischtschenkoana"));
    }

    public static int Solve(string s) => s
            .ToLower()
            .Where(char.IsLetter)
            .Select(c => "aeiou".Contains(c) ? ' ' : c)
            .Aggregate("", (a, b) => $"{a}{b}")
            .Split(" ")
            .Select(w => w.Sum(c => c - 'a' + 1))
            .Max();

    public static int Solve_v2(string s) => s
        .Split("aeiou".ToCharArray())
        .Select(w => w.Sum(c => c - 'a' + 1))
        .Max();
}
