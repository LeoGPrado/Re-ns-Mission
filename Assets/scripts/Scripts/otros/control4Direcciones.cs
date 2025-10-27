using UnityEngine;

public class control4Direcciones : MonoBehaviour
{

    [SerializeField] Rigidbody2D Noranon;
    public int velocidadMovimiento = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Noranon = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        Vector2 direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direccion = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direccion = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            direccion = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direccion = Vector2.down;
        }


        Noranon.linearVelocity = direccion * velocidadMovimiento;
        




    }
}
