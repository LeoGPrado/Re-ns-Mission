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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curacion = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (min.minutos == 2 && momentoMejora)
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
        
        switch (Heart.contador)
        {
            case 1: Heart.Corazon1.SetActive(true); break;
            case 2: Heart.Corazon2.SetActive(true); break;
            case 3: Heart.Corazon3.SetActive(true); break;
            case 4: Heart.Corazon4.SetActive(true); break;
        }

        
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


    }

    IEnumerator SeleccionMejoras()
    {
        yield return new WaitForSeconds(duracionMejoras);
        DesactivarPanel();
    }

    void DesactivarPanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }


}
