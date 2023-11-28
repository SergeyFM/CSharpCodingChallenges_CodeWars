using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Write_out_numbers {

    /*

    Write out numbers

    Create a function that transforms any positive number to a string representing the number in words. The function should work for all numbers between 0 and 999999.

    --- Examples ---

    number2words(0)  ==>  "zero"
    number2words(1)  ==>  "one"
    number2words(9)  ==>  "nine"
    number2words(10)  ==>  "ten"
    number2words(17)  ==>  "seventeen"
    number2words(20)  ==>  "twenty"
    number2words(21)  ==>  "twenty-one"
    number2words(45)  ==>  "forty-five"
    number2words(80)  ==>  "eighty"
    number2words(99)  ==>  "ninety-nine"
    number2words(100)  ==>  "one hundred"
    number2words(301)  ==>  "three hundred one"
    number2words(799)  ==>  "seven hundred ninety-nine"
    number2words(800)  ==>  "eight hundred"
    number2words(950)  ==>  "nine hundred fifty"
    number2words(1000)  ==>  "one thousand"
    number2words(1002)  ==>  "one thousand two"
    number2words(3051)  ==>  "three thousand fifty-one"
    number2words(7200)  ==>  "seven thousand two hundred"
    number2words(7219)  ==>  "seven thousand two hundred nineteen"
    number2words(8330)  ==>  "eight thousand three hundred thirty"
    number2words(99999)  ==>  "ninety-nine thousand nine hundred ninety-nine"
    number2words(888888)  ==>  "eight hundred eighty-eight thousand eight hundred eighty-eight"


    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual("zero", Number2Words(0));
        Assert.AreEqual("one", Number2Words(1));
        Assert.AreEqual("three", Number2Words(3));
        Assert.AreEqual("five", Number2Words(5));
        Assert.AreEqual("eight", Number2Words(8));
        Assert.AreEqual("three hundred one", Number2Words(301));
        Assert.AreEqual("seven hundred ninety-three", Number2Words(793));
        Assert.AreEqual("eight hundred", Number2Words(800));
        Assert.AreEqual("six hundred fifty", Number2Words(650));
        Assert.AreEqual("one thousand", Number2Words(1000));
        Assert.AreEqual("one thousand three", Number2Words(1003));

    }

    public static string Number2Words(int n) {
        if (n == 0) return "zero";
        else if (n < 0) return "negative " + Number2Words(-n);
        return string.Concat(GetInteger(n, "", 0).SkipWhile(c => c == '-'));
    }

    static string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    static string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    static string[] tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
    static string[] thousandsGroups = { "", " thousand", " million", " billion" };
    private static string GetInteger(int n, string leftDigits, int thousands) {
        if (n == 0) return leftDigits;
        string leftInt = leftDigits;
        leftInt += leftInt.Length > 10 ? " " : "-";
        if (n < 10) leftInt += ones[n];
        else if (n < 20) leftInt += teens[n - 10];
        else if (n < 100) leftInt += GetInteger(n % 10, tens[n / 10 - 2], 0);
        else if (n < 1000) leftInt += GetInteger(n % 100, (ones[n / 100] + " hundred"), 0);
        else {
            leftInt += GetInteger(n % 1000, GetInteger(n / 1000, "", thousands + 1), 0);
            if (n % 1000 == 0) return leftInt;
        }
        return leftInt + thousandsGroups[thousands];
    }


}
