using System.Collections;
using UnityEditor;
using UnityEngine;

public class PescadoControl : MonoBehaviour
{
    public Transform FlipPescado;
    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

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

        if (Input.GetMouseButtonDown(1) && medidor.canUseUltimate)
        {
            playerEC.Ultimate();
            //MurodeFuego();
        }
    }
}
