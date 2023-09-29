using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Write_Number_in_Expanded_Form {
    [TestMethod]
    public void Test() {
        /*
        Write Number in Expanded Form
        You will be given a number and you will need to return it as a string in Expanded Form. For example:

        Kata.ExpandedForm(12); # Should return "10 + 2"
        Kata.ExpandedForm(42); # Should return "40 + 2"
        Kata.ExpandedForm(70304); # Should return "70000 + 300 + 4"
        NOTE: All numbers will be whole numbers greater than 0.
        */

        Assert.AreEqual("10 + 2", ExpandedForm(12));
        Assert.AreEqual("40 + 2", ExpandedForm(42));
        Assert.AreEqual("70000 + 300 + 4", ExpandedForm(70304));

        Assert.AreEqual("10 + 2", ExpandedForm_v2(12));
        Assert.AreEqual("40 + 2", ExpandedForm_v2(42));
        Assert.AreEqual("70000 + 300 + 4", ExpandedForm_v2(70304));

        Assert.AreEqual("10 + 2", ExpandedForm_v3(12));
        Assert.AreEqual("40 + 2", ExpandedForm_v3(42));
        Assert.AreEqual("70000 + 300 + 4", ExpandedForm_v3(70304));

    }

    public static string ExpandedForm(long num) {
        List<long> digits = new();
        while (num > 0) {
            digits.Add(num % 10);
            num /= 10;
        }

        long multi = 1;
        List<long> digitValues = new();
        digits.ForEach(d => {
            digitValues.Add(d * multi);
            multi *= 10;
        });

        return digitValues
            .Where(x => x > 0).Reverse()
            .Select(x => $"{x}").Aggregate((a, b) => $"{a} + {b}");
    }

    public static string ExpandedForm_v2(long num) => string.Join(" + ", $"{num}"
        .Select((c, i) => c + new string('0', $"{num}".Length - i - 1))
        .Where(s => s.First() != '0')
    );

    public static string ExpandedForm_v3(long num) => $"{num}"
    .Select((c, i) => c + new string('0', $"{num}".Length - i - 1))
    .Where(s => s.First() != '0')
    .Aggregate((a, b) => $"{a} + {b}");


}
