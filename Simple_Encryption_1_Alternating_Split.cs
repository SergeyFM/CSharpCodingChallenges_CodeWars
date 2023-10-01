using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Simple_Encryption_1_Alternating_Split {
    [TestMethod]
    public void Test() {
        /*

        Simple Encryption #1 - Alternating Split

        Implement a pseudo-encryption algorithm which given a string S and an integer N concatenates all the odd-indexed characters of S with all the even-indexed characters of S, this process should be repeated N times.

        Examples:

        encrypt("012345", 1)  =>  "135024"
        encrypt("012345", 2)  =>  "135024"  ->  "304152"
        encrypt("012345", 3)  =>  "135024"  ->  "304152"  ->  "012345"

        encrypt("01234", 1)  =>  "13024"
        encrypt("01234", 2)  =>  "13024"  ->  "32104"
        encrypt("01234", 3)  =>  "13024"  ->  "32104"  ->  "20314"
        Together with the encryption function, you should also implement a decryption function which reverses the process.

        If the string S is an empty value or the integer N is not positive, return the first argument without changes.

        */

        Assert.AreEqual("123", Decrypt("213", 1));

        Assert.AreEqual("This is a test!", Encrypt("This is a test!", 0));
        Assert.AreEqual("hsi  etTi sats!", Encrypt("This is a test!", 1));
        Assert.AreEqual("s eT ashi tist!", Encrypt("This is a test!", 2));
        Assert.AreEqual(" Tah itse sits!", Encrypt("This is a test!", 3));
        Assert.AreEqual("This is a test!", Encrypt("This is a test!", 4));
        Assert.AreEqual("This is a test!", Encrypt("This is a test!", -1));
        Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", Encrypt("This kata is very interesting!", 1));

        Assert.AreEqual("This is a test!", Decrypt("This is a test!", 0));
        Assert.AreEqual("This is a test!", Decrypt("hsi  etTi sats!", 1));
        Assert.AreEqual("This is a test!", Decrypt("s eT ashi tist!", 2));
        Assert.AreEqual("This is a test!", Decrypt(" Tah itse sits!", 3));
        Assert.AreEqual("This is a test!", Decrypt("This is a test!", 4));
        Assert.AreEqual("This is a test!", Decrypt("This is a test!", -1));
        Assert.AreEqual("This kata is very interesting!", Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));

    }


    public static string Encrypt(string text, int n) {
        if (string.IsNullOrEmpty(text) || n < 1) return text;
        while (n-- > 0) {
            string res = string.Concat(text.Where((a, ind) => ind % 2 != 0));
            res += string.Concat(text.Where((a, ind) => ind % 2 == 0));
            text = res;
        }
        return text;
    }

    public static string Decrypt(string text, int n) {
        if (string.IsNullOrEmpty(text) || n < 1) return text;
        while (n-- > 0) {
            string notEven = text.Substring(0, text.Length / 2);
            string even = text.Substring(text.Length / 2);
            bool endingFlag = even.Length > notEven.Length;
            if (endingFlag) notEven += " ";
            text = even
                .Zip(notEven, (a, b) => $"{a}{b}")
                .Aggregate((a, b) => $"{a}{b}");
            if (endingFlag) text = text[..^1];
        }
        return text;
    }


}
