using System.Collections.Generic;

using Script;
using UnityEngine;

public abstract class Piece {
    
    [Header("valeur unitée:")]
    public int HeuristicValue;
    public int PositionValue;

    [Header("équipe:")]
    public Empire Empire;
    
    public Board CurrentBoard => Manager.CurrentBoard;
    public Vector2Int Coordonee => CurrentBoard.CoordinateOf(this);
    

    protected Vector2Int Top => new Vector2Int(-1, 0);
    protected Vector2Int TopCoord => Coordonee + Top;
    protected Vector2Int TopTopCoord => Coordonee + new Vector2Int(-2, 0);
    
    protected Vector2Int Right => new Vector2Int(0, +1);
    protected Vector2Int RightCoord => Coordonee + Right;

    protected Vector2Int Bottom => new Vector2Int(+1, 0);
    protected Vector2Int BottomCoord => Coordonee + Bottom;
    protected Vector2Int BottomBottomCoord => Coordonee + new Vector2Int(2, 0);

    protected Vector2Int Left => new Vector2Int(0, -1);
    protected Vector2Int LeftCoord => Coordonee + Left;
    
    protected Vector2Int TopRightCoord => Coordonee + Top + Right;
    protected Vector2Int BottomRightCoord => Coordonee + Bottom + Right;
    protected Vector2Int BottomLeftCoord => Coordonee + Bottom + Left;
    protected Vector2Int TopLeftCoord => Coordonee + Top + Left;
    
    protected List<Vector2Int> TopMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x + 1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(TopCoord.x, Coordonee.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    protected List<Vector2Int> TopMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x + 1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(BottomCoord.x, Coordonee.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
                possibleMoves.Add(coord);
                return possibleMoves;
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> RightMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y+1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(Coordonee.x, RightCoord.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    protected List<Vector2Int> RightMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y+1; i <= 7; i++) {
                Vector2Int coord = new Vector2Int(Coordonee.x, LeftCoord.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    protected List<Vector2Int> BottomMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(BottomCoord.x,Coordonee.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    protected List<Vector2Int> BottomMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(TopCoord.x,Coordonee.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    protected List<Vector2Int> LeftMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y+1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(Coordonee.x, LeftCoord.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    protected List<Vector2Int> LeftMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.y+1; i >= 0; i--) {
                Vector2Int coord = new Vector2Int(Coordonee.x, RightCoord.y);
                // Existing piece on current coord
                Piece otherPiece = CurrentBoard.GetPiece(coord);
                if (otherPiece != null) {
                    if (otherPiece.Empire == Empire) {
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
    
    
    protected List<Vector2Int> TopRightMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 7; i++) {
                for (int j = Coordonee.y+1; j <=7; j++) {
                    Vector2Int coord = new Vector2Int(TopCoord.x,RightCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> TopRightMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 7; i++) {
                for (int j = Coordonee.y+1; j <=7; j++) {
                    Vector2Int coord = new Vector2Int(BottomCoord.x,LeftCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> TopLeftMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                for (int j = Coordonee.y+1; j <=7; j++) {
                    Vector2Int coord = new Vector2Int(TopCoord.x, LeftCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> TopLeftMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                for (int j = Coordonee.y+1; j <=7; j++) {
                    Vector2Int coord = new Vector2Int(BottomCoord.x, RightCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomRightMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 7; i++) {
                for (int j = Coordonee.y-1; j >=0; j--) {
                    Vector2Int coord = new Vector2Int(BottomCoord.x, RightCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomRightMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x+1; i <= 7; i++) {
                for (int j = Coordonee.y-1; j >=0; j--) {
                    Vector2Int coord = new Vector2Int(TopCoord.x, LeftCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomLeftMovesBlack {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                for (int j = Coordonee.y-1; j >= 0; j--) {
                    Vector2Int coord = new Vector2Int(BottomCoord.x, LeftCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
                        possibleMoves.Add(coord);
                        return possibleMoves;
                    }
                    possibleMoves.Add(coord);
                }
            }
            return possibleMoves;
        }
    }
    protected List<Vector2Int> BottomLeftMovesWhite {
        get {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            for (int i = Coordonee.x-1; i >= 0; i--) {
                for (int j = Coordonee.y-1; j >= 0; j--) {
                    Vector2Int coord = new Vector2Int(TopCoord.x, RightCoord.y);
                    // Existing piece on current coord
                    Piece otherPiece = CurrentBoard.GetPiece(coord);
                    if (otherPiece != null) {
                        if (otherPiece.Empire == Empire) {
                            return possibleMoves;
                        }
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
