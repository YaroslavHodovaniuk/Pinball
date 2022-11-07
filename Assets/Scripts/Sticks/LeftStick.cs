using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftStick : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private LeftStickControl _control;


    private Rigidbody _balls;
    private bool _onStick = false;
    private void Update()
    {
        TryToPunch();
    }
   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody ball))
        {
            _balls = ball;
            _onStick = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
            _balls = null;
    }
    private void TryToPunch()
    {
        if (_control.IsPunch && _onStick)
        {
            _balls?.AddForce(new Vector2(0.5f, 1) * _force * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
