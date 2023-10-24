using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges;
[TestClass]
public class _3kyu_Help_the_general_decode_secret_enemy_messages {



    [TestMethod]
    public void Test() {

        /*

        Help the general decode secret enemy messages

        General Patron is faced with a problem , his intelligence has intercepted some secret messages from the enemy but they are all encrypted. Those messages are crucial to getting the jump on the enemy and winning the war. Luckily intelligence also captured an encoding device as well. However even the smartest programmers weren't able to crack it though. So the general is asking you , his most odd but brilliant programmer.

        You can call the encoder like this.

        Console.WriteLine(Encoder.Encode("Hello World!"));
        Our cryptoanalysts kept poking at it and found some interesting patterns.

        Console.WriteLine(Encoder.Encode ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        Console.WriteLine(Encoder.Encode ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
        Console.WriteLine(Encoder.Encode ("!@#$%^&*()_+-"));

        StringBuilder a = new StringBuilder();
        StringBuilder b = new StringBuilder();
        StringBuilder c = new StringBuilder();
        foreach (char w in "abcdefghijklmnopqrstuvwxyz") {
            a.Append(Encoder.Encode (  "" + w)[0]);
            b.Append(Encoder.Encode ( "_" + w)[1]);
            c.Append(Encoder.Encode ("__" + w)[2]);
        }

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        We think if you keep on this trail you should be able to crack the code! You are expected to fill in the

        public static string Decode(string p_what)
        function. Good luck ! General Patron is counting on you!

        */

    }

    public static string Decode(string p_what) {
        Dictionary<int, string> theKey = AcquireTheKeyTable();
        string decodedString = string.Concat(p_what.Select((c, ind) =>
             theKey[ind % 66].Contains(c) ? theKey[-1][theKey[ind % 66].IndexOf(c)] : (char)c));
        return decodedString;
    }

    public static Dictionary<int, string> AcquireTheKeyTable() {
        string alfabet = " " + string.Concat(
          Enumerable.Range(44, 79)
            .Where(n => n != 45 && n != 47 && !(n > 57 && n < 63) && !(n > 90 && n < 97))
            .Select(n => (char)n)
        );
        List<string> encodedCharLines = new();
        foreach (char ch in alfabet) {
            string longStr = new string(ch, 66);
            string encoded = Encoder.Encode(longStr);
            encodedCharLines.Add(encoded);
        }
        Dictionary<int, string> dic = new();
        dic.Add(-1, alfabet); //= decoded character
        for (int ptr = 0; ptr < encodedCharLines.First().Length; ptr++) dic.Add(ptr, "");
        for (int ptr = 0; ptr < encodedCharLines.First().Length; ptr++)
            for (int i = 0; i < encodedCharLines.Count(); i++) dic[ptr] += encodedCharLines[i][ptr];
        return dic;
    }

    // Someone else's solution that I chose after completion.
    public static string Decode_v2(string p_what) {
        var key = "abdhpF,82QsLirJejtNmzZKgnB3SwTyXG ?.6YIcflxVC5WE94UA1OoD70MkvRuPqH";
        var response = new StringBuilder();
        for (int i = 0; i < p_what.Length; i++) {
            var idx = key.IndexOf(p_what[i]);
            if (idx == -1) {
                response.Append(p_what[i]);
                continue;
            }
            var locator = (idx + 65 - i) % 66;
            while (locator < 0) {
                locator += 66;
            }
            response.Append(key[locator]);
        }
        return response.ToString();
    }
}
