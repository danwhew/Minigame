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

   /* public GameObject telaVitoria;
    public GameObject telaDerrota;*/

    private void Awake()
    {
        if(instance == null)
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
       // Time.timeScale = 1.0f;

        //Quando tivermos essas telas
       /* telaDerrota.SetActive(false);
        telaVitoria.SetActive(false);*/

        
    }

    // Update is called once per frame
    void Update()
    {
      
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
}
