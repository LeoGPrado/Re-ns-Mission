using UnityEngine;

public class DestruirV2 : MonoBehaviour
{
    private bool puedeDestruir = false;

    public void ActivarDestruccion()
    {
        puedeDestruir = true;
    }

    public void DesactivarDestruccion()
    {
        puedeDestruir = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!puedeDestruir) return;

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }
}
