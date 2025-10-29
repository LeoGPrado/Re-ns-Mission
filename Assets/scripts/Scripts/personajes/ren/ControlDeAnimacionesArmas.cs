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
                Espada.SetActive(false);
                Ren.SetTrigger("AtaqueEspadaP");
                //StartCoroutine(ActivarArma(Espada));
            }
            else if (Pollo != null && Pollo.activeInHierarchy)
            {
                Pollo.SetActive(false);
                Ren.SetTrigger("AtaquePolloP");
                ActivarArmaE = 0.6f;
                //StartCoroutine(ActivarArma(Pollo));
            }
            else if (Arco != null && Arco.activeInHierarchy)
            {
                SpriteRenderer srArco = Arco.GetComponent<SpriteRenderer>();
                srArco.enabled = false;

                Ren.SetTrigger("AtaqueArcoP");
                ActivarArmaE = 0.6f;
                StartCoroutine(ActivarArma(srArco));
            }


        }
    }

    IEnumerator ActivarArma(SpriteRenderer arma)
    {

        yield return new WaitForSeconds(ActivarArmaE);

        arma.enabled = true;



    }
}
