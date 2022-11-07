using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repellent : MonoBehaviour
{
    [SerializeField] private int _force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out var ball))
        {
            ball.AddForce(Vector3.down * _force, ForceMode.Impulse);
        }
    }
}
