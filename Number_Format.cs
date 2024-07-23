using System;
using System.Globalization;

namespace CodingChallenges;

[TestClass]
public class Number_Format {

    /*

        Number Format

        Format any integer provided into a string with "," (commas) in the correct places.

        Example:

        For n = 100000 the function should return '100,000';
        For n = 5678545 the function should return '5,678,545';
        for n = -420902 the function should return '-420,902'.

    */

    [TestMethod]
    public void Test() {

        Assert.AreEqual("100,000", NumberFormat(100000));
        Assert.AreEqual("5,678,545", NumberFormat(5678545));
        Assert.AreEqual("-420,902", NumberFormat(-420902));
        Assert.AreEqual("-42,902", NumberFormat(-42902));
        Assert.AreEqual("0", NumberFormat(0));

        Assert.AreEqual("100,000", NumberFormatQuick(100000));


    }

    public static string NumberFormat(int number) {
        char[] resArr = "0               ".ToCharArray();
        int ind = 0;
        int dInd = 0;
        bool signMinus = number < 0;
        number = Math.Abs(number);
        while (number > 0) {
            dInd++;
            int d = number % 10;
            number /= 10;
            resArr[ind++] = (char)('0' + d);
            if (dInd % 3 == 0 && number != 0) resArr[ind++] = ',';
        }
        if (signMinus) resArr[ind] = '-';
        Array.Reverse(resArr);
        return string.Join("", resArr).Trim();
    }

    public static string NumberFormatQuick(int number) => number
        .ToString("N0", CultureInfo.InvariantCulture);
}
