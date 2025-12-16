using UnityEngine;
using System.Collections;

public class ControlPersonaje : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private GameObject canvasDerrota;
    [SerializeField] private GameObject canvasGameplay;
    [SerializeField] Rigidbody2D ren;
    [SerializeField] Animator animRen;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip movimientoSonido;
    [SerializeField] private AudioClip dañoRecibidoAudio;

    [Header("Demas")]
    public BoxCollider2D DetectarEnemigo;
    public Transform puntoDeAtaque;
    [SerializeField] private CamaraShake camaraShake;

    [SerializeField] SpriteRenderer sr;
    [SerializeField] private BoxCollider2D boxRenDerechaAtaque;
    [SerializeField] private BoxCollider2D boxRenIzquierdaAtaque;

    [Header("Parpadeo vida baja")]
    [SerializeField] private UnityEngine.UI.Image dañoRojo;
    [SerializeField] private int vidaUmbral = 2; 
    [SerializeField] private float intensidadMaxima = 0.15f; 
    [SerializeField] private float frecuencia = 2f;
    [SerializeField] private AudioSource audioLatido;
    [SerializeField] private AudioClip latidoAudio;

    public GameObject espada;
    public static ControlPersonaje Ren;

    [Header("Valores Vida")]
    [SerializeField] public int vidaInicial = 5;
    [SerializeField] float duracionInvulnerabilidad = 1f;
    public bool jugadorInvulnerable = false;
    public int dañoRecibido = 1;

    [Header("Corazones del UI")]
    public GameObject Corazon1;
    public GameObject Corazon2;
    public GameObject Corazon3;
    public GameObject Corazon4;
    public GameObject Corazon5;

    public int contador = 1;
    public bool activarEspecialTercieario;

    [SerializeField] private float tiempoQuieto = 1f;
    public bool desactivar;

    [Header("Cantidad de Enemigos")]
    public int ContadorEnemigos=0;
    public string ContadorEnemigosString="0";

    [Header("Movimiento")]
    public int velocidadMovimiento = 5;
    private void Awake()
    {
        if (Ren == null)
        {
            Ren = this;
        }
    }

    void Start()
    {
        desactivar = true;

        ren = GetComponent<Rigidbody2D>();
        animRen = GetComponent<Animator>();
        animRen.SetBool("SeMueve", false);

        if (canvasDerrota != null)
            canvasDerrota.SetActive(false);
        ContadorEnemigosString = ContadorEnemigos.ToString();
        StartCoroutine(ActivarMovimientoDespues());
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x < transform.position.x)
        {
            sr.flipX = false;
            boxRenDerechaAtaque.enabled = false;
            boxRenIzquierdaAtaque.enabled = true;
        }
        else
        {
            sr.flipX = true;
            boxRenDerechaAtaque.enabled = true;
            boxRenIzquierdaAtaque.enabled = false;
        }


        if (desactivar) return;

        if (vidaInicial <= 2)
        {
            float ratioVida = Mathf.Clamp01(2 - vidaInicial);
            float alphaMax = Mathf.Lerp(0.05f, 0.15f, ratioVida);
            float freq = Mathf.Lerp(1f, 2f, ratioVida);
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * Mathf.PI * freq)) * alphaMax;
            Color c = dañoRojo.color;
            c.a = alpha;
            dañoRojo.color = c;

            if (!audioLatido.isPlaying)
            {
                audioLatido.clip = latidoAudio;
                audioLatido.loop = true;
                audioLatido.Play();
            }

            if (vidaInicial == 1)
            {
                audioLatido.pitch = 2f;  
            }
            else
            {
                audioLatido.pitch = 1f;  
            }
        }
        else
        {
            Color c = dañoRojo.color;
            c.a = 0;
            dañoRojo.color = c;

            if (audioLatido.isPlaying)
                audioLatido.Stop();
        }
        audioLatido.mute = (Time.timeScale == 0f);


        movimiento();
    }

    void movimiento()
    {
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {

            horizontal = Input.GetAxisRaw("Horizontal");
            ren.linearVelocity = new Vector2(horizontal * velocidadMovimiento, ren.linearVelocity.y);

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {

            vertical = Input.GetAxisRaw("Vertical");
            ren.linearVelocity = new Vector2(ren.linearVelocity.x, vertical * velocidadMovimiento);


        }

        bool Moviendose = (horizontal != 0 || vertical != 0);
        animRen.SetBool("SeMueve", Moviendose);

        if (Moviendose)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }


}
IEnumerator ActivarMovimientoDespues()
    {
        ren.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(tiempoQuieto);
        desactivar = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            if (jugadorInvulnerable) return;
            vidaInicial--;
            dañoRecibido++;
            audioSource.PlayOneShot(dañoRecibidoAudio);
            camaraShake.Shake();

            ActualizarCorazones();
            perderVida();

            animRen.SetTrigger("HeridoP");
            StartCoroutine(Invulnerabilidad());          
        }

    }
    public void perderVida()
    {
        if (vidaInicial <= 0)
        {
            audioSource.Stop();

            SlieControl.MutearTodosSlimes(true);
            if (canvasGameplay != null)
                canvasGameplay.SetActive(false);

            if (canvasDerrota != null)
                canvasDerrota.SetActive(true);

            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (vidaInicial == 2)
        {
            activarEspecialTercieario = true;
        }
    }
    private IEnumerator Invulnerabilidad()
 
    {
        jugadorInvulnerable = true;
        yield return new WaitForSeconds(duracionInvulnerabilidad);
        jugadorInvulnerable = false;
    }
    public void ActualizarCorazones()
    {
        Corazon1.SetActive(vidaInicial >= 1);
        Corazon2.SetActive(vidaInicial >= 2);
        Corazon3.SetActive(vidaInicial >= 3);
        Corazon4.SetActive(vidaInicial >= 4);
        Corazon5.SetActive(vidaInicial >= 5);
    }
    public void GanarVida()
    {
            vidaInicial = 5;
            ActualizarCorazones();
    }
    public void AumentarContadorEnemigos()
    {
        ContadorEnemigos++;
        ContadorEnemigosString = ContadorEnemigos.ToString();
    }
}