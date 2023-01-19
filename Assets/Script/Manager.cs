using Script;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


public class Manager : MonoBehaviour {

    [Range(1, 5)] public int Depth;
    public Transform BoardTransform;
    public Transform PieceTransform;
    public GameObject SquarePrefab;
    public GameObject PiecePrefab;
    public Sprite WhiteRook,WhiteKnight,WhiteBishop,WhiteQueen, WhiteKing, WhitePawn;
    public Sprite BlackRook, BlackKnight, BlackBishop, BlackQueen, BlackKing, BlackPawn;
    public Sprite Empty;
    
    public static Board CurrentBoard;
    private Empire _currentEmpire = Empire.White;
    private Stopwatch _stopwatch;
    
    public void Awake() {
        SquarePrefab.GetComponent<Image>().sprite = null;
        GenerateBoard();
        //GenerateBoardTest();
        DisplayBoard(CurrentBoard);
    }

    public void Update() {
        if (Input.GetButtonDown("Jump")) {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            CurrentBoard = Think(_currentEmpire);
            DisplayBoard(CurrentBoard);
            _stopwatch.Stop();
            Debug.Log(_stopwatch.Elapsed);
        }

        if (Input.GetButtonDown("Fire1")) {
            GenerateBoard();
            DisplayBoard(CurrentBoard);
        }
    }

    private void GenerateBoard() {
        CurrentBoard = new Board(){
            Pieces = new Piece[,] {
                { new Tour(Empire.White,5,0), new Cavalier(Empire.White,3,0), new Fou(Empire.White,5,0), new Reine(Empire.White,10,0), new Roi(Empire.White,2000,0), new Fou(Empire.White,5,0), new Cavalier(Empire.White,3,0), new Tour(Empire.White,5,0) },
                { new Pion(Empire.White,1,0), new Pion(Empire.White,1,0),new Pion(Empire.White,1,0),new Pion(Empire.White,1,0),new Pion(Empire.White,1,0),new Pion(Empire.White,1,0),new Pion(Empire.White,1,0),new Pion(Empire.White,1,0),},
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { new Pion(Empire.Black,1,0), new Pion(Empire.Black,1,0),new Pion(Empire.Black,1,0),new Pion(Empire.Black,1,0),new Pion(Empire.Black,1,0),new Pion(Empire.Black,1,0),new Pion(Empire.Black,1,0),new Pion(Empire.Black,1,0),},
                { new Tour(Empire.Black,5,0), new Cavalier(Empire.Black,3,0), new Fou(Empire.Black,5,0), new Reine(Empire.Black,10,0), new Roi(Empire.Black,2000,0), new Fou(Empire.Black,5,0), new Cavalier(Empire.Black,3,0), new Tour(Empire.Black,5,0) },
            },
            EmpireTurn = Empire.White
        };
    }
    
    private void GenerateBoardTest() {
        CurrentBoard = new Board(){
            Pieces = new Piece[,] {
                               
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, null, null, null, null, null, null,  },
                { null, null, new Pion(Empire.White,1,0) ,null, new Pion(Empire.White,1,0), null, null, null,  },
                { null, null, null, null,new Tour(Empire.Black,5,0), null, null, null,  },
            },
            EmpireTurn = Empire.White
        };
    }
    
    public void DisplayBoard(Board board) {
        board = CurrentBoard;
        foreach (Transform child in BoardTransform) {
            Destroy(child.gameObject);
        }
        //création board
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                GameObject instantiate = Instantiate(SquarePrefab, BoardTransform);
                instantiate.GetComponent<Image>().color = (x + y) % 2 == 0 ? Color.black : Color.white;
            }
        } 
        foreach (Transform child in PieceTransform) { 
            Destroy(child.gameObject);
        }
        //création piece
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                GameObject instantiate = Instantiate(PiecePrefab, PieceTransform);
                Piece piece = board.Pieces[x, y];
                instantiate.GetComponent<Image>().sprite = GetSprite(piece);
                instantiate.name = x + "." + y;
            }
        }
    }
    
    private Board Think(Empire currentEmpire) {
        int heuristic = int.MinValue;
        Board bestBoard = new Board();
        foreach (Board child in CurrentBoard.GetChilds()) {
            int newValue = MinMax(child, Depth, false, 
                currentEmpire == Empire.White ? Empire.Black : Empire.White);
            if (newValue > heuristic) {
                heuristic = newValue;
                bestBoard = child;
            }
            Debug.Log("Empire : " + currentEmpire + " - Heuristic : " + heuristic);
        }
        return bestBoard;
    }
    
    // Pour chaque board possible je lance minmax

    public int MinMax(Board board, int depth, bool maximizingPlayer, Empire currentEmpire) { 
        int value = 0;
        if (depth == 0 ) {
            return board.HeuristicSum(currentEmpire);
        }
        if (maximizingPlayer) {
            value = int.MinValue;
            foreach (var child in CurrentBoard.GetChilds()) {
                value = Mathf.Max(value, MinMax(child, depth - 1, false, 
                    currentEmpire == Empire.White ? Empire.Black : Empire.White));
            }
        }
        else {
            value = int.MaxValue;
            foreach (var child in CurrentBoard.GetChilds()) {
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
