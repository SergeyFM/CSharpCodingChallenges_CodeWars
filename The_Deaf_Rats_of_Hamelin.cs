using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class The_Deaf_Rats_of_Hamelin {

    /*

    The Deaf Rats of Hamelin

    Story
    The Pied Piper has been enlisted to play his magical tune and coax all the rats out of town.
    But some of the rats are deaf and are going the wrong way!

    The Task
    How many deaf rats are there?

    Legend
    P = The Pied Piper
    O~ = Rat going left
    ~O = Rat going right

    Example
    ex1 ~O~O~O~O P has 0 deaf rats

    ex2 P O~ O~ ~O O~ has 1 deaf rat

    ex3 ~O~O~O~OP~O~OO~ has 2 deaf rats

    */

    [DataTestMethod]
    [DataRow("~O~O~O~O P", 0)]
    [DataRow("P O~ O~ ~O O~", 1)]
    [DataRow("~O~O~O~OP~O~OO~", 2)]
    public void Test(string town, int count) {
        Assert.AreEqual(count, CountDeafRats(town));
        Assert.AreEqual(count, CountDeafRats_v2(town));

    }

    public static int CountDeafRats(string town) {
        string[] sides = town.Split('P');
        string allLeft = string.Concat(
            (sides.First() + string.Concat(sides.Last().Reverse()))
            .Where("~O".Contains));
        return allLeft
            .Chunk(2)
            .Where(s => new string(s) == "O~")
            .Count();
    }

    public static int CountDeafRats_v2(string town) {
        return town
                .Replace(" ", "")
                .Where((x, i) => i % 2 == 0)
                .Count(x => x == 'O');
    }
}
