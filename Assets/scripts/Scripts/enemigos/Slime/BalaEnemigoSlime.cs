using Unity.VisualScripting;
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


    [Header("Audio")]
    [SerializeField] private AudioClip sonidoDisparo;
    private AudioSource fxSource;


    [Header("Visual & Collider")]
    [SerializeField] private GameObject spriteBala;
    [SerializeField] private Collider2D col;
    private bool impacto = false;


    void Start()
    {
        target = GameObject.FindWithTag("protagonista").transform;
        direccion = (target.position - transform.position).normalized;
        float ang = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, ang - 90f);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direccion * speed;
        rb.WakeUp();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;

        fxSource = gameObject.AddComponent<AudioSource>();
        fxSource.playOnAwake = false;
        fxSource.clip = sonidoDisparo;
        if (sonidoDisparo != null)
            fxSource.Play();

        Destroy(gameObject, tiempoDeVida);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (impacto) return;

        if (collision.gameObject.CompareTag("protagonista"))
        {
            Impacto();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (impacto) return;

        if (collision.gameObject.CompareTag("proyectil"))
        {
            Impacto();
        }
    }

    private void Impacto()
    {
        impacto = true;

        if (spriteBala != null) spriteBala.SetActive(false);
        if (col != null) col.enabled = false;

        if (fxSource != null && fxSource.clip != null)
        {
            Destroy(gameObject, fxSource.clip.length);
        }
        else
        {
            Destroy(gameObject, 0f);
        }

    }
}
