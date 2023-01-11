using System.Collections.Generic;
using Script;
using UnityEngine;

public class Roi : Piece {
   public Roi(Empire empire, int heuristic, int position) : base(empire) {
      HeuristicValue = heuristic;
      PositionValue = position;
   }
   
   public override List<Vector2Int> MovePossible() {
      List<Vector2Int> possibleMoves = new List<Vector2Int>();
      
      possibleMoves.Add(new Vector2Int(TopCoord.x, Coordonee.y ));
      possibleMoves.Add(new Vector2Int(Bottom.x , Coordonee.y ));
      possibleMoves.Add(new Vector2Int(Coordonee.x , RightCoord.y));
      possibleMoves.Add(new Vector2Int(Coordonee.x , LeftCoord.y));
      possibleMoves.Add(new Vector2Int(TopCoord.x, RightCoord.y));
      possibleMoves.Add(new Vector2Int(TopCoord.x, LeftCoord.y));
      possibleMoves.Add(new Vector2Int(Bottom.x, RightCoord.y));
      possibleMoves.Add(new Vector2Int(Bottom.x, LeftCoord.y));
      
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
