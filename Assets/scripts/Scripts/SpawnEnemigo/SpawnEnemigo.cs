using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{

    [SerializeField] GameObject enemigo;

    [SerializeField] GameObject puntoAparicion;
    [SerializeField] float TiempoAparicion = 3;

    //[SerializeField] BoxCollider2D jugador;

    void Start()
    {
        InvokeRepeating(nameof(Enemigo), 1f, TiempoAparicion);
        //jugador = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Enemigo()
    {
        Instantiate(enemigo, puntoAparicion.transform.position, Quaternion.identity);
    }
}
