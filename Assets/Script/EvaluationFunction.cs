using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class EvaluationFunction : MonoBehaviour {

    [SerializeField] public Piece KnightB = new Cavalier(Empire.Black);
    [SerializeField] public Piece RookB = new Tour(Empire.Black);
    [SerializeField] public Piece BishopB = new Fou(Empire.Black);
    [SerializeField] public Piece KingB = new Roi(Empire.Black);
    [SerializeField] public Piece QueenB = new Reine(Empire.Black);
    [SerializeField] public Piece PawnB = new Pion(Empire.Black);

    [SerializeField] public Piece KnightW = new Cavalier(Empire.White);
    [SerializeField] public Piece RookW = new Tour(Empire.White);
    [SerializeField] public Piece BishopW = new Fou(Empire.White);
    [SerializeField] public Piece KingW = new Roi(Empire.White);
    [SerializeField] public Piece QueenW = new Reine(Empire.White);
    [SerializeField] public Piece PawnW = new Pion(Empire.White);

    public Vector2Int CoordKnightB => Board.CoordinateOf(KnightB);
    public Vector2Int CoordRookB => Board.CoordinateOf(RookB);
    public Vector2Int CoordBishopB => Board.CoordinateOf(BishopB);
    public Vector2Int CoordKingB => Board.CoordinateOf(KingB);
    public Vector2Int CoordQueenB => Board.CoordinateOf(QueenB);
    public Vector2Int CoordPawnB => Board.CoordinateOf(PawnB);

    public Vector2Int CoordKnightW => Board.CoordinateOf(KnightW);
    public Vector2Int CoordRookW => Board.CoordinateOf(RookW);
    public Vector2Int CoordBishopW => Board.CoordinateOf(BishopW);
    public Vector2Int CoordKingW => Board.CoordinateOf(KingW);
    public Vector2Int CoordQueenW => Board.CoordinateOf(QueenW);
    public Vector2Int CoordPawnW => Board.CoordinateOf(PawnW);

    [SerializeField] public static Board Board = new Board();


    public void EvaluationStart() {
        // piece noir //
        KnightB.HeuristicValue = 5;
        KnightB.PositionValue = 0;
        RookB.HeuristicValue = 4;
        RookB.PositionValue = 0;
        BishopB.HeuristicValue = 4;
        BishopB.PositionValue = 0;
        KingB.HeuristicValue = 100;
        KingB.PositionValue = 0;
        QueenB.HeuristicValue = 10;
        QueenB.PositionValue = 0;
        PawnB.HeuristicValue = 1;
        PawnB.PositionValue = 0;

        // piece blanche //
        KnightW.HeuristicValue = 5;
        KnightW.PositionValue = 0;
        RookW.HeuristicValue = 4;
        RookW.PositionValue = 0;
        BishopW.HeuristicValue = 4;
        BishopW.PositionValue = 0;
        KingW.HeuristicValue = 100;
        KingW.PositionValue = 0;
        QueenW.HeuristicValue = 10;
        QueenW.PositionValue = 0;
        PawnW.HeuristicValue = 1;
        PawnW.PositionValue = 0;
    }


    public void EvaluationRookB() {
        Vector2Int coordRight = new Vector2Int(CoordRookB.x + 1, CoordRookB.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) {
                RookB.PositionValue -= 2;
            }
            else {
                if (otherPieceRight.CanEat == true) {
                    RookB.PositionValue -= RookB.HeuristicValue;
                }

                if (RookB.CanEat == true) {
                    RookB.PositionValue += otherPieceRight.HeuristicValue;
                }
            }
        }

        Vector2Int coordLeft = new Vector2Int(CoordRookB.x - 1, CoordRookB.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) {
                RookB.PositionValue -= 2;
            }
            else {
                if (otherPieceLeft.CanEat == true) {
                    RookB.PositionValue -= RookB.HeuristicValue;
                }

                if (RookB.CanEat == true) {
                    RookB.PositionValue += otherPieceLeft.HeuristicValue;
                }
            }
        }

        Vector2Int coordForward = new Vector2Int(CoordRookB.x, CoordRookB.y + 1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) {
                RookB.PositionValue -= 2;
            }
            else {
                if (otherPieceForward.CanEat == true) {
                    RookB.PositionValue -= RookB.HeuristicValue;
                }

                if (RookB.CanEat == true) {
                    RookB.PositionValue += otherPieceForward.HeuristicValue;
                }
            }
        }

        Vector2Int coordBackward = new Vector2Int(CoordRookB.x, CoordRookB.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.Black) {
                RookB.PositionValue -= 2;
            }
            else {
                if (otherPieceBackward.CanEat == true) {
                    RookB.PositionValue -= RookB.HeuristicValue;
                }

                if (RookB.CanEat == true) {
                    RookB.PositionValue += otherPieceBackward.HeuristicValue;
                }
            }
        }
    }

    public void EvaluationBishopB() {
        Vector2Int coordRight = new Vector2Int(CoordBishopB.x + 1, CoordBishopB.y + 1);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) {
                BishopB.PositionValue -= 2;
            }
            else {
                if (otherPieceRight.CanEat == true) {
                    BishopB.PositionValue -= BishopB.HeuristicValue;
                }

                if (RookB.CanEat == true) {
                    BishopB.PositionValue += otherPieceRight.HeuristicValue;
                }
            }
        }

        Vector2Int coordLeft = new Vector2Int(CoordBishopB.x - 1, CoordBishopB.y + 1);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) {
                BishopB.PositionValue -= 2;
            }
            else {
                if (otherPieceLeft.CanEat == true) {
                    BishopB.PositionValue -= BishopB.HeuristicValue;
                }

                if (BishopB.CanEat == true) {
                    BishopB.PositionValue += otherPieceLeft.HeuristicValue;
                }
            }
        }

        Vector2Int coordForward = new Vector2Int(CoordBishopB.x - 1, CoordBishopB.y - 1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) {
                BishopB.PositionValue -= 2;
            }
            else {
                if (otherPieceForward.CanEat == true) {
                    BishopB.PositionValue -= BishopB.HeuristicValue;
                }

                if (BishopB.CanEat == true) {
                    BishopB.PositionValue += otherPieceForward.HeuristicValue;
                }
            }

            Vector2Int coordBackward = new Vector2Int(CoordBishopB.x + 1, CoordBishopB.y - 1);
            Piece otherPieceBackward = Board.GetPiece(coordBackward);
            if (otherPieceBackward != null) {
                if (otherPieceBackward.Empire == Empire.Black) {
                    BishopB.PositionValue -= 2;
                }
                else {
                    if (otherPieceBackward.CanEat == true) {
                        BishopB.PositionValue -= BishopB.HeuristicValue;
                    }

                    if (BishopB.CanEat == true) {
                        BishopB.PositionValue += otherPieceBackward.HeuristicValue;
                    }
                }
            }
        }
    }

    public void EvaluationQueen() {
        
    }
}
