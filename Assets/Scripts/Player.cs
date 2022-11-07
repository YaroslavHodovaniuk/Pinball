using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _score;

    public int Score => _score;
    public event UnityAction<int> ScoreChanged;

    public void AddScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }
    public void SubsctractScore(int score)
    {
        _score -= score;
        ScoreChanged?.Invoke(_score);
    }
}
