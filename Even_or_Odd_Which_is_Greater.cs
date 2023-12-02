using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Even_or_Odd_Which_is_Greater {

    /*

    Even or Odd - Which is Greater?

    Given a string of digits confirm whether the sum of all the individual even digits are greater than the sum of all the indiviudal odd digits. Always a string of numbers will be given.

    If the sum of even numbers is greater than the odd numbers return: "Even is greater than Odd"

    If the sum of odd numbers is greater than the sum of even numbers return: "Odd is greater than Even"

    If the total of both even and odd numbers are identical return: "Even and Odd are the same"

    */

    [DataTestMethod]
    [DataRow("123", "Odd is greater than Even")]
    [DataRow("12", "Even is greater than Odd")]
    [DataRow("112", "Even and Odd are the same")]
    public void Test(string input, string expectedResult) => 
        Assert.AreEqual(expectedResult, EvenOrOdd(input));

    public static string EvenOrOdd(string str) => str
        .Select(c => c - '0')
        .Aggregate(0, (bal, num) => num % 2 == 0 ? bal + num : bal - num)
        switch {
            > 0 => "Even is greater than Odd",
            < 0 => "Odd is greater than Even",
            _ => "Even and Odd are the same"
        };
}
