using Script;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

//https://fr.wikipedia.org/wiki/Algorithme_minimax
//https://fr.wikipedia.org/wiki/%C3%89lagage_alpha-b%C3%AAta
//https://www.developpez.net/forums/d1014691/general-developpement/algorithme-mathematiques/intelligence-artificielle/fonction-d-evaluation-minmax-aux-echecs/
//https://forums.commentcamarche.net/forum/affich-20210445-fonction-d-evaluation-de-minmax
//https://openclassrooms.com/forum/sujet/fonction-evaluation-echec-72339

//https://pageperso.lis-lab.fr/~liva.ralaivola/teachings20062005/reversi/MinMaxL2.pdf
public class Manager : MonoBehaviour {
    
    public EvaluationFunction eval => EvaluationFunction.Function;
    
    public Transform BoardTransform;
    public Transform PieceTransform;
    public GameObject SquarePrefab;
    public Sprite WhiteRook,WhiteKnight,WhiteBishop,WhiteQueen, WhiteKing, WhitePawn;
    public Sprite BlackRook, BlackKnight, BlackBishop, BlackQueen, BlackKing, BlackPawn;
    public Sprite Empty;
    
    public int NombreDeTours;
    [SerializeField] public static Board Board = new Board();

    public void Start() {
        SquarePrefab.GetComponent<Image>().sprite = null;
        GenerateBoard();
        DisplayBoard(); 
        EvaluationFunction.Function.Evaluation();
    }

    public void Update() {
        Debug.Log("test: " + eval.RookB);
    }

    private void GenerateBoard() {
        Board.Pieces = new Piece[,] {
            { new Tour(Empire.Black,4), new Cavalier(Empire.Black,5), new Fou(Empire.Black,4), new Reine(Empire.Black,10), new Roi(Empire.Black,100), new Fou(Empire.Black,4), new Cavalier(Empire.Black,5), new Tour(Empire.Black,4) },
            { new Pion(Empire.Black,1), new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),new Pion(Empire.Black,1),},
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { new Pion(Empire.White,1), new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),new Pion(Empire.White,1),},
            { new Tour(Empire.White,4), new Cavalier(Empire.White,5), new Fou(Empire.White,4), new Reine(Empire.White,10), new Roi(Empire.White,100), new Fou(Empire.White,4), new Cavalier(Empire.White,5), new Tour(Empire.White,4) },
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
