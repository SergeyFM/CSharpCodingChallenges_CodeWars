using System;

namespace CodingChallenges;
[TestClass]
public class Round_by_0_5_steps {

    /*

    Round by 0.5 steps

    Round any given number to the closest 0.5 step

    I.E.

    solution(4.2) = 4
    solution(4.3) = 4.5
    solution(4.6) = 4.5
    solution(4.8) = 5
    Round up if number is as close to previous and next 0.5 steps.

    solution(4.75) == 5

    solution(45.5) = 45.0

    */

    [TestMethod]
    public void Main() {

        Assert.AreEqual(4, Solution(4.2));
        Assert.AreEqual(4.5, Solution(4.4));
        Assert.AreEqual(4.5, Solution(4.6));
        Assert.AreEqual(5, Solution(4.8));

        Assert.AreEqual(4, Solution_v2(4.2));
        Assert.AreEqual(4.5, Solution_v2(4.4));
        Assert.AreEqual(4.5, Solution_v2(4.6));
        Assert.AreEqual(5, Solution_v2(4.8));

    }

    public static double Solution(double n) {

        double t = Math.Truncate(n);
        double d = n - t;
        double dRounded = d switch {
            <= 0.25 => 0d,
            < 0.75 => 0.5d,
            _ => 1d
        };
        return t + dRounded;
    }

    public static double Solution_v2(double n) =>
        Math.Round(n * 2) / 2;

}
