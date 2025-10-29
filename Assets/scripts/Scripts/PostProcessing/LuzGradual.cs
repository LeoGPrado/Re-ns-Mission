using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LuzGradual : MonoBehaviour
{
    [Header("Es independiente al timer visible, modifiquen solo desde el inspector")]
    [Space(10)]

    [SerializeField] private Light2D luzDeDia;
    [SerializeField] private float tiempoDeOscuridad = 120f;
    [SerializeField] private float tiempoDeTransicion = 60f; 
    [SerializeField] private float intensidadInicial = 0.02f; 
    [SerializeField] private float intensidadFinal = 1f;

    private float tiempoTranscurrido = 0f;
    
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido < tiempoDeOscuridad)
        {
            luzDeDia.intensity = intensidadInicial;
        }
        else if (tiempoTranscurrido < tiempoDeOscuridad + tiempoDeTransicion)
        {
            float tiempoDesdeTransicion = tiempoTranscurrido - tiempoDeOscuridad;
            float progresoTransicion = tiempoDesdeTransicion / tiempoDeTransicion;
            float cambioGradual = progresoTransicion * progresoTransicion;
            float nuevaIntensidad = intensidadInicial + (intensidadFinal - intensidadInicial) * cambioGradual;
            luzDeDia.intensity = nuevaIntensidad;
        }
        else
        {
            luzDeDia.intensity = intensidadFinal;
        }
    }
}


