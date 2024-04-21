using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InstanciarCenario : MonoBehaviour
{
    public GameObject[] tiles; // Prefabs dos tiles
    public Transform empty;
    public GameObject pai;
    public bool jaInstanciei;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(jaInstanciei == false)
            {
            InstanciarTiles();
                jaInstanciei = true;

            }
            //Destroy(gameObject);
        }

        if (other.CompareTag("MataTile"))
        {
            Debug.Log("mateitile");
            Destroy(pai);

        }
    }

    // Instancia os tiles iniciais ao redor da câmera
    private void InstanciarTiles()
    {


        GameObject novoTile = Instantiate(tiles[Random.Range(0, 5)], empty.position, Quaternion.identity);

    }



}
