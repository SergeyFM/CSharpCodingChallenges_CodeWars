using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Land_perimeter {

    /*

    Land perimeter

    Given an array arr of strings, complete the function by calculating the total perimeter of all the islands. Each piece of land will be marked with 'X' while the water fields are represented as 'O'. Consider each tile being a perfect 1 x 1 piece of land. Some examples for better visualization:

    ['XOOXO',
     'XOOXO',
     'OOOXO',
     'XXOXO',
     'OXOOO'] 

    should return: "Total land perimeter: 24".

    Following input:

    ['XOOO',
     'XOXO',
     'XOXO',
     'OOXX',
     'OOOO']

    should return: "Total land perimeter: 18"


    */


    [DataTestMethod]
    [DataRow("", "Total land perimeter: 0")]
    [DataRow("O", "Total land perimeter: 0")]
    [DataRow("X", "Total land perimeter: 4")]
    [DataRow("OXOOOX OXOXOO XXOOOX OXXXOO OOXOOX OXOOOO OOXOOX OOXOOO OXOOOO OXOOXX", "Total land perimeter: 60")]
    [DataRow("OXOOO OOXXX OXXOO XOOOO XOOOO XXXOO XOXOO OOOXO OXOOX XOOOO OOOXO", "Total land perimeter: 52")]
    [DataRow("XXXXXOOO OOXOOOOO OOOOOOXO XXXOOOXO OXOXXOOX", "Total land perimeter: 40")]
    [DataRow("XOOOXOO OXOOOOO XOXOXOO OXOXXOO OOOOOXX OOOXOXX XXXXOXO", "Total land perimeter: 54")]
    [DataRow("OOOOXO XOXOOX XXOXOX XOXOOO OOOOOO OOOXOO OOXXOO", "Total land perimeter: 40")]
    public void Test(string input, string expected) =>
        Assert.AreEqual(expected, Calculate(input.Split()));
    

    public static string Calculate(string[] map) {
        int peri = 0;
        if (map is null || map.Length == 0 || map.FirstOrDefault("").Length == 0) goto goOut;

        string mapAsString = string.Join(' ', map);
        int countX = mapAsString.Count(c => c == 'X');
        int hDelims = CountContChar(mapAsString, 'X');

        List<string> rotatedArr = new();
        foreach (int ind in map.FirstOrDefault("").Select((_, i) => i)) 
            rotatedArr.Add( string.Concat(map.Select(r => r[ind])) );
        string rotatedMapAsString = string.Join(' ', rotatedArr);
        int vDelims = CountContChar(rotatedMapAsString, 'X');

        peri = countX * 4 - (hDelims + vDelims) * 2;

        goOut: return $"Total land perimeter: {peri}";
    }

    private static int CountContChar(string str, char ch) {
        int masterCounter = 0;
        int regionalCounter = 0;
        foreach (char c in str) {
            if (c == ch) regionalCounter++; else regionalCounter = 0;
            if (regionalCounter > 1) masterCounter++;
        }
        return masterCounter;
    }

}
