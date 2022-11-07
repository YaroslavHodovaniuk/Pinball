using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftStickControl : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Animator _animator;

    public bool IsPunch { get; private set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Punch());
    }

    private IEnumerator Punch() 
    {
        IsPunch = true;
        _animator.SetTrigger("Punch");
        yield return new WaitForSeconds(1f);
        IsPunch = false;
    }
}
