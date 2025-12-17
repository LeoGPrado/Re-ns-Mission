using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMejoras : MonoBehaviour
{

    [SerializeField] private TimerHoras min;
    [SerializeField] private ControlPersonaje Heart;
    [SerializeField] private PuertaHP DoorHp;
    [SerializeField] private int curacion;
    [SerializeField] private float duracionMejoras = 8f;
    [SerializeField] private GameObject panel;
    [SerializeField] private bool momentoMejora = true;


    [SerializeField] private SummonController turret;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject mascotaPrefab;
    [SerializeField] private static int turretNum;
    [SerializeField] private List<GameObject> turretList = new List<GameObject>(turretNum);
    [SerializeField] private bool cartaSeleccionable;

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
        
         DesactivarPanel();
         for (int i = 0; i < turretList.Count; i++)
         {
            turretList[i].GetComponent<PruebaTorreta>().Dispara();

         }
        
     
       

    }


    public void Mejora()
    {
        SlieControl.MutearTodosSlimes(true);
        panel.SetActive(true);
        cartaSeleccionable = true;
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
        cartaSeleccionable = false;
        SlieControl.MutearTodosSlimes(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }    
}
