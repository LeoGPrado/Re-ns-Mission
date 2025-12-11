using UnityEngine;


public class CreditosController : MonoBehaviour
{
    public GameObject[] pergaminos;
    private int indiceActual = 0;

    void Start()
    {
        MostrarPanel(indiceActual);
    }

    public void Siguiente()
    {
        indiceActual++;
        if (indiceActual >= pergaminos.Length)
            indiceActual = 0; 
        MostrarPanel(indiceActual);
    }

    public void Anterior()
    {
        indiceActual--;
        if (indiceActual < 0)
            indiceActual = pergaminos.Length - 1;
        MostrarPanel(indiceActual);
    }

    void MostrarPanel(int indice)
    {
        for (int i = 0; i < pergaminos.Length; i++)
        {
            pergaminos[i].SetActive(i == indice);
        }
    }
}



