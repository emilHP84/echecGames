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
      
      possibleMoves.Add(new Vector2Int(Coordonee.x + 1, Coordonee.y ));
      possibleMoves.Add(new Vector2Int(Coordonee.x - 1, Coordonee.y ));
      possibleMoves.Add(new Vector2Int(Coordonee.x , Coordonee.y + 1));
      possibleMoves.Add(new Vector2Int(Coordonee.x , Coordonee.y - 1));
      possibleMoves.Add(new Vector2Int(Coordonee.x - 1, Coordonee.y + 1));
      possibleMoves.Add(new Vector2Int(Coordonee.x - 1, Coordonee.y - 1));
      possibleMoves.Add(new Vector2Int(Coordonee.x + 1, Coordonee.y + 1));
      possibleMoves.Add(new Vector2Int(Coordonee.x + 1, Coordonee.y - 1));
      
      List<Vector2Int> validMoves = new List<Vector2Int>();
      foreach (Vector2Int possibleMove in possibleMoves) {
         if (!CurrentBoard.ValidCoordinate(possibleMove)) continue;
         Piece piece = CurrentBoard.GetPiece(possibleMove);
         if (piece != null && piece.Empire == Empire) continue;
         validMoves.Add(possibleMove);
      }
      return validMoves;
   }
}
