using System.Linq;

namespace CodingChallenges;
[TestClass]
public class ToLeetSpeakClass {
    [TestMethod]
    public void Test() {

        /*

        ToLeetSpeak

        Your task is to write a function toLeetSpeak that converts a regular english sentence to Leetspeak.

        More about LeetSpeak You can read at wiki -> https://en.wikipedia.org/wiki/Leet

        Consider only uppercase letters (no lowercase letters, no numbers) and spaces.

        For example:

        toLeetSpeak("LEET") returns "1337"
        In this kata we use a simple LeetSpeak dialect. Use this alphabet:

        {
          A : '@',
          B : '8',
          C : '(',
          D : 'D',
          E : '3',
          F : 'F',
          G : '6',
          H : '#',
          I : '!',
          J : 'J',
          K : 'K',
          L : '1',
          M : 'M',
          N : 'N',
          O : '0',
          P : 'P',
          Q : 'Q',
          R : 'R',
          S : '$',
          T : '7',
          U : 'U',
          V : 'V',
          W : 'W',
          X : 'X',
          Y : 'Y',
          Z : '2'
        }

        */

        Assert.AreEqual("1337", ToLeetSpeak("LEET"));
        Assert.AreEqual("(0D3W@R$", ToLeetSpeak("CODEWARS"));
        Assert.AreEqual("#3110 W0R1D", ToLeetSpeak("HELLO WORLD"));
        Assert.AreEqual("10R3M !P$UM D010R $!7 @M37", ToLeetSpeak("LOREM IPSUM DOLOR SIT AMET"));
        Assert.AreEqual("7#3 QU!(K 8R0WN F0X JUMP$ 0V3R 7#3 1@2Y D06", ToLeetSpeak("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"));

    }

    public static string ToLeetSpeak(string str) {
        var codepage = @" A : @,
                          B : 8,
                          C : (,
                          D : D,
                          E : 3,
                          F : F,
                          G : 6,
                          H : #,
                          I : !,
                          J : J,
                          K : K,
                          L : 1,
                          M : M,
                          N : N,
                          O : 0,
                          P : P,
                          Q : Q,
                          R : R,
                          S : $,
                          T : 7,
                          U : U,
                          V : V,
                          W : W,
                          X : X,
                          Y : Y,
                          Z : 2"
        .Split(",").Select(x => x.Split(":")).ToDictionary(x => x.First().Trim().First(), x => x.Last().Trim().First());
        return string.Concat(str.Select(c => codepage.TryGetValue(c, out var val) ? val : c));
    }

}
