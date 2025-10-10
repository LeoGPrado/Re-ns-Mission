using UnityEngine;

public class AtaqueCuerpoCuerpo : MonoBehaviour
{
    [SerializeField] GameObject ataquePrefab;      // prefab del ataque
    [SerializeField] Transform puntoAparicion;     // donde aparece el ataque
    [SerializeField] float duracionAtaque = 0.5f;  // duración antes de desaparecer

    GameObject enemigo;

    void Start()
    {
        // Busca al enemigo (asegúrate de que tiene el tag "Enemigo")
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

        // Calcular dirección hacia el enemigo
        Vector2 direccion = enemigo.transform.position - puntoAparicion.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciar el ataque como hijo del punto de aparición
        GameObject ataque = Instantiate(
            ataquePrefab,
            puntoAparicion.position,
            Quaternion.Euler(0f, 0f, angulo),
            puntoAparicion // ?? esto lo pega al jugador
        );

        // Asegurar que esté centrado en el punto de aparición
        ataque.transform.localPosition = Vector3.zero;

        // Destruir tras X segundos
        Destroy(ataque, duracionAtaque);
    }
}
