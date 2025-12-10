using System.Collections;
using UnityEditor;
using UnityEngine;

public class pincelControl : MonoBehaviour
{
    [Header("Balas")]
    public GameObject balaNormal;
    public GameObject balaEspecialPrefab;
    public Transform puntoAparicionBala;

    [Header("Post Processing")]
    [SerializeField] PostProcessingTest postProcessing;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoUltiPincel;
    public Transform FlipPincel;
    public float velocidadBala = 20f;

    [Header("Disparo")]
    public PlayerEnergyController playerEC;
    public MedidorArteEspecial medidor;
    public bool puedeDisparar = true;
    private bool isOnUltimate = false;
    public float coolDown = 0.2f;
    public float ultCoolDown = 1f;

    [SerializeField] SpriteRenderer personaje;
    [SerializeField] SpriteRenderer pincel;



    void Update()
    {
        ControlFlip();
        if (!isOnUltimate)
        {
            if (Input.GetMouseButtonDown(0) && puedeDisparar)
            {
                StartCoroutine(DisparoConCooldown());
            }
        }

        if (!isOnUltimate && Input.GetMouseButtonDown(1) && medidor.canUseUltimate)
        {
            StartCoroutine(DisparoEspecial());
        }

    }
    public void ControlFlip()
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
    }

    void DisparoNormal()
    {

        GameObject balNormal = Instantiate(balaNormal, puntoAparicionBala.position, puntoAparicionBala.rotation);
        Destroy(balNormal, 3f);

    }
    IEnumerator DisparoConCooldown()
    {
        puedeDisparar = false;
        DisparoNormal();
        yield return new WaitForSeconds(coolDown);
        puedeDisparar = true;
    }

    IEnumerator DisparoEspecial()
    {
        isOnUltimate = true;
        medidor.canUseUltimate = false;
        playerEC.Ultimate();

        if (audioSource != null && sonidoUltiPincel != null)
            audioSource.PlayOneShot(sonidoUltiPincel);

        if (postProcessing != null)
        {
            postProcessing.SaturacionGradual(-100f, 0.5f);
            StartCoroutine(RestarurarSaturacionDelay(0.5f));
        }

        int cantidadBalas = 40;
        float radio = 1.5f;
        float delayEntreBalas = 0.02f;
        Vector3 centro = puntoAparicionBala.position;

        for (int i = 0; i < cantidadBalas; i++)
        {
            float angulo = i * (360f / cantidadBalas);
            float rad = angulo * Mathf.Deg2Rad;
            Vector3 spawnPosicion = centro + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * radio;
            Quaternion rotacion = Quaternion.Euler(0f, 0f, angulo);
            GameObject bala = Instantiate(balaEspecialPrefab, spawnPosicion, rotacion);
            Destroy(bala, 3f);

            yield return new WaitForSeconds(delayEntreBalas);
        }

        isOnUltimate = false;
    }

    private IEnumerator RestarurarSaturacionDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        postProcessing.RestaurarSaturacion(1f);
    }
}

