using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener entrada del teclado (WASD o flechas)
        float moveX = Input.GetAxisRaw("Horizontal");  
        float moveY = Input.GetAxisRaw("Vertical");    

        // Crear vector de movimiento
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Aplicar movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
