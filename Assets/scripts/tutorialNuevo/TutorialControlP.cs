using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialControlP : MonoBehaviour
{
    [SerializeField] Rigidbody2D ren;
    [SerializeField] Animator animRen;
    [SerializeField] SpriteRenderer srRenTutorial;
    public int velocidadMovimiento = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ren = GetComponent<Rigidbody2D>();
        animRen = GetComponent<Animator>();
        srRenTutorial=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPersonaje();
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
        animRen.SetBool("ActivarCaminarP", Moviendose);
    }

    void FlipPersonaje()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);




        if (mousePos.x < transform.position.x)
        {
            srRenTutorial.flipX = false;

        }
        else
        {
            srRenTutorial.flipX = true;

        }

    }
}
