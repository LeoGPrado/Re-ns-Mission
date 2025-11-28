using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;

public class BalaEnemigoSlime : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    public float FuerzaRetroceso = 2;

    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("protagonista");
        if (Player != null)
        {
            target = Player.transform;
            Vector2 direction = (target.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().linearVelocity = direction * speed;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "protagonista")
        {
            Destroy(gameObject);
        }
    }
}
