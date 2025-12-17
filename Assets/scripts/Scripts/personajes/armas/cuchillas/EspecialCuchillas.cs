using UnityEngine;
using UnityEngine.AI;

public class EspecialCuchillas : MonoBehaviour
{
    public GameObject ZonaHelada;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            Instantiate(ZonaHelada, transform.position, Quaternion.identity);
        }
    }
}
