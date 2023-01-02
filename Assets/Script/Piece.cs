using System.Collections.Generic;

using Script;
using UnityEngine;

public abstract class Piece {
    
    [Header("valeur unitée:")]
    public int HeuristicValue;
    public int PositionValue;

    public int xValue;
    public int yValue;
    
    public bool CanEat;
    
    [Header("équipe:")]
    public Empire Empire;
    

    public Board Board => Manager.Board;
    public Vector2Int Coordonee => Board.CoordinateOf(this);
    
    protected Vector2Int TopCoord => Coordonee + new Vector2Int(0,1 );
    protected Vector2Int RightCoord => Coordonee + new Vector2Int(1, 0);
    protected Vector2Int BottomCoord => Coordonee + new Vector2Int(0, -1);
    protected Vector2Int LeftCoord => Coordonee + new Vector2Int(-1, 0);
    protected Vector2Int TopRightCoord => Coordonee + new Vector2Int(1,1 );
    protected Vector2Int BottomRightCoord => Coordonee + new Vector2Int(1, -1);
    protected Vector2Int BottomLeftCoord => Coordonee + new Vector2Int(-1, -1);
    protected Vector2Int TopLeftCoord => Coordonee + new Vector2Int(-1, 1);
    
    
    protected List<Vector2Int> TopMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y+1; i <= 8; i++) {
                Vector2Int coord = new Vector2Int(Coordonee.x, i);
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
    protected List<Vector2Int> RightMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 8; i++) {
                Vector2Int coord = new Vector2Int(i, Coordonee.y);
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
    protected List<Vector2Int> BottomMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y-1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(Coordonee.x,i);
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
    protected List<Vector2Int> LeftMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(i, Coordonee.y);
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
    protected List<Vector2Int> TopRightMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 8; i++) {
                for (int j = Coordonee.y+1; j <=8; j++) {
                    Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y);
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
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> TopLeftMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                for (int j = Coordonee.y+1; j <=8; j++) {
                    Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y);
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
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomRightMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 8; i++) {
                for (int j = Coordonee.y-1; j >=0; j--) {
                    Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y);
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
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomLeftMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                for (int j = Coordonee.y-1; j >= 0; j--) {
                    Vector2Int coord = new Vector2Int(Coordonee.x, Coordonee.y);
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
            }
            return possibleMoves;
        }
    }
    protected Piece(Empire empire) {
        Empire = empire;
    }

    public abstract List<Vector2Int> MovePossible();

}
