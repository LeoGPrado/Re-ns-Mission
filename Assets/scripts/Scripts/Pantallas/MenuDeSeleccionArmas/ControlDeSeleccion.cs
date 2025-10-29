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

    public void apagarSeleccion()
    {
        canvaSeleciionDeObjeto.SetActive(false);
    }

    public void ElegirEspada()
    {
        Espada.SetActive(true);
    }

    public void ElegirArco()
    {
        Arco.SetActive(true);
    }

    public void ElegirPollo()
    {
        Pollo.SetActive(true);
    }

    public void ElegirBaston()
    {
        Baston.SetActive(true);
    }

    public void ElegirCuchilla()
    {
        Cuchilla.SetActive(true);
    }

    public void ElegirPescado()
    {
        Pescado.SetActive(true);
    }
    public void ElegirMazo()
    {
        Mazo.SetActive(true);
    }

    public void ElegirPincel()
    {
        pincel.SetActive(true);
    }
}
