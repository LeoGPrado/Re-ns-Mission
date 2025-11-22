using UnityEngine;
using System.Collections;

public class mazo : MonoBehaviour
{
    public Transform FlipMazo;

    [SerializeField] SpriteRenderer Mazo;
    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;

    public float ultiDuration = 3f;          
    public float ultiScaleMultiplier = 1.7f; 
    private bool ultiActive = false;
    private Vector3 originalScale;

    private Transform playerRoot;

    private void Start()
    {
        playerRoot = transform.root;

        originalScale = playerRoot.localScale;
        FlipMazo = GameObject.Find("PuntoAtaque").transform;

    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

   

        if (mousePos.x < transform.position.x)
        {
            Mazo.flipX = true;
            Mazo.transform.localPosition = FlipMazo.localPosition;
        }
        else
        {
            Mazo.flipX = false;
            Mazo.transform.localPosition = FlipMazo.localPosition;
        }

     
        if (Input.GetMouseButtonDown(1) && !ultiActive && medidor.canUseUltimate)
        {
            medidor.canUseUltimate = false;
            playerEC.Ultimate();

            StartCoroutine(UltimateBuff());
        }
    }

    IEnumerator UltimateBuff()
    {
        ultiActive = true;

        playerRoot.localScale = originalScale * ultiScaleMultiplier;

        yield return new WaitForSeconds(ultiDuration);

        playerRoot.localScale = originalScale;

        ultiActive = false;
    }
}