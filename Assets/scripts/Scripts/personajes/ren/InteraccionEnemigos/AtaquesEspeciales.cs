using UnityEngine;
using System.Collections;

public class AtaquesEspeciales : MonoBehaviour
{
    private bool puedeDestruir = false;
    float xDist = 0;
    GameObject Player;

    [SerializeField] Rigidbody2D slimeR;
    [SerializeField] SpriteRenderer SlimeSprite;
    public SlieControl slimeScript;
    float fuerzaRechazoConstante = 300;

    void Start()
    {


        Player = GameObject.FindWithTag("protagonista");
    }


    public void ActivarDestruccionEspecial()
    {
        puedeDestruir = true;

    }

    public void DesactivarDestruccionEspecial()
    {
        puedeDestruir = false;
    }

    /*public void quemarSlimeEspada()
    {
        StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));
    }*/

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

    public void ataqueEsp(Collider2D collision)
    {
        if (!puedeDestruir) return;

        if (collision.gameObject.tag == "Enemigo")
        {
            if (collision.TryGetComponent<EsqueletoControl>(out var esqueleto))
            {

                esqueleto.controlVida();
            }
            else if (collision.TryGetComponent<SlieControl>(out var slime))
            {
                xDist = transform.position.x - collision.transform.position.x;
                slimeR = collision.GetComponent<Rigidbody2D>();
                SlimeSprite = collision.GetComponent<SpriteRenderer>();
                slimeScript = collision.GetComponent<SlieControl>();

                if (xDist <= 0)
                {



                    Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
                    slimeR.AddForce(directionEnemy * 250, ForceMode2D.Impulse);


                    StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));


                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    StartCoroutine(FrenarRetrocesoEspecial());

                }
                else
                {


                    Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
                    slimeR.AddForce(directionEnemy * -250, ForceMode2D.Impulse);
                    StartCoroutine(DañoPorFuegoEspada(slime, SlimeSprite));


                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    StartCoroutine(FrenarRetrocesoEspecial());
                }

            }

        }
        IEnumerator FrenarRetrocesoEspecial()
        {

            yield return new WaitForSeconds(0.5f);

            slimeR.linearVelocity = Vector2.zero;
            slimeScript.enabled = true;



        }


    }
}
