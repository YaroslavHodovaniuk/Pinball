using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RigthStick : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private RigthStickControl _control;

    private Rigidbody _balls;
    private bool _isCollision = false;

    private void Update()
    {
        TryToPunch();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
        {
            _balls = rigidbody;
            _isCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
            _balls = null;
    }
    private void TryToPunch()
    {
        if (_control.IsPunch && _isCollision)
        {
            _balls?.AddForce(new Vector2(-0.5f, 1)* _force * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
