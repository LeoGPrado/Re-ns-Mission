using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingTest : MonoBehaviour
{
    Volume volume;
    ColorAdjustments colorAdjustments;
    Coroutine Corrutina;
    float saturacionOriginal = 0;

    void Awake()
    {
        volume = GetComponent<Volume>();
        if (volume != null && volume.profile.TryGet(out colorAdjustments)) saturacionOriginal = colorAdjustments.saturation.value;
        else print("XD");
    }

    public void SaturacionGradual(float estado, float duracion)
    {
        if (Corrutina != null) StopCoroutine(Corrutina);
        Corrutina = StartCoroutine(ChangeSaturation(estado, duracion));
    }
    IEnumerator ChangeSaturation(float estado, float duracion)
    {
        float Inicio = colorAdjustments.saturation.value;
        float tiempo = 0;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            colorAdjustments.saturation.value = Mathf.Lerp(Inicio, estado, tiempo / duracion);
            yield return null;
        }
        colorAdjustments.saturation.value = estado;
    }
    public void RestaurarSaturacion(float duracion)
    {
        SaturacionGradual(saturacionOriginal, duracion);
    }
}

