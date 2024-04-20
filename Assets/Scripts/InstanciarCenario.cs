using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCenario : MonoBehaviour
{
    public GameObject[] tiles; // Prefabs dos tiles
    public Transform cameraTransform; // Transform da c�mera
    public float distanciaLimite = 10.0f; // Dist�ncia a partir da qual instanciar novos tiles
    public float offsetVertical = 1.0f; // Espa�amento vertical entre os tiles

    private Vector3 ultimaPosicaoTileInstanciado; // �ltima posi��o em que um tile foi instanciado

    private void Start()
    {
        InstanciarTilesIniciais();
    }

    private void Update()
    {
        // Verifica se � necess�rio instanciar novos tiles
        if (Vector3.Distance(ultimaPosicaoTileInstanciado, cameraTransform.position) > distanciaLimite)
        {
            InstanciarNovosTiles();
        }
    }

    // Instancia os tiles iniciais ao redor da c�mera
    private void InstanciarTilesIniciais()
    {
        Vector3 posicaoAncora = cameraTransform.position;

        foreach (GameObject tilePrefab in tiles)
        {
            GameObject novoTile = Instantiate(tilePrefab, posicaoAncora, Quaternion.identity);
            posicaoAncora += Vector3.up * offsetVertical;
            ultimaPosicaoTileInstanciado = posicaoAncora;
        }
    }

    // Instancia novos tiles � frente da c�mera
    private void InstanciarNovosTiles()
    {
        Vector3 posicaoAncora = ultimaPosicaoTileInstanciado;

        foreach (GameObject tilePrefab in tiles)
        {
            GameObject novoTile = Instantiate(tilePrefab, posicaoAncora, Quaternion.identity);
            posicaoAncora += Vector3.up * offsetVertical;
        }

        ultimaPosicaoTileInstanciado = posicaoAncora;
    }
}
