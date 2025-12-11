using UnityEngine;

public class FireWallMovemnt : MonoBehaviour
{

    public float speed = 5f;
    private Vector3 direccion;

    public void Init(Vector3 direction)
    {
        direccion = direction;
    }

    void Update()
    {
        transform.position += direccion * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
        }
    }

}
