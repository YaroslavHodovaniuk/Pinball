using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private int _currentLvl = 0;
    [SerializeField] private Animator _animatorDoor;
    [SerializeField] private GameObject _winParticles;
    [SerializeField] private GameObject _destroyer;
    [SerializeField] private GameObject _trampline;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private int _winSpawnBalls;
    [SerializeField] private GameObject _winSpawnpointForBalls;

    private IEnumerator NextLvl()
    {
        yield return new WaitForSeconds(5f);
        _currentLvl++;
        SceneManager.LoadScene(_currentLvl);
    }
    public void Finish()
    {
        _animatorDoor.SetBool("Open", true);
        _winParticles.SetActive(true);
        _destroyer.SetActive(true);
        for (int i = 0; i < _winSpawnBalls; i++)
        {
            Instantiate(_ballPrefab, _winSpawnpointForBalls.transform.position, Quaternion.identity);
        }
        StartCoroutine(NextLvl());

        _trampline.SetActive(false);
    }
}
