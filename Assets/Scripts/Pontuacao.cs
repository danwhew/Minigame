using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    public TMP_Text textoPontuacao;
    private Player playerScript; // Refer�ncia ao script do jogador

    void Start()
    {
        // Obt�m a refer�ncia ao script do jogador
        playerScript = FindObjectOfType<Player>();
        if (playerScript == null)
        {
            Debug.LogError("Script do jogador n�o encontrado!");
        }

        // Inicializa o texto de pontua��o
        AtualizarPontuacao();
    }

    void Update()
    {
        // Atualiza a pontua��o continuamente
        AtualizarPontuacao();
    }

    void AtualizarPontuacao()
    {
        // Verifica se o script do jogador foi encontrado
        if (playerScript != null)
        {
            // Obt�m a pontua��o do jogador a partir do script do jogador
            int pontuacao = playerScript.GetPontuacao(); // Assumindo que existe um m�todo GetPontuacao no script do jogador
            textoPontuacao.text = "Pontua��o: " + pontuacao;
        }
        else
        {
            Debug.LogError("Script do jogador n�o encontrado!");
        }
    }
}
