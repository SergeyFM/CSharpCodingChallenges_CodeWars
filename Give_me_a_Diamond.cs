using System.Text;

namespace CodingChallenges;
[TestClass]
public class Give_me_a_Diamond {
    [TestMethod]
    public void Test() {
        /*

        Give me a Diamond

        Jamie is a programmer, and James' girlfriend. She likes diamonds, and wants a diamond string from James. Since James doesn't know how to make this happen, he needs your help.

        Task
        You need to return a string that looks like a diamond shape when printed on the screen, using asterisk (*) characters. Trailing spaces should be removed, and every line must be terminated with a newline character (\n).

        Return null/nil/None/... if the input is an even number or negative, as it is not possible to print a diamond of even or negative size.

        Examples
        A size 3 diamond:

         *
        ***
         *
        ...which would appear as a string of " *\n***\n *\n"

        A size 5 diamond:

          *
         ***
        *****
         ***
          *
        ...that is:

        "  *\n ***\n*****\n ***\n  *\n"

        */

        Assert.IsNull(print(0));
        Assert.IsNull(print(-2));
        Assert.IsNull(print(2));

        var expected = new StringBuilder();
        expected.Append("*\n");
        Assert.AreEqual(expected.ToString(), print(1));

        expected = new StringBuilder();
        expected.Append(" *\n");
        expected.Append("***\n");
        expected.Append(" *\n");
        Assert.AreEqual(expected.ToString(), print(3));

        expected = new StringBuilder();
        expected.Append("  *\n");
        expected.Append(" ***\n");
        expected.Append("*****\n");
        expected.Append(" ***\n");
        expected.Append("  *\n");
        Assert.AreEqual(expected.ToString(), print(5));
    }


    public static string print(int n) {
        if (n < 1 || n % 2 == 0) return null;
        if (n == 1) return "*\n";
        string lines = "";

        int stars = 1;
        for (int i = 0; i < n; i++) {
            string gap = new(' ', n / 2 - stars / 2);
            lines += gap + new string('*', stars) + "\n";
            if (i < n / 2) stars += 2; else stars -= 2;
        }
        return lines;
    }
}
