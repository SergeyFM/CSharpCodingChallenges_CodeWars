namespace CodingChallenges;
[TestClass]
public class Multiply_Word_in_String
{

    /*

    Multiply Word in String

    You are to write a function that takes a string as its first parameter. This string will be a string of words.

    You are expected to then use the second parameter, which will be an integer, to find the corresponding word in the given string. The first word would be represented by 0.

    Once you have the located string you are finally going to multiply by it the third provided parameter, which will also be an integer. You are additionally required to add a hyphen in between each word.

    Example

    modifyMultiply ("This is a string", 3, 5) 

    */

    [TestMethod]
    public void Test()
    {
        Assert.AreEqual("is-is-is", ModifyMultiply("is very easy to resolve that kata", 0, 3), "should return 'is-is-is'");
        Assert.AreEqual("cheap-cheap-cheap-cheap", ModifyMultiply("Talk is cheap Show me the code", 2, 4), "should return 'cheap-cheap-cheap'");
        Assert.AreEqual("think-think-think-think-think-think", ModifyMultiply("Everyone in this country should learn how to program because it teaches you how to think", 15, 6), "should return is-is-is");
        Assert.AreEqual("ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance", ModifyMultiply("Is sloppiness in code caused by ignorance or apathy? I don't know and I don't care.", 6, 8), "should return 'ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance'");
        Assert.AreEqual("around-around-around-around-around", ModifyMultiply("Everything happening around me is very random. I am enjoying the phase, as the journey is far more enjoyable than the destination.", 2, 5), "should return'around-around-around-around-around'");


        Assert.AreEqual("is-is-is", ModifyMultiply_v2("is very easy to resolve that kata", 0, 3), "should return 'is-is-is'");
        Assert.AreEqual("cheap-cheap-cheap-cheap", ModifyMultiply_v2("Talk is cheap Show me the code", 2, 4), "should return 'cheap-cheap-cheap'");
        Assert.AreEqual("think-think-think-think-think-think", ModifyMultiply_v2("Everyone in this country should learn how to program because it teaches you how to think", 15, 6), "should return is-is-is");
        Assert.AreEqual("ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance", ModifyMultiply_v2("Is sloppiness in code caused by ignorance or apathy? I don't know and I don't care.", 6, 8), "should return 'ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance-ignorance'");
        Assert.AreEqual("around-around-around-around-around", ModifyMultiply_v2("Everything happening around me is very random. I am enjoying the phase, as the journey is far more enjoyable than the destination.", 2, 5), "should return'around-around-around-around-around'");


    }


    public static string ModifyMultiply(string str, int loc, int num) {
        if (string.IsNullOrWhiteSpace(str)) return string.Empty;
        string[] words = str.Split();
        if (loc > words.Length) return string.Empty;
        string correspondingWord = words[loc];
        string ret = string.Empty;
        while (num-- > 0) ret += correspondingWord + "-";
        return ret[0..^1];
    }

    public static string ModifyMultiply_v2(string str, int loc, int num) =>
        string.Join("-", System.Linq.Enumerable.Repeat(str.Split()[loc], num));
}
