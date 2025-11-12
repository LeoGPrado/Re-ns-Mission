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

    [SerializeField] Animator Ren;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Espada != null && Espada.activeInHierarchy)
            {
                SpriteRenderer srEspada = Espada.GetComponent<SpriteRenderer>();
                srEspada.enabled = false;

                Ren.SetTrigger("AtaqueEspadaP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srEspada));
                //StartCoroutine(ActivarArma(Espada));
            }
            else if (Pollo != null && Pollo.activeInHierarchy)
            {
                SpriteRenderer srPollo = Pollo.GetComponent<SpriteRenderer>();
                srPollo.enabled = false;

                Ren.SetTrigger("AtaquePolloP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srPollo));
            }
            else if (Arco != null && Arco.activeInHierarchy)
            {
                SpriteRenderer srArco = Arco.GetComponent<SpriteRenderer>();
                srArco.enabled = false;

                Ren.SetTrigger("AtaqueArcoP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srArco));
            }
            else if (Baston != null && Baston.activeInHierarchy)
            {
                SpriteRenderer srBaston = Baston.GetComponent<SpriteRenderer>();
                srBaston.enabled = false;

                Ren.SetTrigger("AtaqueBastonP");
                ActivarArmaE = 0.5f;
                StartCoroutine(ActivarArma(srBaston));
            }
            else if (Mazo != null && Mazo.activeInHierarchy)
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

                Ren.SetTrigger("AtaqueMazoP");
                ActivarArmaE = 0.7f;
                StartCoroutine(ActivarArma(srPescado));
            }




        }
    }

    IEnumerator ActivarArma(SpriteRenderer arma)
    {

        yield return new WaitForSeconds(ActivarArmaE);

        arma.enabled = true;



    }
}
