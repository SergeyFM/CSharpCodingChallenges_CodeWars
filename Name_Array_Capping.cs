using System;
using System.Linq;


namespace CodingChallenges;
[TestClass]
public class Name_Array_Capping {

    /*

    Name Array Capping

    Create a method that accepts an array of names, and returns an array of each name with its first letter capitalized.

    */

    [TestMethod]
    public void Test() {
      var strings = new string[] { "jo", "nelson", "jurie"};
      CollectionAssert.AreEqual(new string[] { "Jo", "Nelson", "Jurie"}, CapMe(strings));

      strings = new string[] { "OZZA", null, "AZZA"};
      CollectionAssert.AreEqual(new string[] { "Ozza", null, "Azza"}, CapMe(strings));

      strings = null;
      Assert.ThrowsException<ArgumentNullException>(() => CapMe(strings));
      

    }

    public static string?[] CapMe(string[] strings) => strings?
      .Select(n => n is not null && n.Length > 0 
          ? char.ToUpper(n.First()) + n.Substring(Math.Min(1, n.Length)).ToLower()
          : n)
      .ToArray() 
    ?? throw new ArgumentNullException(nameof(strings));

}
