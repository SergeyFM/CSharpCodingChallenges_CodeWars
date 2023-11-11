using System.Linq;

namespace CodingChallenges;
[TestClass]
public class The_Office_VI_Sabbatical {

    /*

    The Office VI - Sabbatical

    Learning to code around your full time job is taking over your life. You realise that in order to make significant steps quickly, it would help to go to a coding bootcamp in London.

    Problem is, many of them cost a fortune, and those that don't still involve a significant amount of time off work - who will pay your mortgage?!

    To offset this risk, you decide that rather than leaving work totally, you will request a sabbatical so that you can go back to work post bootcamp and be paid while you look for your next role.

    You need to approach your boss. Her decision will be based on three parameters:

    val = your value to the organisation
    happiness = her happiness level at the time of asking and finally
    The numbers of letters from 'sabbatical' that are present in string s.

    Note that if s contains three instances of the letter 'l', that still scores three points, even though there is only one in the word sabbatical.

    If the sum of the three parameters (as described above) is > 22, return 'Sabbatical! Boom!', else return 'Back to your desk, boy.'.

    */

    [TestMethod]
    public void Test() {
      Assert.AreEqual("Sabbatical! Boom!", Sabb("Can I have a sabbatical?", 5, 5));
      Assert.AreEqual("Back to your desk, boy.", Sabb("Why are you shouting?", 7, 2));
      Assert.AreEqual("Sabbatical! Boom!", Sabb("What do you mean I cant learn to code??", 8, 9));
      Assert.AreEqual("Back to your desk, boy.", Sabb("Please calm down", 9, 1));
    }

    struct Reply {
        public static string YES = "Sabbatical! Boom!";
        public static string NO = "Back to your desk, boy.";
    }

    public static string Sabb(string s, int val, int happiness) {
        int numberOfLetters = s.Where(x => "sabbatical".Contains(char.ToLower(x))).Count();
        int pointsOverall = val + happiness + numberOfLetters;
        return pointsOverall > 22 ? Reply.YES : Reply.NO;
    }
}
