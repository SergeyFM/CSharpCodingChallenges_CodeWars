using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Decipher_this {
    [TestMethod]
    public void Test() {

        /*

        Decipher this!

        You are given a secret message you need to decipher. Here are the things you need to know to decipher it:

        For each word:

        the second and the last letter is switched (e.g. Hello becomes Holle)
        the first letter is replaced by its character code (e.g. H becomes 72)
        Note: there are no special characters used, only letters and spaces

        Examples

        decipherThis('72olle 103doo 100ya'); // 'Hello good day'
        decipherThis('82yade 115te 103o'); // 'Ready set go'

        */

        Assert.AreEqual("Ready set go", DecipherThis("82yade 115te 103o"));
        Assert.AreEqual("A wise old owl lived in an oak", DecipherThis("65 119esi 111dl 111lw 108dvei 105n 97n 111ka"));
        Assert.AreEqual("Have a go at this and see how you do", DecipherThis("72eva 97 103o 97t 116sih 97dn 115ee 104wo 121uo 100o"));

    }

    public static string DecipherThis(string s) => string.IsNullOrWhiteSpace(s) ? "" : string.Join(" ", s
        .Split(" ")
        .Select(w => (char)int.Parse(string.Concat(w.TakeWhile(char.IsDigit))) + 
                                     string.Concat(w.SkipWhile(char.IsDigit)))
        .Select(w => {
            if (w.Length < 3) return w;
            var ret = w.ToCharArray();
            ret[1] = w[^1];
            ret[^1] = w[1];
            return new string(ret);
        })
    );
}
