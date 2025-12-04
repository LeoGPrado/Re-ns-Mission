using UnityEngine;
using System.Collections;

public class cuchillasControl : MonoBehaviour
{
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicion;


    public Transform FlipCuchillas;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer cuchillas;

    public static cuchillasControl controlCuchilla;

    public float cooldown = 0.5f;
    private bool puedeDisparar = true;
    public bool ActivarEspacialCuchilla=false;


    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

    private void Awake()
    {
        if(controlCuchilla == null)
        {
            controlCuchilla = this;
        }
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipCuchillas = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();

        if (mousePos.x < transform.position.x)
        {
            cuchillas.flipX = true;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicion.localPosition = -pos;
            cuchillas.transform.localPosition = FlipCuchillas.localPosition;
            //cuchillas.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            cuchillas.flipX = false;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicion.localPosition = -pos;
            cuchillas.transform.localPosition = FlipCuchillas.localPosition;
            //cuchillas.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0) && puedeDisparar)
        {
            StartCoroutine(DisparoConCooldown());
        }

        //if (Input.GetMouseButtonDown(1)&& ActivarEspacialCuchilla)
        if (Input.GetMouseButtonDown(1) && medidor.canUseUltimate)
        {
            print("Entrando en medidor");
            DisparoEspecial();
        }
    }

    IEnumerator DisparoConCooldown()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(0.2f);

        DisparoNormal();

        yield return new WaitForSeconds(cooldown);
        puedeDisparar = true;
    }

    void DisparoNormal()
    {

        GameObject balNormal = Instantiate(balaNormal, puntoAparicion.position, puntoAparicion.rotation);
        Destroy(balNormal, 3f);

    }

    void DisparoEspecial()
    {
        playerEC.Ultimate();

        GameObject bala = Instantiate(balaEspecialPrefab, puntoAparicion.position, puntoAparicion.rotation);
        ActivarEspacialCuchilla = false;
        Destroy(bala, 1f);
        medidor.canUseUltimate = false;

    }
}
