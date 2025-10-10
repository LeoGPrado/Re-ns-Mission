using UnityEngine;

public class repeler : MonoBehaviour
{
    public bool desactivar;
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if (desactivar) return;
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Enemigo")
        {
            desactivar = true;
            Vector2 direction = collision.contacts[0].normal;
            rb.AddForce(direction * 10, ForceMode2D.Impulse);
            Invoke(nameof(activar), 0.5f);
        }*/
        desactivar = true;
        Vector2 direction = collision.contacts[0].normal;
        rb.AddForce(direction * 10, ForceMode2D.Impulse);
        Invoke(nameof(activar), 0.5f);
    }

    private void activar()
    {
        desactivar = false;
    }

}
