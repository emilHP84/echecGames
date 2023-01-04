using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMax : MonoBehaviour
{
    public int node;
    public int MaxNode;
    public int MinNode;
    
    public int MaximalNode = 2;
    public int terminalNode = 6;

    public EvaluationFunction eval => EvaluationFunction.Function;

    public void MinMaxing( int depth) {
        if (depth <= 0) EvaluationFunction.Function.Evaluation();
        
        float BestScore;
        List<Vector2Int> BestMove;

        if (node == MaxNode) { // ia actuel
            BestScore = -Mathf.Infinity;
            for (Piece.MovePossible() m) {
                // joue les coups m
                int score = MinMaxing(depth - 1);
                // annuler le coups m
                if (score > BestScore) {
                    BestScore = score;
                    BestMove m;
                }
            }
        }
        else { // ia adverse
            BestScore = +Mathf.Infinity;
            for (Piece.MovePossible() m) {
                // joue les coups m
                int score = MinMaxing(depth - 1);
                // annuler le coups m
                if (score < BestScore) {
                    BestScore = score;
                    BestMove m;
                }
            }
        }
    }
}
