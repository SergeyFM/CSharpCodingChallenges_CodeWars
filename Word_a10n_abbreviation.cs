using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Word_a10n_abbreviation {
    [TestMethod]
    public void Test() {

        /*

        Word a10n (abbreviation)

        The word i18n is a common abbreviation of internationalization in the developer community, used instead of typing the whole word and trying to spell it correctly. Similarly, a11y is an abbreviation of accessibility.

        Write a function that takes a string and turns any and all "words" (see below) within that string of length 4 or greater into an abbreviation, following these rules:

        A "word" is a sequence of alphabetical characters. By this definition, any other character like a space or hyphen (eg. "elephant-ride") will split up a series of letters into two words (eg. "elephant" and "ride").
        The abbreviated version of the word should have the first letter, then the number of removed characters, then the last letter (eg. "elephant ride" => "e6t r2e").
        Example
        abbreviate("elephant-rides are really fun!")
        //          ^^^^^^^^*^^^^^*^^^*^^^^^^*^^^*
        // words (^):   "elephant" "rides" "are" "really" "fun"
        //                123456     123     1     1234     1
        // ignore short words:               X              X

        // abbreviate:    "e6t"     "r3s"  "are"  "r4y"   "fun"
        // all non-word characters (*) remain in place
        //                     "-"      " "    " "     " "     "!"
        === "e6t-r3s are r4y fun!"

        */

        Assert.AreEqual("i18n", Abbreviate("internationalization"));
        Assert.AreEqual("my. dog, isn't f5g v2y w2l.", Abbreviate("my. dog, isn't feeling very well."));
        Assert.AreEqual("You n2d, n2d not w2t, to c6e t2s c2e-w2s m5n", Abbreviate("You need, need not want, to complete this caae-waas mission"));

    }

    public static string Abbreviate(string input) {
        string strResult = "";
        string currentWord = "";
        foreach (char c in input + "#") {
            if (char.IsLetter(c)) currentWord += c;
            else {
                strResult += (currentWord.Length >= 4 ? 
                    $"{currentWord.First()}{currentWord.Length - 2}{currentWord.Last()}" : 
                    currentWord) + c;
                currentWord = "";
            }
        }
        return strResult[..^1];
    }


}
