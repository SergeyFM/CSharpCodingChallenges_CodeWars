using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Street_Fighter_2_Character_Selection {
    [TestMethod]
    public void Test() {

        /*

        Street Fighter 2 - Character Selection

        Short Intro

        Some of you might remember spending afternoons playing Street Fighter 2 in some Arcade back in the 90s or emulating it nowadays with the numerous emulators for retro consoles.
        Can you solve it? Suuure-You-Can!

        The Kata

        You'll have to simulate the video game's character selection screen behaviour, more specifically the selection grid. 
        Selection Grid Layout in text:

        | Ryu  | E.Honda | Blanka  | Guile   | Balrog | Vega    |
        | Ken  | Chun Li | Zangief | Dhalsim | Sagat  | M.Bison |
        Input

        the list of game characters in a 2x6 grid;
        the initial position of the selection cursor (top-left is (0,0));
        a list of moves of the selection cursor (which are up, down, left, right);

        Output

        the list of characters who have been hovered by the selection cursor after all the moves (ordered and with repetition, all the ones after a move, whether successful or not, see tests);
        Rules

        Selection cursor is circular horizontally but not vertically!

        As you might remember from the game, the selection cursor rotates horizontally but not vertically; that means that if I'm in the leftmost and I try to go left again I'll get to the rightmost (examples: from Ryu to Vega, from Ken to M.Bison) and vice versa from rightmost to leftmost.

        Instead, if I try to go further up from the upmost or further down from the downmost, I'll just stay where I am located (examples: you can't go lower than lowest row: Ken, Chun Li, Zangief, Dhalsim, Sagat and M.Bison in the above image; you can't go upper than highest row: Ryu, E.Honda, Blanka, Guile, Balrog and Vega in the above image).

        Test

        For this easy version the fighters grid layout and the initial position will always be the same in all tests, only the list of moves change.

        Notice: changing some of the input data might not help you.

        Examples

        fighters = [
          ["Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega"],
          ["Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison"]
        ]
        initial_position = (0,0)
        moves = ['up', 'left', 'right', 'left', 'left']
        then I should get:
         ['Ryu', 'Vega', 'Ryu', 'Vega', 'Balrog']
        as the characters I've been hovering with the selection cursor during my moves. Notice: Ryu is the first just because it "fails" the first up See test cases for more examples.

        fighters = [
          ["Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega"],
          ["Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison"]
        ]
        initial_position = (0,0)
        moves = ['right', 'down', 'left', 'left', 'left', 'left', 'right']
        Result:
          ['E.Honda', 'Chun Li', 'Ken', 'M.Bison', 'Sagat', 'Dhalsim', 'Sagat']

        */

        string[][] fighters = new string[][]
          {
              new string[] { "Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega" },
              new string[] { "Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison" },
          };
        string[] moves;
        string[] expected;



        moves = new string[] { };
        expected = new string[] { };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));

        moves = new string[] { "left", "left", "left", "left", "left", "left", "left", "left" };
        expected = new string[] { "Vega", "Balrog", "Guile", "Blanka", "E.Honda", "Ryu", "Vega", "Balrog" };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));

        moves = new string[] { "right", "right", "right", "right", "right", "right", "right", "right" };
        expected = new string[] { "E.Honda", "Blanka", "Guile", "Balrog", "Vega", "Ryu", "E.Honda", "Blanka" };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));

        moves = new string[] { "up", "left", "down", "right", "up", "left", "down", "right" };
        expected = new string[] { "Ryu", "Vega", "M.Bison", "Ken", "Ryu", "Vega", "M.Bison", "Ken" };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));

        moves = new string[] { "down", "down", "down", "down" };
        expected = new string[] { "Ken", "Ken", "Ken", "Ken" };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));

        moves = new string[] { "up", "up", "up", "up" };
        expected = new string[] { "Ryu", "Ryu", "Ryu", "Ryu" };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));

        moves = new string[] { "up", "left", "right", "left", "left" };
        expected = new string[] { "Ryu", "Vega", "Ryu", "Vega", "Balrog" };

        CollectionAssert.AreEqual(expected, StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
    }

    public string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves) {
        if (fighters is null || position is null || moves is null) return new string[] { };

        Dictionary<string, (int, int)> directions = new(){ // x, y
            { "left", (-1, 0) },
            { "right", (1, 0) },
            { "up", (0, -1) },
            { "down", (0, 1) } };

        List<(int, int)> arrMoves = moves
            .Select(m => directions.ContainsKey(m) ? directions[m] : (0, 0))
            .Where(x => x != (0, 0))
            .ToList();

        int x = position.First(), y = position.Last();
        List<string> who = new();
        int arrWidth = fighters.Min(x => x.Length);
        arrMoves.ForEach(m => {
            (x, y) = (x + m.Item1, y + m.Item2);
            if (x < 0) x = arrWidth - 1;
            if (x > arrWidth - 1) x = 0;
            if (y < 0) y = 0;
            if (y > 1) y = 1;
            who.Add(fighters[y][x]);
        });

        return who.ToArray();
    }

}
