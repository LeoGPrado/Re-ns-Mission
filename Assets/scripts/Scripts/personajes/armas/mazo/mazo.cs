using UnityEngine;
using System.Collections;
using System.Threading;

public class mazo : MonoBehaviour
{
    public Transform FlipMazo;


    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Mazo;

    private void Start()
    {

    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipMazo = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            Mazo.flipX = true;

            Mazo.transform.localPosition = FlipMazo.localPosition;
            //Mazo.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Mazo.flipX = false;

            Mazo.transform.localPosition = FlipMazo.localPosition;
            //Mazo.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButtonDown(1))
        {

        }
    }

}
