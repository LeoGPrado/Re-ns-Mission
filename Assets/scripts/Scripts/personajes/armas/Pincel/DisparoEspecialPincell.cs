using UnityEngine;

public class DisparoEspecialPincell : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform enemigo;
    [SerializeField] Animator ImpoctoArma;

    void Start()
    {
        enemigo = BuscarEnemigoMasCercano();

    }

    void Update()
    {
        if (enemigo == null) return;


        transform.position = Vector2.MoveTowards(transform.position, enemigo.position, velocidad * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            if (ImpoctoArma == null)
            {
                if (collision.TryGetComponent<EsqueletoControl>(out var esqueleto))
                {
                    esqueleto.controlVida();
                }
                else if (collision.TryGetComponent<SlieControl>(out var slime))
                {
                    slime.controlVida();
                }
                Destroy(gameObject);
            }
            else
            {
                ImpoctoArma.SetTrigger("ImpactoP");
                GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                Destroy(collision.gameObject);       
            }
        }

    }

    Transform BuscarEnemigoMasCercano()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        Transform enemigoCercano = null;
        float distanciaMinima = Mathf.Infinity;
        Vector3 posicionActual = transform.position;

        foreach (GameObject enemigo in enemigos)
        {
            float dist = Vector3.Distance(enemigo.transform.position, posicionActual);

            if (dist < distanciaMinima)
            {
                distanciaMinima = dist;
                enemigoCercano = enemigo.transform;
            }
        }

        return enemigoCercano;
    }
}
