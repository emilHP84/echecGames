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
public class Manager : MonoBehaviour
{
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
    }

    private void GenerateBoard() {
        Board.Pieces = new Piece[,] {
            { new Tour(Empire.Black), new Cavalier(Empire.Black), new Fou(Empire.Black), new Reine(Empire.Black), new Roi(Empire.Black), new Fou(Empire.Black), new Cavalier(Empire.Black), new Tour(Empire.Black) },
            { new Pion(Empire.Black), new Pion(Empire.Black), new Pion(Empire.Black), new Pion(Empire.Black), new Pion(Empire.Black), new Pion(Empire.Black), new Pion(Empire.Black), new Pion(Empire.Black) },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { null, null, null, null, null, null, null, null,  },
            { new Pion(Empire.White), new Pion(Empire.White), new Pion(Empire.White), new Pion(Empire.White), new Pion(Empire.White), new Pion(Empire.White), new Pion(Empire.White), new Pion(Empire.White) },
            { new Tour(Empire.White), new Cavalier(Empire.White), new Fou(Empire.White), new Reine(Empire.White), new Roi(Empire.White), new Fou(Empire.White), new Cavalier(Empire.White), new Tour(Empire.White) },
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
