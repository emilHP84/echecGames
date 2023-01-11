using System.Collections.Generic;
using Script;
using UnityEngine;

public class Fou : Piece {
    public Fou(Empire empire, int heuristic, int position) : base(empire) {
        HeuristicValue = heuristic;
        PositionValue = position;
    }
    
    public override List<Vector2Int> MovePossible() {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        if (Empire == Empire.White)
        {
            // TopRight Moves
            possibleMoves.AddRange(TopRightMoves);
            // TopLeft Moves
            possibleMoves.AddRange(TopLeftMoves);
            // BottomLeft Moves
            possibleMoves.AddRange(BottomLeftMoves);
            // BottomRight Moves
            possibleMoves.AddRange(BottomRightMoves);
        }

        if (Empire == Empire.Black)
        {
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
