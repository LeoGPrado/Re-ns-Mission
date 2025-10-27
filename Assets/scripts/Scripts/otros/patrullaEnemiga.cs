using UnityEngine;

public class patrullaEnemiga : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemigo1;
    public int velocidadMovimiento = 5;
    public int direccio = 1;

    public bool horizontalActivado = true;

    public bool horizontal = false;
    public bool vertical = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        if (horizontalActivado)
        {
            if (horizontal == false)
            {
                enemigo1.linearVelocity = new Vector2(direccio * velocidadMovimiento, enemigo1.linearVelocity.y);
            }
            else
            {
                enemigo1.linearVelocity = new Vector2((direccio * -1) * velocidadMovimiento, enemigo1.linearVelocity.y);
            }
        }
        else
        {
            if (vertical == false)
            {
                enemigo1.linearVelocity = new Vector2(enemigo1.linearVelocity.x, direccio * velocidadMovimiento);

            }
            else
            {
                enemigo1.linearVelocity = new Vector2(enemigo1.linearVelocity.x, (direccio*-1) * velocidadMovimiento);
            }
        }
    }
}
