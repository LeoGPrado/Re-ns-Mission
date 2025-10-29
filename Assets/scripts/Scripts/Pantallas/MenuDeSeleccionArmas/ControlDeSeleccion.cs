using UnityEngine;

public class ControlDeSeleccion : MonoBehaviour
{
    [SerializeField] GameObject canvaSeleciionDeObjeto;

    [SerializeField] GameObject Espada;
    [SerializeField] GameObject Arco;
    [SerializeField] GameObject Pollo;
    [SerializeField] GameObject Baston;
    [SerializeField] GameObject Cuchilla;
    [SerializeField] GameObject Pescado;
    [SerializeField] GameObject Mazo;
    [SerializeField] GameObject pincel;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void apagarSeleccion()
    {
        canvaSeleciionDeObjeto.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ElegirEspada()
    {
        Espada.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ElegirArco()
    {
        Arco.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ElegirPollo()
    {
        Pollo.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ElegirBaston()
    {
        Baston.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ElegirCuchilla()
    {
        Cuchilla.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ElegirPescado()
    {
        Pescado.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ElegirMazo()
    {
        Mazo.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ElegirPincel()
    {
        pincel.SetActive(true);
        Time.timeScale = 1f;
    }
}
