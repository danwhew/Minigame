using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InstanciarCenario : MonoBehaviour
{
    public GameObject[] tiles; // Prefabs dos tiles
    public Player player;

    public float timer;

    public Transform empty;


    private void Start()
    {
        InstanciarTiles();
    }

    private void Update()
    {
        

        // Verifica se é necessário instanciar novos tiles
       /* if ()
        {
            InstanciarTiles();
            
        }*/
    }

    // Instancia os tiles iniciais ao redor da câmera
    private void InstanciarTiles()
    {

       
        GameObject novoTile = Instantiate(tiles[Random.Range(0,5)], empty.position, Quaternion.identity);

    }

    
    
}
