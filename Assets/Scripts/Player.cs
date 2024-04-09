using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float force = 100f;
    public Collider colPlataform;
    public int pontuacao = 0;

    Ray ray;
    RaycastHit hit;


    public float contador;
    public bool podeContar = false;
    public float cooldown = 0.1f;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        speed = rb.velocity.y;
         ray = new Ray(transform.position, -transform.up * 100f);

         if (Physics.Raycast(ray, out hit))
         {
             colPlataform = hit.collider.gameObject.GetComponent<Collider>();

             colPlataform.isTrigger = false;
        }
        else
        {
            colPlataform.isTrigger = true;
        }


       
    }

    private void OnTriggerEnter(Collider other)
    {
        //pontuacao++;

    }

    private void OnCollisionStay(Collision collision)
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
            pontuacao++;
        }

    }
    public int GetPontuacao()
    {
        return pontuacao;
    }
   
}
