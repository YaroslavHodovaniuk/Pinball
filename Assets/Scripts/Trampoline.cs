using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private int _force;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out var ball))
        {
            ball.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
    }
}
