using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _finishedGameContainer = null;

    GameManager gameManager;
    private int _whichLevel;
    private int _totalSceneCount;

    private void Start()
    {
        gameManager = GameManager.Instance;

        _totalSceneCount = gameManager.MapsPrefab.Length;
        _whichLevel = gameManager.WhichLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_whichLevel + 1 == _totalSceneCount)
            {
                _finishedGameContainer.SetActive(true);
                
                Time.timeScale = 0f;
                
            }
            else
            {
                _whichLevel++;
                PlayerPrefs.SetInt("WhichLevel", _whichLevel);
                //restart
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
}
