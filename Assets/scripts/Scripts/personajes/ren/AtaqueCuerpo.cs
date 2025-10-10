using UnityEngine;
using System.Collections;

public class AtaqueCuerpo : MonoBehaviour
{

    [SerializeField] Animator ImpoctoArma;

    private Camera cam;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Seguir al puntero
        Vector3 mousePos = Input.mousePosition;// se toma la direccion del puntero del raton


        float distanciaCamaraAlMazo = Mathf.Abs(cam.transform.position.z - transform.position.z);
        mousePos.z = distanciaCamaraAlMazo;

        // 3) Convertimos las coordenadas de pantalla a coordenadas del mundo
        Vector3 mouseWorld = cam.ScreenToWorldPoint(mousePos);

        // 4) (opcional) Aseguramos que el mouseWorld esté en el mismo plano Z que el mazo
        mouseWorld.z = transform.position.z;

        // 5) Calculamos la dirección desde el mazo hacia el puntero
        Vector2 direccion = mouseWorld - transform.position;

        // 6) Calculamos el ángulo en grados usando Atan2 (devuelve radianes)
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // 7) Aplicamos la rotación al mazo (solo en Z porque es 2D)
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);


        if (Input.GetMouseButtonDown(0))
        {
            //ImpoctoArma.SetBool("Impacto", true);
            StartCoroutine(ataqueCuerpoCuerpo());


        }
    }
    

    IEnumerator ataqueCuerpoCuerpo()
    {
        ImpoctoArma.SetBool("ImpactoP", true);

        yield return new WaitForSeconds(0.5f);

        ImpoctoArma.SetBool("ImpactoP", false);

    }
}
