using UnityEngine;
using System.Collections;

public class pincelControl : MonoBehaviour
{
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicionBala;
    [SerializeField] PostProcessingTest postProcessing;


    public Transform FlipPincel;
    public float velocidadBala = 20f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer pincel;



    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject prota = GameObject.Find("PuntoAtaque");

        FlipPincel = prota.GetComponent<Transform>();

        GameObject protagonista = GameObject.Find("personaje");

        personaje = protagonista.GetComponent<SpriteRenderer>();


        if (mousePos.x < transform.position.x)
        {
            pincel.flipX = true;
            Vector3 pos = puntoAparicionBala.localPosition;
            pos.x = -Mathf.Abs(pos.x);
            puntoAparicionBala.localPosition = pos;
            pincel.transform.localPosition = FlipPincel.localPosition;
            pincel.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }
        else
        {
            pincel.flipX = false;
            Vector3 pos = puntoAparicionBala.localPosition;
            pos.x = Mathf.Abs(pos.x);
            puntoAparicionBala.localPosition = pos;
            pincel.transform.localPosition = FlipPincel.localPosition;
            pincel.GetComponent<SpriteRenderer>().flipX = personaje.flipX;
        }

        if (Input.GetMouseButtonDown(0))
        {
            DisparoNormal();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DisparoEspecial();
        }
    }

    void DisparoNormal()
    {

        GameObject balNormal = Instantiate(balaNormal, puntoAparicionBala.position, puntoAparicionBala.rotation);
        Destroy(balNormal, 3f);

    }

    void DisparoEspecial()
    {

        GameObject bala = Instantiate(balaEspecialPrefab, puntoAparicionBala.position, puntoAparicionBala.rotation);
        Destroy(bala, 1f);

        if (postProcessing != null)
        {
            postProcessing.SaturacionGradual(-100f, 0.5f);
            StartCoroutine(RestaurarDelay(0.4f));          
        }

        IEnumerator RestaurarDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            postProcessing.RestaurarSaturacion(1f);
        }
    }
}
