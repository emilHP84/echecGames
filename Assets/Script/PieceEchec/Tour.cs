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
            possibleMoves.AddRange(RightMovesBlack);
            // Left Moves
            possibleMoves.AddRange(LeftMovesBlack);
            // Top Moves
            possibleMoves.AddRange(TopMovesBlack);
            // Bottom Moves
            possibleMoves.AddRange(BottomMovesBlack);
        }
        
        if (Empire == Empire.White) {
            // Right Moves
            possibleMoves.AddRange(RightMovesWhite);
            // Left Moves
            possibleMoves.AddRange(LeftMovesWhite);
            // Top Moves
            possibleMoves.AddRange(TopMovesWhite);
            // Bottom Moves
            possibleMoves.AddRange(BottomMovesWhite);
        }
        
        List<Vector2Int> validMoves = new List<Vector2Int>();
        foreach (Vector2Int possibleMove in possibleMoves) {
            if (!CurrentBoard.ValidCoordinate(possibleMove)) continue;
            Piece otherPiece = CurrentBoard.GetPiece(possibleMove);
            if (otherPiece != null && otherPiece.Empire == Empire) continue;
            validMoves.Add(possibleMove);
        }
        
        return validMoves;
    }
    
}
