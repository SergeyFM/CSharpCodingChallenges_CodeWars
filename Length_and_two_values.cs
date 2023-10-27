using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Length_and_two_values {

    /*

    Length and two values.

    Given an integer n and two other values, build an array of size n filled with these two values alternating.

    Examples
    5, true, false     -->  [true, false, true, false, true]
    10, "blue", "red"  -->  ["blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red"]
    0, "one", "two"    -->  []

    Good luck!

    Assertion(new object[] {true, false, true, false, true}, (5, true, false));
      Assertion(new object[] {"blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red"}, (20, "blue", "red"));
      Assertion(new object[0], (0, "lemons", "apples"));

    */

    [DataTestMethod]
    [DataRow(new object[] { true, false, true, false, true }, 5, true, false)]
    [DataRow(new object[] { "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red", "blue", "red" }, 20, "blue", "red")]
    [DataRow(new object[0], 0, "lemons", "apples")]
    public void Test(object[] expected, int n, object firstValue, object secondValue) {
        CollectionAssert.AreEqual(expected, Alternate(n, firstValue, secondValue));
        CollectionAssert.AreEqual(expected, Alternate_v2(n, firstValue, secondValue));

    }

    public static object[] Alternate(int n, object firstValue, object secondValue) => Enumerable.Repeat(firstValue, n)
        .Zip(Enumerable.Repeat(secondValue, n))
        .SelectMany(x => new[] { x.Item1, x.Item2 })
        .Take(n)
        .ToArray();

    public static object[] Alternate_v2(int n, params object[] obj) => Enumerable.Range(0, n)
        .Select(i => obj[i % 2])
        .ToArray();
    
}
