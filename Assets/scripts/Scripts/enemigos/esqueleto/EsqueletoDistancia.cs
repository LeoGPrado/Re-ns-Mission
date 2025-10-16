using UnityEngine;

public class EsqueletoDistancia : MonoBehaviour
{
    public CircleCollider2D deteccionEnemigo;
    public GameObject balaEnemiga;
    public Transform puntoAparicion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            InvokeRepeating("TiempoDeAtaqueSlime", 1f, 2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            CancelInvoke("TiempoDeAtaqueSlime");
        }

    }
    private void TiempoDeAtaqueSlime()
    {
        GameObject balNormal = Instantiate(balaEnemiga, puntoAparicion.position, puntoAparicion.rotation);
        Destroy(balNormal, 3f);
    }
}
