using UnityEngine;
using System.Collections;

public class RepelerYDetener : MonoBehaviour
{
    [SerializeField] Rigidbody2D ren;
    [SerializeField] BoxCollider2D renCuerpo;

    public ControlPersonaje renScript;
    

    public float FuerzaDeRetroceso;


    void Start()
    {
        ren = GetComponent<Rigidbody2D>();
        renScript = GetComponent<ControlPersonaje>();
    }


    public void Golpeado(Collision2D collision)
    {
        Vector2 direction = collision.contacts[0].normal;
        ren.AddForce(direction * FuerzaDeRetroceso, ForceMode2D.Impulse);
        renScript.enabled = false;

        StartCoroutine(FrenarRetroceso());
    }

    IEnumerator FrenarRetroceso()
    {

        yield return new WaitForSeconds(0.3f);

        ren.linearVelocity = Vector2.zero;
        renScript.enabled = true;

    }
}
