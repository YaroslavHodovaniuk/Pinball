using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _vievScore;
    [SerializeField] private int _indentZ;
    [SerializeField] private int _scoreForFinish;
    [SerializeField] private LvlManager _lvlManager;


    private void Start()
    {
        _vievScore.text = _scoreForFinish.ToString();
        _vievScore.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _indentZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            _scoreForFinish -= _player.Score;
            _vievScore.text = _scoreForFinish.ToString();
            _player.SubsctractScore(_player.Score);

            if (_scoreForFinish <= 0)
            {
                _lvlManager.Finish();
                gameObject.SetActive(false);
                _vievScore.gameObject.SetActive(false);
            }
        }
    }
    
}
