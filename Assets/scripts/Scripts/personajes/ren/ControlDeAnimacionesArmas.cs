using UnityEngine;
using System.Collections;

public class ControlDeAnimacionesArmas : MonoBehaviour
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
    [SerializeField] private PlayerEnergyController playermana;

    [SerializeField] Animator Ren;
    public bool atacando = false;


    public static ControlDeAnimacionesArmas ControlEspecial;

    public bool verificar = false;

    private void Awake()
    {

        if (ControlEspecial == null)
        {
            ControlEspecial = this;
        }

    }

    public void usarEspecial()
    {
        verificar = true;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !atacando)
        {
            atacando = true;

            if (index.armasIndex == 4)
            {
                SpriteRenderer srEspada = Espada.GetComponent<SpriteRenderer>();
                srEspada.enabled = false;

                Ren.SetTrigger("AtaqueEspadaP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srEspada));
                //StartCoroutine(ActivarArma(Espada));
            }
            else if (index.armasIndex == 2)
            {
                SpriteRenderer srPollo = Pollo.GetComponent<SpriteRenderer>();
                srPollo.enabled = false;

                Ren.SetTrigger("AtaquePolloP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srPollo));
            }
            else if (index.armasIndex == 1)
            {
                SpriteRenderer srArco = Arco.GetComponent<SpriteRenderer>();
                srArco.enabled = false;

                Ren.SetTrigger("AtaqueArcoP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srArco));
            }
            else if (index.armasIndex == 0)
            {
                SpriteRenderer srBaston = Baston.GetComponent<SpriteRenderer>();
                srBaston.enabled = false;

                Ren.SetTrigger("AtaqueBastonP");
                ActivarArmaE = 0.5f;
                StartCoroutine(ActivarArma(srBaston));
            }
            else if (index.armasIndex == 3)
            {
                SpriteRenderer srMazo = Mazo.GetComponent<SpriteRenderer>();
                srMazo.enabled = false;

                Ren.SetTrigger("AtaqueMazoP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srMazo));
            }
            else if (Pescado != null && Pescado.activeInHierarchy)
            {
                SpriteRenderer srPescado = Pescado.GetComponent<SpriteRenderer>();
                srPescado.enabled = false;

                Ren.SetTrigger("AtaquePescadoP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPescado));
            }
            else if (Cuchilla != null && Cuchilla.activeInHierarchy)
            {
                SpriteRenderer srCuchilla = Cuchilla.GetComponent<SpriteRenderer>();
                srCuchilla.enabled = false;

                Ren.SetTrigger("AtaqueCuchillaP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srCuchilla));

            }
            else if (Pincel != null && Pincel.activeInHierarchy)
            {
                SpriteRenderer srPincel = Pincel.GetComponent<SpriteRenderer>();
                srPincel.enabled = false;

                Ren.SetTrigger("AtaquePincelP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPincel));

            }
            else
            {
                return;
            }
        }
        else if (Input.GetMouseButtonDown(1)&&verificar==true) 
        {
            if (index.armasIndex == 4)
            {
                SpriteRenderer srEspada = Espada.GetComponent<SpriteRenderer>();
                srEspada.enabled = false;

                Ren.SetTrigger("EspecialEspadaP");
                verificar = false;
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srEspada));
                //playermana.Ultimate();

                //StartCoroutine(ActivarArma(Espada));
            }
            else if (index.armasIndex == 2)
            {
                SpriteRenderer srPollo = Pollo.GetComponent<SpriteRenderer>();
                srPollo.enabled = false;

                Ren.SetTrigger("AtaquePolloP");
                verificar = false;
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srPollo));

            }
            else if (index.armasIndex == 1)
            {
                SpriteRenderer srArco = Arco.GetComponent<SpriteRenderer>();
                srArco.enabled = false;

                Ren.SetTrigger("AtaqueArcoP");
                verificar = false;
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srArco));

            }
            else if (index.armasIndex == 0)
            {
                SpriteRenderer srBaston = Baston.GetComponent<SpriteRenderer>();
                srBaston.enabled = false;

                Ren.SetTrigger("AtaqueBastonP");
                verificar = false;
                ActivarArmaE = 0.5f;
                StartCoroutine(ActivarArma(srBaston));
       
            }
            else if (index.armasIndex == 3)
            {
                SpriteRenderer srMazo = Mazo.GetComponent<SpriteRenderer>();
                srMazo.enabled = false;

                Ren.SetTrigger("AtaqueMazoP");
                verificar = false;
                ActivarArmaE = 0.7f;
                if (verificarMazo == 0)
                {
                    transform.localScale *= 3;
                    verificarMazo++;

                }

                StartCoroutine(ActivarArma(srMazo));
                StartCoroutine(RegresarNormalidad());
          

                //transform.localScale = Vector3.one;
                //verificarMazo = 0;
            }
            else if (Pescado != null && Pescado.activeInHierarchy)
            {
                SpriteRenderer srPescado = Pescado.GetComponent<SpriteRenderer>();
                srPescado.enabled = false;

                Ren.SetTrigger("EspecialPecadoP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPescado));
 
            }
            else if (Pincel != null && Pincel.activeInHierarchy)
            {
                SpriteRenderer srPincel = Pincel.GetComponent<SpriteRenderer>();
                srPincel.enabled = false;

                Ren.SetTrigger("EspecialPincelP");
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

        yield return new WaitForSeconds(ActivarArmaE);

        arma.enabled = true;

    }

    IEnumerator RegresarNormalidad()
    {
        yield return new WaitForSeconds(6);
        transform.localScale = Vector3.one;
        verificarMazo = 0;
    }
}
