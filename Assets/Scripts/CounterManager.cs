using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    public static CounterManager Instance;

    //counters
    private GameObject[] _counter = null;
    private Animator _counterAnim;
    private int _counterNeedsObject = 0;

    private int _whichCounter = 0;

    private MouseMovement _mouseMovement;

    private float _startMouseSpeed = 0;
    private float _startForwardSpeed = 0;

    //count objects
    private int _objectCount = 0;
    public int ObjectCount
    {
        get
        {
            return _objectCount;
        }

        set
        {
            _objectCount = value;
        }
    }

    private bool completeCounting = false;
    private bool isCounting = false;

    //restart lvl
    [SerializeField] private GameObject _restartLevel = null;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _counter = GameObject.FindGameObjectsWithTag("Counter");
        Array.Sort(_counter, CompareObNames);


        _mouseMovement = MouseMovement.Instance;
        _startMouseSpeed = _mouseMovement.MouseSpeed;
        _startForwardSpeed = _mouseMovement.ForwardSpeed;
    }

    void Update()
    {
        if (_mouseMovement.ForwardSpeed == 0 && !isCounting)
        {
            isCounting = true;
            Invoke("CompleteCounting", 2f);
        }

        if (completeCounting)
        {
            _counterNeedsObject = _counter[_whichCounter].GetComponent<CounterPrefabManager>().CounterNeedsObject;
            if (_objectCount >= _counterNeedsObject)
            {
                StartCoroutine(CounterSuccess());
                completeCounting = false;
            }
            else
            {
                RestartLevel();
            }
        }
    }

    private void CompleteCounting()
    {
        completeCounting = true;
    }

    private IEnumerator CounterSuccess()
    {
        yield return new WaitForSeconds(1f);

        _counterAnim = _counter[_whichCounter].GetComponent<Animator>();
        _counterAnim.SetTrigger("checkOpen");

        yield return new WaitForSeconds(1.1f);
        completeCounting = false;

        yield return new WaitForSeconds(1f);


        _mouseMovement.MouseSpeed = _startMouseSpeed;
        _mouseMovement.ForwardSpeed = _startForwardSpeed;

        isCounting = false;
        _objectCount = 0;
        _whichCounter++;

        StopAllCoroutines();
    }

    private void RestartLevel()
    {
        Time.timeScale = 0;
        _restartLevel.SetActive(true);
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
