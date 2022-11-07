using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private float _indentZ;

    private Player _player;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _playerScore.text = _player.Score.ToString();
    }
    private void Update()
    {
        _playerScore.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _indentZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Block>(out Block block))
            _player.AddScore(block.Score);
    }
    private void OnScoreChanged(int score)
    {
        _playerScore.text = score.ToString();
    }
    private void OnDestroy()
    {
        Destroy(_playerScore.gameObject);
    }
}
