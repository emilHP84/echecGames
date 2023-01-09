using System.Collections.Generic;
using Script;
using UnityEngine;

public class Pion : Piece {
    
    public Pion(Empire empire, int heuristic, int position) : base(empire) {
        HeuristicValue = heuristic;
        PositionValue = position;
    }

    private bool hasMoved = false;

    public override List<Vector2Int> MovePossible() {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        if (Empire == Empire.White) {
            possibleMoves.Add(TopCoord);
            if (hasMoved == false) {
                possibleMoves.Add(TopTopCoord);
            }
            Piece otherPiece = CurrentBoard.GetPiece(TopRightCoord);
            if (otherPiece != null && otherPiece.Empire != Empire) {
                possibleMoves.Add(TopRightCoord);
            }
            otherPiece = CurrentBoard.GetPiece(TopLeftCoord);
            if (otherPiece != null && otherPiece.Empire != Empire) {
                possibleMoves.Add(TopLeftCoord);
            }
        }

        if (Empire == Empire.Black) {
            possibleMoves.Add(BottomCoord);
            if (hasMoved == false) {
                possibleMoves.Add(BottomBottomCoord);
            }
            Piece otherPiece = CurrentBoard.GetPiece(BottomRightCoord);
            if (otherPiece != null && otherPiece.Empire != Empire) {
                possibleMoves.Add(BottomRightCoord);
            }
            otherPiece = CurrentBoard.GetPiece(BottomLeftCoord);
            if (otherPiece != null && otherPiece.Empire != Empire) {
                possibleMoves.Add(BottomLeftCoord);
            }
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