using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float _force;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Rigidbody>(out var ball))
        {
            ball.AddForce(transform.right * _force);
        }
    }
}
