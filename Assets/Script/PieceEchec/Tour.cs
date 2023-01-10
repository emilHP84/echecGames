using System.Collections.Generic;
using Script;
using UnityEngine;

public class Tour : Piece {
    public Tour(Empire empire, int heuristic, int position) : base(empire) {
        HeuristicValue = heuristic;
        PositionValue = position;
    }
    
    public override List<Vector2Int> MovePossible() {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        if (Empire == Empire.Black) {
            // Right Moves
            //possibleMoves.AddRange(RightMovesBlack);
            // Left Moves
            //possibleMoves.AddRange(LeftMoves);
            // Top Moves
            //possibleMoves.AddRange(TopMovesBlack);
            // Bottom Moves
            //possibleMoves.AddRange(BottomMovesBlack);

            return possibleMoves;
        }
        if (Empire == Empire.White) {
            // Right Moves
            //possibleMoves.AddRange(RightMovesWhite);
            // Left Moves
            //possibleMoves.AddRange(LeftMoves);
            // Top Moves
            //possibleMoves.AddRange(TopMovesWhite);
            // Bottom Moves
            //possibleMoves.AddRange(BottomMovesWhite);

            return possibleMoves;
        }

        return MovePossible();
    }
    
}
