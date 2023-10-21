using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Sum_of_integers_in_string {
    [TestMethod]
    public void Test() {

        /*

        Sum of integers in string

        Your task is to implement a function that calculates the sum of the integers inside a string. 
        For example, in the string 
            "The30quick20brown10f0x1203jumps914ov3r1349the102l4zy dog", 
        the sum of the integers is 3635.

        Note: only positive integers will be tested.


        */

        Assert.AreEqual(5, SumOfIntegersInString("2 + 3 = "));
        Assert.AreEqual(1, SumOfIntegersInString("Our company made approximately 1 million in gross revenue last quarter."));
        Assert.AreEqual(3868, SumOfIntegersInString("The Great Depression lasted from 1929 to 1939."));
        Assert.AreEqual(0, SumOfIntegersInString("Dogs are our best friends."));
        Assert.AreEqual(18, SumOfIntegersInString("C4t5 are 4m4z1ng."));
        Assert.AreEqual(3635, SumOfIntegersInString("The30quick20brown10f0x1203jumps914ov3r1349the102l4zy dog"));




    }

    public static int SumOfIntegersInString(string s) =>
          string.Concat(s.Select(c => char.IsDigit(c) ? c : ' '))
          .Split(' ')
          .Where(s => !string.IsNullOrWhiteSpace(s))
          .Sum(n => int.TryParse(n, out int val) ? val : 0);
}
