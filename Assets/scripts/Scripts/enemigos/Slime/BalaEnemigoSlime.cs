using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
//using UnityEngine.InputSystem;

public class BalaEnemigoSlime : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    public float FuerzaRetroceso = 2;
    private Vector2 direccion;
    public float tiempoDeVida = 5f;

    void Start()
    {
        target = GameObject.FindWithTag("protagonista").transform;
        direccion = (target.position - transform.position).normalized;
        float ang = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, ang - 90f);
        GetComponent<Rigidbody2D>().linearVelocity = direccion * speed;
        Destroy(gameObject, tiempoDeVida);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            Destroy(gameObject);
        }
    }
}
