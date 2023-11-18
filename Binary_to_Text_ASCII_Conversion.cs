using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Binary_to_Text_ASCII_Conversion {

    /*

    Binary to Text (ASCII) Conversion

    Write a function that takes in a binary string and returns the equivalent decoded text (the text is ASCII encoded).

    Each 8 bits on the binary string represent 1 character on the ASCII table.

    The input string will always be a valid binary string.

    Characters can be in the range from "00000000" to "11111111" (inclusive)

    Note: In the case of an empty binary string your function should return an empty string.

    */


    [TestMethod]
    public void Test() {

        Assert.AreEqual("", BinaryToString(null));
        Assert.AreEqual("", BinaryToString(""));
        Assert.AreEqual("Hello", BinaryToString("0100100001100101011011000110110001101111"));
    }

    public static string BinaryToString(string binary) {
        if (string.IsNullOrWhiteSpace(binary)) return "";
        List<char> chars = new();
        foreach (string strByte in binary.Chunk(8).Select(ch => string.Concat(ch))) {
            int theInt = Convert.ToInt32(strByte, 2);
            char theChar = Convert.ToChar(theInt);
            chars.Add(theChar);
        }
        return string.Concat(chars.ToArray());
    }

}
