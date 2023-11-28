using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class The_Lazy_Startup_Office {

    /*

    The Lazy Startup Office

    A startup office has an ongoing problem with its bin. Due to low budgets, they don't hire cleaners. As a result, the staff are left to voluntarily empty the bin. It has emerged that a voluntary system is not working and the bin is often overflowing. One staff member has suggested creating a rota system based upon the staff seating plan.

    Create a function binRota that accepts a 2D array of names. The function will return a single array containing staff names in the order that they should empty the bin.

    Adding to the problem, the office has some temporary staff. This means that the seating plan changes every month. Both staff members' names and the number of rows of seats may change. Ensure that the function binRota works when tested with these changes.

    Notes:

    All the rows will always be the same length as each other.
    There will be no empty spaces in the seating plan.
    There will be no empty arrays.
    Each row will be at least one seat long.
    An example seating plan is as follows:



    Or as an array:

    [ ["Stefan", "Raj",    "Marie"],
      ["Alexa",  "Amy",    "Edward"],
      ["Liz",    "Claire", "Juan"],
      ["Dee",    "Luke",   "Katie"] ]
    The rota should start with Stefan and end with Dee, taking the left-right zigzag path.

    As an output you would expect in this case:

    ["Stefan", "Raj", "Marie", "Edward", "Amy", "Alexa", "Liz", "Claire", "Juan", "Katie", "Luke", "Dee"])


    */

    [TestMethod]
    public void Main() {
        var testInput = new string[][] { new[] { "Bob", "Nora" }, new[] { "Ruby", "Carl" } };
        CollectionAssert.AreEqual(new[] { "Bob", "Nora", "Carl", "Ruby" }, BinRota(testInput));

        testInput = new string[][] { new[] { "Billy" } };
        CollectionAssert.AreEqual(new[] { "Billy" }, BinRota(testInput));

        testInput = new string[][] { new[] { "Billy", "Nancy" } };
        CollectionAssert.AreEqual(new[] { "Billy", "Nancy" }, BinRota(testInput));

        testInput = new string[][] { new[] { "Billy" }, new[] { "Megan" }, new[] { "Aki" }, new[] { "Arun" }, new[] { "Joy" } };
        CollectionAssert.AreEqual(new[] { "Billy", "Megan", "Aki", "Arun", "Joy" }, BinRota(testInput));

        testInput = new string[][] { new[] { "Sam", "Nina", "Tim", "Helen", "Gurpreet", "Edward", "Holly", "Eliza" }, new[] { "Billy", "Megan", "Aki", "Arun", "Joy", "Anish", "Lee", "Maryan" }, new[] { "Nick", "Josh", "Pete", "Kavita", "Daisy", "Francesca", "Alfie", "Macy" } };
        CollectionAssert.AreEqual(new[] { "Sam", "Nina", "Tim", "Helen", "Gurpreet", "Edward", "Holly", "Eliza", "Maryan", "Lee", "Anish", "Joy", "Arun", "Aki", "Megan", "Billy", "Nick", "Josh", "Pete", "Kavita", "Daisy", "Francesca", "Alfie", "Macy" }, BinRota(testInput));

        testInput = new string[][] { new[] { "Stefan", "Raj", "Marie" }, new[] { "Alexa", "Amy", "Edward" }, new[] { "Liz", "Claire", "Juan" }, new[] { "Dee", "Luke", "Elle" } };
        CollectionAssert.AreEqual(new[] { "Stefan", "Raj", "Marie", "Edward", "Amy", "Alexa", "Liz", "Claire", "Juan", "Elle", "Luke", "Dee" }, BinRota_v2(testInput));

    }

    public static string[] BinRota(string[][] input) => input
        .Select((string[] row, int ind) => ind % 2 == 0 ? row.AsEnumerable() : row.Reverse())
        .SelectMany(x => x)
        .ToArray();

    public static string[] BinRota_v2(string[][] input) => input
        .SelectMany((row, ind) => ind % 2 == 0 ? row : row.Reverse())
        .ToArray();
    

}
