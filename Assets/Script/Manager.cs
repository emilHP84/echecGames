using Script;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour {

    public Transform BoardTransform;
    public GameObject SquarePrefab;
    public Sprite WhiteRook, WhiteKnight, WhiteBishop, WhiteQueen, WhiteKing, WhitePawn;
    public Sprite BlackRook, BlackKnight, BlackBishop, BlackQueen, BlackKing, BlackPawn;
    public Sprite Empty;
    public int NombreDeTours;
    [SerializeField] public static Board Board = new Board();


    public void Start() {
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
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                GameObject instantiate = Instantiate(SquarePrefab, BoardTransform);
                instantiate.GetComponent<Image>().color = (x + y) % 2 == 0 ? Color.black : Color.white;
                Debug.Log((x + y) % 2 == 0 ? Color.black : Color.white);
            }
        }
        for (int i = 0; i < Board.Pieces.GetLength(0); i++) {
            for (int j = 0; j < Board.Pieces.GetLength(1); j++) {
                // Création des pieces
                //Board.Pieces[i,j]
            }
        }
    }

    private Sprite GetSprite(Piece piece) {
        if(piece == null) return Empty;
        Type type = piece.GetType();
        
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
        return BlackRook;
    }
    
}
