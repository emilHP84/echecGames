using Script;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Unity.Mathematics;

//https://fr.wikipedia.org/wiki/Algorithme_minimax
//https://fr.wikipedia.org/wiki/%C3%89lagage_alpha-b%C3%AAta
//https://www.developpez.net/forums/d1014691/general-developpement/algorithme-mathematiques/intelligence-artificielle/fonction-d-evaluation-minmax-aux-echecs/
//https://forums.commentcamarche.net/forum/affich-20210445-fonction-d-evaluation-de-minmax
//https://openclassrooms.com/forum/sujet/fonction-evaluation-echec-72339

//https://pageperso.lis-lab.fr/~liva.ralaivola/teachings20062005/reversi/MinMaxL2.pdf

public class Manager : MonoBehaviour {
    
    public Transform BoardTransform;
    public Transform PieceTransform;
    public GameObject SquarePrefab;
    public Sprite WhiteRook,WhiteKnight,WhiteBishop,WhiteQueen, WhiteKing, WhitePawn;
    public Sprite BlackRook, BlackKnight, BlackBishop, BlackQueen, BlackKing, BlackPawn;
    public Sprite Empty;

    public bool hasMoved = false;
    public Board NewBoard;
    [SerializeField] public static Board Board = new Board();

    public void Awake() {
        SquarePrefab.GetComponent<Image>().sprite = null;
        GenerateBoard();
        DisplayBoard();
        /*if (List<Vector2Int>Board.GetChilds()){
            MinMax(Board, 2, false, Empire.White);
        }*/
    }

    public void FixedUpdate() {
        TeamBearing();
    }

    private void TeamBearing() {
        Empire empire = Empire.White;
        if (empire == Empire.Black) {
            Board.HeuristicSum(Empire.Black);
            Think( Board,2,false,Empire.Black);
        }
        if (empire == Empire.Black && hasMoved == true ) {
            hasMoved = false;
            empire = Empire.White;
        }
        
        if (empire == Empire.White) {
            Board.HeuristicSum(Empire.White);
            Think( Board,2,false,Empire.White);
        }
        if (empire == Empire.White && hasMoved == true ) {
            hasMoved = false;
            empire = Empire.Black;
        }
        
        
    }

    private void GenerateBoard() {
        Board.Pieces = new Piece[,] {
            { new Tour(Empire.Black,5), new Cavalier(Empire.Black,3), new Fou(Empire.Black,5), new Reine(Empire.Black,10), new Roi(Empire.Black,2000), new Fou(Empire.Black,5), new Cavalier(Empire.Black,3), new Tour(Empire.Black,5) },
            { new Pion(Empire.Black,1), new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),},
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { new Pion(Empire.White,1), new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),},
            { new Tour(Empire.White,5), new Cavalier(Empire.White,3), new Fou(Empire.White,5), new Reine(Empire.White,10), new Roi(Empire.White,2000), new Fou(Empire.White,5), new Cavalier(Empire.White,3), new Tour(Empire.White,5) },
        };
    }
    
    public void DisplayBoard() {
        //création board
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                GameObject instantiate = Instantiate(SquarePrefab, BoardTransform);
                instantiate.GetComponent<Image>().color = (x + y) % 2 == 0 ? Color.black : Color.white;
                Debug.Log((x + y) % 2 == 0 ? Color.black : Color.white);
            }
        }
        //création piece
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                GameObject instantiate = Instantiate(SquarePrefab, PieceTransform);
                Piece piece = Board.Pieces[x, y];
                instantiate.GetComponent<Image>().sprite = GetSprite(piece);
            }
        }
    }
    
    private void Think(Board board, int depth, bool maximizingPlayer, Empire currentEmpire) {
        int oldValue = int.MinValue;
        Board bestBoard = new Board();
        foreach (Board child in Board.GetChilds()) {
            int newValue = MinMax(child, 2, false, 
                currentEmpire == Empire.White ? Empire.Black : Empire.White);
            if (newValue > oldValue) {
                oldValue = newValue;
                bestBoard = child;
            }
        }
        board = bestBoard;
    }
    
    // Pour chaque board possible je lance minmax

    public int MinMax(Board board, int depth, bool maximizingPlayer, Empire currentEmpire) { 
        int value = 0;
        if (depth == 0 ) {
            return board.HeuristicSum(currentEmpire);
            hasMoved = true;
        }
        if (maximizingPlayer) {
            value = int.MinValue;
            foreach (var child in Board.GetChilds()) {
                value = Mathf.Max(value, MinMax(child, depth - 1, false, 
                    currentEmpire == Empire.White ? Empire.Black : Empire.White));
            }
        }
        else {
            value = int.MaxValue;
            foreach (var child in Board.GetChilds()) {
                value = Mathf.Min(value, MinMax(child, depth - 1, true, 
                    currentEmpire == Empire.White ? Empire.Black : Empire.White));

            }
        }
        return value;
    }

    private Sprite GetSprite(Piece piece) {
        
        if(piece == null) return Empty;
        Type type = piece.GetType();
        
        if (type == typeof(Tour) && piece.Empire == Empire.Black) {
            return BlackRook;
        }
        if (type == typeof(Pion) && piece.Empire == Empire.Black) {
            return BlackPawn;
        }
        if (type == typeof(Reine) && piece.Empire == Empire.Black) {
            return BlackQueen;
        }
        if (type == typeof(Roi) && piece.Empire == Empire.Black) {
            return BlackKing;
        }
        if (type == typeof(Cavalier) && piece.Empire == Empire.Black) {
            return BlackKnight;
        }
        if (type == typeof(Fou) && piece.Empire == Empire.Black) {
            return BlackBishop;
        }
        
        
        if (type == typeof(Tour) && piece.Empire == Empire.White) {
            return WhiteRook;
        }
        if (type == typeof(Pion) && piece.Empire == Empire.White) {
            return WhitePawn;
        }
        if (type == typeof(Reine) && piece.Empire == Empire.White) {
            return WhiteQueen;
        }
        if (type == typeof(Roi) && piece.Empire == Empire.White) {
            return WhiteKing;
        }
        if (type == typeof(Cavalier) && piece.Empire == Empire.White) {
            return WhiteKnight;
        }
        if (type == typeof(Fou) && piece.Empire == Empire.White) {
            return WhiteBishop;
        }
        
        return BlackRook;
    }
}
