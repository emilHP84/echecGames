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
            possibleMoves.AddRange(TopRightMovesWhite);
            // TopLeft Moves
            possibleMoves.AddRange(TopLeftMovesWhite);
            // BottomLeft Moves
            possibleMoves.AddRange(BottomLeftMovesWhite);
            // BottomRight Moves
            possibleMoves.AddRange(BottomRightMovesWhite);
        }

        if (Empire == Empire.Black)
        {
            // TopRight Moves
            possibleMoves.AddRange(TopRightMovesBlack);
            // TopLeft Moves
            possibleMoves.AddRange(TopLeftMovesBlack);
            // BottomLeft Moves
            possibleMoves.AddRange(BottomLeftMovesBlack);
            // BottomRight Moves
            possibleMoves.AddRange(BottomRightMovesBlack);
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
