using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Your_order_please {
    [TestMethod]
    public void Test() {

        /*

        Your order, please

        Your task is to sort a given string. Each word in the string will contain a single number. 
        This number is the position the word should have in the result.

        Note: Numbers can be from 1 to 9. So 1 will be the first word (not 0).
        If the input string is empty, return an empty string. 
        The words in the input String will only contain valid consecutive numbers.


        */

        Assert.AreEqual("Thi1s is2 3a T4est", Order("is2 Thi1s T4est 3a"));
        Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", Order("4of Fo1r pe6ople g3ood th5e the2"));
        Assert.AreEqual("", Order(""));

        Assert.AreEqual("Thi1s is2 3a T4est", Order_v2("is2 Thi1s T4est 3a"));
        Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", Order_v2("4of Fo1r pe6ople g3ood th5e the2"));
        Assert.AreEqual("", Order_v2(""));
    }

    public static string Order(string words) => words
        .Split(" ")
        .Select(x => (x, x.Where(char.IsDigit).FirstOrDefault() - '0'))
        .OrderBy(t => t.Item2)
        .Select(t => t.Item1)
        .Aggregate((a, b) => $"{a} {b}");

    public static string Order_v2(string words) => words
        .Split(" ")
        .OrderBy(w => w.SingleOrDefault(char.IsDigit))
        .Aggregate((a, b) => $"{a} {b}");

}
