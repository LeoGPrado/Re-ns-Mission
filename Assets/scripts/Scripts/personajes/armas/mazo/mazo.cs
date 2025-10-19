using UnityEngine;
using System.Collections;
using System.Threading;

public class mazo : MonoBehaviour
{
    public GameObject Mazo;
    public Transform puntoAparicion;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Maza;

    [SerializeField] Animator ImpoctoArma;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Tiempo=Time.deltaTime;
        
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x > transform.position.x)
        {

            Maza.transform.localPosition = puntoAparicion.localPosition;
            Maza.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Maza.transform.localPosition = puntoAparicion.localPosition;
            Maza.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }


        if (Input.GetMouseButtonDown(0))
        {

                StartCoroutine(ataqueCuerpoCuerpo());

     
        }

        if (Input.GetMouseButtonDown(1))
        {

                StartCoroutine(ataqueCuerpoCuerpoEspecial());

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
        if (Mazo.transform.localScale.x <= 4) {

            Mazo.GetComponent<Transform>().localScale = new Vector2(Mazo.transform.localScale.x+1, Mazo.transform.localScale.y+1);

        }
        //Mazo.GetComponent<Transform>().localScale = new Vector2(Mazo.transform.localScale.x*2, Mazo.transform.localScale.y*2);
        ImpoctoArma.SetBool("ImpactoP", true);

        yield return new WaitForSeconds(0.5f);

        ImpoctoArma.SetBool("ImpactoP", false);

    }

}
