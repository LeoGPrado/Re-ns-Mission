using UnityEngine;
using System.Collections;
using UnityEditor;

public class ArcoControlador : MonoBehaviour
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
    private bool puedeDisparar = true;
    public float timer = 0;
    [SerializeField] private bool ultTriggered = false;
    private bool isOnUltimate = false;

    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

    private void Start()
    {
        //FlipArco = transform.parent;
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipArco = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje=protagonista.GetComponent<SpriteRenderer>();



        if (mousePos.x < transform.position.x)
        {
            arco.flipX = true;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            arco.transform.localPosition = FlipArco.localPosition;
            //arco.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            arco.flipX = false;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            arco.transform.localPosition = FlipArco.localPosition;
            //arco.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (!isOnUltimate)
        {
            if (Input.GetMouseButtonDown(0) && puedeDisparar)
            {
                StartCoroutine(DisparoConCooldown());
            }
        }
        else if (isOnUltimate)
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(DisparoConCooldown());
                
            }
        }



        /*if (Input.GetMouseButtonDown(1))
        {
            DisparoEspecial();
        }*/

        if (Input.GetMouseButtonDown(1) && medidor.canUseUltimate)
        {         
            StartCoroutine(DisparoEspecial());
            StartCoroutine(ManaObtain());
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

    IEnumerator CooldownUltBurst()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(0.2f);

        DisparoNormal();

        yield return new WaitForSeconds(ultcooldown);
        puedeDisparar = true;
    }

    IEnumerator ManaObtain()
    {
        playerEC.canObtainMana = false;

        yield return new WaitForSeconds(2f);
        playerEC.canObtainMana = true;
    }

    void DisparoNormal()
    {

        GameObject balNormal = Instantiate(balaNormal, puntoAparicion.position, puntoAparicion.rotation);
        SpriteRenderer srBala = balNormal.GetComponentInChildren<SpriteRenderer>();

       

        Destroy(balNormal, 3f);
    }




    IEnumerator DisparoEspecial()
    {
        isOnUltimate = true;
        medidor.canUseUltimate = false;
        playerEC.Ultimate();

        int cantidadDeFlechas = 140;      
        float intervalo = 0.01f;         

        for (int i = 0; i < cantidadDeFlechas; i++)
        {
            DisparoNormal();           
            yield return new WaitForSeconds(intervalo);
        }

        isOnUltimate = false;
    }


}
