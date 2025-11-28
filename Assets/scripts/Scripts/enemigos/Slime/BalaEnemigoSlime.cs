using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;

public class BalaEnemigoSlime : MonoBehaviour
{
    [SerializeField] Rigidbody2D balaEnemigo;
    public int velocidadMovimiento = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        balaEnemigo=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        balaEnemigo.linearVelocity = new Vector2(velocidadMovimiento*1, balaEnemigo.linearVelocity.y);
    }
}
