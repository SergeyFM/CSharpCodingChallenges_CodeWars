namespace CodingChallenges;
[TestClass]
public class Playing_on_a_chessboard {

    /*

    Playing on a chessboard

    With a friend we used to play the following game on a chessboard (8, rows, 8 columns). On the first row at the bottom we put numbers:

    1/2, 2/3, 3/4, 4/5, 5/6, 6/7, 7/8, 8/9

    On row 2 (2nd row from the bottom) we have:

    1/3, 2/4, 3/5, 4/6, 5/7, 6/8, 7/9, 8/10

    On row 3:

    1/4, 2/5, 3/6, 4/7, 5/8, 6/9, 7/10, 8/11

    until last row:

    1/9, 2/10, 3/11, 4/12, 5/13, 6/14, 7/15, 8/16

    When all numbers are on the chessboard each in turn we toss a coin. The one who get "head" wins and the other gives him, in dollars, the sum of the numbers on the chessboard. We play for fun, the dollars come from a monopoly game!

    Task
    How much can I (or my friend) win or loses for each game if the chessboard has n rows and n columns? Add all of the fractional values on an n by n sized board and give the answer as a simplified fraction.


    */

    [TestMethod]
    public void Test() {
        Assert.AreEqual("[0]", game(0));
        Assert.AreEqual("[1, 2]", game(1));
        Assert.AreEqual("[32]", game(8));
    }

    /*
      0       0
      1       1/2
      8       32                    x4
      40      800                   x20
      101     [10201, 2]            x101
      204     20808                 x102
      807     [651249, 2]           x807
      5014    12'570'098            x2507
      36875   [1'359'765'625, 2]    x36875    
      120000  7'200'000'000         x60000          
      750000  281'250'000'000       x375000
      750001  [562'501'500'001, 2]  x750001
    
    deduction...
      if odd => n*n ,2
      if even => n/2*n   
    */
  
    public static string game(long n) =>
        n % 2 != 0 
        ? $"[{n*n}, 2]" // odd
        : $"[{n/2*n}]"; // even
}
