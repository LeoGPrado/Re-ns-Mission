using UnityEngine;

public class NuevoEspadaControl : MonoBehaviour
{

    public Transform FlipEspada;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Espada;

    private void Start()
    {

    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipEspada = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            Espada.flipX = true;

            Espada.transform.localPosition = FlipEspada.localPosition;
            Espada.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Espada.flipX = false;

            Espada.transform.localPosition = FlipEspada.localPosition;
            Espada.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButtonDown(1))
        {

        }
    }
}
