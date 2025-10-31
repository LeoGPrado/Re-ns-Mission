using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SelectorArmas : MonoBehaviour
{

    public List<GameObject> listaArmas = new List<GameObject>(7);
    public List<GameObject> listaBotonesA1 = new List<GameObject>(7);
    public List<GameObject> listaBotonesA2 = new List<GameObject>(7);
    public List<GameObject> listaBotonesA3 = new List<GameObject>(7);
    [SerializeField] private int randomizer1, randomizer2, randomizer3;
    [SerializeField] private GameObject panelArmas;
    [SerializeField] private bool armaElegida = false;
    [SerializeField] private bool elegirArma = false;
    public int numeroArma;
    [SerializeField] private int armasIndex;



    private void Awake()
    {
        randomizer1 = 1; //Random.Range(0, 8);
        randomizer2 = 2; //Random.Range(0, 8);
        randomizer3 = 3; //Random.Range(0, 8);


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        abrirSelector();
    }

    // Update is called once per frame
    void Update()
    {
        if (elegirArma)
        {
            switch (armasIndex)
            {
                case 0: ActivarArmas(); 
                    break;
                case 1: ActivarArmas(); 
                    break;
                case 2: ActivarArmas(); 
                    break;
                case 3: ActivarArmas(); 
                    break;
                case 4: ActivarArmas();
                    break;
                case 5: ActivarArmas(); 
                    break;
                case 6: ActivarArmas(); 
                    break;
                case 7: ActivarArmas(); 
                    break;
            }

            armaElegida = true;
            panelArmas.SetActive(false);
            Time.timeScale = 1.0f;

        }
    }

    void ActivarArmas()
    {
        listaArmas[armasIndex].SetActive(true);
    }

    public void ElegirBaston()
    {
        armasIndex = 0;
    }

    public void ElegirPincel()
    {
        armasIndex = 1;
        elegirArma = true;

    }

    public void ElegirPollo()
    {
        armasIndex = 2;
        elegirArma = true;
    }

    public void ElegirEspadas()
    {
        armasIndex = 3;
        elegirArma = true;
    }

    public void ElegirMazo()
    {
        armasIndex = 4;
        elegirArma = true;
    }

    public void ElegirPescado()
    {
        armasIndex = 5;
        elegirArma = true;
    }

    public void ElegirArco()
    {
        armasIndex = 6;
        elegirArma = true;
    }

    public void ElegirCuchillas()
    {
        armasIndex = 7;
        elegirArma = true;
    }

    void abrirSelector()
    {
        panelArmas.SetActive(true);
        Time.timeScale = 0;
    }




}
