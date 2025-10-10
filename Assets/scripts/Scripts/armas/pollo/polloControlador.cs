using UnityEngine;
using System.Collections;

public class polloControlador : MonoBehaviour
{
    public GameObject Pollo;
    public Transform puntoAparicion;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer pollo;

    [SerializeField] Animator ImpoctoArma;

    private float tiempoUltimoAtaque = 0f;
    private float tiempoEspera = 3f;

    public GameObject ondaExplosiva;


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

            Pollo.transform.localPosition = puntoAparicion.localPosition;
            Pollo.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Pollo.transform.localPosition = puntoAparicion.localPosition;
            Pollo.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
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
        ondaExplosiva.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(DesactivarAtaqueCuerpoCuerpoEspecial());
    }

    IEnumerator DesactivarAtaqueCuerpoCuerpoEspecial()
    {
        ondaExplosiva.SetActive(false);
        return null;
    }
}
