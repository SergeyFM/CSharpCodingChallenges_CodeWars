using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Complete_The_Pattern_4 {

    /*

    Complete The Pattern #4

    --- Task:
    You have to write a function pattern which creates the following pattern upto n number of rows. 
    If the Argument is 0 or a Negative Integer then it should return "" i.e. empty string.

    --- Examples:
    pattern(4):

    1234
    234
    34
    4
    pattern(6):

    123456
    23456
    3456
    456
    56
    6

    Note: There are no blank spaces

    Hint: Use \n in string to jump to next line

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual("1", Pattern(1));
        Assert.AreEqual("12\n2", Pattern(2));
        Assert.AreEqual("12345\n2345\n345\n45\n5", Pattern(5));
        Assert.AreEqual("", Pattern(0));
        Assert.AreEqual("", Pattern(-25));

        Assert.AreEqual("1", Pattern_v2(1));
        Assert.AreEqual("12\n2", Pattern_v2(2));
        Assert.AreEqual("12345\n2345\n345\n45\n5", Pattern_v2(5));
        Assert.AreEqual("", Pattern_v2(0));
        Assert.AreEqual("", Pattern_v2(-25));
    }

    public static string Pattern(int n) => n <= 0 ? string.Empty :
        string.Join('\n',
            Enumerable.Range(0, n)
                .Select(row => string.Concat(Enumerable.Range(n - row, row + 1)))
                .Reverse()
        );

    public static string Pattern_v2(int n) => string.Join('\n', 
        Enumerable.Range(0, n < 0 ? 0 : n)
        .Select(i => string.Concat(Enumerable.Range(1, n).Skip(i)))
    );
  

}
