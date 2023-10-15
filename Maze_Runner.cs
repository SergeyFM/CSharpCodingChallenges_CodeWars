using System.Collections.Generic;

namespace CodingChallenges;
[TestClass]
public class Maze_Runner {
    [TestMethod]
    public void Test() {

        /*

        Maze Runner

        Welcome Adventurer. Your aim is to navigate the maze and reach the finish point 
        without touching any walls. Doing so will kill you instantly!
        
        Task
        You will be given a 2D array of the maze and an array of directions. Your task is to follow the directions given. 
        If you reach the end point before all your moves have gone, you should return Finish. If you hit any walls or 
        go outside the maze border, you should return Dead. If you find yourself still in the maze after using all the 
        moves, you should return Lost.

        The Maze array will look like

        maze = [[1,1,1,1,1,1,1],
                [1,0,0,0,0,0,3],
                [1,0,1,0,1,0,1],
                [0,0,1,0,0,0,1],
                [1,0,1,0,1,0,1],
                [1,0,0,0,0,0,1],
                [1,2,1,0,1,0,1]]

        ..with the following key

              0 = Safe place to walk
              1 = Wall
              2 = Start Point
              3 = Finish Point

          direction = ["N","N","N","N","N","E","E","E","E","E"] == "Finish"
        
        Rules
        1. The Maze array will always be square i.e. N x N but its size and content will alter from test to test.
        2. The start and finish positions will change for the final tests.
        3. The directions array will always be in upper case and will be in the format of N = North, E = East, W = West and S = South.
        4. If you reach the end point before all your moves have gone, you should return Finish.
        5. If you hit any walls or go outside the maze border, you should return Dead.
        6. If you find yourself still in the maze after using all the moves, you should return Lost.

        */

        int[,] maze = new int[,] {  { 1, 1, 1, 1, 1, 1, 1 },
                                    { 1, 0, 0, 0, 0, 0, 3 },
                                    { 1, 0, 1, 0, 1, 0, 1 },
                                    { 0, 0, 1, 0, 0, 0, 1 },
                                    { 1, 0, 1, 0, 1, 0, 1 },
                                    { 1, 0, 0, 0, 0, 0, 1 },
                                    { 1, 2, 1, 0, 1, 0, 1 }  };

        string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
        string result = mazeRunner(maze, directions);
        Assert.AreEqual("Finish", result, "Should return: 'Finish'");

        directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "S", "S", "E", "E", "N", "N", "E" };
        result = mazeRunner(maze, directions);
        Assert.AreEqual("Finish", result, "Should return: 'Finish'");

        directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E", "W", "W" };
        result = mazeRunner(maze, directions);
        Assert.AreEqual("Finish", result, "Should return: 'Finish'");

        directions = new string[] { "N", "N", "N", "W", "W" };
        result = mazeRunner(maze, directions);
        Assert.AreEqual("Dead", result, "Should return: 'Dead'");

        directions = new string[] { "N", "E", "E", "E", "E" };
        result = mazeRunner(maze, directions);
        Assert.AreEqual("Lost", result, "Should return: 'Lost'");


    }

    public string mazeRunner(int[,] maze, string[] directions) {

        (int, int) GetStart(int[,] m) {
            for (int row = 0; row < m.GetLength(0); row++) {
                for (int col = 0; col < m.GetLength(1); col++)
                    if (m[row, col] == 2) return (row, col);
            }
            return (0, 0);
        }

        (int row, int col) = GetStart(maze);

        Dictionary<string, (int row, int col)> steps = new() {
            {"N", (-1,0) },
            {"S", (1, 0) },
            {"W", (0, -1) },
            {"E", (0, 1) } 
        };

        foreach (string d in directions) {
            (row, col) = steps.ContainsKey(d) ? (row + steps[d].row, col + steps[d].col) : (row, col);
            if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1) || maze[row, col] == 1) return "Dead";
            if (maze[row, col] == 3) return "Finish";
        };

        return "Lost";
    }
}
