using System.Collections.Generic;
using Script;
using UnityEngine;

public class Cavalier : Piece {
   public Cavalier(Empire empire, int heuristic) : base(empire) {
      HeuristicValue = heuristic;
      
   }
   
   public override List<Vector2Int> MovePossible() {
      List<Vector2Int> possibleMoves = new List<Vector2Int>();
      // Top left Moves
      possibleMoves.AddRange(KingTopLeftMoves);
      // Top right Moves
      possibleMoves.AddRange(KingTopRightMoves);
      // bottom right Moves
      possibleMoves.AddRange(KingBottomRightMoves);
      //  bottom left Moves
      possibleMoves.AddRange(KingBottomLeftMoves);
      //  left top Moves
      possibleMoves.AddRange(KingLeftTopMoves);
      //  right top Moves
      possibleMoves.AddRange(KingRightTopMoves);
      //  right bottom Moves
      possibleMoves.AddRange(KingRightBottomMoves);
      //  left bottom Moves
      possibleMoves.AddRange(KingLeftBottomMoves);
      
      return possibleMoves;
   }
   protected List<Vector2Int> KingTopLeftMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x-1, Coordonee.y+2); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null)
        {
           if (otherPiece.Empire == Empire)
           {
              return possibleMoves;
           }
           CanEat = true;
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
        Vector2Int coord = new Vector2Int(Coordonee.x+1, Coordonee.y+2); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
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
        Vector2Int coord = new Vector2Int(Coordonee.x-1, Coordonee.y-2); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
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
        Vector2Int coord = new Vector2Int(Coordonee.x+1, Coordonee.y-2); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   }
   protected List<Vector2Int> KingRightTopMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x+2, Coordonee.y+1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingLeftTopMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x-2, Coordonee.y+1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingLeftBottomMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x-2, Coordonee.y-1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   } 
   protected List<Vector2Int> KingRightBottomMoves {
     get {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Vector2Int coord = new Vector2Int(Coordonee.x+2, Coordonee.y-1); 
        // Existing piece on current coord
        Piece otherPiece = Board.GetPiece(coord);
        if (otherPiece != null) {
           if (otherPiece.Empire == Empire) {
              return possibleMoves;
           }
           CanEat = true;
           possibleMoves.Add(coord);
           return possibleMoves;
        }
        possibleMoves.Add(coord);
        return possibleMoves;
     } 
   }
}