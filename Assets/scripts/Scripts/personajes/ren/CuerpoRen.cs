using UnityEngine;

public class DetectarGolpeCuerpo : MonoBehaviour
{
    private RepelerYDetener repeler;

    void Start()
    {
        // Busca el script en el padre
        repeler = GetComponentInParent<RepelerYDetener>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo notifica si choca con un enemigo
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            repeler.Golpeado(collision);
        }
    }
}