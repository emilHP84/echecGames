using System.Collections.Generic;
using Script;
using Unity.VisualScripting;
using UnityEngine;

public class Tour : Piece {
    public Tour(Empire empire) : base(empire) { }
    
    public void Start() {
        HeuristicValue = 4;
        PositionValue = 0;
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
