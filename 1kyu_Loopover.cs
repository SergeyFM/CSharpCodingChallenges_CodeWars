using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;

// ---------- Test class --------
[TestClass]
public class _1kyu_Loopover {

    /*

    Loopover

    DESCRIPTION:
    Everybody likes sliding puzzles! For this kata, we're going to be looking at a special type of sliding puzzle called Loopover. With Loopover, it is more like a flat rubik's cube than a sliding puzzle. Instead of having one open spot for pieces to slide into, the entire grid is filled with pieces that wrap back around when a row or column is slid.

    Try it out: https://www.openprocessing.org/sketch/576328

    Note: computer scientists start counting at zero!

    Your task: return a List of moves that will transform the unsolved grid into the solved one. All values of the scrambled and unscrambled grids will be unique! Moves will be 2 character long Strings like the ones below.

    For example, if we have the grid:

    ABCDE
    FGHIJ
    KLMNO
    PQRST
    UVWXY
    and we do R0 (move the 0th row right) then we get:

    EABCD
    FGHIJ
    KLMNO
    PQRST
    UVWXY
    Likewise, if we do L0 (move the 0th row left), we get:

    ABCDE
    FGHIJ
    KLMNO
    PQRST
    UVWXY
    if we do U2 (2nd column up):

    ABHDE
    FGMIJ
    KLRNO
    PQWST
    UVCXY
    and if we do D2 (2nd column down) we will once again return to the original grid. With all of this in mind, I'm going to make a Loopover with a scrambled grid, and your solve method will give me a List of moves I can do to get back to the solved grid I give you.

    For example:

    SCRAMBLED GRID:

    DEABC
    FGHIJ
    KLMNO
    PQRST
    UVWXY
    SOLVED GRID:

    ABCDE
    FGHIJ
    KLMNO
    PQRST
    UVWXY
    One possible solution would be ["L0", "L0"] as moving the top row left twice would result in the original, solved grid. Another would be ["R0", "R0", "R0"], etc. etc.

    NOTE: The solved grid will not always look as nice as the one shown above, so make sure your solution can always get the mixed up grid to the "solved" grid!

    Input
    mixedUpBoard and solvedBoard are two-dimensional arrays (or lists of lists) of symbols representing the initial (unsolved) and final (solved) grids.

    Different grid sizes are tested: from 2x2 to 9x9 grids (including rectangular grids like 4x5).

    Output
    Return a list of moves to transform the mixedUpBoard grid to the solvedBoard grid.

    Some configurations cannot be solved. Return null for unsolvable configurations.

     Ux,Dx,Lx,Rx means move Up,Down,Left,Right by x

    */


    [TestMethod]
    public void Test() {
        string mixedUpBoard =
@"XGJBA
WUFHT
QMNIS
YVOLD
CKEPR";

        string solvedBoard =
@"ABCDE
FGHIJ
KLMNO
PQRST
UVWXY";

        Assert.AreEqual(
            GetArrayFromBoard(solvedBoard), Solve(GetArrayFromBoard(mixedUpBoard), GetArrayFromBoard(solvedBoard))
        );

    }

    // ---------- Helper functions ----------
    private static char[][] GetArrayFromBoard(string input) {
        // Turns a string representation of the board into a jagged char array
        string[] rows = input.Split('\n');
        char[][] arr = new char[rows.Length][];
        for (int i = 0; i < rows.Length; i++) {
            char[] rowArr = rows[i].Trim().ToCharArray();
            arr[i] = rowArr;
        }
        return arr;
    }

    private static List<List<char>> GetListFromBoard(string input) {
        return JaggedArrayToList(GetArrayFromBoard(input));
    }

    private static string GetStringFromBoard(char[][] arr) =>
        // Turns a jagged char array board into a string
        string.Join('\n', arr.Select(row => string.Concat(row)));

    private static string GetStringFromBoard(List<List<char>> arr) =>
        string.Join('\n', arr.Select(row => string.Concat(row)));

    private static List<List<char>> JaggedArrayToList(char[][] arr) {
        return arr.Select(row => row.ToList()).ToList();
    }

     // ---------- THE SOLUTION ----------
    public static List<string> Solve(char[][] mixedUpBoard, char[][] targetBoard) {

        Board theBoard = new(mixedUpBoard, targetBoard);

        Console.WriteLine("targetBoard:");
        theBoard.targetMatrix.PrintOut();
        Console.WriteLine("mixedUpBoard:");
        theBoard.boardMatrix.PrintOut();

        // Assemble a square except the last col and row ----------------------------------
        for (int row = 0; row < theBoard.boardMatrixSize.LastRowPtr; row++) {
            Console.WriteLine("\nRow: " + row);
            for (int col = 0; col < theBoard.boardMatrixSize.LastColPtr; col++) {
                Coords currentCoords = new Coords(row, col);
                char targetPiece = theBoard.GetTargetPiece(currentCoords);
                char currentPiece = theBoard.GetCurrentPiece(currentCoords);
                Console.WriteLine(targetPiece + ": ");
                // If the piece is on the right place, skip
                if (targetPiece == currentPiece) { Console.WriteLine("Already in the right place\n"); continue; }
                // Check if the piece is on the current row
                bool isOnTheRow = theBoard.ThePieceIsOnTheRow(targetPiece, row);
                // If yes move it right to the end, down
                if (isOnTheRow) {
                    int resultingShift = theBoard.DragPieceAllTheWayToTheRight(targetPiece);
                    theBoard.DragPieceToLocation(targetPiece, new Coords(1, 0));
                    theBoard.DragLocation(currentCoords, new Coords(0, -resultingShift));
                }
                // Move target place to the last col
                theBoard.DragTargetPieceAllTheWayToTheRight(targetPiece);
                // Move target piece to the last col
                theBoard.DragPieceAllTheWayToTheRight(targetPiece);
                // Move target piece to the current row
                theBoard.DragPieceToRowN(targetPiece, row);
                // Move it to the target place
                theBoard.DragPieceToColN(targetPiece, col);

                theBoard.boardMatrix.PrintOut();
            }
        }
        
        // Assemble the last col and row --------------------------------------------------



        // Print out the results ----------------------------------------------------------
        Console.WriteLine("\n");

        Console.WriteLine("Resulting board:");
        theBoard.boardMatrix.PrintOut();

        Console.WriteLine("Steps made:");
        theBoard.steps.PrintOut();

        if (GetStringFromBoard(theBoard.targetMatrix) == GetStringFromBoard(theBoard.boardMatrix))
            Console.WriteLine("The riddle was solved.");
        else Console.WriteLine("NOT SOLVED!!!");

        return theBoard.steps;
    }


    // --------- The board class and structures ----------
    struct Coords {
        public int row;
        public int col;
        public Coords(int _row, int _col) {
            row = _row; col = _col;
        }
        public static Coords operator +(Coords a, Coords b) => new Coords(a.row + b.row, a.col + b.col);
        public static Coords operator -(Coords a, Coords b) => new Coords(a.row - b.row, a.col - b.col);

        public override string ToString() => $"[{row}:{col}]";
    }

    class Board {
        // A basic board class representing a real board
        // You can move pieces and check if the riddle is solved
        public List<List<char>> boardMatrix;
        public List<List<char>> targetMatrix;
        public List<string> steps = new();
        public Dictionary<char, Coords> targetPositionsMap;
        public (int LastRowPtr, int LastColPtr) boardMatrixSize;
        public Board(char[][] _mixedUpBoard, char[][] _targetBoard) {
            if (_mixedUpBoard is null || _targetBoard is null
                || _mixedUpBoard.Length == 0 || _targetBoard.Length == 0
                || _mixedUpBoard.First().Length == 0 || _targetBoard.First().Length == 0) throw new ArgumentException("Can't init a board with wrong arguments!");
            boardMatrix = JaggedArrayToList(_mixedUpBoard);
            targetMatrix = JaggedArrayToList(_targetBoard);
            targetPositionsMap = targetMatrix.Select((row, rowIndex) =>
                    row.Select((colItem, colIndex) => (colItem, (rowIndex, colIndex))))
                .SelectMany(x => x).ToDictionary(x => x.Item1, x => new Coords(x.Item2.rowIndex, x.Item2.colIndex));
            boardMatrixSize = (boardMatrix.Count() - 1, boardMatrix.First().Count() - 1);
        }
        public bool isSolved() => targetMatrix.SequenceEqual(boardMatrix);

        public Coords GetPieceCurrentPosition(char piece) =>
            // Returns current row&col of a piece on the board
            boardMatrix
                .Select((row, rowIndex) => row.Contains(piece) ? new Coords(rowIndex, row.IndexOf(piece)) : new Coords(-1, -1))
                .Where(coord => coord.row != -1)
                .First();

        public Coords GetPieceTargetPosition(char piece) => 
            // Returns target coordinates for a given piece
            targetPositionsMap[piece];
        public char GetTargetPiece(Coords c) => targetMatrix[c.row][c.col];
        public char GetCurrentPiece(Coords c) => boardMatrix[c.row][c.col];

        public bool ThePieceIsOnTheRow(char piece, int row) => boardMatrix[row].Contains(piece);

        public int DragPieceAllTheWayToTheRight(char piece) {
            Coords currCoords = GetPieceCurrentPosition(piece);
            int distanceToTheRight = boardMatrixSize.LastRowPtr - currCoords.col;
            DragPieceToLocation(piece, new Coords(0, distanceToTheRight));
            return distanceToTheRight;
        }

        public void DragTargetPieceAllTheWayToTheRight(char piece) {
            Coords targetCoords = GetPieceTargetPosition(piece);
            int distanceToTheRight = boardMatrixSize.LastColPtr - targetCoords.col;
            DragTargetPieceToLocation(piece, new Coords(0, distanceToTheRight));
        }

        public void DragTargetPieceToLocation(char piece, Coords movements) {
            // Drags the place where target piece should be
            Coords targetLocation = GetPieceTargetPosition(piece);
            DragLocation(targetLocation, movements);
        }
        public void DragPieceToLocation(char piece, Coords movement) {
            // Drags a piece on the board
            // piece - char piece on the board
            // movement - the movement Coords(0,1) => move to the right
            Coords curLocation = GetPieceCurrentPosition(piece);
            DragLocation(curLocation, movement);
        }

        public void DragPieceToRowN(char piece, int row) {
            int curRow = GetPieceCurrentPosition(piece).row;
            int distance = row - curRow;
            DragPieceToLocation(piece, new Coords(distance, 0));
        }

        public void DragPieceToColN(char piece, int col) {
            int curCol = GetPieceCurrentPosition(piece).col;
            int distance = col - curCol;
            DragPieceToLocation(piece, new Coords(0, distance));
        }
        
        public void DragLocation(Coords location, Coords movement) {
            // Move a row or a col of the board by dragging according to movement on the location
            // Movement shuld have only one direction, i.e. either row or col should be zero.
            if (movement.row == 0 && movement.col == 0) return;
            if (movement.row != 0 && movement.col != 0) throw new ArgumentOutOfRangeException("Either row or col should be zero!");

            // Let's decide what exactly to do
            string direction = ""; // where to move
            int distance = 0; // how far
            int rowOrcolToMove = 0;
            if (movement.row != 0) {
                direction = movement.row > 0 ? "D" : "U";
                distance = Math.Abs(movement.row);
                rowOrcolToMove = location.col;
            }
            if (movement.col != 0) {
                direction = movement.col > 0 ? "R" : "L";
                distance = Math.Abs(movement.col);
                rowOrcolToMove = location.row;
            }

            // Save the step
            steps.Add($"{direction}{distance}");

            // Now let's change the matrix
            while (distance-- > 0) {
                if (direction == "U") {
                    int col = rowOrcolToMove;
                    char tmpTopValue = boardMatrix.First()[col];
                    for (int row = 0; row < boardMatrix.Count - 1; row++) {
                        boardMatrix[row][col] = boardMatrix[row + 1][col];
                    }
                    boardMatrix.Last()[col] = tmpTopValue;
                }

                if (direction == "D") {
                    int col = rowOrcolToMove;
                    char tmpBottomValue = boardMatrix.Last()[col];
                    for (int row = boardMatrix.Count - 2; row >= 0; row--) {
                        boardMatrix[row + 1][col] = boardMatrix[row][col];
                    }
                    boardMatrix.First()[col] = tmpBottomValue;
                }

                if (direction == "L") {
                    int row = rowOrcolToMove;
                    char tmpFirstValue = boardMatrix[row].First();
                    for (int col = 1; col < boardMatrix[row].Count(); col++) {
                        boardMatrix[row][col - 1] = boardMatrix[row][col];
                    }
                    boardMatrix[row][boardMatrix[row].Count - 1] = tmpFirstValue;
                }

                if (direction == "R") {
                    int row = rowOrcolToMove;
                    char tmpLastValue = boardMatrix[row].Last();
                    for (int col = boardMatrix[row].Count() - 2; col >= 0; col--) {
                        boardMatrix[row][col + 1] = boardMatrix[row][col];
                    }
                    boardMatrix[row][0] = tmpLastValue;
                }
            }

        }


    }

    // ---------- Tests ----------
    public static void TestTheBoardClass(char[][] mixedUpBoard, char[][] solvedBoard) {
        Board theBoard = new(mixedUpBoard, mixedUpBoard);

        /*        Console.WriteLine("solvedBoard:");
                theBoard.targetMatrix.PrintOut(); */

        Console.WriteLine("mixedUpBoard:");
        theBoard.boardMatrix.PrintOut();

        Console.WriteLine("GetPieceCurrentPosition(R): " + theBoard.GetPieceCurrentPosition('R'));
        Console.WriteLine("targetPositionsMap:");
        theBoard.targetPositionsMap.PrintOut();
        Console.WriteLine("GetPieceTargetPosition(R): " + theBoard.GetPieceTargetPosition('R'));

        Console.WriteLine("Drag piece UP to location: A (-4,0)");
        theBoard.DragPieceToLocation('A', new Coords(-4, 0));
        theBoard.boardMatrix.PrintOut();

        Console.WriteLine("Drag piece DOWN to location: A (4,0)");
        theBoard.DragPieceToLocation('A', new Coords(4, 0));
        theBoard.boardMatrix.PrintOut();

        Console.WriteLine("Drag piece LEFT to location: A (0,-4)");
        theBoard.DragPieceToLocation('A', new Coords(0, -4));
        theBoard.boardMatrix.PrintOut();

        Console.WriteLine("Drag piece RIGHT to location: A (0,4)");
        theBoard.DragPieceToLocation('A', new Coords(0, 4));
        theBoard.boardMatrix.PrintOut();

        Console.WriteLine("Steps made:");
        theBoard.steps.PrintOut();

        if (GetStringFromBoard(theBoard.targetMatrix) == GetStringFromBoard(theBoard.boardMatrix))
            Console.WriteLine("The board is the same");
        else Console.WriteLine("Boards are DIFFERENT!!!");

    }

}

// ---------- Extensions ----------
static class Extensions {
    public static void PrintOut(this char[][] arr) {
        foreach (char[] row in arr) Console.WriteLine(string.Concat(row));
        Console.WriteLine();
    }
    public static void PrintOut(this List<List<char>> arr) {
        foreach (List<char> row in arr) Console.WriteLine(string.Concat(row));
        Console.WriteLine();
    }

    public static void PrintOut(this List<string> arr) {
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine();
    }
    public static void PrintOut<TValue>(this Dictionary<char, TValue> dic) {
        Console.WriteLine("Count: " + dic.Count);
        foreach (KeyValuePair<char, TValue> ent in dic) Console.WriteLine($"{ent.Key} -> {ent.Value}");
        Console.WriteLine();
    }
}