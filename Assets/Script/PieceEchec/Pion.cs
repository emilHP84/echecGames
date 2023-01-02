using System.Collections.Generic;
using Script;
using UnityEngine;

public class Pion : Piece {
  public Pion(Empire empire) : base(empire) { }
  private bool hasMoved;

  public void Start() {
    HeuristicValue = 1;
    PositionValue = 0;
    hasMoved = false;
  }

  public override List<Vector2Int> MovePossible() {
   List<Vector2Int> possibleMoves = new List<Vector2Int>();
   // Top Moves
   possibleMoves.AddRange(PionTopMoves);
   // Top Mega Moves
   possibleMoves.AddRange(PionMegaTopMoves);
   // Top right Moves
   possibleMoves.AddRange(PionTopRightMoves);
   // Top left Moves
   possibleMoves.AddRange(PionTopLeftMoves);
   
   return possibleMoves;
 }
  protected List<Vector2Int> PionMegaTopMoves {
    get {
      List<Vector2Int> possibleMoves = new List<Vector2Int>();
      if (hasMoved == false) {
        hasMoved = true;
        Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y + 2);
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
      }
      return possibleMoves;
    }
  }
 protected List<Vector2Int> PionTopMoves {
   get {
     List<Vector2Int> possibleMoves = new List<Vector2Int>();
     Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y+1); 
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
 protected List<Vector2Int> PionTopRightMoves {
   get
   {
     List<Vector2Int> possibleMoves = new List<Vector2Int>();
     if (CanEat == true) {
       Vector2Int coord = new Vector2Int(Coordonee.x + 1, Coordonee.y + 1);
       // Existing piece on current coord
       Piece otherPiece = Board.GetPiece(coord);
       if (otherPiece != null)
       {
         if (otherPiece.Empire == Empire)
         {
           return possibleMoves;
         }
         possibleMoves.Add(coord);
         return possibleMoves;
       }
       possibleMoves.Add(coord);
     }
     return possibleMoves;
   }
 }
 protected List<Vector2Int> PionTopLeftMoves {
   get
   {
     List<Vector2Int> possibleMoves = new List<Vector2Int>();
     if (CanEat == true) {
       Vector2Int coord = new Vector2Int(Coordonee.x - 1, Coordonee.y + 1);
       // Existing piece on current coord
       Piece otherPiece = Board.GetPiece(coord);
       if (otherPiece != null)
       {
         if (otherPiece.Empire == Empire)
         {
           return possibleMoves;
         }
         possibleMoves.Add(coord);
         return possibleMoves;
       }
       possibleMoves.Add(coord);
     }
     return possibleMoves;
   }
 }
}
