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
        // Right Moves
        possibleMoves.AddRange(RightMoves);
        // Left Moves
        possibleMoves.AddRange(LeftMoves);
        // Top Moves
        possibleMoves.AddRange(TopMoves);
        // Bottom Moves
        possibleMoves.AddRange(BottomMoves);
        
        return possibleMoves;
    }
    
}
