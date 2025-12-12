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
            if (index.armasIndex == 0)
            {
                SpriteRenderer sr = Baston.GetComponent<SpriteRenderer>();
                sr.enabled = false;

                Ren.SetTrigger("AtaqueBastonP");
                ActivarArmaE = 0.5f;
                StartCoroutine(ActivarArma(sr));
            }
            else if (index.armasIndex == 1)
            {
                SpriteRenderer sr = Arco.GetComponent<SpriteRenderer>();
                sr.enabled = false;

                Ren.SetTrigger("AtaqueArcoP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(sr));
            }
            else if (index.armasIndex == 2)
            {
                SpriteRenderer sr = Pincel.GetComponent<SpriteRenderer>();
                sr.enabled = false;

                Ren.SetTrigger("AtaquePincelP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(sr));
            }
            else if (index.armasIndex == 3)
            {
                SpriteRenderer sr = Cuchilla.GetComponent<SpriteRenderer>();
                sr.enabled = false;

                Ren.SetTrigger("AtaqueCuchillaP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(sr));
            }
                               
        }
        //verificar falta
        else if (Input.GetMouseButtonDown(1) && !atacando && medidor.canUseUltimate)
        {
            atacando = true;

            if (index.armasIndex == 0)
            {
                SpriteRenderer srBaston = Baston.GetComponent<SpriteRenderer>();
                srBaston.enabled = false;

                Ren.SetTrigger("AtaqueBastonP");
                verificar = false;
                ActivarArmaE = 0.5f;
                StartCoroutine(ActivarArma(srBaston));

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

            else if (index.armasIndex == 2)
            {
                SpriteRenderer srPincel = Pincel.GetComponent<SpriteRenderer>();
                srPincel.enabled = false;

                Ren.SetTrigger("EspecialPincelP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPincel));

            }
            
             
            else if (index.armasIndex == 3)
            {
                SpriteRenderer srCuchilla = Cuchilla.GetComponent<SpriteRenderer>();
                srCuchilla.enabled = false;

                Ren.SetTrigger("AtaqueCuchillaP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srCuchilla));
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
        atacando = false;

    }

    IEnumerator RegresarNormalidad()
    {
        yield return new WaitForSeconds(6);
        transform.localScale = Vector3.one;
        verificarMazo = 0;
    }
}
