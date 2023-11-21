using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Very_Even_Numbers {

    /*

    "Very Even" Numbers

    Write a function that returns true if the number is a "Very Even" number.

    If a number is a single digit, then it is simply "Very Even" if it itself is even.

    If it has 2 or more digits, it is "Very Even" if the sum of its digits is "Very Even".

    Examples
    number = 88 => returns false -> 8 + 8 = 16 -> 1 + 6 = 7 => 7 is odd 

    number = 222 => returns true -> 2 + 2 + 2 = 6 => 6 is even

    number = 5 => returns false

    number = 841 => returns true -> 8 + 4 + 1 = 13 -> 1 + 3 => 4 is even
    Note: The numbers will always be 0 or positive integers!

    */

    [DataTestMethod]
    [DataRow(0, true, "0 is 'Very Even'")]
    [DataRow(4, true, "4 is 'Very Even'")]
    [DataRow(12, false, "12 is not 'Very Even'")]
    [DataRow(222, true, "222 is 'Very Even'")]
    [DataRow(5, false, "5 is not 'Very Even'")]
    [DataRow(45, false, "45 is not 'Very Even'")]
    [DataRow(4554, false, "4554 is not 'Very Even'")]
    [DataRow(1234, false, "1234 is not 'Very Even'")]
    [DataRow(88, false, "88 is not 'Very Even'")]
    [DataRow(24, true, "24 is 'Very Even'")]
    [DataRow(400000220, true, "400000220 is 'Very Even'")]
    public void Test(int num, bool expected, string msg) {
        Assert.AreEqual(expected, IsVeryEvenNumber(num), msg);
        Assert.AreEqual(expected, IsVeryEvenNumber_v2(num), msg);
    }

    public static bool IsVeryEvenNumber(int number) =>
        $"{number}".Length <= 1
        ? number % 2 == 0
        : IsVeryEvenNumber($"{number}".Where(char.IsDigit).Select(c => c - '0').Sum());

    public static bool IsVeryEvenNumber_v2(int n) => (--n % 9 + 1) % 2 == 0;
}
