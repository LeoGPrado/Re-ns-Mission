using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PanelMejoras : MonoBehaviour
{

    [SerializeField] private TimerHoras min;
    [SerializeField] private ControlPersonaje Heart;
    [SerializeField] private PuertaHP DoorHp;
    [SerializeField] private int curacion;
    [SerializeField] private float duracionMejoras = 6f;
    [SerializeField] private GameObject panel;
    [SerializeField] private bool momentoMejora = true;
    


    [SerializeField] private Transform player;
    [SerializeField] private GameObject mascotaPrefab;

    void Start()
    {
        curacion = 1000;
    }

    void Update()
    {
        if (min.minutos == 2 && momentoMejora || min.minutos == 4 && momentoMejora)
        {
            Invoke("Mejora", 0f);
            Time.timeScale = 0f;

        }
    }

    public void CurarRen()
    {
        DesactivarPanel();

        if (Heart.contador > 1)
        {
            Heart.contador -= 2;

        }

        ControlPersonaje.Ren.GanarVida();

        /*switch (Heart.contador)
        {
            case 1: Heart.Corazon1.SetActive(true);
                ControlPersonaje.Ren.GanarVida(); break;
            case 2: Heart.Corazon2.SetActive(true);
                ControlPersonaje.Ren.GanarVida(); break;
            case 3: Heart.Corazon3.SetActive(true);
                ControlPersonaje.Ren.GanarVida(); break;
            case 4: Heart.Corazon4.SetActive(true);
                ControlPersonaje.Ren.GanarVida(); break;
        }*/


    }


    public void CurarPuerta()
    {
        DesactivarPanel();
        DoorHp.CurarHP(curacion);

    }

    public void InvocarMascota()
    {
        DesactivarPanel();
        Instantiate(mascotaPrefab, player.transform.position, Quaternion.identity);

    }


    void Mejora()
    {

        panel.SetActive(true);
        StartCoroutine(SeleccionMejoras());
        momentoMejora = false;
        StartCoroutine(MejoraActivate());


    }

    IEnumerator SeleccionMejoras()
    {
        yield return new WaitForSeconds(duracionMejoras);
        DesactivarPanel();
    }

    IEnumerator MejoraActivate()
    {
        yield return new WaitForSeconds(30f);
        momentoMejora = true;
    }

    void DesactivarPanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }


}
