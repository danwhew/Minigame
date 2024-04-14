using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float force = 100f;
    public Collider colPlataform;
    public Plataforma plataforma;

    Ray ray;
    RaycastHit hit;

    public float horizontal;

    public float speed = 10f;
    public float tamanhoRay;


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
        //movimentacao pc
        horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        //

        ray = new Ray(transform.position, -transform.up * tamanhoRay);

        Debug.DrawRay(transform.position, -transform.up * tamanhoRay, Color.red);

        // se ele acertar o raycast
        if (Physics.Raycast(ray, out hit, tamanhoRay))
        {
            Debug.Log("Raycastando");
            colPlataform = hit.collider.gameObject.GetComponent<Collider>();
            plataforma = hit.collider.gameObject.GetComponent<Plataforma>();


            if (colPlataform != null)
            {
                //se ele tiver raycastado uma plataforma, ela deixa de ser trigger, entao ele nao atravessesa
                colPlataform.isTrigger = false;

            }

        }

        //se ele nao tiver acertando o raycast
        else
        {

            Debug.Log("Nao Raycastando");
            if (colPlataform != null)
            {
                //a ultima plataforma que ele passou vira trigger
                colPlataform.isTrigger = true;

            }


        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        // se ele colidir com a plataforma e a velocidade for 0
        //significa que ele precisa pular, ja que ele estaria parado
        if (rb.velocity.y == 0)
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);

            if(plataforma.scoreAdicionado == false)
            {

            GameController.instance.addScore(10);
            plataforma.scoreAdicionado = true;
            }

        }



    }

    private void OnCollisionStay(Collision collision)
    {

        // mesma logica do collision enter, se ele ta parado ele precisa pular
        if (rb.velocity.y == 0)
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);

            if (plataforma.scoreAdicionado == false)
            {

                GameController.instance.addScore(10);
                plataforma.scoreAdicionado = true;
            }

        }
        // mas se ele ta colidindo e nao ta parado, significa que a plataforma tem que continuar trigger
       /* else
        {
            if (colPlataform != null)
            {
                colPlataform.isTrigger = true;
            }
        }*/

    }


    private void FixedUpdate()
    {

        rb.AddForce(Input.acceleration.x * speed, 0, 0, ForceMode.VelocityChange);

    }
}
