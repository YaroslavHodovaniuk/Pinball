using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out var ball))
        {
            Destroy(ball.gameObject);
        }
    }
}
