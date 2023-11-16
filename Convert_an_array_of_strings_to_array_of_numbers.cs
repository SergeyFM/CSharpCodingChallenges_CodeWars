using System;
using System.Globalization;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Convert_an_array_of_strings_to_array_of_numbers {
    [TestMethod]
    public void Test() {

        /*

        Convert an array of strings to array of numbers

        Oh no!
        Some really funny web dev gave you a sequence of numbers from his API response as an sequence of strings!

        You need to cast the whole array to the correct type.

        Create the function that takes as a parameter a sequence of numbers represented as strings and outputs a sequence of numbers.

        ie:["1", "2", "3"] to [1, 2, 3]

        Note that you can receive floats as well.

        */

        CollectionAssert.AreEqual(new double[] { 1.1, 2.2, 3.3 }, ToDoubleArray(new string[] { "1.1", "2.2", "3.3" }));
        //CollectionAssert.AreEqual(new double[] { 1.1, 2.2, 3.3 }, ToDoubleArray_v2(new string[] { "1.1", "2.2", "3.3" }));


    }

    public static double[] ToDoubleArray(string[] stringArray) => stringArray
          .Select(s => double.TryParse(s, CultureInfo.InvariantCulture, out double d) ? d : 0)
          .ToArray();

    public static double[] ToDoubleArray_v2(string[] stringArray) => Array.ConvertAll(stringArray, Double.Parse);
    
}
