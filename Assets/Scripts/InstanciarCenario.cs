using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCenario : MonoBehaviour
{
    public GameObject[] tiles;
    public Transform anchor;
    public float offsetVertical = 1.0f; // Espaçamento vertical entre os tiles

    private void OnEnable()
    {
        InstanciarTiles();
    }

    public void InstanciarTiles()
    {
        // Posição inicial da âncora
        Vector3 posicaoAncora = anchor.position;

        // Instancia cada tile em uma posição verticalmente deslocada
        foreach (GameObject tilePrefab in tiles)
        {
            // Instancia o tile na posição da âncora
            Instantiate(tilePrefab, posicaoAncora, Quaternion.identity, transform.parent);

            // Atualiza a posição vertical da âncora para o próximo tile
            posicaoAncora += Vector3.up * offsetVertical;
        }
    }
}
