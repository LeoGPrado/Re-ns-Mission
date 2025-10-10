  using UnityEngine;

public class ataqueCuerpoCuerpo : MonoBehaviour
{

    [SerializeField] GameObject ataqueCaCAlto;

    public Transform puntoAparicion;
    
    [SerializeField] float TiempoAparicion = 1;

    GameObject ataqueCaC;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Invoke(nameof(ataque_CaCAlto), 0f);

        }
    }
    void ataque_CaCAlto()
    {
        /*GameObject ataqueCuerpo = Instantiate(ataqueCaCAlto);
        ataqueCuerpo.transform.SetParent(puntoAparicion.transform, false);
        ataqueCuerpo.transform.localPosition = Vector3.zero;*/

        GameObject ataqueCuerpo = Instantiate(ataqueCaCAlto, puntoAparicion.position, puntoAparicion.rotation);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // mantener en 2D

        // Calcular dirección jugador → mouse
        Vector2 direccion = (mousePos - transform.position).normalized;

        // Calcular el ángulo en grados
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        ataqueCuerpo.transform.rotation = Quaternion.Euler(0, 0, angulo);

        ataqueCuerpo.transform.SetParent(transform);


        Destroy(ataqueCuerpo, 0.5f);
    }
}
