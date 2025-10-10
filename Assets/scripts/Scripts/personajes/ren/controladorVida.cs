using UnityEngine;
using System.Collections;

public class controladorVida : MonoBehaviour
{
    [SerializeField] Rigidbody2D personaje;


    public ControlPersonaje ControlDelPersonaje;

    //public float FuerzaDeRetroceso =3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            StartCoroutine(FrenarRetroceso());
        }

    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            StartCoroutine(FrenarRetroceso());
        }
    }*/

    /*IEnumerator FrenarRetroceso()
    {
        personaje.AddForce(Vector2.left * FuerzaDeRetroceso * Time.timeScale, ForceMode2D.Impulse);
        ControlDelPersonaje.enabled = false;
        yield return new WaitForSeconds(0.5f);


        ControlDelPersonaje.enabled = true;
        personaje.linearVelocity = new Vector2(0f, personaje.linearVelocity.y);
        yield return new WaitForSeconds(0.2f);

    }*/
}
