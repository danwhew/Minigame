using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCenario : MonoBehaviour
{
    public GameObject[] tiles;
    public Transform anchor;
    public float offsetVertical = 1.0f; // Espa�amento vertical entre os tiles

    private void OnEnable()
    {
        InstanciarTiles();
    }

    public void InstanciarTiles()
    {
        // Posi��o inicial da �ncora
        Vector3 posicaoAncora = anchor.position;

        // Instancia cada tile em uma posi��o verticalmente deslocada
        foreach (GameObject tilePrefab in tiles)
        {
            // Instancia o tile na posi��o da �ncora
            Instantiate(tilePrefab, posicaoAncora, Quaternion.identity, transform.parent);

            // Atualiza a posi��o vertical da �ncora para o pr�ximo tile
            posicaoAncora += Vector3.up * offsetVertical;
        }
    }
}
