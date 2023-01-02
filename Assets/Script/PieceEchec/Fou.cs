using System.Collections.Generic;
using Script;
using UnityEngine;

public class Fou : Piece {
    public Fou(Empire empire) : base(empire) { }
    
    public void Start() {
        HeuristicValue = 4;
        PositionValue = 0;
    }
    
    public override List<Vector2Int> MovePossible() {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
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
