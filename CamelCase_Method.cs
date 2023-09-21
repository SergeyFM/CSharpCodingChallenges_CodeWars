using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;

[TestClass]
public class CamelCase_Method {
    [TestMethod]
    public void Test() {

        /*
        Write a method (or function, depending on the language) that converts a string to camelCase, 
        that is, all words must have their first letter capitalized and spaces must be removed.
        */

        Assert.AreEqual("TestCase", "test case".CamelCase());
        Assert.AreEqual("CamelCaseMethod", "camel case method".CamelCase());
        Assert.AreEqual("SayHello", "say hello".CamelCase());
        Assert.AreEqual("CamelCaseWord", " camel case word".CamelCase());
        Assert.AreEqual("", "".CamelCase());
    }

}

public static class CamelCase_StringMethod {
    public static string CamelCase(this string str) {
        IEnumerable<string> d = str.Split(" ").Where(w => !String.IsNullOrWhiteSpace(w)).Select(w => Char.ToUpper(w.First()) + w.Substring(1));
        return String.Join("", d);
    }
}
