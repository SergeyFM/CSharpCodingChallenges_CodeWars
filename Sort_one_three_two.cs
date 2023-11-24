using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Sort_one_three_two {

    /*

    Sort - one, three, two

    Hey You !

    Sort these integers for me ...

    By name ...

    Do it now !

    --- Input
    Range is 0-999

    There may be duplicates

    The array may be empty

    --- Example
    Input: 1, 2, 3, 4
    Equivalent names: "one", "two", "three", "four"
    Sorted by name: "four", "one", "three", "two"
    Output: 4, 1, 3, 2

    --- Notes
    Don't pack words together:
    e.g. 99 may be "ninety nine" or "ninety-nine"; but not "ninetynine"
    e.g 101 may be "one hundred one" or "one hundred and one"; but not "onehundredone"

    Don't fret about formatting rules, because if rules are consistently applied it has no effect anyway:
    e.g. "one hundred one", "one hundred two"; is same order as "one hundred and one", "one hundred and two"
    e.g. "ninety eight", "ninety nine"; is same order as "ninety-eight", "ninety-nine"


    */


    [TestMethod]
    public void Test() {

        CollectionAssert.AreEqual(new[] { 8, 8, 9, 9, 10, 10 }, Sort(new[] { 8, 8, 9, 9, 10, 10 }));
        CollectionAssert.AreEqual(new[] { 4, 1, 3, 2 }, Sort(new[] { 1, 2, 3, 4 }));
        CollectionAssert.AreEqual(new[] { 9, 999, 99 }, Sort(new[] { 9, 99, 999 }));

    }

    public static int[] Sort(int[] array) => array
        .Select(n => (n, HumanFriendlyInteger.IntegerToWritten(n)))
        .OrderBy(n => n.Item2)
        .Select(n => n.Item1)
        .ToArray();
}

public static class HumanFriendlyInteger {
    // Initial class author: Susan Davis
    static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    static string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    static string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };
    private static string FriendlyInteger(int n, string leftDigits, int thousands) {
        if (n == 0) return leftDigits;
        string friendlyInt = leftDigits;
        if (friendlyInt.Length > 0) friendlyInt += " ";
        if (n < 10) friendlyInt += ones[n];
        else if (n < 20) friendlyInt += teens[n - 10];
        else if (n < 100) friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
        else if (n < 1000) friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Hundred"), 0);
        else {
            friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);
            if (n % 1000 == 0) return friendlyInt;
        }
        return friendlyInt + thousandsGroups[thousands];
    }
    public static string IntegerToWritten(int n) {
        if (n == 0) return "Zero";
        else if (n < 0) return "Negative " + IntegerToWritten(-n);
        return FriendlyInteger(n, "", 0);
    }
}