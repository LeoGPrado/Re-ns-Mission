using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System.Collections;

public class SlieControl : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private Vector3 velo = Vector3.zero;
    GameObject obj;
    //public Rigidbody2D slimeR;

    //public CircleCollider2D AreaDeteccionJugador;
    //public bool DetectaAlJugador = false;

    public static SlieControl slime;

    private NavMeshAgent agent;
    private Transform player, door;
    public int VidaEnemigo = 1;

    [SerializeField] private GameObject manaPartícula;

    public bool slimeFuego=false;
    public bool slimeHielo=false;
    public bool slimeNaturaleza=false;
    public bool Slime=false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //slimeR = GetComponent<Rigidbody2D>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (slime == null)
        {
            slime = this;
        }
    }


    void Start()
    {
        obj = GameObject.Find("PuntoEntrada");
        player = GameObject.FindWithTag("protagonista").transform;

        if (obj != null)
        {
            door = objetivo = obj.transform;
        }

    }


    void Update()
    {
        //area de deteccion
        Vector2 direccion = player.position - transform.position;
        if (direccion.magnitude < 5)
        {
            objetivo = player;
        }
        else
        {
            objetivo = door;
        }

        //seguir objetivo
        if (objetivo == null) return;

        agent.SetDestination(objetivo.position);
        //transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
        //transform.position = Vector3.SmoothDamp(transform.position, objetivo.position, ref velo, 3f);

        if (objetivo.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (objetivo.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
   

    public void controlVida()
    {
        if (VidaEnemigo < 1)
        {
            Destroy(gameObject);
            Instantiate(manaPartícula, transform.position, Quaternion.identity);
        }
        else
        {
            if (slimeFuego == true)
            {
                VidaEnemigo --;
            }
            else if (slimeHielo==true)
            {

                VidaEnemigo--;
            }
            else if (slimeNaturaleza == true)
            {

                VidaEnemigo--;
            }
            else if (slime == true)
            {

                VidaEnemigo--;
            }

        }
    }
    public string confirmarElemento()
    {
        if (slimeFuego == true)
        {
            print("slimeFuegoEsTrue");
            return "fuego";
        }
        else if (slimeHielo == true)
        {

            return "hielo";
        }
        else if (slimeNaturaleza == true)
        {

            return "naturaleza";
        }
        else if (slime == true)
        {

            return "normal";
        }
        else
        {
            return "desconocido";
        }
        
    }



    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            obj = GameObject.Find("personaje");

            if (obj != null)
            {
                objetivo = obj.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            obj = GameObject.Find("PuntoEntrada");

            if (obj != null)
            {
                objetivo = obj.transform;
            }
        }
    }*/
}
