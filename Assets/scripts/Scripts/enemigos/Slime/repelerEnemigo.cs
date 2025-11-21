using UnityEngine;
using System.Collections;

public class repelerEnemigo : MonoBehaviour
{
    [SerializeField] Rigidbody2D slimeR;
    public SlieControl slimeScript;
    public float FuerzaDeRetroceso;
    GameObject Player;
    //bool fueGolpeado = false;

    float xDist = 0;

    void Start()
    {
        slimeR = GetComponent<Rigidbody2D>();
        slimeScript = GetComponent<SlieControl>();
        Player = GameObject.FindWithTag("protagonista");
    }

    private void Update()
    {

        xDist = Player.transform.position.x - transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "proyectil")
        {
            print("esta entrando");
            Vector2 directionEnemy = collision.contacts[0].normal;
            slimeR.AddForce(directionEnemy * FuerzaDeRetroceso, ForceMode2D.Impulse);
            //NoranonAnimaciones.SetTrigger("HeridoP");
            slimeScript.enabled = false;

            StartCoroutine(FrenarRetroceso());
        }*/
    }

    public void Hitted()
    {
        //if (fueGolpeado) return;
        //fueGolpeado = true;

        slimeScript.enabled = false;

        Invoke("Reactivate", 0.3f);
    }

    public void Reactivate()
    {
        slimeScript.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "proyectil")
        {

            /*Vector2 directionEnemy = (transform.position - (collision.transform.position * 10)).normalized;
            slimeR.AddForce(directionEnemy * 500, ForceMode2D.Impulse);

            slimeScript.enabled = false;
            print("esta entrando en trigger");
            StartCoroutine(FrenarRetroceso());*/

            if (xDist <= 0)
            {
                Vector2 directionEnemy = (collision.transform.position - transform.position).normalized;
                slimeR.AddForce(-directionEnemy * 500, ForceMode2D.Impulse);

                slimeScript.enabled = false;
                print("esta entrando en trigger");
                StartCoroutine(FrenarRetroceso());
            }
            else
            {
                Vector2 directionEnemy = (collision.transform.position -transform.position).normalized;
                slimeR.AddForce(-directionEnemy * 500, ForceMode2D.Impulse);

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


    /*public void Golpeado(Collision2D collision)
    {
        print("esta entrando");
        Vector2 direction = collision.contacts[0].normal;
        slimeR.AddForce(direction * FuerzaDeRetroceso, ForceMode2D.Impulse);
        //NoranonAnimaciones.SetTrigger("HeridoP");
        slimeScript.enabled = false;

        StartCoroutine(FrenarRetroceso());
    }*/

    IEnumerator FrenarRetroceso()
    {

        yield return new WaitForSeconds(0.5f);

        slimeR.linearVelocity = Vector2.zero;
        slimeScript.enabled = true;
        //ren.linearVelocity = new Vector2(0f, ren.linearVelocity.y);
        //ren.linearVelocity = new Vector2(ren.linearVelocity.x, 0f);


    }
}
