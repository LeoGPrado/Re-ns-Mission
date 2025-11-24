using UnityEngine;
using System.Collections;

public class TutorialMazo : MonoBehaviour
{
    public Transform FlipMazo;

    [SerializeField] SpriteRenderer Mazo;
    public PlayerEnergyController playerEC;

    public float ultiDuration = 3f;
    public float ultiScaleMultiplier = 1.7f;
    private bool ultiActive = false;
    private Vector3 originalScale;

    private Transform playerRoot;

    public static TutorialMazo MazoEspecia;
    public bool EspecialMazo = false;
    private void Awake()
    {
        if (MazoEspecia == null)
        {
            MazoEspecia = this;
        }
    }
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


        if (Input.GetMouseButtonDown(1) && EspecialMazo==true)
        {

            StartCoroutine(UltimateBuff());
        }
    }

    IEnumerator UltimateBuff()
    {

        playerRoot.localScale = originalScale * ultiScaleMultiplier;
        EspecialMazo = false;
        yield return new WaitForSeconds(ultiDuration);

        playerRoot.localScale = originalScale;


    }
}
