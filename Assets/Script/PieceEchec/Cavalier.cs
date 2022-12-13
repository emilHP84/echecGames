using System.Collections.Generic;
using Script;
using UnityEngine;

public class Cavalier : Piece {
   public Cavalier(Empire empire) : base(empire) { }

   public override List<Vector2Int> MovePossible() {
      List<Vector2Int> possibleMoves = new List<Vector2Int>();

      return possibleMoves;
   }
}