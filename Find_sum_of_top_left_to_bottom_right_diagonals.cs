using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Find_sum_of_top_left_to_bottom_right_diagonals {

    /*

    Find sum of top-left to bottom-right diagonals

    Given a square matrix (i.e. an array of subarrays), find the sum of values from the first value of the first array, the second value of the second array, the third value of the third array, and so on...

    Examples
    array = [[1, 2],
             [3, 4]]

    diagonal sum: 1 + 4 = 5
    array = [[5, 9, 1, 0],
             [8, 7, 2, 3],
             [1, 4, 1, 9],
             [2, 3, 8, 2]]

    diagonal sum: 5 + 7 + 1 + 2 = 15

    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual(12, DiagonalSum(new int[,] { { 12 } }));
        Assert.AreEqual(5, DiagonalSum(new int[2, 2] { { 1, 2 }, { 3, 4 } }));
        Assert.AreEqual(15, DiagonalSum(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }));
        Assert.AreEqual(34, DiagonalSum(new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } }));
    }

    public static int DiagonalSum(int[,] matrix) => Enumerable
        .Range(0, matrix.GetLength(0))
        .Select(i => matrix[i,i])
        .Sum();

}
