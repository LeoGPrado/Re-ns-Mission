using UnityEngine;

public class NuevoEspadaControl : MonoBehaviour
{

    public Transform FlipEspada;


    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer Espada;
    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

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

            Espada.transform.localPosition = FlipEspada.localPosition + new Vector3(0f, 0f, 0f);
            Espada.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            Espada.flipX = false;

            Espada.transform.localPosition = FlipEspada.localPosition + new Vector3(0f, 0f, 0f);
            Espada.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        if (Input.GetMouseButtonDown(1))
        {
            medidor.canUseUltimate = false;
            playerEC.Ultimate();
        }
    }
}
