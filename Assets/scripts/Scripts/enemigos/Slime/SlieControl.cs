using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SlieControl : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private Vector3 velo = Vector3.zero;
    GameObject objPuerta;
    GameObject objPersonaje;
    //public Rigidbody2D slimeR;

    //public CircleCollider2D AreaDeteccionJugador;
    //public bool DetectaAlJugador = false;

    public static SlieControl slime;

    private NavMeshAgent agent;
    private Transform player, door;
    [SerializeField] public int VidaEnemigo;
    

    [SerializeField] private GameObject manaPartícula;
    [SerializeField] private float manaPartCount = 4f;
    [SerializeField] private bool canDropMana = true;

    public bool objetivoPuerta;
    public bool objetivoRen;

    public bool slimeFuego=false;
    public bool slimeHielo=false;
    public bool slimeNaturaleza=false;
    public bool Slime=false;

    //invocacionBala
    public GameObject balaNormal;
    public Transform puntoAparicion;
    public bool activarDisparo;
    public bool VerificarSlime;

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
    private void OnEnable()
    {
        if (objetivoPuerta == true)
        {
            objPuerta = GameObject.Find("PuntoEntrada");
            player = GameObject.FindWithTag("protagonista").transform;
        }

        if (objetivoRen == true)
        {
            objPersonaje = GameObject.Find("personaje");
            player = GameObject.FindWithTag("protagonista").transform;
        }


        if (objPuerta != null)
        {
            door = objetivo = objPuerta.transform;
        }
        if (objPersonaje != null)
        {
            door = objetivo = objPersonaje.transform;
        }

    }

    void Start()
    {
        if(objetivoPuerta == true)
        {
            objPuerta = GameObject.Find("PuntoEntrada");
            player = GameObject.FindWithTag("protagonista").transform;
        }

        if (objetivoRen == true)
        {
            objPersonaje = GameObject.Find("personaje");
            player = GameObject.FindWithTag("protagonista").transform;
        }

        /*objPuerta = GameObject.Find("PuntoEntrada");
        player = GameObject.FindWithTag("protagonista").transform;*/

        VidaEnemigo = 5;

        if (objPuerta != null)
        {
            door = objetivo = objPuerta.transform;
        }

        if (objPersonaje != null)
        {
            door = objetivo = objPersonaje.transform;
        }

    }


    void Update()
    {
        //area de deteccion
        Vector2 direccion = player.position - transform.position;
        if (direccion.magnitude < 5 && !activarDisparo)
        {
            objetivo = player;

            if (VerificarSlime == true)
            {
                activarDisparo = true;
                StartCoroutine(InvocacionDeBalaSlime());
            }

        }
        else if (direccion.magnitude > 5 && !activarDisparo)
        {
            //activarDisparo = false;
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
   
    public void Instakill()
    {
        StartCoroutine(DropAndCooldown());
        Destroy(gameObject);
    }

    public void controlVida()
    {
        print("RECIBIO DAÑO!!!!");
        if (VidaEnemigo < 1)
        {
            StartCoroutine(DropAndCooldown());
            Destroy(gameObject);
            
            
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
            else
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
    public void quemarSlime()
    {
        StartCoroutine(DañoPorFuego());
    }

    public void ManaDrop()
    {

        for (int i = 0; i < manaPartCount; i++)
        {
            //Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * Random.Range(0.5f, 1.5f);
            GameObject particle = Instantiate(manaPartícula, transform.position, Quaternion.identity);
            //Instantiate(manaPartícula, spawnPos, Quaternion.identity);


        }
    }

    IEnumerator DropAndCooldown()
    {
        if (canDropMana)
        {
            ManaDrop();
            canDropMana = false;
        }
        

        yield return new WaitForSeconds(1f);
        canDropMana = true;
    }

    IEnumerator DañoPorFuego()
    {
        int repeticiones = 0;
        GetComponent<SpriteRenderer>().color = Color.red;

        while (repeticiones > 6)
        {
            repeticiones++;
            controlVida();

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator InvocacionDeBalaSlime()
    {
        Instantiate(balaNormal, puntoAparicion.position, puntoAparicion.rotation);
        yield return new WaitForSecondsRealtime(1f);
        activarDisparo = false;
    }
}
