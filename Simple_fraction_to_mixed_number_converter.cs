using System;

namespace CodingChallenges;

[TestClass]
public class Simple_fraction_to_mixed_number_converter {
    /*
        Simple fraction to mixed number converter

        Given a string representing a simple fraction x/y, your function must return a string representing the corresponding mixed fraction in the following format:

        [sign]a b/c

        where a is integer part and b/c is irreducible proper fraction. There must be exactly one space between a and b/c. Provide [sign] only if negative (and non zero) and only at the beginning of the number (both integer part and fractional part must be provided absolute).

        If the x/y equals the integer part, return integer part only. If integer part is zero, return the irreducible proper fraction only. In both of these cases, the resulting string must not contain any spaces.

        Division by zero should raise an error (preferably, the standard zero division error of your language).

        Value ranges
        -10 000 000 < x < 10 000 000
        -10 000 000 < y < 10 000 000
        Examples
        Input: 42/9, expected result: 4 2/3.
        Input: 6/3, expedted result: 2.
        Input: 4/6, expected result: 2/3.
        Input: 0/18891, expected result: 0.
        Input: -10/7, expected result: -1 3/7.
        Inputs 0/0 or 3/0 must raise a zero division error.

        Note
        Make sure not to modify the input of your function in-place, it is a bad practice.

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual("4 2/3", MixedFraction("42/9"));
        Assert.AreEqual("2", MixedFraction("6/3"));
        Assert.AreEqual("1", MixedFraction("1/1"));
        Assert.AreEqual("1", MixedFraction("11/11"));
        Assert.AreEqual("2/3", MixedFraction("4/6"));
        Assert.AreEqual("0", MixedFraction("0/18891"));
        Assert.AreEqual("-1 3/7", MixedFraction("-10/7"));
        Assert.AreEqual("3 1/7", MixedFraction("-22/-7"));
        Assert.AreEqual("-195595/564071", MixedFraction("-195595/564071"));
        Assert.AreEqual("0", MixedFraction("0/-731900"));
    }

    public static string MixedFraction(string s) {

        // Split and parse the numerator and denominator
        string[] nums = s.Split('/');
        if (nums.Length != 2) throw new ArgumentException("Input is wrong");
        if (
            !int.TryParse(nums[0], out int numerator) ||
            !int.TryParse(nums[1], out int denominator)
            ) throw new ArgumentException("Couldn't parse the numbers");
        if (denominator == 0) throw new DivideByZeroException("Denominator shouldn't be zero");
        if (numerator == 0) return "0";
        bool signMinus = numerator < 0 ^ denominator < 0;
        numerator = Math.Abs(numerator);
        denominator = Math.Abs(denominator);

        // The integer part
        int intPart = numerator / denominator;
        int remainder = numerator % denominator;

        // If there's no reminder, we can return the answer
        if (remainder == 0) return (signMinus ? "-" : "") + $"{intPart}";

        // Simplify the fraction part
        int gcd = remainder;
        int d = denominator;
        while (d != 0) {
            int temp = d;
            d = gcd % d;
            gcd = temp;
        }
        remainder /= gcd;
        denominator /= gcd;

        // Build the answer
        string result = signMinus ? "-" : "";
        result += intPart > 0 ? $"{intPart} " : "";
        result += remainder > 0 ? $"{remainder}/{denominator}" : "";
        return result.TrimEnd();
    }

}
