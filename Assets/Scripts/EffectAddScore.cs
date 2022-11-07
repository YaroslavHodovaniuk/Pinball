using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EffectAddScore : MonoBehaviour
{
    private Text _text;
    private Vector3 _targetPosition;
    void Start()
    {
        _text = GetComponent<Text>();
        _text.DOFade(0, 1);
        _targetPosition = transform.position + Vector3.up;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime);
    }
}
