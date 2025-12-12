using UnityEngine;

public class destruirBala : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigos")
        {
            Destroy(gameObject);
        }
    }
}
