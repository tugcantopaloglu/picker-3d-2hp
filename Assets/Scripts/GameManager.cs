using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject[] _mapsPrefab = null;
    public GameObject[] MapsPrefab
    {
        get
        {
            return _mapsPrefab;
        }
    }

    [SerializeField] private GameObject[] _objectsPrefab = null;

    [SerializeField] private GameObject _playerPrefab = null;

    private int _whichLevel = 0;
    public int WhichLevel
    {
        get
        {
            return _whichLevel;
        }

        set
        {
            _whichLevel = value;
        }
    }

    private void Awake()
    {
        _whichLevel = PlayerPrefs.GetInt("WhichLevel");

        Instantiate(_mapsPrefab[_whichLevel], transform.position, Quaternion.identity);
        Instantiate(_objectsPrefab[_whichLevel], transform.position, Quaternion.identity);
        Instantiate(_playerPrefab);

        Instance = this;
    }
}
