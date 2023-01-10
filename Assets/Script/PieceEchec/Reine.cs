using System.Collections.Generic;
using Script;
using UnityEngine;

public class Reine : Piece {
    public Reine(Empire empire, int heuristic, int position) : base(empire) {
        HeuristicValue = heuristic;
        PositionValue = position;
    }
    
    public override List<Vector2Int> MovePossible() {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        // Right Moves
        possibleMoves.AddRange(RightMovesBlack);
        // Left Moves
        possibleMoves.AddRange(LeftMoves);
        // Top Moves
        possibleMoves.AddRange(TopMovesBlack);
        // Bottom Moves
        possibleMoves.AddRange(BottomMovesBlack);
        // TopRight Moves
        possibleMoves.AddRange(TopRightMoves);
        // TopLeft Moves
        possibleMoves.AddRange(TopLeftMoves);
        // BottomLeft Moves
        possibleMoves.AddRange(BottomLeftMoves);
        // BottomRight Moves
        possibleMoves.AddRange(BottomRightMoves);
        
        return possibleMoves;
    }
}
