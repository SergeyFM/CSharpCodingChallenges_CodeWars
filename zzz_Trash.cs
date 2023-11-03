
namespace CodingChallenges;
internal class zzz_Trash {
}

#if DONTINCLUDE

------------------------------------------------------------------------------------------------------------------------

// Assemble the last col
// Coords oneUpPos = second to last position in the target right col (usually 'T')

int ATTEMPTS = 10;

phase2_col:

        if (ATTEMPTS-- <= 0) goto stop_trying;
        Console.WriteLine("ATTEMPT " + ATTEMPTS);
        // Check if column is already assembled
        if (theBoard.targetMatrix.Select(x => x.Last()).SequenceEqual(theBoard.boardMatrix.Select(x => x.Last())) ) goto phase2_row;

        char bottomRightTargetPiece = theBoard.targetMatrix.Last().Last();
        // For each piece in the target last col
        for (int row = 0; row <= theBoard.boardMatrixSize.LastRowPtr; row++) {
            Coords currentCoords = new(row, theBoard.boardMatrixSize.LastColPtr);
char targetPiece = theBoard.GetTargetPiece(currentCoords);
char bottomRightCurrentPiece = theBoard.boardMatrix.Last().Last();

            // If the target piece is already in the bottomRigthCurrentPiece - move 1 up
            if (targetPiece == bottomRightCurrentPiece) {
                if (targetPiece != bottomRightTargetPiece)
                    theBoard.DragPieceToLocation(targetPiece, new Coords(-1, 0));
                continue;
            }

            // If the target piece is in the last row
            // move it all the way to the right and on the oneUpPos
            bool isOnTheLastRow = theBoard.ThePieceIsOnTheRow(targetPiece, theBoard.boardMatrixSize.LastRowPtr);
if (isOnTheLastRow) {
    theBoard.DragPieceAllTheWayToTheRight(targetPiece);
    if (targetPiece != bottomRightTargetPiece) // only if it is not the last piece
        theBoard.DragPieceToLocation(targetPiece, new Coords(-1, 0));
    continue;
}
if (isOnTheLastRow == false) { // means it is on the last col
    theBoard.FixTheLastCol(); // set the right col correctly
    if (targetPiece == bottomRightTargetPiece) continue; // the last one
                                                         // Move it all the way down
    theBoard.DragPieceAllTheWayDown(targetPiece);
    // Move it 1 left
    theBoard.DragPieceToLocation(targetPiece, new Coords(0, -1));
    // Move target piece on the col all the way down
    theBoard.FixTheLastCol();
    theBoard.DragTargetPieceAllTheWayDown(targetPiece);
    // Move it 1 right
    theBoard.DragPieceToLocation(targetPiece, new Coords(0, 1));
    // Move it 1 up
    theBoard.DragPieceToLocation(targetPiece, new Coords(-1, 0));
    continue;
}
        }

        Console.WriteLine("Board except the last row:");
theBoard.boardMatrix.PrintOut();



// Assemble the last row
phase2_row:

char bottomLeftTargetPiece = theBoard.targetMatrix.Last().First();
// For each target piece on the last row
for (int col = 0; col <= theBoard.boardMatrixSize.LastColPtr; col++) {
    Coords currentCoords = new(theBoard.boardMatrixSize.LastRowPtr, col);
    char targetPiece = theBoard.GetTargetPiece(currentCoords);
    char currentPiece = theBoard.GetCurrentPiece(currentCoords);
    Console.WriteLine("piece: " + targetPiece);
    // Check if solved
    theBoard.FixBottomRow();
    if (theBoard.isSolved()) break;

    // If the piece is on the right place, continue
    if (targetPiece == currentPiece) continue;

    // If first (usually 'U') continue, it doesn't matter where it is
    if (targetPiece == bottomLeftTargetPiece) {
        theBoard.boardMatrix.PrintOut();
        continue;
    }

    // Move the piece all the way to the right
    theBoard.DragPieceAllTheWayToTheRight(targetPiece);
    theBoard.boardMatrix.PrintOut();

    // Last row 1 down
    theBoard.DragPieceToLocation(targetPiece, new Coords(1, 0));
    theBoard.boardMatrix.PrintOut();

    // Fix bottom row
    theBoard.FixBottomRow();
    theBoard.boardMatrix.PrintOut();

    theBoard.DragTargetPieceAllTheWayToTheRight(targetPiece);

    theBoard.boardMatrix.PrintOut();

    // Last row 1 up 
    theBoard.DragPieceToLocation(targetPiece, new Coords(-1, 0));
    //theBoard.DragPieceAllTheWayDown(targetPiece);

    theBoard.boardMatrix.PrintOut();
    // Fix the row
    theBoard.FixBottomRow();
    theBoard.boardMatrix.PrintOut();

}
if (!theBoard.isSolved()) goto phase2_col;

stop_trying:

-----------------------------------------------------------------------------------------------------------------


// Phase 3 - the last two tiles in the right column
if (!theBoard.isSolved()) {
    Console.WriteLine("Attempt to soleve the last two tiles");
    int attempts = 200;
    Coords bottomRightLocation = new Coords(theBoard.boardMatrixSize.LastRowPtr, theBoard.boardMatrixSize.LastColPtr);
    theBoard.DragLocation(bottomRightLocation, new Coords(0, -1)); // left
    theBoard.DragLocation(bottomRightLocation, new Coords(1, 0)); // down
    theBoard.DragLocation(bottomRightLocation, new Coords(0, 1)); // right
    theBoard.DragLocation(bottomRightLocation, new Coords(-1, 0)); // up
    while (attempts-- > 0 && !theBoard.isSolved()) {
        theBoard.DragLocation(bottomRightLocation, new Coords(-1, 0)); // up
        if (theBoard.isSolved()) break;
        theBoard.DragLocation(bottomRightLocation, new Coords(0, 1)); // right
        if (theBoard.isSolved()) break;
        theBoard.DragLocation(bottomRightLocation, new Coords(-1, 0)); // up
        if (theBoard.isSolved()) break;
        theBoard.DragLocation(bottomRightLocation, new Coords(0, -1)); // left
        if (theBoard.isSolved()) break;
        theBoard.DragLocation(bottomRightLocation, new Coords(0, -1)); // left
        if (theBoard.isSolved()) break;
        theBoard.DragLocation(bottomRightLocation, new Coords(0, 1)); // right

    }

}


// HACK: put the correct last two pieces in the target matrix for success later
List<List<char>> tmpTargetMatrix = theBoard.targetMatrix.FullClone();
theBoard.targetMatrix[theBoard.boardMatrixSize.LastRowPtr][theBoard.boardMatrixSize.LastColPtr] =
    tmpTargetMatrix.Last().SkipLast(3).Last();
theBoard.targetMatrix[theBoard.boardMatrixSize.LastRowPtr-1][theBoard.boardMatrixSize.LastColPtr] =
    tmpTargetMatrix.Last().SkipLast(2).Last();

Console.WriteLine("corrected matix:");
theBoard.targetMatrix.PrintOut();

        theBoard.targetMatrix = tmpTargetMatrix;
        Console.WriteLine("Fixed target matrix:");
        theBoard.targetMatrix.PrintOut();
-----------------------------------------------------------------------------------------------------------------------

#endif