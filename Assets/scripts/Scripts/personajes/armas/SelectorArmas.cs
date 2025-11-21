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
    public int armasIndex;
    



    private void Awake()
    {
        randomizer1 = Random.Range(0, 8); //Random.Range(0, 8);
        randomizer2 = Random.Range(0, 8); //Random.Range(0, 8);
        randomizer3 = Random.Range(0, 8); //Random.Range(0, 8);


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        abrirSelector();
        listaBotonesA1[randomizer1].SetActive(true);
        listaBotonesA2[randomizer2].SetActive(true);
        listaBotonesA3[randomizer3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (elegirArma)
        {
            ActivarArmas();

            /*switch (armasIndex)
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
            }*/

            armaElegida = true;
            panelArmas.SetActive(false);
            

        }
    }

    void ActivarArmas()
    {
        listaArmas[armasIndex].SetActive(true);
    }

    public void EleccionDeArmas(int armasIndice)
    {
        armasIndex = armasIndice;
        elegirArma = true;

        Time.timeScale = 1;
    }

    /*public void ElegirBaston()
    {
        armasIndex = 0;
        elegirArma = true;

        Time.timeScale = 1;
    }

    public void ElegirArco()
    {
        armasIndex = 1;
        elegirArma = true;

        Time.timeScale = 1;
    }

    public void ElegirPollo()
    {
        armasIndex = 2;
        elegirArma = true;

        Time.timeScale = 1;
    }

    public void ElegirMazo()
    {
        armasIndex = 3;
        elegirArma = true;

        Time.timeScale = 1;
    }

    public void ElegirEspadas()
    {
        armasIndex = 4;
        elegirArma = true;

        Time.timeScale = 1;
    }

    public void ElegirPescado()
    {
        armasIndex = 5;
        elegirArma = true;

        Time.timeScale = 1;
    }

  

    public void ElegirPincel()
    {
        armasIndex = 6;
        elegirArma = true;

        Time.timeScale = 1;

    }


    public void ElegirCuchillas()
    {
        armasIndex = 7;
        elegirArma = true;

        Time.timeScale = 1;
    }*/

    void abrirSelector()
    {
        panelArmas.SetActive(true);
        Time.timeScale = 0;
    }
}
