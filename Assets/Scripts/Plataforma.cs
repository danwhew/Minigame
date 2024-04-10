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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colisor.isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        colisor.isTrigger = true;
    }
}
