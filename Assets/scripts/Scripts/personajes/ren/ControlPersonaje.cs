using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{

    [SerializeField] Rigidbody2D ren;
    public BoxCollider2D DetectarEnemigo;
    public Transform puntoDeAtaque;


    [SerializeField] SpriteRenderer sr;

    public GameObject espada;

    //vida
    [SerializeField] public int vidaInicial = 10;



    public bool desactivar;

    //movimiento
    public int velocidadMovimiento = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ren = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if (mousePos.x < transform.position.x)
        {
            sr.flipX = true;   
            Vector3 pos = puntoDeAtaque.localPosition;
            pos.x = -Mathf.Abs(pos.x);  
            puntoDeAtaque.localPosition = pos;
            espada.transform.localPosition = puntoDeAtaque.localPosition;
            espada.GetComponent<SpriteRenderer>().flipX = sr.flipX;
        }
        else
        {
            sr.flipX = false;  
            Vector3 pos = puntoDeAtaque.localPosition;
            pos.x = Mathf.Abs(pos.x);  
            puntoDeAtaque.localPosition = pos;
            espada.transform.localPosition = puntoDeAtaque.localPosition;
            espada.GetComponent<SpriteRenderer>().flipX = sr.flipX;
        }


        if (desactivar) return;

        movimiento();
    }

    void movimiento()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            ren.linearVelocity = new Vector2(horizontal * velocidadMovimiento, ren.linearVelocity.y);

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {

            float vertical = Input.GetAxisRaw("Vertical");
            ren.linearVelocity = new Vector2(ren.linearVelocity.x, vertical * velocidadMovimiento);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            desactivar = true;
            Vector2 direction = collision.contacts[0].normal;
            ren.AddForce(direction * 5, ForceMode2D.Impulse);
            vidaInicial--;
            if (vidaInicial == 0)
            {
                Destroy(gameObject);
            }

            Invoke(nameof(activar), 0.5f);
        }
        
    }

    private void activar()
    {
        desactivar = false;
    }
}
