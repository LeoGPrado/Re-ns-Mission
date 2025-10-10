using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class OscurecerEscena : MonoBehaviour
{
    public GameObject gameObjectOscurecer;
    public RawImage Oscurecer;
    public float TOscurecer = 2f;

    public void Jugar()
    {
        gameObjectOscurecer.SetActive(true);
        StartCoroutine(oscuro());
    }

    IEnumerator oscuro()
    {
        float tiempo = 0;
        Color oscurecer = Oscurecer.color;

        // Ir subiendo el alpha de 0 → 1
        while (tiempo < TOscurecer)
        {
            tiempo += Time.deltaTime;
            oscurecer.a = Mathf.Lerp(0, 1, tiempo / TOscurecer);
            Oscurecer.color = oscurecer;
            yield return null;
        }

        SceneManager.LoadScene("Testeos Generales");
    }
}