using UnityEngine;
using System.Collections;

public class PescadoControl : MonoBehaviour
{
    public GameObject Pescado;
    public Transform puntoAparicion;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer pescado;

    [SerializeField] Animator ImpoctoArma;

    private float tiempoUltimoAtaque = 0f;
    private float tiempoEspera = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiempoUltimoAtaque = Time.time;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x > transform.position.x)
        {

            Pescado.transform.localPosition = puntoAparicion.localPosition;
            Pescado.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Pescado.transform.localPosition = puntoAparicion.localPosition;
            Pescado.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }


        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time - tiempoUltimoAtaque >= tiempoEspera)
            {
                StartCoroutine(ataqueCuerpoCuerpo());
                tiempoUltimoAtaque = Time.time;
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - tiempoUltimoAtaque >= tiempoEspera)
            {
                StartCoroutine(ataqueCuerpoCuerpoEspecial());
                tiempoUltimoAtaque = Time.time;
            }
        }
    }

    IEnumerator ataqueCuerpoCuerpo()
    {
        ImpoctoArma.SetBool("ImpactoP", true);

        yield return new WaitForSeconds(0.5f);

        ImpoctoArma.SetBool("ImpactoP", false);

    }

    IEnumerator ataqueCuerpoCuerpoEspecial()
    {

        return null;
    }
}
