using UnityEngine;
using UnityEngine.UI;

public class PuertaHP : MonoBehaviour
{
    [SerializeField] private GameObject canvasDerrota;
    [SerializeField] private GameObject canvasGameplay;
    [SerializeField] private Slider sliderVida;
    //[SerializeField] public Slider sliderVidaFinDeJuego;
    [SerializeField] private int vidaMax = 1000;
    [SerializeField] private int vidaActual;
    public int dañoTotalRecibido = 0;
    public PuertaHP puerta;

    private void Start()
    {
        vidaActual = vidaMax;
        sliderVida.maxValue = vidaMax;
        //sliderVidaFinDeJuego.value = vidaMax;
        sliderVida.value = vidaActual;
        //sliderVidaFinDeJuego.value = vidaActual;
    }
    private void Update()
    {
        //sliderVidaFinDeJuego.value = sliderVida.value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            BajarHP(50);
            Destroy(collision.gameObject);
        }
    }

    void BajarHP(int daño)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        dañoTotalRecibido += daño;

        sliderVida.value = vidaActual;
        //sliderVidaFinDeJuego.value = vidaActual;

        if (vidaActual <= 0)
        {
            canvasGameplay.SetActive(false);
            canvasDerrota.SetActive(true); 
            Time.timeScale = 0f;

        }
    }

    public void CurarHP (int curacion)
    {
        vidaActual += curacion;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);

        sliderVida.value = vidaActual;
        //sliderVidaFinDeJuego.value = vidaActual;
    }
}
