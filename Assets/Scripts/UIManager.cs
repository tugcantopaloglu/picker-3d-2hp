using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //restart level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //restart game
    public void RestartGame()
    {
        PlayerPrefs.SetInt("WhichLevel", 0);
        SceneManager.LoadScene(0);
    }
}
