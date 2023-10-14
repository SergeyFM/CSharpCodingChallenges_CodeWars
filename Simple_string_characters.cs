using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Simple_string_characters {
    [TestMethod]
    public void Test() {

        /*

        Simple string characters

        In this challenge, you will be given a string and your task will be to return a list of ints detailing the count of uppercase letters, lowercase, numbers and special characters, as follows.

        Solve("*'&ABCDabcde12345") = [4,5,5,3]. 
        --the order is: uppercase letters, lowercase, numbers and special characters.
        More examples in the test cases.

        */

        CollectionAssert.AreEqual(new int[] { 1, 18, 3, 2 }, Solve("Codewars@codewars123.com"));
        CollectionAssert.AreEqual(new int[] { 7, 6, 3, 2 }, Solve("bgA5<1d-tOwUZTS8yQ"));
        CollectionAssert.AreEqual(new int[] { 9, 9, 6, 9 }, Solve("P*K4%>mQUDaG$h=cx2?.Czt7!Zn16p@5H"));
        CollectionAssert.AreEqual(new int[] { 15, 8, 6, 9 }, Solve("RYT'>s&gO-.CM9AKeH?,5317tWGpS<*x2ukXZD"));

    }

    public static int[] Solve(String s) => new int[] {
      s.Count(char.IsUpper),
      s.Count(char.IsLower),
      s.Count(char.IsDigit),
      s.Count(c=> !char.IsLetterOrDigit(c))
    };
}
