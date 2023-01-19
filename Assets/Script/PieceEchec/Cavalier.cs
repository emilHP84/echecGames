using System.Collections.Generic;
using Script;
using UnityEngine;

public class Cavalier : Piece {
   public Cavalier(Empire empire, int heuristic, int position) : base(empire) {
      HeuristicValue = heuristic;
      PositionValue = position;
   }
   
   public override List<Vector2Int> MovePossible() {
      List<Vector2Int> possibleMoves = new List<Vector2Int>();

      if (Empire == Empire.White) {
         if (CurrentBoard.ValidCoordinate(TopRightCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(TopRightCoordC);
            if (topPiece == null) possibleMoves.Add(TopRightCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(TopRightCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(BottomRightCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(BottomRightCoordC);
            if (topPiece == null) possibleMoves.Add(BottomRightCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(BottomRightCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(BottomLeftCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(BottomLeftCoordC);
            if (topPiece == null) possibleMoves.Add(BottomLeftCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(BottomLeftCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(TopLeftCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(TopLeftCoordC);
            if (topPiece == null) possibleMoves.Add(TopLeftCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(TopLeftCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(RightTopCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(RightTopCoordC);
            if (topPiece == null) possibleMoves.Add(RightTopCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(RightTopCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(RightBottomCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(RightBottomCoordC);
            if (topPiece == null) possibleMoves.Add(RightBottomCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(RightBottomCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(LeftBottomCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(LeftBottomCoordC);
            if (topPiece == null) possibleMoves.Add(LeftBottomCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(LeftBottomCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(LeftTopCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(LeftTopCoordC);
            if (topPiece == null) possibleMoves.Add(LeftTopCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(LeftTopCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
      }
      
      if (Empire == Empire.Black) {
        if (CurrentBoard.ValidCoordinate(TopRightCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(TopRightCoordC);
            if (topPiece == null) possibleMoves.Add(TopRightCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(TopRightCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(BottomRightCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(BottomRightCoordC);
            if (topPiece == null) possibleMoves.Add(BottomRightCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(BottomRightCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(BottomLeftCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(BottomLeftCoordC);
            if (topPiece == null) possibleMoves.Add(BottomLeftCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(BottomLeftCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(TopLeftCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(TopLeftCoordC);
            if (topPiece == null) possibleMoves.Add(TopLeftCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(TopLeftCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(RightTopCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(RightTopCoordC);
            if (topPiece == null) possibleMoves.Add(RightTopCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(RightTopCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(RightBottomCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(RightBottomCoordC);
            if (topPiece == null) possibleMoves.Add(RightBottomCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(RightBottomCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(LeftBottomCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(LeftBottomCoordC);
            if (topPiece == null) possibleMoves.Add(LeftBottomCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(LeftBottomCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
         if (CurrentBoard.ValidCoordinate(LeftTopCoordC)) {
            Piece topPiece = CurrentBoard.GetPiece(LeftTopCoordC);
            if (topPiece == null) possibleMoves.Add(LeftTopCoordC);
            if (topPiece != null && topPiece.Empire == Empire) {
               return possibleMoves;
            }
            if (topPiece != null && topPiece.Empire != Empire) {
               possibleMoves.Add(LeftTopCoordC);
               return possibleMoves;
            }
            return possibleMoves;
         }
      }
      List<Vector2Int> validMoves = new List<Vector2Int>();
      foreach (Vector2Int possibleMove in possibleMoves) {
         if (!CurrentBoard.ValidCoordinate(possibleMove)) {
            Piece piece = CurrentBoard.GetPiece(possibleMove);
            if (piece != null && piece.Empire == Empire) return possibleMoves;
            if (piece != null && piece.Empire != Empire) validMoves.Add(possibleMove);
         }
      }
      return validMoves;
   }
}