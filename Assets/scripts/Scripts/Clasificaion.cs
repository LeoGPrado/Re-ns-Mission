using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Clasificaion : MonoBehaviour
{
    public TextMeshProUGUI CantidadEnemigos;
    public TextMeshProUGUI CantidadTiempo;

    //public Image ImagenDePuerta;
    //public Image NuevoEstadoPuerta;
    public int CantidadEnemigosOperador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CantidadEnemigos.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        CantidadEnemigos.text = ControlPersonaje.Ren.ContadorEnemigosString;
        CantidadTiempo.text = TimerMinutos.SeleccionarTiempo.TiempoTotal;
        //ImagenDePuerta.sprite = NuevoEstadoPuerta.sprite;
    }


    void tomarCantidadEnemigos()
    {
        CantidadEnemigosOperador = int.Parse(CantidadEnemigos.text);

    }
    
    void operarClasificacion()
    {

    }
}
