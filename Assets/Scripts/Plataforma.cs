using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Collider colisor;
    public bool scoreAdicionado = false;

    private void OnEnable()
    {
        colisor = GetComponent<Collider>();
    }

   private void OnTriggerExit(Collider other)
    {
        colisor.isTrigger = true;
    }

    
}
