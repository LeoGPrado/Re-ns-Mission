using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Clasificaion : MonoBehaviour
{
    public TextMeshProUGUI CantidadEnemigos;
    public TextMeshProUGUI CantidadTiempo;
    public TextMeshProUGUI clasificacionFinal;
    public PuertaHP puerta;
    //public Image ImagenDePuerta;
    //public Image NuevoEstadoPuerta;
    public int CantidadEnemigosOperador;

    void Start()
    {
        CantidadEnemigos.text = "0";
    }

    void Update()
    {
        CantidadEnemigos.text = ControlPersonaje.Ren.ContadorEnemigosString;
        CantidadTiempo.text = TimerMinutos.SeleccionarTiempo.TiempoTotal;
        //ImagenDePuerta.sprite = NuevoEstadoPuerta.sprite;
        operarClasificacion();
    }


    void tomarCantidadEnemigos()
    {
        CantidadEnemigosOperador = int.Parse(CantidadEnemigos.text);

    }

    public void operarClasificacion()
    {
        if (clasificacionFinal == null)
            return;

        int daño = puerta.dañoTotalRecibido;
        string rango;

        if (daño == 0)
        {
            rango = "S";
            clasificacionFinal.color = new Color(1f, 0.7f, 0.2f);
        }
        else if (daño <= 200)
        {
            rango = "A";
            clasificacionFinal.color = new Color(0.3f, 1f, 0.3f);
        }
        else if (daño <= 400)
        {
            rango = "B";
            clasificacionFinal.color = Color.cyan;
        }
        else if (daño <= 600)
        {
            rango = "C";
            clasificacionFinal.color = Color.white;
        }
        else
        {
            rango = "F";
            clasificacionFinal.color = Color.red;
        }

        clasificacionFinal.text = rango;
    }
}


