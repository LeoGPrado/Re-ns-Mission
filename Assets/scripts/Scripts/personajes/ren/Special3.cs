using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Special3 : MonoBehaviour
{
    [Header("Indicador pollo")]
    [SerializeField] private GameObject canvasEspecial;
    [SerializeField] private GameObject canvasGamePlay;
    private bool tutorialMostrado = false;

    [Header("Audio Especial del pollo")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoEspecial;

    [Header("Timer Canvas Especial")]
    [SerializeField] private float tiempoCanvas = 3f;
    [SerializeField] private TMPro.TextMeshProUGUI textoTimer;




    public MedidorArteEspecial medidor;
    public PlayerEnergyController playerEC;
    public ControlPersonaje personaje;

    public GameObject ataqueArea;
    public Animator renAnimator;


    void Start()
    {
        if (canvasEspecial != null)
            canvasEspecial.SetActive(false);
    }



    void Update()
    {
        VerificarTutorialEspecial();
        if (medidor.canUseUltimate && Input.GetKeyDown(KeyCode.F) && personaje.vidaInicial <= 1)
        {
            ataqueArea.SetActive(true);
            StartCoroutine(FrenarRetroceso());
            renAnimator.SetTrigger("AtaqueTerceario");
            medidor.canUseUltimate = false;
            playerEC.Ultimate();
            audioSource.PlayOneShot(sonidoEspecial);
        }
    }

    IEnumerator FrenarRetroceso()
    {
        yield return new WaitForSeconds(1f);
        ataqueArea.SetActive(false);

    }

    void MostrarCanvasEspecial()
    {
        StartCoroutine(CanvasEspecialConTimer());
    }
    IEnumerator CanvasEspecialConTimer()
    {
        float tiempo = tiempoCanvas;

        canvasEspecial.SetActive(true);
        canvasGamePlay.SetActive(false);
        Time.timeScale = 0f;
        SlieControl.MutearTodosSlimes(true);

        while (tiempo > 0)
        {
            textoTimer.text = $"Returning to the game in {(int)tiempo}...";
            tiempo -= Time.unscaledDeltaTime;
            yield return null;
        }
    
        canvasEspecial.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        SlieControl.MutearTodosSlimes(false);
        canvasGamePlay.SetActive(true);

    }

    void VerificarTutorialEspecial()
    {
        if (tutorialMostrado) return;

        if (personaje.vidaInicial == 1 && medidor.canUseUltimate)
        {
            tutorialMostrado = true;
            MostrarCanvasEspecial();
        }
    }
}
