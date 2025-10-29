using UnityEngine;

public class DestruirV2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            Destroy(collision.gameObject);        
        }
    }
}
