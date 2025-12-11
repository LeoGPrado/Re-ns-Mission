using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DestruirEnemigo : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoBala;

    [Header("Varios")]
    [SerializeField] float velocidad = 8f;
    public bool quieto = true;
    [SerializeField] Animator ImpoctoArma;
    [SerializeField] private Rigidbody2D rb;
    public Transform spriteHijo;
    [SerializeField] private Light2D luz;

    [Header("Tipo De Daño")]
    public bool DFuego = false;
    public bool Dhielo = false;
    public bool Dnaturaleza = false;
    public bool Dnormal = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Start()
    {
        audioSource.PlayOneShot(sonidoBala);

        if (!quieto)        
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;


            Vector2 direccion = (mousePos - transform.position).normalized;


            rb.linearVelocity = direccion * velocidad;
        }

    }

    private void Update()
    {
        Vector2 dir = rb.linearVelocity;

        if (dir.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            spriteHijo.rotation = Quaternion.Euler(0f, 0f, angle + 180f);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemigo")) return;

        if (ImpoctoArma == null)
        {
            if (collision.TryGetComponent<SlieControl>(out var slime))
            {
                int golpes = slime.CalcularDañoRecibido(DFuego, Dhielo, Dnaturaleza);

                if (golpes == -1)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    for (int i = 0; i < golpes; i++)
                        slime.controlVida();
                }
            }

            DesactivarYEsperarAudio();
        }
        else
        {
            ImpoctoArma.SetTrigger("ImpactoP");
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            Destroy(collision.gameObject);
        }
    }



    private void DesactivarYEsperarAudio()
    {
        spriteHijo.gameObject.SetActive(false);
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        luz.enabled = false;
        rb.linearVelocity = Vector2.zero;
        StartCoroutine(DestruirDespuesDelAudio());
    }
    private IEnumerator DestruirDespuesDelAudio()
    {
        yield return new WaitForSeconds(sonidoBala.length);
        Destroy(gameObject);
    }

}
