using System;
using System.Collections.Generic;
using Script;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Board {
   
   public Piece[,] Pieces = new Piece[8, 8];
   public Empire EmpireTurn;

   public Board Clone() {
      return new Board {
         Pieces = Pieces.Clone() as Piece[,],
         EmpireTurn = EmpireTurn
      };
   }
   
   public Piece GetPiece(Vector2Int coordinate) {
      if (coordinate.x < 0) return null;
      if (coordinate.y < 0) return null;
      if (coordinate.x > 7) return null;
      if (coordinate.y > 7) return null;
      return Pieces[coordinate.x, coordinate.y];
   }

   public bool ValidCoordinate(Vector2Int coordinate) {
      if (coordinate.x < 0) return false;
      if (coordinate.y < 0) return false;
      if (coordinate.x > 7) return false;
      if (coordinate.y > 7) return false;
      return true;
   }
   
   public Vector2Int CoordinateOf(Piece piece) {
      for (int x = 0; x < Pieces.GetLength(0); x++) {
         for (int y = 0; y < Pieces.GetLength(1); y++) {
            if (Pieces[y, x] == piece) return new Vector2Int(y, x);
         }
      }
      return -Vector2Int.one;
   }

   public int HeuristicSum(Empire empire) {
      int heuristicSum = 0;
      for (int x = 0; x < Pieces.GetLength(0); x++) {
         for (int y = 0; y < Pieces.GetLength(1); y++) {
            if (Pieces[y, x] == null) continue;
            if (Pieces[y, x].Empire == empire) heuristicSum += Pieces[y, x].HeuristicValue;
            else heuristicSum -= Pieces[y, x].HeuristicValue;
         }
      }
      return heuristicSum;
   }

   public List<Board> GetChilds() {
      List<Board> boards = new List<Board>();
      // Récupération de la liste des boards
      for (var x = 0; x < Pieces.GetLength(0); x++) {
         for (var y = 0; y < Pieces.GetLength(1); y++) {
            var piece = Pieces[y, x];
            if (piece == null) continue;
            if (piece.Empire != EmpireTurn) continue;
            foreach (Vector2Int vector2Int in piece.MovePossible()) {
               // Cloner le board actuel
               Board clonedBoard = Clone();
               // Déplacer la piece vers son mouvement possible
               if (vector2Int.x < 0 || vector2Int.x > 7 || vector2Int.y < 0 || vector2Int.y > 7)
                  Debug.Log(piece.GetType().Name + " with " + vector2Int.x + " " + vector2Int.y + " coordinate");
               //Debug.Log(vector2Int.x + " " + vector2Int.y);
               clonedBoard.Pieces[vector2Int.x, vector2Int.y] = piece;
               // Vider ancienne position
               clonedBoard.Pieces[y, x] = null;
               // Changer le tour
               clonedBoard.EmpireTurn = clonedBoard.EmpireTurn == Empire.White ? Empire.Black : Empire.White;
               // Ajout du board
               boards.Add(clonedBoard);
            }
         }
      }
      // Fin de récupération
      return boards;
   }
   
}