using UnityEngine;

public class MovimientoFlecha : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float speed = 4;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(speed, rb2d.linearVelocity.y);
    }
}
