using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Longest_palindrome {
    [DataTestMethod]
    [DataRow("abc0cba1", 7, "'abc0cba1' value test")]
    [DataRow("", 0, "empty string test")]
    [DataRow(null, 0, "'null' value test")]
    [DataRow("a", 1, "'a' value test")]
    [DataRow("aa", 2, "'aa' value test")]
    [DataRow("baa", 2, "'baa' value test")]
    [DataRow("abc0cba1", 7, "'abc0cba1' value test")]
    [DataRow("12 21glg", 5, "'12 21glg' value test")]
    [DataRow("   ", 3, "empty space test")]
    public void Test(string str, int exp, string inf) {

        /*

        longest_palindrome

        Longest Palindrome
        Find the length of the longest substring in the given string s that is the same in reverse.

        As an example, if the input was “I like racecars that go fast”, the substring (racecar) length would be 7.

        If the length of the input string is 0, the return value must be 0.

        Example:
        "a" -> 1 
        "aab" -> 2  
        "abcde" -> 1
        "zzbaabcd" -> 4
        "" -> 0

        */

        Console.WriteLine(inf);
        Assert.AreEqual(exp, GetLongestPalindrome(str));


    }

    // split, reverse, compare
    public static int GetLongestPalindrome(string str) {
        if (string.IsNullOrEmpty(str)) return 0;

        Func<string, string, int> compareStrBeginnings = (string str1, string str2) => {
            int lenEqual = 0;
            for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++) {
                if (str2[i] == str1[i]) lenEqual++;
                else break;
            }
            return lenEqual * 2;
        };

        string first, second;
        int maxPalindrome = 1, lenEqual = 0;
        for (int ind = 0; ind < str.Length - 1; ind++) {
            first = string.Concat(str.Substring(0, ind + 1).Reverse());
            second = str.Substring(ind + 1);
            lenEqual = compareStrBeginnings(first, second);
            maxPalindrome = maxPalindrome < lenEqual ? lenEqual : maxPalindrome;
            if (ind < str.Length - 2) {
                first = string.Concat(str.Substring(0, ind + 1).Reverse());
                second = str.Substring(ind + 2);
                lenEqual = compareStrBeginnings(first, second) + 1;
                maxPalindrome = maxPalindrome < lenEqual ? lenEqual : maxPalindrome;
            }

        }
        return maxPalindrome;
    }

}
