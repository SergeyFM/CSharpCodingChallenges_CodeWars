using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CodingChallenges;
[TestClass]
public class Printing_Array_elements_with_Comma_delimiters {
    [TestMethod]
    public void Test() {
        /*
        Printing Array elements with Comma delimiters

        Input: Array of elements
        ["h","o","l","a"]

        Output: String with comma delimited elements of the array in th same order.
        "h,o,l,a"

        */

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var data = new object[] { 2 };
        Assert.AreEqual("2", PrintArray_v2(data), "single int test failed 2 !=" + PrintArray(data));

        data = new object[] { 2, 4, 5, 2 };
        Assert.AreEqual("2,4,5,2", PrintArray_v2(data), "int test failed 2,4,5,2 != " + PrintArray(data));

        data = new object[] { 2.0, 4.2, 5.1, 2.2 };
        Assert.AreEqual("2,4.2,5.1,2.2", PrintArray_v2(data), "floats test failed 2,4.2,5.1,2.2 !=" + PrintArray(data));

        data = new object[] { "2", "4", "5", "2" };
        Assert.AreEqual("2,4,5,2", PrintArray(data), "String test failed 2,4,5,2 != " + PrintArray(data));

        var array1 = new object[] { "hello", "this", "is", "an", "array!" };
        var array2 = new object[] { "a", "b", "c", "d", "e!" };
        data = new object[] { array1, array2 };
        Assert.AreEqual("hello,this,is,an,array!,a,b,c,d,e!", PrintArray(data), "Array of array test failed hello,this,is,an,array!,a,b,c,d,e! !=" + PrintArray(data));

        array1 = new object[] { "hello", "this", "is", "an", "array!" };
        array2 = new object[] { 1, 2, 3, 4, 5 };
        data = new object[] { array1, array2 };
        Assert.AreEqual("hello,this,is,an,array!,1,2,3,4,5", PrintArray(data), "arrays of different type array test failed hello,this,is,an,array!,1,2,3,4,5 !=" + PrintArray(data));

        object x = new { firstName = "John", lastName = "Doe" };
        object y = new { firstName = "Ruslan", lastName = "López" };
        data = new object[] { x, y };
        Assert.AreEqual("{ firstName = John, lastName = Doe },{ firstName = Ruslan, lastName = López }", PrintArray(data), "object test failed [object Object],[object Object] != " + PrintArray(data));

        data = new object[] { true, false };
        Assert.AreEqual("True,False", PrintArray(data), "boolean test failed true,false != " + PrintArray(data));

    }

    public static string PrintArray(object[] array) {
        List<string> ret = new();
        foreach (var item in array) {
            var obj = item as object[];
            if (obj is null) ret.Add($"{item}");
            else ret.Add(PrintArray(obj));
        }
        return string.Join(",", ret);
    }

    public static string PrintArray_v2(object[] array) => array
    .Select(x => x is object[]? PrintArray(x as object[]) : $"{x}")
    .Aggregate((a, b) => $"{a},{b}");
    
}
