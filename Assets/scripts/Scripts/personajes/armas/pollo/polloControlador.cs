using UnityEngine;
using System.Collections;

public class polloControlador : MonoBehaviour
{
    public Transform FlipPollo;


    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Pollo;

    private void Start()
    {

    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipPollo = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            Pollo.flipX = true;

            Pollo.transform.localPosition = FlipPollo.localPosition;
            Pollo.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Pollo.flipX = false;

            Pollo.transform.localPosition = FlipPollo.localPosition;
            Pollo.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButtonDown(1))
        {

        }
    }
}
