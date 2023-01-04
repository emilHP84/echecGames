using System;
using System.Linq;
using UnityEngine;
[Serializable]
public class Board {
   
   public static Board instanceBoard = new Board();
   [SerializeField] public Piece[,] Pieces = new Piece[8, 8];
   
   public Piece GetPiece(Vector2Int coordonee) {
      if (coordonee.x < 0) return null;
      if (coordonee.y < 0) return null;
      if (coordonee.x >= 8) return null;
      if (coordonee.y >= 8) return null;
      return Pieces[coordonee.x, coordonee.y];
   }

   public Vector2Int CoordinateOf(Piece piece) {
      for (int i = 0; i < Pieces.GetLength(0); i++) {
         for (int j = 0; j < Pieces.GetLength(1); j++) {
            if (Pieces[i, j] == piece) return new Vector2Int(i, j);
         }
      }
      return -Vector2Int.one;
   }
   
}
