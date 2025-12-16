using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMejoras : MonoBehaviour
{

    [SerializeField] private TimerHoras min;
    [SerializeField] private ControlPersonaje Heart;
    [SerializeField] private PuertaHP DoorHp;
    [SerializeField] private int curacion;
    [SerializeField] private float duracionMejoras = 6f;
    [SerializeField] private GameObject panel;
    [SerializeField] private bool momentoMejora = true;


    [SerializeField] private SummonController turret;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject mascotaPrefab;
    [SerializeField] private GameObject[] torretas;

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
    }

    public void CurarRen()
    {
        ControlPersonaje.Ren.GanarVida();
        DesactivarPanel();
    }


    public void CurarPuerta()
    {
        DesactivarPanel();
        DoorHp.CurarHP(curacion);

    }

    public void InvocarMascota()
    {
        DesactivarPanel();
        for(int i = 0; i < torretas.Length; i++)
        {
            torretas[i].GetComponent<SummonController>().isSummoned = true;
            
        }
       

    }


    public void Mejora()
    {
        SlieControl.MutearTodosSlimes(true);
        panel.SetActive(true);
        StartCoroutine(SeleccionMejoras());
        momentoMejora = false;
        StartCoroutine(MejoraActivate());
    }

    IEnumerator SeleccionMejoras()
    {
        yield return new WaitForSecondsRealtime(duracionMejoras);
        DesactivarPanel();
    }

    IEnumerator MejoraActivate()
    {
        yield return new WaitForSeconds(30f);
        momentoMejora = true;
    }

    void DesactivarPanel()
    {
        SlieControl.MutearTodosSlimes(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }    
}
