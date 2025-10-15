using UnityEngine;
using System.Collections;

public class AtaqueDistanciaSlime : MonoBehaviour
{
    public CircleCollider2D deteccionEnemigo;
    public GameObject balaEnemiga;
    public Transform puntoAparicion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    void TiempoDeAtaqueSlime()
    {
        GameObject balNormal = Instantiate(balaEnemiga, puntoAparicion.position, puntoAparicion.rotation);
        Destroy(balNormal, 3f);

    }
}
