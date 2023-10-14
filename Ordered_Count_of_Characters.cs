using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;
[TestClass]
public class Ordered_Count_of_Characters {
    [TestMethod]
    public void Test() {

        /*

        Ordered Count of Characters

        Count the number of occurrences of each character and return it as a (list of tuples) in order of appearance. For empty output return (an empty list).

        Consult the solution set-up for the exact data structure implementation depending on your language.

        Example:

        OrderedCount("abracadabra") == new List<Tuple<char, int>> () {
          new Tuple<char, int>('a', 5),
          new Tuple<char, int>('b', 2),
          new Tuple<char, int>('r', 2), 
          new Tuple<char, int>('c', 1),
          new Tuple<char, int>('d', 1)
        }

        */

        CollectionAssert.AreEqual(
                new List<Tuple<char, int>>() {
                    new Tuple<char, int>('a', 5),
                    new Tuple<char, int>('b', 2),
                    new Tuple<char, int>('r', 2),
                    new Tuple<char, int>('c', 1),
                    new Tuple<char, int>('d', 1)
                },
                OrderedCount("abracadabra"));

    }

    public static List<Tuple<char, int>> OrderedCount(string input) => input
          .GroupBy(x => x)
          .Select(x => new Tuple<char, int>(x.Key, x.Count()))
          .ToList();


}
