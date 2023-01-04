using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class EvaluationFunction : MonoBehaviour {

    public Board Board => Board.instanceBoard;
    public static EvaluationFunction Function;
    
    [SerializeField] public Piece KnightB = new Cavalier(Empire.Black, 5);
    [SerializeField] public Piece RookB = new Tour(Empire.Black,4);
    [SerializeField] public Piece BishopB = new Fou(Empire.Black,4);
    [SerializeField] public Piece KingB = new Roi(Empire.Black,100);
    [SerializeField] public Piece QueenB = new Reine(Empire.Black,10);
    [SerializeField] public Piece PawnB = new Pion(Empire.Black,1);
    

    [SerializeField] public Piece KnightW = new Cavalier(Empire.White,5);
    [SerializeField] public Piece RookW = new Tour(Empire.White,4);
    [SerializeField] public Piece BishopW = new Fou(Empire.White,4);
    [SerializeField] public Piece KingW = new Roi(Empire.White,100);
    [SerializeField] public Piece QueenW = new Reine(Empire.White,10);
    [SerializeField] public Piece PawnW = new Pion(Empire.White,1);
    
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

    public void Awake() {
        Function = this;
        RookB.HeuristicValue = 0;
    }
    public void Evaluation() {
        KnightB = Board.Pieces[0, 1];
         RookB = Board.Pieces[0, 0];
    }
    public void Update() {
        EvaluationRookB();
        EvaluationKingB();
        EvaluationBishopB();
        EvaluationKnightB();
        EvaluationQueenB();
        EvaluationPawnB();
        
        EvaluationRookW();
        EvaluationKingW();
        EvaluationBishopW();
        EvaluationKnightW();
        EvaluationQueenW();
        EvaluationPawnW();
    }
    


    public void EvaluationRookB() {
        Vector2Int coordRight = new Vector2Int(CoordRookB.x + 1, CoordRookB.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) RookB.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) RookB.PositionValue -= RookB.HeuristicValue;
                if (RookB.CanEat == true) RookB.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordRookB.x - 1, CoordRookB.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) RookB.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) RookB.PositionValue -= RookB.HeuristicValue;
                if (RookB.CanEat == true)RookB.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordRookB.x, CoordRookB.y + 1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) RookB.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) RookB.PositionValue -= RookB.HeuristicValue;
                if (RookB.CanEat == true) RookB.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordRookB.x, CoordRookB.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.Black) RookB.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) RookB.PositionValue -= RookB.HeuristicValue;
                if (RookB.CanEat == true) RookB.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
    } 
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationBishopB() {
        Vector2Int coordRight = new Vector2Int(CoordBishopB.x + 1, CoordBishopB.y + 1);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) BishopB.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) BishopB.PositionValue -= BishopB.HeuristicValue;
                if (RookB.CanEat == true) BishopB.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordBishopB.x - 1, CoordBishopB.y + 1);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) BishopB.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) BishopB.PositionValue -= BishopB.HeuristicValue;
                if (BishopB.CanEat == true) BishopB.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordBishopB.x - 1, CoordBishopB.y - 1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) BishopB.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) BishopB.PositionValue -= BishopB.HeuristicValue;
                if (BishopB.CanEat == true) BishopB.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordBishopB.x + 1, CoordBishopB.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.Black)BishopB.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) BishopB.PositionValue -= BishopB.HeuristicValue;
                if (BishopB.CanEat == true) BishopB.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
    } 
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationQueenB() {
        Vector2Int coordRight = new Vector2Int(CoordQueenB.x + 1, CoordQueenB.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordQueenB.x -1, CoordQueenB.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordQueenB.x, CoordQueenB.y +1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordQueenB.x , CoordQueenB.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
        Vector2Int coordRightF = new Vector2Int(CoordQueenB.x + 1, CoordQueenB.y+1);
        Piece otherPieceRightF = Board.GetPiece(coordRightF);
        if (otherPieceRightF != null) {
            if (otherPieceRightF.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceRightF.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceRightF.HeuristicValue;
            }
        }
        Vector2Int coordLeftB = new Vector2Int(CoordQueenB.x -1, CoordQueenB.y-1);
        Piece otherPieceLeftB = Board.GetPiece(coordLeftB);
        if (otherPieceLeftB != null) {
            if (otherPieceLeftB.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceLeftB.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceLeftB.HeuristicValue;
            }
        }
        Vector2Int coordForwardL = new Vector2Int(CoordQueenB.x-1, CoordQueenB.y +1);
        Piece otherPieceForwardL = Board.GetPiece(coordForwardL);
        if (otherPieceForwardL != null) {
            if (otherPieceForwardL.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceForwardL.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceForwardL.HeuristicValue;
            }
        }
        Vector2Int coordBackwardR = new Vector2Int(CoordQueenB.x+1 , CoordQueenB.y - 1);
        Piece otherPieceBackwardR = Board.GetPiece(coordBackwardR);
        if (otherPieceBackwardR != null) {
            if (otherPieceBackwardR.Empire == Empire.Black) QueenB.PositionValue -= 2;
            else {
                if (otherPieceBackwardR.CanEat == true) QueenB.PositionValue -= QueenB.HeuristicValue;
                if (QueenB.CanEat == true) QueenB.PositionValue += otherPieceBackwardR.HeuristicValue;
            }
        }
    } 
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationKingB() {
        Vector2Int coordRight = new Vector2Int(CoordKingB.x + 1, CoordKingB.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordKingB.x -1, CoordKingB.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordKingB.x, CoordKingB.y +1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordKingB.x , CoordKingB.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
        Vector2Int coordRightF = new Vector2Int(CoordKingB.x + 1, CoordKingB.y+1);
        Piece otherPieceRightF = Board.GetPiece(coordRightF);
        if (otherPieceRightF != null) {
            if (otherPieceRightF.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceRightF.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceRightF.HeuristicValue;
            }
        }
        Vector2Int coordLeftB = new Vector2Int(CoordKingB.x -1, CoordKingB.y-1);
        Piece otherPieceLeftB = Board.GetPiece(coordLeftB);
        if (otherPieceLeftB != null) {
            if (otherPieceLeftB.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceLeftB.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceLeftB.HeuristicValue;
            }
        }
        Vector2Int coordForwardL = new Vector2Int(CoordKingB.x-1, CoordKingB.y +1);
        Piece otherPieceForwardL = Board.GetPiece(coordForwardL);
        if (otherPieceForwardL != null) {
            if (otherPieceForwardL.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceForwardL.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceForwardL.HeuristicValue;
            }
        }
        Vector2Int coordBackwardR = new Vector2Int(CoordKingB.x+1 , CoordKingB.y - 1);
        Piece otherPieceBackwardR = Board.GetPiece(coordBackwardR);
        if (otherPieceBackwardR != null) {
            if (otherPieceBackwardR.Empire == Empire.Black) KingB.PositionValue -= 2;
            else {
                if (otherPieceBackwardR.CanEat == true) KingB.PositionValue -= KingB.HeuristicValue;
                if (KingB.CanEat == true) KingB.PositionValue += otherPieceBackwardR.HeuristicValue;
            }
        }
    }
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationKnightB() {
        Vector2Int coordRight = new Vector2Int(CoordKnightB.x+2, CoordKnightB.y-1);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordKnightB.x-2 , CoordKnightB.y+1);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordKnightB.x+1, CoordKnightB.y+2);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordKnightB.x-1, CoordKnightB.y-2);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
        Vector2Int coordRightF = new Vector2Int(CoordKnightB.x+2 , CoordKnightB.y+1);
        Piece otherPieceRightF = Board.GetPiece(coordRightF);
        if (otherPieceRightF != null) {
            if (otherPieceRightF.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceRightF.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceRightF.HeuristicValue;
            }
        }
        Vector2Int coordLeftB = new Vector2Int(CoordKnightB.x-2 , CoordKnightB.y-1);
        Piece otherPieceLeftB = Board.GetPiece(coordLeftB);
        if (otherPieceLeftB != null) {
            if (otherPieceLeftB.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceLeftB.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceLeftB.HeuristicValue;
            }
        }
        Vector2Int coordForwardL = new Vector2Int(CoordKnightB.x-1 , CoordKnightB.y+2);
        Piece otherPieceForwardL = Board.GetPiece(coordForwardL);
        if (otherPieceForwardL != null) {
            if (otherPieceForwardL.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceForwardL.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceForwardL.HeuristicValue;
            }
        }
        Vector2Int coordBackwardR = new Vector2Int(CoordKnightB.x+1 , CoordKnightB.y-2);
        Piece otherPieceBackwardR = Board.GetPiece(coordBackwardR);
        if (otherPieceBackwardR != null) {
            if (otherPieceBackwardR.Empire == Empire.Black) KnightB.PositionValue -= 2;
            else {
                if (otherPieceBackwardR.CanEat == true) KnightB.PositionValue -= KnightB.HeuristicValue;
                if (KnightB.CanEat == true) KnightB.PositionValue += otherPieceBackwardR.HeuristicValue;
            }
        }
    }
     //-----------------------------------------------------------------------------------------------------//
    public void EvaluationPawnB() {
        Vector2Int coordForward = new Vector2Int(CoordPawnB.x, CoordPawnB.y + 1);
        Piece otherPieceforward = Board.GetPiece(coordForward);
        if (otherPieceforward != null) {
            if (otherPieceforward.Empire == Empire.Black) PawnB.PositionValue -= 2;
            else {
                if (otherPieceforward.CanEat == true) PawnB.PositionValue -= PawnB.HeuristicValue;
                if (PawnB.CanEat == true) PawnB.PositionValue += otherPieceforward.HeuristicValue;
            }
        }
        
    } 
    
    
    public void EvaluationRookW() {
        Vector2Int coordRight = new Vector2Int(CoordRookW.x + 1, CoordRookW.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.White) RookW.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) RookW.PositionValue -= RookW.HeuristicValue;
                if (RookW.CanEat == true) RookW.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordRookW.x - 1, CoordRookW.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.White) RookW.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) RookW.PositionValue -= RookW.HeuristicValue;
                if (RookW.CanEat == true)RookW.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordRookW.x, CoordRookW.y + 1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.White) RookW.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) RookW.PositionValue -= RookW.HeuristicValue;
                if (RookW.CanEat == true) RookW.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordRookW.x, CoordRookW.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.White) RookW.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) RookW.PositionValue -= RookW.HeuristicValue;
                if (RookW.CanEat == true) RookW.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
    } 
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationBishopW() {
        Vector2Int coordRight = new Vector2Int(CoordBishopW.x + 1, CoordBishopW.y + 1);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.White) BishopW.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) BishopW.PositionValue -= BishopW.HeuristicValue;
                if (BishopW.CanEat == true) BishopW.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordBishopW.x - 1, CoordBishopW.y + 1);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.White) BishopW.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) BishopW.PositionValue -= BishopW.HeuristicValue;
                if (BishopW.CanEat == true) BishopW.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordBishopW.x - 1, CoordBishopW.y - 1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.White) BishopW.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) BishopW.PositionValue -= BishopW.HeuristicValue;
                if (BishopW.CanEat == true) BishopW.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordBishopW.x + 1, CoordBishopW.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.White)BishopW.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) BishopW.PositionValue -= BishopW.HeuristicValue;
                if (BishopW.CanEat == true) BishopW.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
    } 
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationQueenW() {
        Vector2Int coordRight = new Vector2Int(CoordQueenW.x + 1, CoordQueenW.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordQueenW.x -1, CoordQueenW.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenB.CanEat == true) QueenW.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordQueenW.x, CoordQueenW.y +1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordQueenW.x , CoordQueenW.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
        Vector2Int coordRightF = new Vector2Int(CoordQueenW.x + 1, CoordQueenW.y+1);
        Piece otherPieceRightF = Board.GetPiece(coordRightF);
        if (otherPieceRightF != null) {
            if (otherPieceRightF.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceRightF.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceRightF.HeuristicValue;
            }
        }
        Vector2Int coordLeftB = new Vector2Int(CoordQueenW.x -1, CoordQueenW.y-1);
        Piece otherPieceLeftB = Board.GetPiece(coordLeftB);
        if (otherPieceLeftB != null) {
            if (otherPieceLeftB.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceLeftB.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceLeftB.HeuristicValue;
            }
        }
        Vector2Int coordForwardL = new Vector2Int(CoordQueenW.x-1, CoordQueenW.y +1);
        Piece otherPieceForwardL = Board.GetPiece(coordForwardL);
        if (otherPieceForwardL != null) {
            if (otherPieceForwardL.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceForwardL.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceForwardL.HeuristicValue;
            }
        }
        Vector2Int coordBackwardR = new Vector2Int(CoordQueenW.x+1 , CoordQueenW.y - 1);
        Piece otherPieceBackwardR = Board.GetPiece(coordBackwardR);
        if (otherPieceBackwardR != null) {
            if (otherPieceBackwardR.Empire == Empire.White) QueenW.PositionValue -= 2;
            else {
                if (otherPieceBackwardR.CanEat == true) QueenW.PositionValue -= QueenW.HeuristicValue;
                if (QueenW.CanEat == true) QueenW.PositionValue += otherPieceBackwardR.HeuristicValue;
            }
        }
    } 
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationKingW() {
        Vector2Int coordRight = new Vector2Int(CoordKingW.x + 1, CoordKingW.y);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordKingW.x -1, CoordKingW.y);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordKingW.x, CoordKingW.y +1);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordKingW.x , CoordKingW.y - 1);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
        Vector2Int coordRightF = new Vector2Int(CoordKingW.x + 1, CoordKingW.y+1);
        Piece otherPieceRightF = Board.GetPiece(coordRightF);
        if (otherPieceRightF != null) {
            if (otherPieceRightF.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceRightF.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceRightF.HeuristicValue;
            }
        }
        Vector2Int coordLeftB = new Vector2Int(CoordKingW.x -1, CoordKingW.y-1);
        Piece otherPieceLeftB = Board.GetPiece(coordLeftB);
        if (otherPieceLeftB != null) {
            if (otherPieceLeftB.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceLeftB.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceLeftB.HeuristicValue;
            }
        }
        Vector2Int coordForwardL = new Vector2Int(CoordKingW.x-1, CoordKingW.y +1);
        Piece otherPieceForwardL = Board.GetPiece(coordForwardL);
        if (otherPieceForwardL != null) {
            if (otherPieceForwardL.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceForwardL.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceForwardL.HeuristicValue;
            }
        }
        Vector2Int coordBackwardR = new Vector2Int(CoordKingW.x+1 , CoordKingW.y - 1);
        Piece otherPieceBackwardR = Board.GetPiece(coordBackwardR);
        if (otherPieceBackwardR != null) {
            if (otherPieceBackwardR.Empire == Empire.White) KingW.PositionValue -= 2;
            else {
                if (otherPieceBackwardR.CanEat == true) KingW.PositionValue -= KingW.HeuristicValue;
                if (KingW.CanEat == true) KingW.PositionValue += otherPieceBackwardR.HeuristicValue;
            }
        }
    }
    //-----------------------------------------------------------------------------------------------------//
    public void EvaluationKnightW() {
        Vector2Int coordRight = new Vector2Int(CoordKnightW.x+2, CoordKnightW.y-1);
        Piece otherPieceRight = Board.GetPiece(coordRight);
        if (otherPieceRight != null) {
            if (otherPieceRight.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceRight.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceRight.HeuristicValue;
            }
        }
        Vector2Int coordLeft = new Vector2Int(CoordKnightW.x-2 , CoordKnightW.y+1);
        Piece otherPieceLeft = Board.GetPiece(coordLeft);
        if (otherPieceLeft != null) {
            if (otherPieceLeft.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceLeft.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceLeft.HeuristicValue;
            }
        }
        Vector2Int coordForward = new Vector2Int(CoordKnightW.x+1, CoordKnightW.y+2);
        Piece otherPieceForward = Board.GetPiece(coordForward);
        if (otherPieceForward != null) {
            if (otherPieceForward.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceForward.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceForward.HeuristicValue;
            }
        }
        Vector2Int coordBackward = new Vector2Int(CoordKnightW.x-1, CoordKnightW.y-2);
        Piece otherPieceBackward = Board.GetPiece(coordBackward);
        if (otherPieceBackward != null) {
            if (otherPieceBackward.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceBackward.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceBackward.HeuristicValue;
            }
        }
        Vector2Int coordRightF = new Vector2Int(CoordKnightW.x+2 , CoordKnightW.y+1);
        Piece otherPieceRightF = Board.GetPiece(coordRightF);
        if (otherPieceRightF != null) {
            if (otherPieceRightF.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceRightF.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceRightF.HeuristicValue;
            }
        }
        Vector2Int coordLeftB = new Vector2Int(CoordKnightW.x-2 , CoordKnightW.y-1);
        Piece otherPieceLeftB = Board.GetPiece(coordLeftB);
        if (otherPieceLeftB != null) {
            if (otherPieceLeftB.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceLeftB.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceLeftB.HeuristicValue;
            }
        }
        Vector2Int coordForwardL = new Vector2Int(CoordKnightW.x-1 , CoordKnightW.y+2);
        Piece otherPieceForwardL = Board.GetPiece(coordForwardL);
        if (otherPieceForwardL != null) {
            if (otherPieceForwardL.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceForwardL.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceForwardL.HeuristicValue;
            }
        }
        Vector2Int coordBackwardR = new Vector2Int(CoordKnightW.x+1 , CoordKnightW.y-2);
        Piece otherPieceBackwardR = Board.GetPiece(coordBackwardR);
        if (otherPieceBackwardR != null) {
            if (otherPieceBackwardR.Empire == Empire.White) KnightW.PositionValue -= 2;
            else {
                if (otherPieceBackwardR.CanEat == true) KnightW.PositionValue -= KnightW.HeuristicValue;
                if (KnightW.CanEat == true) KnightW.PositionValue += otherPieceBackwardR.HeuristicValue;
            }
        }
    }
     //-----------------------------------------------------------------------------------------------------//
    public void EvaluationPawnW() {
        Vector2Int coordForward = new Vector2Int(CoordPawnW.x, CoordPawnW.y + 1);
        Piece otherPieceforward = Board.GetPiece(coordForward);
        if (otherPieceforward != null) {
            if (otherPieceforward.Empire == Empire.White) PawnW.PositionValue -= 2;
            else {
                if (otherPieceforward.CanEat == true) PawnW.PositionValue -= PawnW.HeuristicValue;
                if (PawnW.CanEat == true) PawnW.PositionValue += otherPieceforward.HeuristicValue;
            }
        }
        
    } 
    
}
