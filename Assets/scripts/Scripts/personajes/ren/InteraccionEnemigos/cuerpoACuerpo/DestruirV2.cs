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
    //ataque normal
    public void ataqueNormal()
    {
        slimeScript.controlVida();
    }


    //espada
    /*public void ataqueEspaceial()
    {
        StartCoroutine(DañoPorFuegoEspada(slimeScript, SlimeSprite));
    }*/


    public void ActivarDestruccion()
    {
        puedeDestruir = true;
        
    }

    public void DesactivarDestruccion()
    {
        puedeDestruir = false;
    }


    //parte de la espada
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

        if (collision.gameObject.tag == "Enemigo")
        {
            print("enemigo!!!!");
            //talvez esto sea el problema
            if (collision.TryGetComponent<SlieControl>(out var slime))
            {
                print("tiene componente!!!!");
                xDist = transform.position.x - collision.transform.position.x;
                slimeR = collision.GetComponent<Rigidbody2D>();
                SlimeSprite = collision.GetComponent<SpriteRenderer>();
                slimeScript = collision.GetComponent<SlieControl>();

                string tipoSlime = slime.confirmarElemento();
                print("Elemento detectado en enemigo: " + tipoSlime);

                Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;

                if (xDist <= 0)
                {
                    slimeR?.AddForce(directionEnemy * 250, ForceMode2D.Impulse);
                }
                else
                {
                    slimeR?.AddForce(directionEnemy * -250, ForceMode2D.Impulse);
                }

                if (ataqueDeFuego)
                {
                    StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));
                }
                else
                {
                    switch (tipoSlime)
                    {
                        case "fuego": ApplyDamage(DFuego, Dhielo); break;
                        case "hielo": ApplyDamage(Dhielo, Dnaturaleza); break;
                        case "naturaleza": ApplyDamage(Dnaturaleza, DFuego); break;
                        default: ataqueNormal(); break;
                    }
                    if (tipoSlime == "normal")
                    {
                        print("La bala ha entrado a enemigo normal");
                        ataqueNormal();
                        ataqueNormal();
                    }
                    else
                    {
                        ataqueNormal();
                    }
                }


                slimeScript.enabled = false;
                print("esta entrando en trigger");
                StartCoroutine(FrenarRetroceso());
            }

        }

        void ApplyDamage(bool firstOption, bool secondOption)
        {
            if (firstOption)
            {
                ataqueNormal();
            }
            else if (secondOption)
            {
                ataqueNormal();
                ataqueNormal();
                ataqueNormal();
            }
            else
            {
                ataqueNormal();
                ataqueNormal();
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
}