using UnityEngine;
using System.Collections;

public class TutorialArmasEspeciales : MonoBehaviour
{
    [SerializeField] GameObject Espada;
    [SerializeField] GameObject Pollo;
    [SerializeField] GameObject Mazo;
    [SerializeField] GameObject Pescado;
    [SerializeField] GameObject Arco;
    [SerializeField] GameObject Pincel;
    [SerializeField] GameObject Baston;
    [SerializeField] GameObject Cuchilla;



    public float ActivarArmaE = 0f;
    public int verificarMazo = 0;
    public SelectorArmas index;
    public MedidorArteEspecial medidor;

    public GameObject tutorialBarraEspecial;

    bool atacando = false;
    public bool ActivarEspecial2 = false;

    [SerializeField] Animator Ren;



    public static TutorialArmasEspeciales TutorialControlEspecialE;

    public bool verificar = false;

    private void Awake()
    {

        if (TutorialControlEspecialE == null)
        {
            TutorialControlEspecialE = this;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !atacando && ActivarEspecial2 == true)
        {
            atacando = true;

            if (Espada.activeInHierarchy)
            {
                SpriteRenderer srEspada = Espada.GetComponent<SpriteRenderer>();
                srEspada.enabled = false;

                Ren.SetTrigger("TEspecialEspadaP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srEspada));
            }
            else if (Pollo.activeInHierarchy)
            {
                SpriteRenderer srPollo = Pollo.GetComponent<SpriteRenderer>();
                srPollo.enabled = false;

                Ren.SetTrigger("TAtaquePolloP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srPollo));
            }
            else if (Arco.activeInHierarchy)
            {
                SpriteRenderer srArco = Arco.GetComponent<SpriteRenderer>();
                srArco.enabled = false;

                Ren.SetTrigger("TAtaqueArcoP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srArco));
            }
            else if (Baston.activeInHierarchy)
            {
                SpriteRenderer srBaston = Baston.GetComponent<SpriteRenderer>();
                srBaston.enabled = false;

                Ren.SetTrigger("TAtaqueBastonP");
                ActivarArmaE = 0.5f;
                StartCoroutine(ActivarArma(srBaston));
            }
            else if (Mazo.activeInHierarchy)
            {
                SpriteRenderer srMazo = Mazo.GetComponent<SpriteRenderer>();
                srMazo.enabled = false;

                Ren.SetTrigger("TEspecialMazoP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srMazo));
            }
            else if (Pescado.activeInHierarchy)
            {
                SpriteRenderer srPescado = Pescado.GetComponent<SpriteRenderer>();
                srPescado.enabled = false;

                Ren.SetTrigger("TEspecialPescadoP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPescado));
            }
            else if (Cuchilla.activeInHierarchy)
            {
                SpriteRenderer srCuchilla = Cuchilla.GetComponent<SpriteRenderer>();
                srCuchilla.enabled = false;

                Ren.SetTrigger("TAtaqueCuchillaP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srCuchilla));

            }
            else if (Pincel.activeInHierarchy)
            {
                SpriteRenderer srPincel = Pincel.GetComponent<SpriteRenderer>();
                srPincel.enabled = false;

                Ren.SetTrigger("TAtaquePincelP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPincel));

            }
            else
            {
                return;
            }
        }
    }

    IEnumerator ActivarArma(SpriteRenderer arma)
    {
        //tutorialBarraEspecial.SetActive(false);
        //ActivarEspecial2 = false;
        yield return new WaitForSeconds(ActivarArmaE);

        arma.enabled = true;
        atacando = false;

    }

    IEnumerator RegresarNormalidad()
    {
        yield return new WaitForSeconds(6);
        transform.localScale = Vector3.one;
        verificarMazo = 0;
    }
    void ejecutarEspecialPescado()
    {

        TutorialPescado.PescadoEspecial.iniciarSpecialPescado();

    }
}
