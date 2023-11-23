using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class up_AND_down {

    /*

    up AND down

    You are given a string s made up of substring s(1), s(2), ..., s(n) separated by whitespaces. Example: "after be arrived two My so"

    Task
    Return a string t having the following property:

    length t(O) <= length t(1) >= length t(2) <= length t(3) >= length t(4) .... (P)

    where the t(i) are the substring of s; you must respect the following rule:

    at each step from left to right, you can only move either already consecutive strings or strings that became consecutive after a previous move. The number of moves should be minimum.

    Let us go with our example:
    The length of "after" is greater than the length of "be". Let us move them ->"be after arrived two My so"

    The length of "after" is smaller than the length of "arrived". Let us move them -> "be arrived after two My so"

    The length of "after" is greater than the length of "two" ->"be arrived two after My so"

    The length of "after" is greater than the length of "My". Good! Finally the length of "My" and "so" are the same, nothing to do. At the end of the process, the substrings s(i) verify:

    length s(0) <= length s(1) >= length s(2) <= length s(3) >= length (s4) <= length (s5)

    Hence given a string s of substrings s(i) the function arrange with the previous process should return a unique string t having the property (P).

    It is kind of roller coaster or up and down. When you have property (P), to make the result more "up and down" visible t(0), t(2), ... will be lower cases and the others upper cases.

    arrange("after be arrived two My so") should return "be ARRIVED two AFTER my SO"
    Notes:
    The string "My after be arrived so two" has the property (P) but can't be obtained by the described process so it won't be accepted as a result. The property (P) doesn't give unicity by itself.
    Process: go from left to right, move only consecutive strings when needed.
    For the first fixed tests the needed number of moves to get property (P) is given as a comment so that you can know if your process follows the rule.

    */

    [DataTestMethod]
    [DataRow("Braslia Braslia Eventually He I If She The Then They Waiting", "braslia EVENTUALLY he BRASLIA i SHE if THEN the WAITING they")]
    [DataRow("after be arrived two My so", "be ARRIVED two AFTER my SO")] //3
    [DataRow("who hit retaining The That a we taken", "who RETAINING hit THAT a THE we TAKEN")] //3
    [DataRow("on I came up were so grandmothers", "i CAME on WERE up GRANDMOTHERS so")] //4
    [DataRow("way the my wall them him", "way THE my WALL him THEM")] //1
    [DataRow("turn know great-aunts aunt look A to back", "turn GREAT-AUNTS know AUNT a LOOK to BACK")] //2

    public void Test(string input, string expected) {
        Console.WriteLine($"     INPUT: \t{input}");
        string result = Arrange(input);
        Console.WriteLine($"    RESULT: \t{result}");
        Console.WriteLine($"    EXPECT: \t{expected}");
        Assert.AreEqual(expected, result);

        //Console.WriteLine($"{item}".PadLeft(10) +": \t" + string.Join(' ',words));
        //Console.WriteLine ($"\"{strng}\"");


    }

    public static string Arrange(string strng) {
        List<string> words = strng.Split().ToList();
        // move
        for (int i = 0; i < words.Count() - 1; i++) {
            string item = words[i];
            string nextItem = words[i + 1];
            if (i % 2 == 0 && item.Length > nextItem.Length) words.Move(i, 1);
            if (i % 2 != 0 && item.Length < nextItem.Length) words.Move(i, 1);
        }
        // capitalize and lowercasize
        words = words.Select((w, ind) => ind % 2 == 0 ? w.ToLower() : w.ToUpper()).ToList();
        return string.Join(' ', words);
    }
}

public static class ListExtensions {
    // Moves item back or forward (one back: -1, one forward: +1), circular
    public static void Move<T>(this List<T> words, int currIndex, int direction) {
        int len = words?.Count() ?? 0;
        if (words is null || len == 0 || currIndex < 0 || currIndex >= len) return;
        T item = words[currIndex];
        int newIndex = currIndex + direction;
        if (newIndex < 0) newIndex = len - 1;
        else if (newIndex >= len) newIndex = 0;
        words.RemoveAt(currIndex);
        words.Insert(newIndex, item);
    }
}