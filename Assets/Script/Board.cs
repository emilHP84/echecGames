using System;
using System.Collections.Generic;
using Script;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Board {
   
   [SerializeField] public Piece[,] Pieces = new Piece[8, 8];

   public Board Clone() {
      return new Board {
         Pieces = Pieces.Clone() as Piece[,]
      };
   }
   
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

   public int HeuristicSum(Empire empire) {
      int heuristicSum = 0;
      for (int x = 0; x < Pieces.GetLength(0); x++) {
         for (int y = 0; y < Pieces.GetLength(1); y++) {
            if (Pieces[x,y] == null) continue;
            if (Pieces[x,y].Empire == empire) heuristicSum += Pieces[x,y].HeuristicValue;
            else heuristicSum -= Pieces[x,y].HeuristicValue;
            Debug.Log("test: " + heuristicSum);
         }
      }
      return heuristicSum;
   }
   
   public List<Board> GetChilds() {
      List<Board> boards = new List<Board>();
      // Récupération de la liste des boards
      
      foreach (Piece piece in Pieces) {
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[0, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
           
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[1, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
           
            
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[2, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
           
            
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[3, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            

            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[4, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            
            
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[5, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            
            
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[6, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            
            
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 0] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 1] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 2] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 3] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 4] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 5] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 6] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               Board clonedBoard = Clone();
               clonedBoard.Pieces[7, 7] = piece;
               clonedBoard.GetPiece(vector2Int);
            }
            
      }
      // Fin de récupération
         return boards;
      }
}
