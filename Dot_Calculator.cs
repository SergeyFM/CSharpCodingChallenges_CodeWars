using System;

namespace CodingChallenges;
[TestClass]
public class Dot_Calculator {

    /*

    Dot Calculator
    
    You have to write a calculator that receives strings for input. The dots will represent the number in the equation. There will be dots on one side, an operator, and dots again after the operator. The dots and the operator will be separated by one space.

    Here are the following valid operators :

    + Addition
    - Subtraction
    * Multiplication
    // Integer Division
    Your Work (Task)
    You'll have to return a string that contains dots, as many the equation returns. If the result is 0, return the empty string. When it comes to subtraction, the first number will always be greater than or equal to the second number.

    Examples (Input => Output)
    * "..... + ..............." => "...................."
    * "..... - ..."             => ".."
    * "..... - ."               => "...."
    * "..... * ..."             => "..............."
    * "..... * .."              => ".........."
    * "..... // .."             => ".."
    * "..... // ."              => "....."
    * ". // .."                 => ""
    * ".. - .."                 => ""

    */

    [TestMethod]
    public void Test() {

        Assert.AreEqual("....................", Calculator("..... + ..............."));
        Assert.AreEqual("..", Calculator("..... - ..."));
        Assert.AreEqual("....", Calculator("..... - ."));
        Assert.AreEqual("...............", Calculator("..... * ..."));
        Assert.AreEqual("..........", Calculator("..... * .."));
        Assert.AreEqual("..", Calculator("..... // .."));
        Assert.AreEqual(".....", Calculator("..... // ."));
        Assert.AreEqual("", Calculator(". // .."));
        Assert.AreEqual("", Calculator(". - ."));


    }

    public static string Calculator(string txt) {
        if (string.IsNullOrWhiteSpace(txt)) throw new ArgumentException("txt");
        string[] delimeters = { "*", "+", "-", "//" };
        string theDelimeter = string.Empty;
        foreach (string del in delimeters) {
            if (txt.Contains(del)) theDelimeter = del;
            txt = txt.Replace(del, "#");
        }
        string[] parts = txt.Split('#');
        if (parts.Length != 2) throw new InvalidOperationException("txt: should contain only two parts");
        int[] numbers = { 0, 0 };
        for (int i = 0; i <= 1; i++) {
            string part = parts[i].Trim();
            if (part.Replace(".", "") != string.Empty) throw new InvalidOperationException("txt: only dots are allowed");
            numbers[i] = part.Length;
        }
        Func<int, int, int> oper = theDelimeter switch {
            "*" => (a, b) => a * b,
            "+" => (a, b) => a + b,
            "-" => (a, b) => a - b,
            "//" => (a, b) => a / b,
            _ => throw new InvalidOperationException("Invalid operator")
        };
        int res = oper(numbers[0], numbers[1]);
        return new string('.', res);
    }
}
