using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Computer_problem_series_1_Fill_the_Hard_Disk_Drive {

    /*

    Computer problem series #1: Fill the Hard Disk Drive

    Your task is to determine how many files of the copy queue you will be able to save into your Hard Disk Drive. The files must be saved in the order they appear in the queue.

    Zero size files can always be saved even HD full.

    Input:
    Array of file sizes (0 <= s <= 100)
    Capacity of the HD (0 <= c <= 500)
    Output:
    Number of files that can be fully saved in the HD.
    Examples:
    save([4,4,4,3,3], 12) -> 3
    # 4+4+4 <= 12, but 4+4+4+3 > 12
    save([4,4,4,3,3], 11) -> 2
    # 4+4 <= 11, but 4+4+4 > 11
    save([12, 0, 0, 1], 12) -> 3
    # 12+0+0 <= 12, but 12+0+0+1 > 12
    Do not expect any negative or invalid inputs.

    */

    [DataTestMethod]
    [DataRow(new int[] { 4, 4, 4, 3, 3 }, 12, 3)]
    [DataRow(new int[] { 4, 4, 4, 3, 3 }, 11, 2)]
    [DataRow(new int[] { 4, 8, 15, 16, 23, 42 }, 108, 6)]
    [DataRow(new int[] { 13 }, 13, 1)]
    [DataRow(new int[] { 1, 2, 3, 4 }, 250, 4)]
    [DataRow(new int[] { 100 }, 500, 1)]
    [DataRow(new int[] { 11, 13, 15, 17, 19 }, 8, 0)]
    [DataRow(new int[] { 45 }, 12, 0)]
    public void Test(int[] sizes, int hd, int expectedResult) {
        Assert.AreEqual(expectedResult, Save(sizes, hd));
        Assert.AreEqual(expectedResult, Save_v2(sizes, hd));

    }

    public static int Save(int[] sizes, int hd) => sizes
        .Aggregate((0, 0), (saved, newF) =>
            saved.Item1 >= 0 && saved.Item1 + newF <= hd
                ? (saved.Item1 + newF, ++saved.Item2)
                : (-1, saved.Item2) )
        .Item2;

        public static int Save_v2(int[] sizes, int hd) => sizes
            .TakeWhile(newF => (hd -= newF) >= 0)
            .Count();
}
