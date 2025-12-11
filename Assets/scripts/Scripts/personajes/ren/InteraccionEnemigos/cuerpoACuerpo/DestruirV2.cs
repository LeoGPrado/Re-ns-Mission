using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class DestruirV2 : MonoBehaviour
{
    private bool puedeDestruir = false;
    float xDist = 0;
    GameObject Player;

    [SerializeField] Rigidbody2D slimeR;
    [SerializeField] SpriteRenderer SlimeSprite;
    public SlieControl slimeScript;
    float fuerzaRechazoConstante = 300;

    public GameObject espada;
    public GameObject mazo;
    public GameObject pollo;
    public GameObject pescado;

    public bool DFuego = false;
    public bool Dhielo = false;
    public bool Dnaturaleza = false;
    public bool Dnormal = false;

    public static DestruirV2 SeleccionElemento;


    public bool ataqueDeFuego = false;


    public void ActivarFuego() => ataqueDeFuego = true;
    public void DesactivarFuego() => ataqueDeFuego = false;
    private void Awake()
    {

        if (SeleccionElemento == null)
        {
            SeleccionElemento = this;
        }

    }



    void Start()
    {


        Player = GameObject.FindWithTag("protagonista");
    }

    public void ataqueNormal()
    {
        slimeScript.controlVida();
    }

    public void ActivarDestruccion()
    {
        puedeDestruir = true;
        
    }

    public void DesactivarDestruccion()
    {
        puedeDestruir = false;
    }

    IEnumerator DañoPorFuegoEspada(SlieControl slime, SpriteRenderer sr)
    {
        int repeticiones = 6;
        sr.GetComponent<SpriteRenderer>().color = Color.red;

        for (int i = 0; i < repeticiones; i++)
        {
            slime.controlVida();

            yield return new WaitForSeconds(1f);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!puedeDestruir) return;
        print("deteccion!!!!");

        if (espada.activeInHierarchy)
        {
            DestruirV2.SeleccionElemento.DFuego = true;
        }
        else if(mazo.activeInHierarchy)
        {
            DestruirV2.SeleccionElemento.Dnaturaleza = true;
        }
        else if (pollo.activeInHierarchy)
        {
            DestruirV2.SeleccionElemento.Dnormal = true;
        }
        else if (pescado.activeInHierarchy)
        {
            DestruirV2.SeleccionElemento.Dhielo = true;
        }
        //DestruirV2.SeleccionElemento.DFuego=true

        if (collision.CompareTag("Enemigo"))
        {
            if (collision.TryGetComponent<SlieControl>(out var slime))
            {
                xDist = transform.position.x - collision.transform.position.x;
                slimeR = collision.GetComponent<Rigidbody2D>();
                SlimeSprite = collision.GetComponent<SpriteRenderer>();
                slimeScript = slime;

                Vector2 directionEnemy =
                    (transform.position - collision.transform.position).normalized;

                slimeR?.AddForce(directionEnemy * 250, ForceMode2D.Impulse);

                if (ataqueDeFuego)
                {
                    StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));
                }
                else
                {
                    int golpes = slime.CalcularDañoRecibido(DFuego, Dhielo, Dnaturaleza);

                    for (int i = 0; i < golpes; i++)
                        slime.controlVida();

                    DFuego = Dhielo = Dnaturaleza = Dnormal = false;
                }

                slimeScript.enabled = false;
                StartCoroutine(FrenarRetroceso());
            }
        }
    }
    IEnumerator FrenarRetroceso()
        {

            yield return new WaitForSeconds(0.5f);

            if (slimeR)
                slimeR.linearVelocity = Vector2.zero;
            
            if (slimeScript)
                slimeScript.enabled = true;
        }
}
