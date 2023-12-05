using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Remove_the_parentheses {

    /*

    Remove the parentheses

    In this kata you are given a string for example:

    "example(unwanted thing)example"
    Your task is to remove everything inside the parentheses as well as the parentheses themselves.

    The example above would return:

    "exampleexample"
    Notes
    Other than parentheses only letters and spaces can occur in the string. Don't worry about other brackets like "[]" and "{}" as these will never appear.
    There can be multiple parentheses.
    The parentheses can be nested.

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual("exampleexample", RemoveParentheses("example(unwanted thing)example"));
        Assert.AreEqual("example  example", RemoveParentheses("example (unwanted thing) example"));
        Assert.AreEqual("a e", RemoveParentheses("a (bc d)e"));
        Assert.AreEqual("a", RemoveParentheses("a(b(c))"));
        Assert.AreEqual("hello example  something", RemoveParentheses("hello example (words(more words) here) something"));
        Assert.AreEqual("  ", RemoveParentheses("(first group) (second group) (third group)"));
        Assert.AreEqual("fKi fskbxfFnRlT", RemoveParentheses("fKi(eWEryBG) fsk( fvijhsQ(ofdrBuLAwfKVWPaeTNWXLt)ZK(TyP)o)b(UYshWkOBiCRJuXDTfCPoSpL)xfFnR(i(E jhR pFiYiYknw EqKWVPb) F(wIh(YloKgYkIlRvq)NF WxfkyTcWztWjL(ZGe(wyTCnx dP qAKx)fgx  GTTjikpsHuyA d)c nu)eJxfPW(yJqEEoVQZSlpzu )(pTolhTELJueuHNmeubE )AMndR)lT"));

    }


    public static string RemoveParentheses(string s) {
        Func<List<char>, bool> removeOneParenthesis = (lstS) => {
            int firstParIndex = -1;
            int secondParIndex = -1;
            for (int i = 0; i < lstS.Count(); i++) {
                char curr = lstS[i];
                if (curr == '(') firstParIndex = i;
                if (curr == ')' && firstParIndex >= 0) {
                    secondParIndex = i;
                    break;
                }
            }
            if (firstParIndex >= 0 && secondParIndex >= 0) {
                lstS.RemoveRange(firstParIndex, secondParIndex - firstParIndex + 1);
                return true;
            }
            return false;
        };
        List<char> sAsAList = s.ToCharArray().ToList();
        while (removeOneParenthesis(sAsAList)) { };
        return string.Concat(sAsAList);
    }
}
