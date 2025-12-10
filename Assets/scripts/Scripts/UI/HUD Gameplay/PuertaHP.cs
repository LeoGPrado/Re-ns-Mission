using UnityEngine;
using UnityEngine.UI;

public class PuertaHP : MonoBehaviour
{
    [SerializeField] private GameObject canvasDerrota;
    [SerializeField] private GameObject canvasGameplay;
    [SerializeField] private Slider sliderVida;
    [SerializeField] private Slider sliderDerrota;
    [SerializeField] private Slider sliderVictoria;
    [SerializeField] private int vidaMax = 1000;
    [SerializeField] private int vidaActual;
    public int dañoTotalRecibido = 0;


    private void Start()
    {
        vidaActual = vidaMax;
        sliderVida.maxValue = vidaMax;
        sliderDerrota.maxValue = vidaMax;
        sliderVictoria.maxValue = vidaMax;
        ActualizarSliders();
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
        ActualizarSliders();

        if (vidaActual <= 0)
        {
            SlieControl.MutearTodosSlimes(true);
            canvasGameplay.SetActive(false);
            canvasDerrota.SetActive(true); 
            Time.timeScale = 0f;

        }
    }
    public void ActualizarSliders()
    {
        sliderVida.value = vidaActual;
        sliderDerrota.value = vidaActual;
        sliderVictoria.value = vidaActual;
    }

    public void CurarHP(int curacion)
    {
        vidaActual += curacion;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);

        sliderVida.value = vidaActual;
        ActualizarSliders();
    }
}
