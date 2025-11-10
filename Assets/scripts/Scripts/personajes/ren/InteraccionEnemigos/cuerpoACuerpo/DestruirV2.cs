using UnityEngine;
using System.Collections;

public class DestruirV2 : MonoBehaviour
{
    private bool puedeDestruir = false;
    float xDist = 0;
    GameObject Player;

    [SerializeField] Rigidbody2D slimeR;
    public SlieControl slimeScript;
    float fuerzaRechazoConstante = 300;

    void Start()
    {
        // slimeR = GetComponent<Rigidbody2D>();

        Player = GameObject.FindWithTag("protagonista");
    }

    private void Update()
    {


    }

    public void ActivarDestruccion()
    {
        puedeDestruir = true;
    }

    public void DesactivarDestruccion()
    {
        puedeDestruir = false;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!puedeDestruir) return;

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!puedeDestruir) return;

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (collision.TryGetComponent<EsqueletoControl>(out var esqueleto))
            {

                esqueleto.controlVida();
            }
            else if (collision.TryGetComponent<SlieControl>(out var slime))
            {
                xDist = transform.position.x - collision.transform.position.x;
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                slimeScript = collision.GetComponent<SlieControl>();

                if (xDist <= 0)
                {

                    //rb.linearVelocity = Vector2.zero; // ← detiene cualquier movimiento previo
                    //rb.angularVelocity = 0f;

                    Vector2 directionEnemy = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(directionEnemy * fuerzaRechazoConstante, ForceMode2D.Impulse);

                    //slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    collision.GetComponent<repelerEnemigo>().Hitted();
                }
                else
                {
                    //rb.linearVelocity = Vector2.zero; // ← detiene cualquier movimiento previo
                   // rb.angularVelocity = 0f;

                    Vector2 directionEnemy = (collision.transform.position - transform.position).normalized;
                    rb.AddForce(directionEnemy * fuerzaRechazoConstante, ForceMode2D.Impulse);

                    //slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    collision.GetComponent<repelerEnemigo>().Hitted();
                    slime.controlVida();
                }

                //slime.controlVida();
            }

            //Destroy(collision.gameObject);
        }


    }*/

    public void OnTriggerEnter2D(Collider2D collision)
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
                slimeScript = collision.GetComponent<SlieControl>();

                if (xDist <= 0)
                {

                    //rb.linearVelocity = Vector2.zero; // ← detiene cualquier movimiento previo
                    //rb.angularVelocity = 0f;

                    Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
                    slimeR.AddForce(directionEnemy * 250, ForceMode2D.Impulse);

                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    StartCoroutine(FrenarRetroceso());

                }
                else
                {
                    //rb.linearVelocity = Vector2.zero; // ← detiene cualquier movimiento previo
                    // rb.angularVelocity = 0f;

                    Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
                    slimeR.AddForce(directionEnemy * -250, ForceMode2D.Impulse);

                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    StartCoroutine(FrenarRetroceso());
                }

                /*Vector2 directionEnemy = (transform.position - (collision.transform.position*10)).normalized;
                slimeR.AddForce(directionEnemy * 500, ForceMode2D.Impulse);

                slimeScript.enabled = false;
                print("esta entrando en trigger");
                StartCoroutine(FrenarRetroceso());*/
            }

        }
        IEnumerator FrenarRetroceso()
        {

            yield return new WaitForSeconds(0.5f);

            slimeR.linearVelocity = Vector2.zero;
            slimeScript.enabled = true;
            //ren.linearVelocity = new Vector2(0f, ren.linearVelocity.y);
            //ren.linearVelocity = new Vector2(ren.linearVelocity.x, 0f);


        }



    }
}
