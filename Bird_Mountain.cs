using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Bird_Mountain {

    /*

    Bird Mountain

    The Task
    A bird flying high above a mountain range is able to estimate the height of the highest peak.

    Can you?

    Example
    The birds-eye view
    ^^^^^^
     ^^^^^^^^
      ^^^^^^^
      ^^^^^
      ^^^^^^^^^^^
      ^^^^^^
      ^^^^
    The bird-brain calculations
    111111
     1^^^^111
      1^^^^11
      1^^^1
      1^^^^111111
      1^^^11
      1111

    111111
     12222111
      12^^211
      12^21
      12^^2111111
      122211
      1111

    111111
     12222111
      1233211
      12321
      12332111111
      122211
      1111

    Height = 3

    */


    [TestMethod]
    public void Test() {
        char[][] mountain =
{
            "^^^^^^        ".ToCharArray(),
            " ^^^^^^^^     ".ToCharArray(),
            "  ^^^^^^^     ".ToCharArray(),
            "  ^^^^^       ".ToCharArray(),
            "  ^^^^^^^^^^^ ".ToCharArray(),
            "  ^^^^^^      ".ToCharArray(),
            "  ^^^^        ".ToCharArray()
        };
        Assert.AreEqual(3, PeakHeight(mountain));
    }

    public static int PeakHeight(char[][] m) {

        Console.WriteLine(string.Join("\n", m.Select(x => "|" + string.Concat(x) + "|")) + "\n");
        int round = 0;
        while (m.Any(x => x.Contains('^'))) {
            round++;
            // scan left-right
            for (int y = 0; y < m.Length; y++) {
                for (int x = 0; x < m[y].Length; x++) {
                    if (x == 0 || x == m[y].Length - 1) { if (m[y][x] != ' ') m[y][x] = '#'; }
                    else if ((m[y][x - 1] == ' ' || m[y][x + 1] == ' ') && m[y][x] != ' ') m[y][x] = '#';
                }
            }

            // scan up-down
            for (int x = 0; x < m[0].Length; x++) {
                for (int y = 0; y < m.Length; y++) {
                    if (y == 0 || y == m.Length - 1) { if (m[y][x] != ' ') m[y][x] = '#'; }
                    else if ((m[y - 1][x] == ' ' || m[y + 1][x] == ' ') && m[y][x] != ' ') m[y][x] = '#';
                }
            }

            Console.WriteLine(string.Join("\n", m.Select(x => "|" + string.Concat(x) + "|")) + "\n");
            // remove edges
            for (int y = 0; y < m.Length; y++) {
                for (int x = 0; x < m[y].Length; x++) {
                    if (m[y][x] == '#') m[y][x] = ' ';
                }
            }
        }

        return round;
    }



}
