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
        if (Empire == Empire.Black)
        {
            // Right Moves
            possibleMoves.AddRange(RightMoves);
            // Left Moves
            possibleMoves.AddRange(LeftMoves);
            // Top Moves
            possibleMoves.AddRange(TopMoves);
            // Bottom Moves
            possibleMoves.AddRange(BottomMoves);
            // TopRight Moves
            possibleMoves.AddRange(TopRightMoves);
            // TopLeft Moves
            possibleMoves.AddRange(TopLeftMoves);
            // BottomLeft Moves
            possibleMoves.AddRange(BottomLeftMoves);
            // BottomRight Moves
            possibleMoves.AddRange(BottomRightMoves);
        }

        if (Empire == Empire.White)
        {
            // Right Moves
            possibleMoves.AddRange(RightMoves);
            // Left Moves
            possibleMoves.AddRange(LeftMoves);
            // Top Moves
            possibleMoves.AddRange(TopMoves);
            // Bottom Moves
            possibleMoves.AddRange(BottomMoves);
            // TopRight Moves
            possibleMoves.AddRange(TopRightMoves);
            // TopLeft Moves
            possibleMoves.AddRange(TopLeftMoves);
            // BottomLeft Moves
            possibleMoves.AddRange(BottomLeftMoves);
            // BottomRight Moves
            possibleMoves.AddRange(BottomRightMoves);
        }
        
        
        return possibleMoves;
    }
}
