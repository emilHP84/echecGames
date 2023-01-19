using System.Collections.Generic;

using Script;
using UnityEngine;

public abstract class Piece {
    
    [Header("valeur unitée:")]
    public int HeuristicValue;
    public int PositionValue;

    public int i;
    

    [Header("équipe:")]
    public Empire Empire;
    
    public Board CurrentBoard => Manager.CurrentBoard;
    public Vector2Int Coordonee => CurrentBoard.CoordinateOf(this);
    

    protected Vector2Int Top => new Vector2Int(1, 0);
    protected Vector2Int TopCoord => Coordonee + Top;
    protected Vector2Int TopTopCoord => new Vector2Int(-2, 0);
    
    protected Vector2Int Right => new Vector2Int(0, 1);
    protected Vector2Int RightCoord => Coordonee + Right;
    protected Vector2Int RightRightCoord => new Vector2Int(0, 2);

    protected Vector2Int Bottom => new Vector2Int(-1, 0);
    protected Vector2Int BottomCoord => Coordonee + Bottom;
    protected Vector2Int BottomBottomCoord =>new Vector2Int(2, 0);

    protected Vector2Int Left => new Vector2Int(0, -1);
    protected Vector2Int LeftCoord => Coordonee + Left;
    protected Vector2Int leftLeftCoord => new Vector2Int(0, -2);
    
    protected Vector2Int TopRightCoord => Coordonee + Top + Right;
    protected Vector2Int BottomRightCoord => Coordonee + Bottom + Right;
    protected Vector2Int BottomLeftCoord => Coordonee + Bottom + Left;
    protected Vector2Int TopLeftCoord => Coordonee + Top + Left;
    
    protected Vector2Int TopRightCoordC => Coordonee + TopTopCoord + Right;
    protected Vector2Int BottomRightCoordC => Coordonee + BottomBottomCoord + Right;
    protected Vector2Int BottomLeftCoordC => Coordonee + BottomBottomCoord + Left;
    protected Vector2Int TopLeftCoordC => Coordonee + TopTopCoord + Left;
    protected Vector2Int RightTopCoordC => Coordonee + Top + RightRightCoord;
    protected Vector2Int RightBottomCoordC => Coordonee + Bottom + RightRightCoord;
    protected Vector2Int LeftBottomCoordC => Coordonee + Bottom + leftLeftCoord;
    protected Vector2Int LeftTopCoordC => Coordonee + Top + leftLeftCoord;
    
    protected List<Vector2Int> TopMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x - 1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(i, Coordonee.y);
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece == null) possibleMoves.Add(coord);
                if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                if (otherPiece != null && otherPiece.Empire != Empire) {
                    possibleMoves.Add(coord);
                    return possibleMoves;
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> RightMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y + 1 ; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(Coordonee.x, i);
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece == null) possibleMoves.Add(coord);
                if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                if (otherPiece != null && otherPiece.Empire != Empire) {
                    possibleMoves.Add(coord);
                    return possibleMoves;
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x + 1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int( i, Coordonee.y);
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece == null) possibleMoves.Add(coord);
                if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                if (otherPiece != null && otherPiece.Empire != Empire) { 
                    possibleMoves.Add(coord); 
                    return possibleMoves;
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> LeftMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y - 1; i >= 0; i--) { 
                Vector2Int coord = new Vector2Int(Coordonee.x, i);
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece == null) possibleMoves.Add(coord);
                if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                if (otherPiece != null && otherPiece.Empire != Empire) { 
                    possibleMoves.Add(coord); 
                    return possibleMoves;
                }
            }
            return possibleMoves;
        }
    }
    
    
    
    
    

    protected List<Vector2Int> TopRightMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for ( int i = 1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(Coordonee.x - i, Coordonee.y + i);
                if (!CurrentBoard.ValidCoordinate(coord)) return possibleMoves;
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> TopLeftMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for ( int i = 1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(Coordonee.x - i, Coordonee.y - i);
                if (!CurrentBoard.ValidCoordinate(coord)) return possibleMoves;
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                

            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomRightMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for ( int i = 1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(Coordonee.x + i, Coordonee.y + i);
                if (!CurrentBoard.ValidCoordinate(coord)) return possibleMoves;
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomLeftMoves {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for ( int i = 1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(Coordonee.x + i, Coordonee.y - i);
                if (!CurrentBoard.ValidCoordinate(coord)) return possibleMoves;
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                
            }
            return possibleMoves;
        }
    }
    
    
    
    
    
    
    protected List<Vector2Int> TopRightMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x - 2, Coordonee.y + 1);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> TopLeftMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x - 2, Coordonee.y - 1);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomRightMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x + 2, Coordonee.y + 1);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomLeftMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x + 2, Coordonee.y - 1);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> RightTopMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x - 1, Coordonee.y + 2);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> LeftTopMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x - 1, Coordonee.y - 2);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> RightBottomMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            Vector2Int coord = new Vector2Int(Coordonee.x + 1, Coordonee.y + 2);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    return possibleMoves;
        }
    }
    protected List<Vector2Int> LeftBottomMovesCavalier {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = 1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(Coordonee.x + 1, Coordonee.y - 2);
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece == null) possibleMoves.Add(coord);
                    if (otherPiece != null && otherPiece.Empire == Empire) return possibleMoves;
                    if (otherPiece != null && otherPiece.Empire != Empire) {
                        possibleMoves.Add(coord);
                        return possibleMoves;
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
