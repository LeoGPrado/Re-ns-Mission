using UnityEngine;
using System.Collections;

public class DestruirV2 : MonoBehaviour
{
    private bool puedeDestruir = false;
    float xDist = 0;
    GameObject Player;

    [SerializeField] Rigidbody2D slimeR;
    public SlieControl slimeScript;


    void Start()
    {
        slimeR = GetComponent<Rigidbody2D>();

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

    private void OnTriggerEnter2D(Collider2D collision)
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
                    Vector2 directionEnemy = (transform.position - (collision.transform.position)).normalized;
                    rb.AddForce(directionEnemy * -100, ForceMode2D.Impulse);

                    //slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    collision.GetComponent<repelerEnemigo>().Hitted();
                }
                else
                {
                    Vector2 directionEnemy = (transform.position - (collision.transform.position)).normalized;
                    rb.AddForce(directionEnemy * -100, ForceMode2D.Impulse);

                    slimeScript.enabled = false;
                    print("esta entrando en trigger");
                    collision.GetComponent<repelerEnemigo>().Hitted();
                }

                slime.controlVida();
            }

            //Destroy(collision.gameObject);
        }
    }



}
