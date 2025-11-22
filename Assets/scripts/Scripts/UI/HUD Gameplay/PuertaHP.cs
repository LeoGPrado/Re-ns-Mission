using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuertaHP : MonoBehaviour
{

    [SerializeField] private Slider sliderVida;
    [SerializeField] private int vidaMax = 650;
    [SerializeField] private int vidaActual;

    private void Start()
    {
        vidaActual = vidaMax;
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vidaActual;
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

        sliderVida.value = vidaActual;

        if (vidaActual <= 0)
        {
            SceneManager.LoadScene("FinDemo");
        }
    }
}
