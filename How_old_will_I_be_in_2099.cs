using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class How_old_will_I_be_in_2099 {
    [TestMethod]
    public void Test() {
        /*
        How old will I be in 2099?

        Philip's just turned four and he wants to know how old he will be in various years in the future such as 2090 or 3044. His parents can't keep up calculating this so they've begged you to help them out by writing a programme that can answer Philip's endless questions.

        Your task is to write a function that takes two parameters: the year of birth and the year to count years in relation to. As Philip is getting more curious every day he may soon want to know how many years it was until he would be born, so your function needs to work with both dates in the future and in the past.

        Provide output in this format: For dates in the future: "You are ... year(s) old." For dates in the past: "You will be born in ... year(s)." If the year of birth equals the year requested return: "You were born this very year!"

        "..." are to be replaced by the number, followed and proceeded by a single space. Mind that you need to account for both "year" and "years", depending on the result.

        Good Luck!

        */

        Assert.AreEqual("You are 17 years old.", CalculateAge(2003, 2020));
        Assert.AreEqual("You are 1 year old.", CalculateAge(2019, 2020));
        Assert.AreEqual("You were born this very year!", CalculateAge(2003, 2003));
        Assert.AreEqual("You will be born in 17 years.", CalculateAge(2020, 2003));
        Assert.AreEqual("You will be born in 1 year.", CalculateAge(2020, 2019));

        Assert.AreEqual("You are 17 years old.", CalculateAge_v2(2003, 2020));
        Assert.AreEqual("You are 1 year old.", CalculateAge_v2(2019, 2020));
        Assert.AreEqual("You were born this very year!", CalculateAge_v2(2003, 2003));
        Assert.AreEqual("You will be born in 17 years.", CalculateAge_v2(2020, 2003));
        Assert.AreEqual("You will be born in 1 year.", CalculateAge_v2(2020, 2019));
    }

    public static string CalculateAge(int birth, int yearTo) =>
      (new Dictionary<int, string>() {
          {-1, "You will be born in இ years."},
          { 0, "You were born this very year!"},
          { 1, "You are இ years old."} })
        [Math.Sign(yearTo - birth)]
        .Replace("இ", $"{Math.Abs(yearTo - birth)}")
        .Replace(Math.Abs(yearTo - birth) == 1 ? "years" : "ൠ", "year");

    public static string CalculateAge_v2(int birth, int yearTo) => (yearTo - birth) switch {
              0 => "You were born this very year!",
              1 => "You are 1 year old.",
            > 1 => $"You are {yearTo - birth} years old.",
             -1 => "You will be born in 1 year.",
              _ => $"You will be born in {birth - yearTo} years."
        };
    
}
