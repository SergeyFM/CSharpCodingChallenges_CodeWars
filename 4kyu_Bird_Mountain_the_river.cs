using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class _4kyu_Bird_Mountain_the_river {

    /*

    https://www.codewars.com/kata/5c2fd9188e358f301f5f7a7b/train/csharp

    Bird Mountain - the river

    * Background
    A high flying bird is able to estimate the contours of the ground below.
    He sees hills and valleys, he sees plains and mountains.
    But this time our protagonist bird also sees a RIVER.
    Not only that, but he sees that the river is rising rapidly, so much so that in a few days it threatens to inundate the surrounding land.
    And all this is very important to the bird because he cannot land on water!

    * The Task
    The bird quickly calculates how much ground will remain dry as the water rises.

    Can you?

    * Output
    A list of how many dry landing spots there are for the next 3 days only (include day 0)

    * Notes
    The ground is always supplied as a rectangular grid
    The normal river is at level -0.5. It is rising at 1 unit per day
    Sometimes there isn't any river at all, so you better account for those cases too!

    * Example
    The birds-eye view
      ^^^^^^       
    ^^^^^^^^       ^^^
    ^^^^^^^  ^^^
    ^^^^^^^  ^^^
    ^^^^^^^  ^^^
    ---------------------
    ^^^^^        
       ^^^^^^^^  ^^^^^^^
    ^^^^^^^^     ^     ^
    ^^^^^        ^^^^^^^
    
    The bird-brain calculations
    Day	Prediction	Number of dry landing spots

    Day 0	
      111111       
    11222221       111
    1233321  111
    1222221  121
    1111111  111
    ---------------------
    11111        
       12111111  1111111
    11122111     1     1
    11111        1111111
    189

    Day 1	
      111111-------------
    11222221-------111---
    1233321--111---------
    1222221--121---------
    1111111--111---------
    ---------------------
    11111----------------
       12111111--1111111-
    11122111-----1     1-
    11111--------1111111-
    99

    Day 2	
    ---------------------
    --22222--------------
    -23332---------------
    -22222----2----------
    ---------------------
    ---------------------
    ---------------------
    ----2----------------
    ---22----------------
    ---------------------
    19

    Day 3	
    ---------------------
    ---------------------
    --333----------------
    ---------------------
    ---------------------
    ---------------------
    ---------------------
    ---------------------
    ---------------------
    ---------------------
    3

    Dry ground = [189, 99, 19, 3]


    */


    [TestMethod]
    public void Test() {
        char[][] terrain =
       {
            "  ^^^^^^             ".ToCharArray(),
            "^^^^^^^^       ^^^   ".ToCharArray(),
            "^^^^^^^  ^^^         ".ToCharArray(),
            "^^^^^^^  ^^^         ".ToCharArray(),
            "^^^^^^^  ^^^         ".ToCharArray(),
            "---------------------".ToCharArray(),
            "^^^^^                ".ToCharArray(),
            "   ^^^^^^^^  ^^^^^^^ ".ToCharArray(),
            "^^^^^^^^     ^     ^ ".ToCharArray(),
            "^^^^^        ^^^^^^^ ".ToCharArray()
        };
        CollectionAssert.AreEqual(new int[] { 189, 99, 19, 3 }, DryGround(terrain));

    }

    public static int[] DryGround(char[][] m) {


        Console.Write(string.Join("\n", m.Select(x => "|" + string.Concat(x) + "|")) + "\n");
        Console.WriteLine(m.SelectMany(x => x).Count(p => p != '-'));

        FillTheTerrain(m);
        Console.Write(string.Join("\n", m.Select(x => "|" + string.Concat(x) + "|")) + "\n");
        Console.WriteLine(m.SelectMany(x => x).Count(p => p != '-'));


        return new int[] { 0, 0, 0, 0 };
    }

    private static void FillTheTerrain(char[][] m) {
        int rounds = 2;
        while (rounds-- > 0) {
            for (int y = 0; y < m.Length - 1; y++) { // down
                for (int x = 0; x < m[y].Length; x++) {
                    if (m[y][x] == '-') {
                        if (x < m[y].Length-1 && m[y][x + 1] != '^') m[y][x + 1] = '-';
                        if (m[y + 1][x] != '^') m[y + 1][x] = '-';
                    }

                }
            }
            for (int y = m.Length - 1; y > 0; y--) { // up
                for (int x = m[y].Length - 1; x >= 0; x--) {
                    if (m[y][x] == '-') {
                        if (x > 0 && m[y][x - 1] != '^') m[y][x - 1] = '-';
                        if (m[y - 1][x] != '^') m[y - 1][x] = '-';
                    }

                }
            }
        }
    }
}
