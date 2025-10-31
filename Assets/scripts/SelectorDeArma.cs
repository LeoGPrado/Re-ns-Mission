using System.Collections.Generic;
using UnityEngine;

public class SelectorDeArma : MonoBehaviour
{
    [SerializeField] private bool armaElegida = false;
    public List<GameObject> listaArmas = new List<GameObject>(9);
    public int numeroArma;
    [SerializeField] private int ArmasIndex;



    void Start()
    {

    }


    void Update()
    {

        if (armaElegida)
        {
            switch (numeroArma)
            {
                case 1:
                    ; ActivarArmas(); armaElegida = false;
                    break;
                case 2:
                    ; ActivarArmas(); armaElegida = false;
                    break;
                case 3:
                    ; ActivarArmas(); armaElegida = false;
                    break;
            }
        }



    }

    void ActivarArmas()
    {
        listaArmas[ArmasIndex].SetActive(true);

    }

    public void ElegirEspada()
    {
        numeroArma = 1;
        ArmasIndex = 0;
        armaElegida = true;
    }

    public void ElegirCono()
    {
        numeroArma = 2;
        ArmasIndex = 1;
        armaElegida = true;
    }

    public void ElegirDisco()
    {
        numeroArma = 3;
        ArmasIndex = 2;
        armaElegida = true;
    }
}
