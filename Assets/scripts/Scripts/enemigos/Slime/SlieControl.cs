using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SlieControl : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoMovimiento;
    [SerializeField] private AudioClip sonidoDisparoSlime;
    [SerializeField] private AudioClip sonidoDeMuerte;

    public Transform objetivo;
    public float velocidad = 5f;
    GameObject objPuerta;
    GameObject objPersonaje;


    public static SlieControl slime;
    public bool estaMuerto = false;
    public Rigidbody enemigoRB;
    private NavMeshAgent agent;
    private Transform player, door;
    [SerializeField] public int VidaEnemigo;
    

    [SerializeField] private GameObject manaPartícula;
    [SerializeField] private float manaPartCount = 4f;
    [SerializeField] private bool canDropMana = true;
    private bool audioMuteado = false;


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
            else if (VerificarSlime == false)
            {
                //ControlPersonaje.Ren.DetectorSlime = false;
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
        if (!audioMuteado)
        {
            if (agent.velocity.magnitude > 0.1f)
            {
                if (audioSource != null && !audioSource.isPlaying)
                    audioSource.Play();
            }
            else
            {
                if (audioSource != null && audioSource.isPlaying)
                    audioSource.Stop();
            }
        }
        else
        {
            if (audioSource != null && audioSource.isPlaying)
                audioSource.Pause();

        }
    }
    public void Instakill()
    {
        StartCoroutine(DropAndCooldown());
        Destroy(gameObject);
    }

    public void controlVida()
    {
        if (estaMuerto) return;
        print("RECIBIO DAÑO!!!!");
        if (VidaEnemigo < 1)
        {
            StartCoroutine(SlimeMuere());          
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
        if (slimeFuego) return "fuego";
        if (slimeHielo) return "hielo";
        if (slimeNaturaleza) return "naturaleza";
        if (slime) return "normal";

        return "desconocido";
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
        Instantiate(balaNormal, puntoAparicion.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(4f);
        activarDisparo = false;
    }

    public void CongelamientoControl()
    {
        //print("descongelando navmesh");
        StartCoroutine(ExCongelamiento());
    }

    IEnumerator ExCongelamiento()
    {
        yield return new WaitForSecondsRealtime(3f);
        agent.isStopped = false;
    }
    IEnumerator SlimeMuere()
    {
        if (estaMuerto) yield break;
        estaMuerto = true;
        GetComponent<Collider2D>().enabled = false;

        VidaEnemigo = 0;
        if (audioSource != null && sonidoDeMuerte != null)
            audioSource.PlayOneShot(sonidoDeMuerte);

        StartCoroutine(DropAndCooldown());
        if (sonidoDeMuerte != null)
            yield return new WaitForSeconds(sonidoDeMuerte.length);

        Destroy(gameObject);
        ControlPersonaje.Ren.AumentarContadorEnemigos();

    }
    public static void MutearTodosSlimes(bool mutear)
    {
        SlieControl[] slimes = FindObjectsByType<SlieControl>(FindObjectsSortMode.None);
        foreach (SlieControl slime in slimes)
        {
            slime.audioMuteado = mutear;
            if (mutear) slime.audioSource.Pause();
            else slime.audioSource.UnPause();
        }
    }
}
