using UnityEngine;
using System.Collections;

public class PescadoControl : MonoBehaviour
{
    public Transform FlipPescado;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Pescado;

    private void Start()
    {

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
    }
}
