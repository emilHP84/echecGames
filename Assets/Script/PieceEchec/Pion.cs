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
            // Forward Move
            if (CurrentBoard.ValidCoordinate(TopCoord)) {
                Piece topPiece = CurrentBoard.GetPiece(TopCoord);
                if (topPiece == null) possibleMoves.Add(TopCoord);
                if (topPiece != null && topPiece.Empire == Empire) {
                    return possibleMoves;
                }
                if (topPiece != null && topPiece.Empire != Empire) {
                    return possibleMoves;
                }
                return possibleMoves;
            }
            
            // Forward Double Move
            if (CurrentBoard.ValidCoordinate(TopTopCoord)) {
                Piece topPiece = CurrentBoard.GetPiece(TopCoord);
                Piece topTopPiece = CurrentBoard.GetPiece(TopTopCoord);
                if (topPiece == null && topTopPiece == null && hasMoved == false) possibleMoves.Add(TopTopCoord);
                return possibleMoves;
            }
            // Eat Forward Right

            if (CurrentBoard.ValidCoordinate(TopRightCoord)) {
                Piece otherPiece = CurrentBoard.GetPiece(TopRightCoord);
                if (otherPiece != null && otherPiece.Empire != Empire) {
                    possibleMoves.Add(TopRightCoord);
                }
                return possibleMoves;
            }

            // Eat Forward Left
            if (CurrentBoard.ValidCoordinate(TopLeftCoord)) {
                Piece otherPiece = CurrentBoard.GetPiece(TopLeftCoord);
                if (otherPiece != null && otherPiece.Empire != Empire) {
                    possibleMoves.Add(TopLeftCoord);
                }
                return possibleMoves;
            }
            return possibleMoves;
        }
        if (Empire == Empire.Black) {
            // Forward Move
            if (CurrentBoard.ValidCoordinate(BottomCoord)) {
                Piece topPiece = CurrentBoard.GetPiece(BottomCoord);
                if (topPiece == null) possibleMoves.Add(BottomCoord);
                return possibleMoves;
            }
            // Forward Double Move
            if (CurrentBoard.ValidCoordinate(BottomBottomCoord)) {
                Piece topPiece = CurrentBoard.GetPiece(BottomCoord);
                Piece topTopPiece = CurrentBoard.GetPiece(BottomBottomCoord);
                if (topPiece == null && topTopPiece == null && hasMoved == false) possibleMoves.Add(TopTopCoord);
                return possibleMoves;
            }
            // Eat Forward Right

            if (CurrentBoard.ValidCoordinate(BottomRightCoord)) {
                Piece otherPiece = CurrentBoard.GetPiece(BottomRightCoord);
                if (otherPiece != null && otherPiece.Empire != Empire) {
                    possibleMoves.Add(BottomRightCoord);
                }
                return possibleMoves;
            }

            // Eat Forward Left
            if (CurrentBoard.ValidCoordinate(BottomLeftCoord)) {
                Piece otherPiece = CurrentBoard.GetPiece(BottomLeftCoord);
                if (otherPiece != null && otherPiece.Empire != Empire) {
                    possibleMoves.Add(BottomLeftCoord);
                }
                return possibleMoves;
            }
            return possibleMoves;
        }
        return possibleMoves;
    }
    
}