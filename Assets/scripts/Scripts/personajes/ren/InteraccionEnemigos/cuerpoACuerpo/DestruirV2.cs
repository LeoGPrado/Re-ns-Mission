using UnityEngine;
using System.Collections;

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

        if (collision.gameObject.tag == "Enemigo")
        {
            //talvez esto sea el problema
            if (collision.TryGetComponent<SlieControl>(out var slime))
            {
                xDist = transform.position.x - collision.transform.position.x;
                slimeR = collision.GetComponent<Rigidbody2D>();
                SlimeSprite = collision.GetComponent<SpriteRenderer>();
                slimeScript = collision.GetComponent<SlieControl>();

                string tipoSlime = slime.confirmarElemento();
                print("Elemento detectado en enemigo: " + tipoSlime);

                if (xDist <= 0)
                {



                    Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
                    slimeR.AddForce(directionEnemy * 250, ForceMode2D.Impulse);
                    //slimeScript.controlVida();


                    if (ataqueDeFuego)
                    {
                        StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));
                    }
                    else
                    {

                        if (tipoSlime == "fuego")
                        {
                            if (DFuego == true)
                            {
                                ataqueNormal();
                            }
                            else if (Dhielo == true)
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
                        else if (tipoSlime == "hielo")
                        {
                            if (Dhielo == true)
                            {
                                ataqueNormal();
                            }
                            else if (Dnaturaleza == true)
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
                        else if (tipoSlime == "naturaleza")
                        {
                            if (Dnaturaleza == true)
                            {
                                ataqueNormal();
                            }
                            else if (DFuego == true)
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
                        else if (tipoSlime == "normal")
                        {
                            print("La bala ha entrado a enemigo normal");
                            ataqueNormal();
                            ataqueNormal();
                        }
                    }


                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    StartCoroutine(FrenarRetroceso());

                }
                else
                {


                    Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
                    slimeR.AddForce(directionEnemy * -250, ForceMode2D.Impulse);
                    //slimeScript.controlVida();

                    if (ataqueDeFuego)
                    {
                        StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));
                    }
                    else
                    {

                        if (tipoSlime == "fuego")
                        {
                            if (DFuego == true)
                            {
                                slime.controlVida();
                            }
                            else if (Dhielo == true)
                            {
                                slime.controlVida();
                                slime.controlVida();
                                slime.controlVida();
                            }
                            else
                            {
                                slime.controlVida();
                                slime.controlVida();
                            }

                        }
                        else if (tipoSlime == "hielo")
                        {
                            if (Dhielo == true)
                            {
                                slime.controlVida();
                            }
                            else if (Dnaturaleza == true)
                            {
                                slime.controlVida();
                                slime.controlVida();
                                slime.controlVida();
                            }
                            else
                            {
                                slime.controlVida();
                                slime.controlVida();
                            }

                        }
                        else if (tipoSlime == "naturaleza")
                        {
                            if (Dnaturaleza == true)
                            {
                                slime.controlVida();
                            }
                            else if (DFuego == true)
                            {
                                slime.controlVida();
                                slime.controlVida();
                                slime.controlVida();
                            }
                            else
                            {
                                slime.controlVida();
                                slime.controlVida();
                            }

                        }
                        else if (tipoSlime == "normal")
                        {
                            print("La bala ha entrado a enemigo normal");
                            slime.controlVida();
                            slime.controlVida();
                        }
                    }



                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    StartCoroutine(FrenarRetroceso());
                }

            }

        }
        IEnumerator FrenarRetroceso()
        {

            yield return new WaitForSeconds(0.5f);

            slimeR.linearVelocity = Vector2.zero;
            slimeScript.enabled = true;



        }

    }
}
