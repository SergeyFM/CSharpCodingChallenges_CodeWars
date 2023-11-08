using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
internal class Building_Strings_From_a_Hash {

    /*

    Building Strings From a Hash

    Complete the solution so that it takes the object (JavaScript/CoffeeScript) or hash (ruby) passed in and generates a human readable string from its key/value pairs.

    The format should be "KEY = VALUE". Each key/value pair should be separated by a comma except for the last pair.

    Example:

    StringifyDict(new Dictionary<char, int> {{'a', 1}, {'b', 2}}) => "a = 1,b = 2";


    */


    [TestMethod]
    public void Test() {

        Assert.AreEqual("a = 1,b = 2", StringifyDict(new Dictionary<char, int> { { 'a', 1 }, { 'b', 2 } }));
        Assert.AreEqual("b = 1,c = 2,e = 3", StringifyDict(new Dictionary<char, int> { { 'b', 1 }, { 'c', 2 }, { 'e', 3 } }));
        Assert.AreEqual("", StringifyDict(new Dictionary<char, int>()));

    }

    public static string StringifyDict<TKey, TValue>(Dictionary<TKey, TValue> hash) => hash is not null ? string.Join(",",
        hash.Select(x => $"{x.Key} = {x.Value}")
    ) : string.Empty;

}
