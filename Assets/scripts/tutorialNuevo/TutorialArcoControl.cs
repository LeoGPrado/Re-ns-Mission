using UnityEngine;
using System.Collections;

public class TutorialArcoControl : MonoBehaviour
{
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicion;


    public Transform FlipArco;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer arco;

    public float cooldown = 2f;
    public float ultcooldown = 1f;
    private bool puedeUsarUlti = true;
    private bool puedeDisparar = true;
    public float timer = 0;
    [SerializeField] private bool ultTriggered = false;


    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

    public static TutorialArcoControl TArcoEspecial;
    public bool AtqueEspecial = false;

    public void Awake()
    {
        if (TArcoEspecial == null)
        {
            TArcoEspecial = this;
        }

    }



    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipArco = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            arco.flipX = true;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            arco.transform.localPosition = FlipArco.localPosition;

        }
        else
        {
            arco.flipX = false;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            arco.transform.localPosition = FlipArco.localPosition;

        }

        if (Input.GetMouseButtonDown(0) && puedeDisparar)
        {
            StartCoroutine(DisparoConCooldown());
        }


        if (Input.GetMouseButtonDown(1) && AtqueEspecial == true && puedeUsarUlti)
        {
            StartCoroutine(DisparoEspecial());
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
        SpriteRenderer srBala = balNormal.GetComponentInChildren<SpriteRenderer>();



        Destroy(balNormal, 3f);
    }


    void DisparoEspecialUnitario()
    {
        GameObject balaEsp = Instantiate(balaEspecialPrefab, puntoAparicion.position, puntoAparicion.rotation);
        Destroy(balaEsp, 3f);

    }


    IEnumerator DisparoEspecial()
    {
        puedeUsarUlti = false;
        int cantidadDeFlechas = 140;
        float intervalo = 0.01f;

        for (int i = 0; i < cantidadDeFlechas; i++)
        {

            DisparoEspecialUnitario();
            yield return new WaitForSeconds(intervalo);
        }
        yield return new WaitForSeconds(ultcooldown);
        puedeUsarUlti = true;
    }
}
