using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _force;
    [SerializeField] private TMP_Text _vievScore;
    [SerializeField] private int _indentZ;
    [SerializeField] private Text _pefabText;
    [SerializeField] private Canvas _mainCanvas;

    private void Start()
    {
        _vievScore.text = _score.ToString();
        _vievScore.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _indentZ);
    }

    public int Score => _score;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Rigidbody>(out var player)){
            player.AddForce(Vector2.up * _force, ForceMode.Impulse);
            StartCoroutine(AddScoreEffect());
        }
    }
    private IEnumerator AddScoreEffect()
    {
        Text text = Instantiate(_pefabText, transform.position, Quaternion.identity, _mainCanvas.transform);
        text.text = "+" + _score.ToString();
        yield return new WaitForSeconds(1f);
        Destroy(text.gameObject);
    }
}
