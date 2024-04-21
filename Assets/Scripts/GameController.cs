using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameController instance;

    public TMP_Text scoreText;

    public int score = 0;

    public GameObject telaDerrota;
    public GameObject telaVitoria;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        //Quando tivermos essas telas
        if (telaDerrota != null)
        {
            telaDerrota.SetActive(false);
        }

        if (telaVitoria != null)
        {
            telaVitoria.SetActive(false);

        }


    }

    //quem chama eh o player, e uma vez so
    public void addScore(int adicionar)
    {
        score += adicionar;
        scoreText.text = "Score: " + score.ToString();
    }

    //depois pra colocar em algum botao da UI
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void loseGame()
    {
        if(telaDerrota != null)
        {
        telaDerrota.SetActive(true);
        Time.timeScale = 0f;

        }
    }



}
