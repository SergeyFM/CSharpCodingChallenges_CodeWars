using System;

namespace CodingChallenges;
[TestClass]
public class Balanced_Number_Special_Numbers_Series_1 {

    /*

    Balanced Number (Special Numbers Series #1 )

    A balanced number is a number where the sum of digits to the left of the middle digit(s) and the sum of digits to the right of the middle digit(s) are equal.

    If the number has an odd number of digits, then there is only one middle digit. (For example, 92645 has one middle digit, 6.) Otherwise, there are two middle digits. (For example, the middle digits of 1301 are 3 and 0.)

    The middle digit(s) should not be considered when determining whether a number is balanced or not, e.g. 413023 is a balanced number because the left sum and right sum are both 5.

    The task
    Given a number, find if it is balanced, and return the string "Balanced" or "Not Balanced" accordingly. The passed number will always be positive.

    Examples

    7 ==> return "Balanced"
    Explanation:
    middle digit(s): 7
    sum of all digits to the left of the middle digit(s) -> 0
    sum of all digits to the right of the middle digit(s) -> 0
    0 and 0 are equal, so it's balanced.
    295591 ==> return "Not Balanced"
    Explanation:
    middle digit(s): 55
    sum of all digits to the left of the middle digit(s) -> 11
    sum of all digits to the right of the middle digit(s) -> 10
    11 and 10 are not equal, so it's not balanced.
    959 ==> return "Balanced"
    Explanation:
    middle digit(s): 5
    sum of all digits to the left of the middle digit(s) -> 9
    sum of all digits to the right of the middle digit(s) -> 9
    9 and 9 are equal, so it's balanced.
    27102983 ==> return "Not Balanced"
    Explanation:
    middle digit(s): 02
    sum of all digits to the left of the middle digit(s) -> 10
    sum of all digits to the right of the middle digit(s) -> 20
    10 and 20 are not equal, so it's not balanced.

    */
    [DataTestMethod]
    [DataRow(56239814, "Balanced")]
    [DataRow(7, "Balanced")]
    [DataRow(959, "Balanced")]
    [DataRow(13, "Balanced")]
    [DataRow(424, "Balanced")]
    [DataRow(438361970, "Not Balanced")]
    [DataRow(66545, "Not Balanced")]
    [DataRow(295591, "Not Balanced")]
    [DataRow(1230987, "Not Balanced")]
    [DataRow(432, "Not Balanced")]
    public void Test(int num, string exp) => Assert.AreEqual(exp, BalancedNumber(num));

    public static string BalancedNumber(int number) {
        if (number < 0) throw new ArgumentOutOfRangeException("number");
        if (number < 10) return "Balanced";

        //split
        string strNumber = $"{number}";
        string left, right;
        if (strNumber.Length % 2 == 0) { // 123 0 xx 0 321
            left = strNumber.Substring(0, strNumber.Length / 2 - 1) + "0";
            right = "0" + strNumber.Substring(strNumber.Length / 2 + 1);
        }
        else { // 123 0 x 0 321
            left = strNumber.Substring(0, strNumber.Length / 2) + "0";
            right = "0" + strNumber.Substring(strNumber.Length / 2 + 1);
        }

        //try sum
        int len = left.Length;
        int leftSum = 0;
        int rightSum = 0;
        for (int i = 0; i < len; i++) {
            leftSum += left[i] - '0';
            rightSum += right[len - i - 1] - '0';
        }
        if (leftSum == rightSum) return "Balanced";
        return "Not Balanced";
    }


}
