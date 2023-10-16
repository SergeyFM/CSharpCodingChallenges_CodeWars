using System;
using System.Data;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class _4kyu_Find_the_unknown_digit {
    [TestMethod]
    public void Test() {

        /*

        Find the unknown digit

        To give credit where credit is due: This problem was taken from the ACMICPC-Northwest Regional Programming Contest. Thank you problem writers.

        You are helping an archaeologist decipher some runes. He knows that this ancient society used a Base 10 system, and that they never start a number with a leading zero. He's figured out most of the digits as well as a few operators, but he needs your help to figure out the rest.

        The professor will give you a simple math expression, of the form

        [number][op][number]=[number]
        He has converted all of the runes he knows into digits. The only operators he knows are addition (+),subtraction(-), and multiplication (*), so those are the only ones that will appear. Each number will be in the range from -1000000 to 1000000, and will consist of only the digits 0-9, possibly a leading -, and maybe a few ?s. If there are ?s in an expression, they represent a digit rune that the professor doesn't know (never an operator, and never a leading -). All of the ?s in an expression will represent the same digit (0-9), and it won't be one of the other given digits in the expression. No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.

        Given an expression, figure out the value of the rune represented by the question mark. If more than one digit works, give the lowest one. If no digit works, well, that's bad news for the professor - it means that he's got some of his runes wrong. output -1 in that case.

        Complete the method to solve the expression to find the value of the unknown rune. The method takes a string as a paramater repressenting the expression and will return an int value representing the unknown rune or -1 if no such rune exists.

        ------------------------
            //Write code to determine the missing digit or unknown rune
            //Expression will always be in the form
            //(number)[opperator](number)=(number)
            //Unknown digit will not be the same as any other digits used in expression

        */


        Assert.AreEqual(2, solveExpression("1+1=?"), "Answer for expression '1+1=?' ");
        Assert.AreEqual(6, solveExpression("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");
        Assert.AreEqual(0, solveExpression("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
        Assert.AreEqual(-1, solveExpression("19--45=5?"), "Answer for expression '19--45=5?' ");
        Assert.AreEqual(5, solveExpression("??*??=302?"), "Answer for expression '??*??=302?' ");
        Assert.AreEqual(2, solveExpression("?*11=??"), "Answer for expression '?*11=??' ");
        Assert.AreEqual(2, solveExpression("??*1=??"), "Answer for expression '??*1=??' ");
        Assert.AreEqual(-1, solveExpression("??+??=??"), "Answer for expression '??+??=??' ");


        Assert.AreEqual(2, solveExpression_v2("1+1=?"), "Answer for expression '1+1=?' ");
        Assert.AreEqual(6, solveExpression_v2("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");
        Assert.AreEqual(0, solveExpression_v2("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
        Assert.AreEqual(-1, solveExpression_v2("19--45=5?"), "Answer for expression '19--45=5?' ");
        Assert.AreEqual(5, solveExpression_v2("??*??=302?"), "Answer for expression '??*??=302?' ");
        Assert.AreEqual(2, solveExpression_v2("?*11=??"), "Answer for expression '?*11=??' ");
        Assert.AreEqual(2, solveExpression_v2("??*1=??"), "Answer for expression '??*1=??' ");
        Assert.AreEqual(-1, solveExpression_v2("??+??=??"), "Answer for expression '??+??=??' ");

    }

    public static int solveExpression(string expression) {
        int missingDigit = -1;
        foreach (int Glückszahl in Enumerable.Range(0, 10)) {
            if (expression.Contains($"{Glückszahl}")) continue;
            string tryExpr = expression.Replace("?", $"{Glückszahl}");
            var parsed = parseExpr(tryExpr);
            var success = checkExpr(parsed);
            if (success) { missingDigit = Glückszahl; break; }
        }
        return missingDigit;
    }

    public static (string p1, string op, string p2, string res)? parseExpr(string e) {
        if (!e.Contains('=')) return null;
        e = e.Replace("--", "+");
        string p1 = "", op = "", p2 = "", res = "";
        string[] tmp = e.Split('=');
        res = tmp.Last();
        string left = tmp.First();
        p1 = "" + left[0];
        foreach (char c in left.Substring(1)) {
            if (char.IsDigit(c)) p1 += c;
            else { op = "" + c; break; }
        }
        p2 = left.Split(op).Last();
        return (p1.Length > 1 && p1.SkipWhile(c => !char.IsDigit(c)).First() == '0') ||
            (p2.Length > 1 && p2.SkipWhile(c => !char.IsDigit(c)).First() == '0') ||
            (res.Length > 1 && res.SkipWhile(c => !char.IsDigit(c)).First() == '0')
            ? null
            : (p1, op, p2, res);
    }

    public static bool checkExpr((string p1, string op, string p2, string res)? _e) {
        if (_e == null) return false; var e = _e ?? throw new ArgumentNullException();
        int p1 = int.TryParse(e.p1, out int tmp) ? tmp : 0;
        int p2 = int.TryParse(e.p2, out tmp) ? tmp : 0;
        int res = int.TryParse(e.res, out tmp) ? tmp : 0;
        Func<int, int, int> op = e.op switch {
            "+" => (int a, int b) => a + b,
            "-" => (int a, int b) => a - b,
            "*" => (int a, int b) => a * b,
            "/" => (int a, int b) => a / b,
            _ => (int a, int b) => 0
        };
        return op(p1, p2) == res;
    }

    public static int solveExpression_v2(string expression) {
        DataTable dt = new();
        foreach (int Glückszahl in Enumerable.Range(0, 10)) {
            if (expression.Contains($"{Glückszahl}")) continue;
            string[] parts = expression.Replace("?", $"{Glückszahl}").Split('=');
            if (dt.Compute(parts.First(), "").ToString() == parts.Last()) return Glückszahl;
        }
        return -1;
    }

}
