using UnityEngine;
using System.Collections;

public class ControlPersonaje : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private GameObject canvasDerrota;
    [SerializeField] private GameObject canvasGameplay;
    [SerializeField] Rigidbody2D ren;
    [SerializeField] Animator animRen;

    public BoxCollider2D DetectarEnemigo;
    public Transform puntoDeAtaque;


    [SerializeField] SpriteRenderer sr;
    [SerializeField] private BoxCollider2D boxRenDerechaAtaque;
    [SerializeField] private BoxCollider2D boxRenIzquierdaAtaque;


    public GameObject espada;
    public static ControlPersonaje Ren;

    [Header("Valores Vida")]
    [SerializeField] public int vidaInicial = 5;
    [SerializeField] float duracionInvulnerabilidad = 1f;
    public bool jugadorInvulnerable = false;

    [Header("Corazones del UI")]
    public GameObject Corazon1;
    public GameObject Corazon2;
    public GameObject Corazon3;
    public GameObject Corazon4;
    public GameObject Corazon5;

    public int contador = 1;


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
            if (canvasGameplay != null)
                canvasGameplay.SetActive(false);

            if (canvasDerrota != null)
                canvasDerrota.SetActive(true);

            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private IEnumerator Invulnerabilidad()
 
    {
        jugadorInvulnerable = true;
        yield return new WaitForSeconds(duracionInvulnerabilidad);
        jugadorInvulnerable = false;
    }
    //private void activar()
    //{
    //    desactivar = false;
    //}

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
