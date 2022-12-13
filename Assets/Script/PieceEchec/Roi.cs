using System.Collections.Generic;
using Script;
using UnityEngine;

public class Roi : Piece {
   public Roi(Empire empire) : base(empire) { }
   
   public override List<Vector2Int> MovePossible() {
     List<Vector2Int> possibleMoves = new List<Vector2Int>();
     // Top Moves
     possibleMoves.AddRange(KingTopMoves);
     // bottom Moves
     possibleMoves.AddRange(KingBottomMoves);
     // left Moves
     possibleMoves.AddRange(KingLeftMoves);
     // right Moves
     possibleMoves.AddRange(KingRightMoves);
     // Top Moves
     possibleMoves.AddRange(KingTopRightMoves);
     // bottom Moves
     possibleMoves.AddRange(KingTopLeftMoves);
     // left Moves
     possibleMoves.AddRange(KingBottomLeftMoves);
     // right Moves
     possibleMoves.AddRange(KingBottomRightMoves);
     
     return possibleMoves; 
   }
   
   protected List<Vector2Int> KingTopMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y+1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingBottomMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y-1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingLeftMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x-1, Coordonee.y); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingRightMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x+1, Coordonee.y); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   }
   protected List<Vector2Int> KingTopRightMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x+1, Coordonee.y+1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingTopLeftMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x-1, Coordonee.y-1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingBottomLeftMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x-1, Coordonee.y-1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingBottomRightMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x+1, Coordonee.y+1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   }
}
