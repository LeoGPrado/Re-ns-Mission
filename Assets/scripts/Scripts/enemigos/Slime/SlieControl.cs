using UnityEngine;
using UnityEngine.AI;

public class SlieControl : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private Vector3 velo = Vector3.zero;
    GameObject obj;

    public CircleCollider2D AreaDeteccionJugador;
    public bool DetectaAlJugador = false;

    public static SlieControl slime;

    private NavMeshAgent agent;
    private Transform player, door;
    public int VidaEnemigo = 1;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        if (VidaEnemigo <= 1)
        {
            Destroy(gameObject);
        }
        else
        {
            VidaEnemigo--;
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
