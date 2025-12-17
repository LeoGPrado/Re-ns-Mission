using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelMejoras : MonoBehaviour
{

    [Header("Referencias")]
    [SerializeField] private TimerHoras min;
    [SerializeField] private PuertaHP DoorHp;

    [Header("UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject mejorasUI;
    [SerializeField] private Slider timeBar;
    [SerializeField] private TextMeshProUGUI cdText;
    [SerializeField] private int curacion;
    [SerializeField] private int contadorPaneles = 0;

    [Header("Timer")]
    [SerializeField] private float duracionMejoras = 6.5f;

    [Header("Botones")]
    [SerializeField] private List<Button> buttons;

    [Header("Torretas")]
    [SerializeField] private List<GameObject> turretList;

    private float tiempoActual;
    private bool timerActivo;
    private bool momentoMejora = true;
    private bool cartaSeleccionable;

    void Start()
    {
        curacion = 1000;
    }

    void Update()
    {
        if ((min.minutos == 2 || min.minutos == 4) && momentoMejora)
        {
            Mejora();
            Time.timeScale = 0f;
        }

        ActualizarTimer();
    }

    public void CurarRen()
    {
        if (!cartaSeleccionable) return;

        if (cartaSeleccionable)
        {
            ControlPersonaje.Ren.GanarVida();
            DesactivarPanel();
        }
        
    }


    public void CurarPuerta()
    {
        if (!cartaSeleccionable) return;

        if (cartaSeleccionable)
        {
            DesactivarPanel();
            DoorHp.CurarHP(curacion);
        }
        

    }

    public void InvocarMascota()
    {
        if (!cartaSeleccionable) return;

         for (int i = 0; i < turretList.Count; i++)
         {
            turretList[i].GetComponent<PruebaTorreta>().Dispara();

         }
        DesactivarPanel();
    }


    public void Mejora()
    {
        momentoMejora = false;
        contadorPaneles++;

        panel.SetActive(true);
        mejorasUI.SetActive(true);
        Time.timeScale = 0f;

        SlieControl.MutearTodosSlimes(true);

        tiempoActual = duracionMejoras;
        timerActivo = true;
        cartaSeleccionable = false;

        timeBar.maxValue = duracionMejoras;
        timeBar.value = duracionMejoras;

        StartCoroutine(HabilitarSeleccion());
        StartCoroutine(ResetMomentoMejora());
    }

    void ActualizarTimer()
    {
        if (!timerActivo) return;

        tiempoActual -= Time.unscaledDeltaTime;
        tiempoActual = Mathf.Clamp(tiempoActual, 0f, duracionMejoras);

        timeBar.value = tiempoActual;
        cdText.text = Mathf.CeilToInt(tiempoActual).ToString();

        if (tiempoActual <= 0f)
        {
            timerActivo = false;
            ElegirAleatorio();
        }
    }

    IEnumerator HabilitarSeleccion()
    {
        yield return new WaitForSecondsRealtime(1f);
        cartaSeleccionable = true;
    }

    void ElegirAleatorio()
    {
        if (buttons.Count == 0) return;

        int index = Random.Range(0, buttons.Count);
        buttons[index].onClick.Invoke();

        DesactivarPanel();
    }

    IEnumerator ResetMomentoMejora()
    {
        yield return new WaitForSeconds(30f);

        if(contadorPaneles == 1)
        momentoMejora = true;
    }

    void DesactivarPanel()
    {
        cartaSeleccionable = false;
        SlieControl.MutearTodosSlimes(false);
        panel.SetActive(false);
        mejorasUI.SetActive(false);
        Time.timeScale = 1f;
    }    
}
