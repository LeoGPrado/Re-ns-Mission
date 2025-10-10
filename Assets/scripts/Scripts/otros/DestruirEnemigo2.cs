using UnityEngine;

public class AtaqueCuerpoCuerpo : MonoBehaviour
{
    [SerializeField] GameObject ataquePrefab;      // prefab del ataque
    [SerializeField] Transform puntoAparicion;     // donde aparece el ataque
    [SerializeField] float duracionAtaque = 0.5f;  // duraci�n antes de desaparecer

    GameObject enemigo;

    void Start()
    {
        // Busca al enemigo (aseg�rate de que tiene el tag "Enemigo")
        enemigo = GameObject.FindWithTag("Enemigo");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GenerarAtaque();
        }
    }

    void GenerarAtaque()
    {
        if (enemigo == null) return;

        // Calcular direcci�n hacia el enemigo
        Vector2 direccion = enemigo.transform.position - puntoAparicion.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciar el ataque como hijo del punto de aparici�n
        GameObject ataque = Instantiate(
            ataquePrefab,
            puntoAparicion.position,
            Quaternion.Euler(0f, 0f, angulo),
            puntoAparicion // ?? esto lo pega al jugador
        );

        // Asegurar que est� centrado en el punto de aparici�n
        ataque.transform.localPosition = Vector3.zero;

        // Destruir tras X segundos
        Destroy(ataque, duracionAtaque);
    }
}
