using UnityEngine;
using System.Collections;

public class TutorialPescado : MonoBehaviour
{
    public Transform FlipPescado;


    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Pescado;
    public GameObject Especial;

    private void Start()
    {
        Animator animacionEspecial = Especial.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipPescado = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            Pescado.flipX = true;

            Pescado.transform.localPosition = FlipPescado.localPosition;
            Pescado.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Pescado.flipX = false;

            Pescado.transform.localPosition = FlipPescado.localPosition;
            Pescado.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(TiempoEspecial());
        }
    }

    IEnumerator TiempoEspecial()
    {
        Especial.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Especial.SetActive(false);
    }
}
