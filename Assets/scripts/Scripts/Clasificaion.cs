using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Clasificaion : MonoBehaviour
{
    [Header("Datos")]
    public TextMeshProUGUI CantidadEnemigos;
    public TextMeshProUGUI CantidadTiempo;
    public TextMeshProUGUI clasificacionFinal;
    public PuertaHP puerta;
    public ControlPersonaje ren;

    //public Image ImagenDePuerta;
    //public Image NuevoEstadoPuerta;
    public int CantidadEnemigosOperador;
    [Space(10)]


    [Header("Colores")]
    [SerializeField] private Color colorS;
    [SerializeField] private Color colorA;
    [SerializeField] private Color colorB;
    [SerializeField] private Color colorC;
    [SerializeField] private Color colorF;
    [Space(10)]

    [Header("Armas")]
    public Image ArmaUtilizada;
    [SerializeField] private GameObject[] armas;
    

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
        armaUsada();
    }


    void tomarCantidadEnemigos()
    {
        CantidadEnemigosOperador = int.Parse(CantidadEnemigos.text);

    }

    void armaUsada()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            if (armas[i].activeInHierarchy)
            {
                ArmaUtilizada.sprite = armas[i].GetComponent<SpriteRenderer>().sprite;
                return;
                /// Mano prioriza no usar tantos else if
            }
        }

    }

    public void operarClasificacion()
    {
        if (clasificacionFinal == null)
            return;

        int dañoPuerta = puerta.dañoTotalRecibido;
        int dañoRen = ren.dañoRecibido;
        string rango;
        int dañoTotalClasificacion = dañoPuerta + (dañoRen * 100);

        switch (dañoTotalClasificacion)
        {
            case 0: rango = "S"; clasificacionFinal.color = Color.black; break;
            case <= 200: rango = "A"; clasificacionFinal.color = colorA; break;
            case <= 400: rango = "B"; clasificacionFinal.color = colorB; break;
            case <= 600: rango = "C"; clasificacionFinal.color = colorC; break;
            default: rango = "F"; clasificacionFinal.color = colorF; break;
        }
        clasificacionFinal.text = rango;
    }
}