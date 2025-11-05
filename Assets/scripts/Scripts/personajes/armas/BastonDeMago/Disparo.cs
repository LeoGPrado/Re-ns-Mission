using UnityEngine;
using System.Collections;
public class Disparo : MonoBehaviour
{
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicion;
    [SerializeField] private MedidorArteEspecial medidor;



    public Transform FlipBaston;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer baston;

    public float cooldown = 0.5f;
    private bool puedeDisparar = true;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipBaston = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();


        if (mousePos.x < transform.position.x)
        {
            baston.flipX = true;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            baston.transform.localPosition = FlipBaston.localPosition;
            //baston.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            baston.flipX = false;
            Vector3 pos = puntoAparicion.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicion.localPosition = pos;
            baston.transform.localPosition = FlipBaston.localPosition;
            //baston.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0) && puedeDisparar)
        {
            StartCoroutine(DisparoConCooldown());
        }

        if (medidor.canUseUltimate)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DisparoEspecial();
            }
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
        SpriteRenderer srBala = balNormal.GetComponent<SpriteRenderer>();

        if (personaje.flipX)
        {
            srBala.flipX = true;
        }




        Destroy(balNormal, 3f);

    }

    void DisparoEspecial()
    {
        if (medidor.canUseUltimate)
        {
            GameObject bala = Instantiate(balaEspecialPrefab, puntoAparicion.position, puntoAparicion.rotation);
            Destroy(bala, 1f);
            medidor.canUseUltimate = false;
        }
        

    }
}
