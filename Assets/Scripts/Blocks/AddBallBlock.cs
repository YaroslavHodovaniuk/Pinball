using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddBallBlock : MonoBehaviour
{
    [SerializeField] private string _inscription;
    [SerializeField] private int _force;
    [SerializeField] private TMP_Text _vievScore;
    [SerializeField] private int _indentZ;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _spawnpoint;

    private void Start()
    {
        _vievScore.text = _inscription;
        _vievScore.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _indentZ);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out var player))
        {
            player.AddForce(Vector3.up * _force, ForceMode.Impulse);
            Instantiate(_ballPrefab, _spawnpoint.position, Quaternion.identity);
        }
    }
}
