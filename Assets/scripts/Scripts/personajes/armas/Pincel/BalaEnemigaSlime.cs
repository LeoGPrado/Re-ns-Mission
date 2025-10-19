using UnityEngine;

public class BalaEnemigaSlime : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform ren;

    Vector2 direccion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("protagonista");

        if (obj)
        {
            direccion = (obj.transform.position - transform.position).normalized;

        }

    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(direccion * velocidad * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, ren.position, velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="protagonista")
        {
            ControlPersonaje.Ren.perderVida();
            Destroy(gameObject);
        }

    }
}
