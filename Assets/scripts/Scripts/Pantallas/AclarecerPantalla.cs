using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AclarecerPantalla : MonoBehaviour
{

    public RawImage DesOscurecer;
    public float TDOscurecer = 2f;

    private void Start()
    {
        StartCoroutine(oscuro());
    }


    IEnumerator oscuro()
    {
        float tiempo = 0;
        Color oscurecer = DesOscurecer.color;

        while (tiempo < TDOscurecer)
        {
            tiempo += Time.deltaTime;
            oscurecer.a = Mathf.Lerp(1, 0, tiempo / TDOscurecer);
            DesOscurecer.color = oscurecer;
            yield return null;
        }

    }
}
