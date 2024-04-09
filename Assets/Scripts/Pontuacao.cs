using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    public TMP_Text textoPontuacao;
    private Player playerScript; // Referência ao script do jogador

    void Start()
    {
        // Obtém a referência ao script do jogador
        playerScript = FindObjectOfType<Player>();
        if (playerScript == null)
        {
            Debug.LogError("Script do jogador não encontrado!");
        }

        // Inicializa o texto de pontuação
        AtualizarPontuacao();
    }

    void Update()
    {
        // Atualiza a pontuação continuamente
        AtualizarPontuacao();
    }

    void AtualizarPontuacao()
    {
        // Verifica se o script do jogador foi encontrado
        if (playerScript != null)
        {
            // Obtém a pontuação do jogador a partir do script do jogador
            int pontuacao = playerScript.GetPontuacao(); // Assumindo que existe um método GetPontuacao no script do jogador
            textoPontuacao.text = "Pontuação: " + pontuacao;
        }
        else
        {
            Debug.LogError("Script do jogador não encontrado!");
        }
    }
}
