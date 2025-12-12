using System.Collections.Generic;
using UnityEngine;

public class SelectorArmas : MonoBehaviour
{

    public List<GameObject> listaArmas = new List<GameObject>(4);
    public List<GameObject> listaBotonesA1 = new List<GameObject>(4);
    public List<GameObject> listaBotonesA2 = new List<GameObject>(4);
    public List<GameObject> listaBotonesA3 = new List<GameObject>(4);
    [SerializeField] private int randomizer1, randomizer2, randomizer3;
    [SerializeField] private GameObject panelArmas;
    //[SerializeField] private bool armaElegida = false;
    [SerializeField] private bool elegirArma = false;
    //public int numeroArma;
    public int armasIndex;


    private List<int> numeros = new();

    private void Awake()
    {
        numeros.Clear();
        while (numeros.Count < 3)
        {
            int numeroNoRepetido = Random.Range(0, listaArmas.Count);

            if (!numeros.Contains(numeroNoRepetido))
            {
                numeros.Add(numeroNoRepetido);
            }
        }
        randomizer1 = numeros[0];
        randomizer2 = numeros[1];
        randomizer3 = numeros[2];
    }

    void Start()
    {
        if (panelArmas == null)
        {
            return;

        }
        else
        {
            abrirSelector();
            listaBotonesA1[randomizer1].SetActive(true);
            listaBotonesA2[randomizer2].SetActive(true);
            listaBotonesA3[randomizer3].SetActive(true);
        }

    }

    void Update()
    {
        if (elegirArma)
        {
            ActivarArmas();

            panelArmas.SetActive(false);
            elegirArma = false;
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
  
    void abrirSelector()
    {
        panelArmas.SetActive(true);
        Time.timeScale = 0;
    }
}
