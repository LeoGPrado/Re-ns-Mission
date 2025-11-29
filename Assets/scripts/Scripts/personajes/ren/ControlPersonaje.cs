using UnityEngine;
using System.Collections;

public class ControlPersonaje : MonoBehaviour
{
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

    //vida
    [SerializeField] public int vidaInicial = 5;
    [SerializeField] float duracionInvulnerabilidad = 1f;
    public bool jugadorInvulnerable = false;

    //corazones de vida
    public GameObject Corazon1;
    public GameObject Corazon2;
    public GameObject Corazon3;
    public GameObject Corazon4;
    public GameObject Corazon5;

    public int contador = 1;



    public bool desactivar;

    //movimiento
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
        ren = GetComponent<Rigidbody2D>();
        animRen = GetComponent<Animator>();

        if (canvasDerrota != null)
            canvasDerrota.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (contador > 5)
        {
            contador = 5;
        }


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            if (jugadorInvulnerable) return;

            if (contador == 1)
            {
                Corazon1.SetActive(false);
                contador++;

            }
            else if (contador == 2)
            {
                Corazon2.SetActive(false);
                contador++;

            }
            else if (contador == 3)
            {
                Corazon3.SetActive(false);
                contador++;

            }
            else if (contador == 4)
            {
                Corazon4.SetActive(false);
                contador++;

            }
            else if (contador == 5)
            {
                Corazon5.SetActive(false);
                contador++;
            }
            perderVida();

            animRen.SetTrigger("HeridoP");

            StartCoroutine(Invulnerabilidad());

        }

    }

    public void perderVida()
    {
        vidaInicial--;
        if (vidaInicial == 0)
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
    private void activar()
    {
        desactivar = false;
    }
}
