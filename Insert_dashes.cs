using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Insert_dashes {
    [TestMethod]
    public void Test() {

        /*

        Insert dashes

        Write a function insert_dash(num) / insertDash(num) / InsertDash(int num) that will insert dashes ('-') between each two odd digits in num. 
        For example: if num is 454793 the output should be 4547-9-3.
        Note that the number will always be non-negative (>= 0).

        */

        Assert.AreEqual("4547-9-3", InsertDash(454793));
        Assert.AreEqual("123456", InsertDash(123456));
        Assert.AreEqual("1003-567", InsertDash(1003567));

        Assert.AreEqual("4547-9-3", InsertDash_v2(454793));
        Assert.AreEqual("123456", InsertDash_v2(123456));
        Assert.AreEqual("1003-567", InsertDash_v2(1003567));

    }

    public static string InsertDash(int num) {
        string strNum = "";
        while (num > 0) {
            strNum += "" + num % 10;
            num /= 10;
        }
        strNum = string.Concat(strNum.Reverse());
        string ret = $"{strNum[0]}";
        for (int i = 0; i < strNum.Length - 1; i++)
            ret += (strNum[i] - '0') % 2 == 1 && (strNum[i + 1] - '0') % 2 == 1 ? $"-{strNum[i + 1]}" : $"{strNum[i + 1]}";
        return ret;
    }

    public static string InsertDash_v2(int num) => $"{num}"
        .Aggregate("", (s, c) => s.Length != 0 && (c & s[^1] & 1) == 1 ? $"{s}-{c}" : $"{s}{c}");

}
