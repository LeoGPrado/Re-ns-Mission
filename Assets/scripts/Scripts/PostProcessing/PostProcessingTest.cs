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

    public void SaturacionGradual(float target, float duracion)
    {
        if (Corrutina != null) StopCoroutine(Corrutina);
        Corrutina = StartCoroutine(ChangeSaturation(target, duracion));
    }
    IEnumerator ChangeSaturation(float target, float duracion)
    {
        float Inicio = colorAdjustments.saturation.value;
        float tiempo = 0;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            colorAdjustments.saturation.value = Mathf.Lerp(Inicio, target, tiempo / duracion);
            yield return null;
        }
        colorAdjustments.saturation.value = target;
    }
    public void RestaurarSaturacion(float duracion)
    {
        SaturacionGradual(saturacionOriginal, duracion);
    }
}

