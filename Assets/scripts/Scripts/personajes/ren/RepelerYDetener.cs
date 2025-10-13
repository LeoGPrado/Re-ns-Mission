using UnityEngine;
using System.Collections;

public class RepelerYDetener : MonoBehaviour
{
    [SerializeField] Rigidbody2D ren;
    //[SerializeField] Animator renAnimaciones;

    public ControlPersonaje renScript;


    public float FuerzaDeRetroceso;


    void Start()
    {
        ren = GetComponent<Rigidbody2D>();
        //renAnimaciones = GetComponent<Animator>();
        renScript = GetComponent<ControlPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            Vector2 direction = collision.contacts[0].normal;
            ren.AddForce(direction * FuerzaDeRetroceso * Time.timeScale, ForceMode2D.Impulse);
            //NoranonAnimaciones.SetTrigger("HeridoP");
            renScript.enabled = false;

            StartCoroutine(FrenarRetroceso());



        }

    }

    IEnumerator FrenarRetroceso()
    {

        yield return new WaitForSeconds(2f);


        renScript.enabled = true;
        ren.linearVelocity = new Vector2(0f, ren.linearVelocity.y);
        ren.linearVelocity = new Vector2(ren.linearVelocity.x, 0f);
        yield return new WaitForSeconds(0.2f);

    }
}
