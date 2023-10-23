using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class _4kyu_Connect_Four {

    /*

    Connect Four

    Take a look at wiki description of Connect Four game:

    Wiki Connect Four

    The grid is 6 row by 7 columns, those being named from A to G.

    You will receive a list of strings showing the order of the pieces which dropped in columns:

    List<string> myList = new List<string>()
    {
        "A_Red",
        "B_Yellow",
        "A_Red",
        "B_Yellow",
        "A_Red",
        "B_Yellow",
        "G_Red",
        "B_Yellow"
    };
    The list may contain up to 42 moves and shows the order the players are playing.

    The first player who connects four items of the same color is the winner.

    You should return "Yellow", "Red" or "Draw" accordingly.

    */

    [TestMethod]
    public void Main() {

        List<string> myList = new List<string>()
           {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            };
        Assert.AreEqual("Yellow", WhoIsWinner(myList), "it should return Yellow");

        myList = new List<string>()
       {
                "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            };
        Assert.AreEqual("Red", WhoIsWinner(myList), "it should return Red");


        myList = new List<string>()
         {
                "C_Yellow",
                "E_Red",
                "G_Yellow",
                "B_Red",
                "D_Yellow",
                "B_Red",
                "B_Yellow",
                "G_Red",
                "C_Yellow",
                "C_Red",
                "D_Yellow",
                "F_Red",
                "E_Yellow",
                "A_Red",
                "A_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "F_Yellow",
                "D_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "A_Red",
                "G_Yellow",
                "D_Red",
                "D_Yellow",
                "C_Red"
            };
        Assert.AreEqual("Yellow", WhoIsWinner(myList), "it should return Yellow");

        myList = new List<string>() {
            "C_Yellow", "B_Red", "B_Yellow", "E_Red", "D_Yellow", "G_Red", "B_Yellow", "G_Red", "E_Yellow", "A_Red", "G_Yellow", "C_Red", "A_Yellow", "A_Red", "D_Yellow", "B_Red", "G_Yellow", "A_Red", "F_Yellow", "B_Red", "D_Yellow", "A_Red", "F_Yellow", "F_Red", "B_Yellow", "F_Red", "F_Yellow", "G_Red", "A_Yellow", "F_Red", "C_Yellow", "C_Red", "G_Yellow", "C_Red", "D_Yellow", "D_Red", "E_Yellow", "D_Red", "E_Yellow", "C_Red", "E_Yellow", "E_Red"

            };
        Assert.AreEqual("Yellow", WhoIsWinner(myList), "it should return Yellow");

    }

    public static string WhoIsWinner(List<string> piecesPositionList) {
        // Put the grid into a dictionary and check it 
        Dictionary<char, List<char>> rows = "ABCDEFG".ToDictionary(c => c, c => new List<char>());
        foreach (var piece in piecesPositionList) {
            char row = char.ToUpper(piece.First());
            char color = char.ToUpper(piece.Split('_').Last().First());
            if (rows.ContainsKey(row)) rows[row].Add(color);
            bool win = CheckTheRows(rows);
            if (win) return color == 'Y' ? "Yellow" : "Red";
        }
        return "Draw";
    }

    public static bool CheckTheRows(Dictionary<char, List<char>> rows) {
        int maxLength = rows.Values.Max(r => r.Count());

        //check each row
        if (rows.Values.Any(r => CantainsWin(string.Concat(r)))) return true;

        // check each line
        string[] lines = new string[maxLength];
        for (int x = 0; x < lines.Length; x++) {
            foreach (List<char> row in rows.Values) {
                lines[x] += x < row.Count ? row[x] : '*';
            }
        }
        if (lines.Count() > 0 && lines.Any(CantainsWin))  return true;

        // check queer 1: /
        for (int x = 0; x < 7 + maxLength; x++) {
            int xPtr = x;
            string line = "";
            foreach (List<char> row in rows.Values) {
                line += xPtr >= 0 && xPtr < row.Count ? row[xPtr] : "*"; 
                xPtr--;
            }
            if (CantainsWin(line))  return true;
        }
        // check queer 2: \
        for (int x = -7 - maxLength; x < maxLength; x++) {
            int xPtr = x;
            string line = "";
            foreach (List<char> row in rows.Values) {
                line += xPtr >= 0 && xPtr < row.Count ? row[xPtr] : "*";
                xPtr++;
            }
            if (CantainsWin(line)) return true;
        }
        return false;
    }

    public static bool CantainsWin(string line) => string.IsNullOrWhiteSpace(line) ? false : line.Contains("YYYY") || line.Contains("RRRR");


}
