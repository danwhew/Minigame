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
    public LayerMask layersToHit;

    public float horizontal;

    public float speed = 10f;
    public float tamanhoRay;

    private Vector3 moveScreen;

    public float radius = 0.75f;
    public float offsetRaycast = 1;


    void Start()
    {
        // utilizando a camera para calcular os limites da tela
        moveScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 playerPosition = transform.position;
        if (playerPosition.x + transform.localScale.x / 2 < -moveScreen.x)
        {
            // aparece no direito da tela
            transform.position = new Vector3(moveScreen.x, playerPosition.y, playerPosition.z);
        }
        else if (playerPosition.x - transform.localScale.x / 2 > moveScreen.x)
        {
            // aparece no esquerdo d tela
            transform.position = new Vector3(-moveScreen.x, playerPosition.y, playerPosition.z);
        }

        //movimentacao  celular
        transform.Translate(Input.acceleration.x * speed * Time.deltaTime, 0, 0);

        //Debug.Log(Input.acceleration.x * speed);

        //movimentacao pc
        horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);


        //detectar plataformas em baixo
        if (Physics.SphereCast(transform.position + new Vector3(0, offsetRaycast, 0), radius, -transform.up, out hit, 100f, layersToHit))
        {
            //Debug.Log("Raycastando");
            colPlataform = hit.collider.gameObject.GetComponent<Collider>();
            plataforma = hit.collider.gameObject.GetComponent<Plataforma>();


            if (colPlataform != null)
            {
                //se ele tiver raycastado uma plataforma, ela deixa de ser trigger, entao ele nao atravessesa
                colPlataform.isTrigger = false;
                //Debug.Log(" Raycastando");
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


            if (plataforma.scoreAdicionado == false)
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


    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MataPlayer"))
        {
            Time.timeScale = 0;
            GameController.instance.loseGame();
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, offsetRaycast, 0), radius);
    }
}

