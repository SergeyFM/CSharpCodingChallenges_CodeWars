using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Next_Palindromic_Number {
    [TestMethod]
    public void Test() {

        /*
            Next Palindromic Number

            There were and still are many problem in CW about palindrome numbers and palindrome strings. We suposse that you know which kind of numbers they are. If not, you may search about them using your favourite search engine.

            In this kata you will be given a positive integer, val and you have to create the function next_pal() that will output the smallest palindrome number higher than val.

            Let's see:

            For C#
            Kata.NextPal(11) == 22

            Kata.NextPal(188) == 191

            Kata.NextPal(191) == 202

            Kata.NextPal(2541) == 2552
            You will be receiving values higher than 10, all valid.

            Enjoy it!!

            */

        Assert.AreEqual(22, NextPal_Naive(11));
        Assert.AreEqual(191, NextPal_Naive(188));
        Assert.AreEqual(202, NextPal_Naive(191));
        Assert.AreEqual(2552, NextPal_Naive(2541));
        Assert.AreEqual(10001, NextPal_Naive(9999));

        Assert.AreEqual(22, NextPal(11));
        Assert.AreEqual(191, NextPal(188));
        Assert.AreEqual(202, NextPal(191));
        Assert.AreEqual(2552, NextPal(2541));
        Assert.AreEqual(10001, NextPal(9999));

    }

    // Naive approach
    public static int NextPal_Naive(int val) {
        if (val < 10) throw new ArgumentOutOfRangeException("val < 10");
        static bool isPalindrome(int x) {
            string strVal = $"{x}";
            IEnumerable<char> l = strVal.Take(strVal.Length / 2);
            IEnumerable<char> r = strVal.TakeLast(strVal.Length / 2).Reverse();
            return l.SequenceEqual(r);
        }
        while (!isPalindrome(++val)) ;
        return val;
    }

    // More efficient algorithm
    public static int NextPal(int val) {
        if (val < 10) throw new ArgumentOutOfRangeException("val < 10");
        string Mirror(string s, bool even) {
            string s2 = even ? s : s[..^1];
            return s + string.Join("", s2.Reverse());
        };
        int palindrome;
        string strVal = $"{++val}";
        int len = strVal.Length;
        bool even = len % 2 == 0;
        int halfLen = (len + 1) / 2;
        string firstHalf = strVal[..halfLen];
        do {
            palindrome = int.Parse(Mirror(firstHalf, even));
            firstHalf = $"{int.Parse(firstHalf) + 1}";
        } while (palindrome <= val);
        return palindrome;
    }

}
