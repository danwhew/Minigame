using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject lose;
    public Button restarLose;

    public static GameOver instance;

    void Start()
    {
        instance = this;
    }

    /*public void winGame()

    {
        victory.SetActive(true);
        Time.timeScale = 0f;
    } */

    public void loseGame()

    {
        restarLose.gameObject.SetActive(true);
        lose.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
